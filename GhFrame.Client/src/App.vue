<script setup lang="ts">
import { RouterLink, RouterView, useRouter } from 'vue-router'
import { useAuthenticationStore } from '@/stores/authentication'
import { Permissions } from '@/models'

const authStore = useAuthenticationStore()
const router = useRouter()

async function logout() {
  const result = await authStore.logout()

  if (result.isSuccess) {
    return router.replace({ name: 'home' })
  }
}
</script>
<template>
  <v-app style="width: 100%">
    <v-progress-linear v-if="authStore.isLoading" indeterminate color="primary" height="4" />

    <v-app-bar app color="primary" dark>
      <v-app-bar-title>
        <RouterLink :to="{ name: 'home' }" class="text-white text-decoration-none">Home</RouterLink>
      </v-app-bar-title>

      <v-spacer />

      <template v-if="authStore.isAuthenticated">
        <v-btn text>
          {{ authStore?.user?.username }}
        </v-btn>

        <v-btn
          text
          :to="{ name: 'authentication-permissions' }"
          tag="RouterLink"
        >
          Permissions
        </v-btn>

        <v-btn
          v-if="authStore.hasPermission(Permissions.RoleCreate)"
          text
          :to="{ name: 'authorization-roles' }"
          tag="RouterLink"
        >
          Roles
        </v-btn>

        <v-btn text color="red" @click="logout">
          Logout
        </v-btn>
      </template>

      <template v-else>
        <v-btn
          text
          :to="{ name: 'authentication-login' }"
          tag="RouterLink"
        >
          Login
        </v-btn>
        <v-btn
          text
          :to="{ name: 'authentication-register' }"
          tag="RouterLink"
        >
          Register
        </v-btn>
      </template>
    </v-app-bar>

    <v-main>
      <v-container fluid>
        <RouterView />
      </v-container>
    </v-main>
  </v-app>
</template>
