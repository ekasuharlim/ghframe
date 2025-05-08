<script setup lang="ts">
import { ref, computed, onMounted } from 'vue'
import { usePrivateHttpClient } from '@/composables/useHttpClient'
import { AppError } from '@/primitives/Error'
import type { AxiosError, AxiosResponse } from 'axios'

interface InventoryItem {
  id: string
  warehouseId: string
  name: string
  quantity: number
  itemGroupName: string
  warehouseName: string
}

interface GroupedData {
  [warehouseName: string]: {
    groups: {
      [groupName: string]: InventoryItem[]
    }
  }
}

// Reactive data
const items = ref<InventoryItem[]>([])
const loading = ref<boolean>(true)

const reportDate = new Date().toLocaleDateString('id-ID', {
  day: '2-digit',
  month: '2-digit',
  year: 'numeric'
})

// Grouping logic
const groupedData = computed<GroupedData>(() => {
  const result: GroupedData = {}

  items.value.forEach(item => {
    if (!result[item.warehouseName]) {
      result[item.warehouseName] = { groups: {} }
    }

    const groups = result[item.warehouseName].groups

    if (!groups[item.itemGroupName]) {
      groups[item.itemGroupName] = []
    }

    groups[item.itemGroupName].push(item)
  })

  return result
})

const getGroupTotal = (items: InventoryItem[]): number =>
  items.reduce((sum, item) => sum + item.quantity, 0)

const getWarehouseTotal = (groups: { [groupName: string]: InventoryItem[] }): number =>
  Object.values(groups).flat().reduce((sum, item) => sum + item.quantity, 0)

const grandTotal = computed<number>(() =>
  items.value.reduce((sum, item) => sum + item.quantity, 0)
)

// Fetch from API
const fetchData = async (): Promise<void> => {
  try {
    const response: AxiosResponse<InventoryItem[]> = await usePrivateHttpClient().get('api/InventoryItems')
    items.value = response.data
  } catch (error: unknown) {
    const err = error as AxiosError<AppError>
    console.error('Error fetching inventory data:', err)
  } finally {
    loading.value = false
  }
}

onMounted(fetchData)
</script>

<template>
    <v-container>
      <v-row justify="center">
        <v-col cols="12" md="10">
          <v-card class="pa-4">
            <v-card-title class="text-center text-h6 font-weight-bold">
              Laporan Persediaan Barang
            </v-card-title>
            <div class="text-center mb-4">per Tanggal: {{ reportDate }}</div>
  
            <v-progress-linear v-if="loading" indeterminate color="primary" class="mb-4" />
            <v-col cols="auto">
              <v-btn :loading="loading" color="primary" @click="fetchData">
                <v-icon start>mdi-refresh</v-icon>
                Refresh
              </v-btn>
            </v-col>            
  
            <div v-if="!loading" v-for="(warehouseGroups, warehouseName) in groupedData" :key="warehouseName" class="mb-6">
              <h3 class="text-subtitle-1 font-weight-bold text-uppercase">{{ warehouseName }}</h3>
  
              <div v-for="(items, groupName) in warehouseGroups.groups" :key="groupName" class="ml-4 mt-2">
                <h4 class="text-body-2 font-weight-medium">{{ groupName }}</h4>
                <v-table density="compact" class="ml-2">
                  <thead>
                    <tr>
                      <th class="text-left">Kode</th>
                      <th class="text-left">Nama Barang</th>
                      <th class="text-right">Persediaan</th>
                    </tr>
                  </thead>
                  <tbody>
                    <tr v-for="item in items" :key="item.id">
                      <td>{{ item.id }}</td>
                      <td>{{ item.name }}</td>
                      <td class="text-right">{{ item.quantity.toFixed(2) }}</td>
                    </tr>
                    <tr class="font-weight-bold">
                      <td colspan="2" class="text-right">Total :: {{ groupName }}</td>
                      <td class="text-right">{{ getGroupTotal(items).toFixed(2) }}</td>
                    </tr>
                  </tbody>
                </v-table>
              </div>
  
              <div class="text-right font-weight-bold mt-2 mr-2">
                Total :: {{ warehouseName }} = {{ getWarehouseTotal(warehouseGroups.groups).toFixed(2) }}
              </div>
            </div>
  
            <v-divider class="my-4" />
            <div class="text-right font-weight-bold text-body-1 mr-2">
              Total Keseluruhan = {{ grandTotal.toFixed(2) }}
            </div>
          </v-card>
        </v-col>
      </v-row>
    </v-container>
  </template>