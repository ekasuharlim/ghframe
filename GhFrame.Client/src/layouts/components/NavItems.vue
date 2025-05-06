<script lang="ts" setup>
import VerticalNavSectionTitle from '@/@layouts/components/VerticalNavSectionTitle.vue'
import VerticalNavGroup from '@layouts/components/VerticalNavGroup.vue'
import VerticalNavLink from '@layouts/components/VerticalNavLink.vue'
</script>

<template>
  <!-- 👉 Dashboards -->
  <VerticalNavGroup
    :item="{
      title: 'Reports',
      icon: 'ri-home-smile-line',
    }"
  >
    <VerticalNavLink
      :item="{
        title: 'Laporan Persediaan Barang',
        to: '/stock-report',
      }"
    />
    <VerticalNavLink
      :item="{
        title: 'Laporan Penjualan',
        to: '/sales-report',
      }"
    />
    <VerticalNavLink
      :item="{
        title: 'Laporan Kas Bank Harian',
        to: '/finance-report',
      }"
    />
  </VerticalNavGroup>

  <VerticalNavLink
      :item="{
        title: 'Home',
        to: '/home',
      }"
    />
    <VerticalNavLink
      :item="{
        title: 'Content',
        to: '/content',
      }"
    />


</template>
