<script>
import { defineComponent } from "vue";

export default defineComponent({
  name: 'not-found-view',
});
</script>

<template>
    <p>Page not found</p>
    <RouterLink to="/">Return to home</RouterLink>
  </template>