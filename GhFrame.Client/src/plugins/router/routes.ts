export const routes = [
  { 
    path: '/',
    component: () => import('@/layouts/default.vue'),
    children: [
      {
        path: 'content',
        name: 'content',
        component: () => import('@/pages/content-view.vue'),
        meta: { requiresAuth: true },
      },
      {
        path: 'home',
        name: 'home',
        component: () => import('@/pages/home-view.vue'),
        meta: { requiresAuth: true },
      },
      {
        path: 'inventory-report',
        name: 'inventory-report',
        component: () => import('@/pages/inventory-report.vue'),
        meta: { requiresAuth: true },
      },

    ],
   },

  { 
    path: '/',
    component: () => import('@/layouts/blank.vue'),
    children: [
      {
        path: 'login',
        name: 'login',
        component: () => import('@/pages/login.vue'),
      },
      
    ],
   },


  
]
