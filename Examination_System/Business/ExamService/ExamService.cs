using ExaminationSystem.Data_Access;
using ExaminationSystem.Data_Access.Models;
using System.Data;
using Microsoft.Data.SqlClient;
using Examination_System;


namespace ExaminationSystem.Business.ExamService
{
    internal class ExamService
    {
        public static int GetScore(int examId, int studentId)
        {
            int totalMarks = 0;

            using (SqlConnection conn = new SqlConnection(General.connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT dbo.GetTotalScore(@ExamId, @StudentId)", conn))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ExamId", examId);
                    cmd.Parameters.AddWithValue("@StudentId", studentId);

                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    conn.Close();

                    // 🔹 Check if result is not NULL before converting to int
                    if (result != DBNull.Value && result != null)
                    {
                        totalMarks = Convert.ToInt32(result);
                    }
                }
            }

            return totalMarks;
        }
        public static bool CreateExam(Exam exam)
        {
            if (exam.CourseID == 0 || exam.Duration == 0 || exam.NoOfQuestions == 0 || exam.Type == default || exam.StartTime == default || exam.EndTime == default)
                throw new ArgumentException("All fields are required.");
            try
            {
                ExamRepository.CreateExam(exam);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        public static DataTable GetExamById(int id)
        {
            using (SqlCommand cmd = new SqlCommand(@$"Select [ID]
                      ,[CourseID]
                      ,[ExamType]
                      ,[StartTime]
                      ,[EndTime]
                      ,case
	                  when [Status] = 0 then 'Pending'
	                  when [Status] = 1 then 'Started'
	                  else 'Finished' end as Status
                      ,[NoOFQuestions]
                      ,[Duration]
                      ,[TotalMarks]
                        FROM [FatmaLast].[dbo].[Exam]
                        where id ={id}
                "))

            {
                try
                {
                    return ExamRepository.select(cmd);
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }
        DatabaseHelper _dl;

        public ExamService()
        {
            _dl = new DatabaseHelper();
        }

        public DataTable GetCoursesByTeacher(int teacherId)
        {
            string query = $"SELECT CourseName FROM Courses WHERE TeacherID = {teacherId}";
            return _dl.Executequery(query);
        }
        public DataTable FilterByDate(int teacherId, DateTime startDate, DateTime endDate)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@startDate", SqlDbType.DateTime) { Value = startDate },
                new SqlParameter("@endDate", SqlDbType.DateTime) { Value = endDate },
                new SqlParameter("@teacherid", SqlDbType.Int) { Value = teacherId }
            };

            return _dl.ExecuteStoredProcedure("filterByDate", parameters);
        }
        public DataTable GetExamStatus(int teacherId, List<int> statusList)
        {
            string selectedExamStatus = string.Join(",", statusList);
            SqlParameter[] parameters = {
                new SqlParameter("@examstatus", SqlDbType.NVarChar) { Value = selectedExamStatus },
                new SqlParameter("@teacherid", SqlDbType.Int) { Value = teacherId }
            };

            return _dl.ExecuteStoredProcedure("getExamStatus", parameters);
        }
        public DataTable GetExamType(int teacherId, List<int> typeList)
        {
            string selectedExamType = string.Join(",", typeList);
            SqlParameter[] parameters = {
                new SqlParameter("@examsType", SqlDbType.NVarChar) { Value = selectedExamType },
                new SqlParameter("@teacherid", SqlDbType.Int) { Value = teacherId }
            };

            return _dl.ExecuteStoredProcedure("getExamType", parameters);
        }
        public DataTable GetCoursesWithExams(int teacherId, List<string> courses)
        {
            SqlParameter[] parameters = {
                new SqlParameter("@coursename", SqlDbType.VarChar) { Value = courses.Contains("All") ? (object)DBNull.Value : string.Join(",", courses) },
                new SqlParameter("@teacherid", SqlDbType.Int) { Value = teacherId }
            };

            return _dl.ExecuteStoredProcedure("getCoursesWhichHaveExams", parameters);
        }
        public DataTable FilterExams(int teacherId, DateTime? startDate, DateTime? endDate,
                             List<int>? statusList, List<int>? typeList, List<string>? courses)
        {
            SqlParameter[] parameters = {
        new SqlParameter("@teacherid", SqlDbType.Int) { Value = teacherId },


        new SqlParameter("@startDate", SqlDbType.DateTime) { Value = startDate.HasValue ? startDate.Value : (object)DBNull.Value },
        new SqlParameter("@endDate", SqlDbType.DateTime) { Value = endDate.HasValue ? endDate.Value : (object)DBNull.Value },

        new SqlParameter("@examstatus", SqlDbType.NVarChar) { Value = (statusList != null && statusList.Count > 0)
            ? string.Join(",", statusList) : (object)DBNull.Value },

        new SqlParameter("@examsType", SqlDbType.NVarChar) { Value = (typeList != null && typeList.Count > 0)
            ? string.Join(",", typeList) : (object)DBNull.Value },

        new SqlParameter("@coursename", SqlDbType.NVarChar) { Value = (courses != null && courses.Count > 0)
            ? string.Join(",", courses) : (object)DBNull.Value }
    };

            return _dl.ExecuteStoredProcedure("FilterExams", parameters);
        }

    }
}