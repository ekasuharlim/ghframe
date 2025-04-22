
import { createApp } from 'vue'
import App from './App.vue'
import { registerPlugins } from './@core/utils/plugins'

import { createPinia } from 'pinia'

// Styles
import '@core/scss/template/index.scss'
import '@layouts/styles/index.scss'


const app = createApp(App)

registerPlugins(app)
app.mount('#app')
