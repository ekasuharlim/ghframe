<script setup lang="ts">
import { RouterLink, RouterView, useRouter } from 'vue-router'


</script>
<template>
  <v-app style="width: 100%">
    <v-main>
      <v-container fluid>
        <RouterView />
      </v-container>
    </v-main>
  </v-app>
</template>
