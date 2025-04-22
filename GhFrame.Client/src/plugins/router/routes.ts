export const routes = [
  { 
    path: '/',
    component: () => import('@/layouts/default.vue'),
    children: [
      {
        path: 'content',
        component: () => import('@/pages/content-view.vue'),
      }
    ],
   },

  { 
    path: '/',
    component: () => import('@/layouts/blank.vue'),
    children: [
      {
        path: 'home',
        component: () => import('@/pages/home-view.vue'),
      },
      {
        path: 'login',
        component: () => import('@/pages/login.vue'),
      },
      
    ],
   },


  
]
