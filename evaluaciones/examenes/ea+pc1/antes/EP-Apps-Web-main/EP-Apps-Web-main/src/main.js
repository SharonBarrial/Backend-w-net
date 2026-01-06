import './assets/main.css'

import { createApp } from 'vue'
import App from './App.vue'
import router from './router'
import PrimeVue from 'primevue/config';
import Toolbar from "primevue/toolbar";
import DataTable from 'primevue/datatable';
import Column from 'primevue/column';
import Card from 'primevue/card';

import 'primevue/resources/primevue.min.css';
import 'primevue/resources/themes/md-light-indigo/theme.css';

const app = createApp(App)

app.use(router)
app.use(PrimeVue)
app.component('pv-toolbar', Toolbar)
app.component('pv-datatable', DataTable)
app.component('pv-column', Column)
app.component('pv-card', Card)
app.mount('#app')
