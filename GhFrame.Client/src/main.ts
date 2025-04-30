
import { createApp } from 'vue'
import App from './App.vue'
import { registerPlugins } from './@core/utils/plugins'

import { createPinia } from 'pinia'

// Styles
import '@core/scss/template/index.scss'
import '@layouts/styles/index.scss'


const app = createApp(App)

app.config.globalProperties.$companyName = import.meta.env.VITE_COMPANY_NAME

registerPlugins(app)
app.mount('#app')
