import './assets/main.css'
/* Autor: Sharon Antuanet Ivet Barrial Marin - U202114900
  Caso de Estudio: Fake Store Inc
En este archivo main de js se importo primevue para poder usar su libreria
y sus componentes como el componente de toolbar y card para poder mostrar
la informacion de los crurrencies del enuniado.

También se importo i18n para la internalización.

El proposito de este trabajo es demostrar el uso de una API sobre monedas
y mostrarla en una pagina web
*/
import { createApp } from 'vue'
import App from './App.vue'
import PrimeVue from "primevue/config";
import "primevue/resources/themes/saga-blue/theme.css";
import Toolbar from "primevue/toolbar";
import Card from "primevue/card";
import Rating from 'primevue/rating';
import i18n from "@/locale/i18n.js";

const app= createApp(App);
app.use(PrimeVue);
app.use(i18n);
app.component('pv-toolbar', Toolbar)
app.component("pv-card", Card)
app.component('pv-rating', Rating)
app.mount('#app')