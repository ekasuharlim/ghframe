<script lang="ts" setup>


const { appContext } = getCurrentInstance()
const companyName = appContext.config.globalProperties.$companyName
</script>


<template>
  <div class="h-100 d-flex align-center justify-md-space-between justify-center">
    <!-- 👉 Footer: left content -->
    <span class="d-flex align-center">
    </span>
    <!-- 👉 Footer: right content -->
    <span class="d-md-flex gap-x-4 text-primary d-none">
      {{companyName}}
      &copy;
      {{ new Date().getFullYear() }}
    </span>
  </div>
</template>
