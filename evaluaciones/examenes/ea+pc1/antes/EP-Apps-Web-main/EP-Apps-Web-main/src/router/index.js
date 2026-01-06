import { createRouter, createWebHistory } from 'vue-router'
import HomeView from '../public/views/home-view.component.vue'
import HealthChecksView from '../analytics/components/health-checks.component.vue'
import NotFoundView from '../public/views/not-found-view.component.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      redirect: '/home',
    },
    {
      path: '/home',
      component: HomeView,
    },
    {
      path:'/analytics/health-checks',
      component: HealthChecksView,
    },
    {
      path: '/:pathMatch(.*)*',
      component: NotFoundView,
    }
  ]
})

export default router
