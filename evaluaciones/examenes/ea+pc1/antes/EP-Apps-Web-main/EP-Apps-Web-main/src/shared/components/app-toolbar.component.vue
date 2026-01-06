<script>
import { defineComponent } from "vue";

export default defineComponent({
  name: 'app-toolbar',

})
</script>

<template>
  <pv-toolbar>
    <template #start>
      <h1>Mental State Exam Analytics</h1>
 
    </template>
    <template #end>
      <RouterLink to="/home">
        <span>Home</span>
      </RouterLink>
      <RouterLink to="/analytics/health-checks">
      <span>Health Checks</span>
      </RouterLink>
    </template>
  </pv-toolbar>
</template>

<style scoped>
.p-toolbar {
  background-color: lightgray;
}
.p-toolbar-group-right span {
  padding: 1rem;
}
</style>
