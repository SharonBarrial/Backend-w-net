<template>
  <div>
    <h1>Health Checks Overview</h1>
  
      <p>Exam Count: {{ examCount }}</p>
      <p>Highest Score: {{ highestScore }}</p>
      <p>Lowest Score: {{ lowestScore }}</p>
      <p>Average Score: {{ averageScore }}</p>
    
  </div>
</template>

<script>
import { defineComponent } from "vue";
import { HealthChecksService } from "../../../src/analytics/services/health-checks.service";

export default defineComponent({
  data() {
    return {
      loading: true,
      patientsWithSupervisors: [],
      examCount: 0,
      highestScore: 0,
      lowestScore: 0,
      averageScore: 0
    };
  },
  async created() {
    try {
      const healthChecksService = new HealthChecksService();
      const { examCount, highestScore, lowestScore, averageScore, patientData } = await healthChecksService.getAllPatientsWithSupervisors();
      this.examCount = examCount;
      this.highestScore = highestScore;
      this.lowestScore = lowestScore;
      this.averageScore = averageScore;
      this.patientsWithSupervisors = patientData;
    } catch (error) {
      console.error("Error fetching health checks overview:", error);
    } finally {
      this.loading = false;
    }
  }
});
</script>

<style scoped>

</style>
