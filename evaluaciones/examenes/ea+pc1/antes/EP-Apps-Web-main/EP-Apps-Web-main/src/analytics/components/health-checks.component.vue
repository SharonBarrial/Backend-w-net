<template>
  <div style="display: flex; flex-wrap: wrap;">
    <pv-card style="width: 25rem; overflow: hidden; margin: 25px;" v-for="examiner in examiners" :key="examiner.fullName">
      <template #header>
        
      </template>
      <template #title>{{ examiner.fullName }}</template>
      <template #content>
        <p><strong>NPI:</strong> {{ examiner.NPI }}</p>
        <p><strong>Mental State Exam Performance</strong></p>
        <p><strong>Current Assigned Mental State Exam Count:</strong> {{ examiner.currentExamCount }}</p>
        <p><strong>Average Assigned Mental State Exam Total Score:</strong> {{ examiner.averageScore }}</p>
      </template>
    </pv-card>
  </div>
</template>

<script>
import { defineComponent } from "vue";
import { HealthChecksService } from "../services/health-checks.service";

export default defineComponent({
  name: 'health-check-view',
  data() {
    return {
      healthChecksService: new HealthChecksService(),
      examiners: [],
      loading: false,
    }
  },
  methods: {
    async getExaminerPerformanceOverview() {
      try {
        this.loading = true;
        this.examiners = await this.healthChecksService.getExaminerPerformanceOverview();
        this.loading = false;
      } catch (error) {
        console.error('Error fetching Examiner Performance Overview:', error);
        this.loading = false;
      }
    },
  },
  created() {
    this.getExaminerPerformanceOverview();
  }
});
</script>
