using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace Examination_System.Business.StudentExamHistory
{
    class StudentExamService
    {
        private string connString = General.connectionString;

        public DataTable GetStudentExams(int stdID)
        {
            DataTable dt = new DataTable();

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();


                    using (SqlCommand cmd = new SqlCommand("select distinct e.Id, e.CourseID,cr.CourseName, e.StartTime, e.EndTime, e.NoOFQuestions, e.Duration,e.TotalMarks\r\nfrom Exam e join StudentCourses sc on e.CourseID = sc.CourseID join Courses cr on e.CourseID=cr.ID\r\nwhere sc.StudentID = @StudentID and e.EndTime < GETDATE()", conn))
                    {
                        cmd.Parameters.AddWithValue("StudentID", stdID);

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            da.Fill(dt);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error happened: " + ex.Message);
            }

            return dt;
        }
    }
}
