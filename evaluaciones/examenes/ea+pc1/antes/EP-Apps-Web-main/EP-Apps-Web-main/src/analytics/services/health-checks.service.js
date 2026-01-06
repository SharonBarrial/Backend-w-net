import axios from 'axios';

const BASE_URL = 'http://localhost:3000';

export class HealthChecksService {
    async getAllPatientsWithSupervisors() {
        try {
            const [patientsResponse, examsResponse, examinersResponse] = await Promise.all([
                axios.get(`${BASE_URL}/patients`),
                axios.get(`${BASE_URL}/mental-state-exams`),
                axios.get(`${BASE_URL}/examiners`)
            ]);

            const patients = patientsResponse.data;
            const exams = examsResponse.data;
            const examiners = examinersResponse.data;

            let examCount = exams.length;
            let totalScore = 0;
            let highestScore = -Infinity;
            let lowestScore = Infinity;

            exams.forEach(exam => {
                const orientationScore = Number(exam.orientationScore);
                const registrationScore = Number(exam.registrationScore);
                const attentionAndCalculationScore = Number(exam.attentionAndCalculationScore);
                const recallScore = Number(exam.recallScore);
                const languageScore = Number(exam.languageScore);

                const score = orientationScore + registrationScore + attentionAndCalculationScore + recallScore + languageScore;

                totalScore += score;
                if (score > highestScore) {
                    highestScore = score;
                }
                if (score < lowestScore) {
                    lowestScore = score;
                }
            });

            const averageScore = totalScore / examCount;

            return {
                examCount,
                highestScore,
                lowestScore,
                averageScore
            };
        } catch (error) {
            console.error('Error fetching patients with supervisors:', error);
            throw error;
        }
    }

    async getExaminerPerformanceOverview() {
        try {
            
            const examinersResponse = await axios.get(`${BASE_URL}/examiners`);
            const examiners = examinersResponse.data;

    
            const examsResponse = await axios.get(`${BASE_URL}/mental-state-exams`);
            const exams = examsResponse.data;

         
            const examinerPerformanceOverview = [];


            examiners.forEach(examiner => {
                const examinerInfo = {
                    fullName: `${examiner.firstName} ${examiner.lastName}`,
                    NPI: `NPI: ${examiner.nationalProviderIdentifier}`,
                    performance: "Mental State Exam Performance",
                    currentExamCount: 0,
                    totalScore: 0
                };

    
                exams.forEach(exam => {
                    if (exam.examinerId === examiner.id) {
                        examinerInfo.currentExamCount++;
                        const totalExamScore = exam.orientationScore + exam.registrationScore + exam.attentionAndCalculationScore + exam.recallScore + exam.languageScore;
                        examinerInfo.totalScore += totalExamScore;
                    }
                });

                if (examinerInfo.currentExamCount > 0) {
                    examinerInfo.averageScore = examinerInfo.totalScore / examinerInfo.currentExamCount;
                } else {
                    examinerInfo.averageScore = 0;
                }


                examinerPerformanceOverview.push(examinerInfo);
            });

            return examinerPerformanceOverview;
        } catch (error) {
            console.error('Error fetching Examiner Performance Overview:', error);
            throw error;
        }
    }
}
