import type { App } from 'vue'
import { createRouter, createWebHistory } from 'vue-router'
import { routes } from './routes'
import { useAuthenticationStore } from '@/stores/authentication'

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes,
})

export default function (app: App) {
  app.use(router)
}

router.beforeResolve(async (to, from, next) => {
  const authStore = useAuthenticationStore()

  if (authStore.isLoading) {
    await authStore.getUserInfo()
    console.log('User info fetched')
  }

  if (to.meta.requiresAuth && !authStore.isAuthenticated) {
    return next({ name: 'login', query: { redirect: to.fullPath } })
  } else {
    return next()
  }
})

export { router }
