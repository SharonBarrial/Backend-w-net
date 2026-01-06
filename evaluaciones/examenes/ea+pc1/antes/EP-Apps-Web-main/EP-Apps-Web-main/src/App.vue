<script >
import { defineComponent } from "vue";
import AppToolbar from './shared/components/app-toolbar.component.vue';

export default defineComponent({
  components: { AppToolbar },
})
</script>

<template>
  <app-toolbar></app-toolbar>
  <RouterView></RouterView>
</template>
