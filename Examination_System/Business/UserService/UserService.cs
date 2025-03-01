using Examination_System.Business.Enums;
using Examination_System.Data_Access;
using Examination_System.Data_Access.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Data;


namespace Examination_System.Business
{
    public static class UserService
    {
        public static DataTable GetStudentAnswers(int studentId, int examId)
        {
            DataTable dtStudentAnswers = new DataTable();


            try
            {

                // SQL query to retrieve the student's answers
                string query = @"
                    SELECT 
                        QuestionId, 
                        AnswerId 
                    FROM 
                        Submit 
                    WHERE 
                        StudentId = @StudentId 
                        AND ExamId = @ExamId";

                using (SqlCommand command = new SqlCommand(query))
                {
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    command.Parameters.AddWithValue("@ExamId", examId);

                    dtStudentAnswers = UserRepository.UserDAL(command);
                }
            }
            catch (SqlException ex)
            {
                // Handle database exceptions (e.g., log the error)
                throw new Exception("An error occurred while fetching student answers: " + ex.Message);
            }



            return dtStudentAnswers;
        }

        public static void SubmitAnswer(int studentId, int examId, int questionId, int answerId)
        {
            try
            {
                // SQL query to insert the student's answer into the Submit table
                string query = @$"
                    INSERT INTO Submit (studentId, ExamId, QuestionId, AnswerId)
                    VALUES ({studentId}, {examId}, {questionId}, {answerId})";

                // Parameters for the query
                
                using (SqlConnection con = new SqlConnection(General.connectionString))
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    

                    // Execute the query
                    Reposatory.DML(cmd);

                }

            }
            catch (Exception ex)
            {
                // Handle any exceptions (e.g., log the error or throw it)
                throw new Exception("Failed to submit answer: " + ex.Message);
            }
        }
        public static Tuple<int, User> Login(string usernameOrEmail, string password)
        {
            try
            {
                return UserRepository.GetLogin(usernameOrEmail, password);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static void Logout()
        {
            General.LoggedUser = null;
        }

        public static Tuple<string, int> UpdateUserData(User updatedData)
        {
            try
            {
                int result = UserRepository.UpdateUserData(updatedData);

                switch ((UserErrorMessage)result)
                {
                    case UserErrorMessage.NotApplied:
                        return new Tuple<string, int>("Error: Data was not saved.", result);

                    case UserErrorMessage.Suceeded:
                        return new Tuple<string, int>("Success: Data was saved successfully!", result);

                    case UserErrorMessage.NotFound:
                        return new Tuple<string, int>("Error: User was not found.", result);

                    case UserErrorMessage.NotUniqueUsername:
                        return new Tuple<string, int>("Error: Username is already taken. Please choose another one.", result);

                    case UserErrorMessage.NotUniqueEmail:
                        return new Tuple<string, int>("Error: Email is already registered. Please use a different email.", result);

                    case UserErrorMessage.NotUniqueSSN:
                        return new Tuple<string, int>("Error: SSN is already in use. Please enter a valid SSN.", result);

                    case UserErrorMessage.ConstraintViolation:
                        return new Tuple<string, int>("Error: Data update failed due to constraint violation.", result);

                    default:
                        return new Tuple<string, int>("Unknown error occurred.", result);
                }
            }
            catch (Exception ex)
            {
                return new Tuple<string, int>($"Unexpected error: {ex.Message}", -99);
            }
        }
        public static void SetUserImage(PictureBox pic, User user)
        {
            string imagePath = Path.Combine(General.rootPath, "Images");
            if (user.UserImg != null)
            {
                using (MemoryStream stream = new MemoryStream(user.UserImg))
                {

                    pic.Image = Image.FromStream(stream);
                }
            }
            else
            {
                string imageFileName = user.Gender == Business.Enums.Gender.Male
                ? "man.png"
                : "woman.png";


                string fullImagePath = Path.Combine(imagePath, imageFileName);


                if (File.Exists(fullImagePath))
                {
                    pic.Image = new Bitmap(fullImagePath);
                }
                else
                {
                    // Handle the case when the image file doesn't exist
                    MessageBox.Show("Profile image not found at: " + fullImagePath);
                }
            }


        }
        public static int DeleteTeacherById(int teacherId)
        {
            try
            {
                SqlCommand cmd = new SqlCommand($"DeleteTeacherById");
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TeacherId", teacherId);
                SqlParameter Status = new SqlParameter("@Status", SqlDbType.Int) { Direction = ParameterDirection.Output };
                SqlParameter Error = new SqlParameter("@Error", SqlDbType.NVarChar, 255) { Direction = ParameterDirection.Output };
                cmd.Parameters.AddRange(new SqlParameter[]
                {
                    Status, Error
                });
                Reposatory.DML(cmd);
                return (int)Status.Value;
            }
            catch (Exception ex)
            {


                throw ex;
            }
        }
        public static DataTable GetAllTeachers()
        {
            return UserRepository.GetAllTeachers();
        }
        public static HomeData GetHomeData()
        {
            SqlCommand cmd = new SqlCommand("GetHomeData");
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter studentsNumber = new SqlParameter("@stNum", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter teacherssNumber = new SqlParameter("@tNum", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter coursesNumber = new SqlParameter("@cNum", SqlDbType.Int) { Direction = ParameterDirection.Output };
            SqlParameter examsNumber = new SqlParameter("@eNum", SqlDbType.Int) { Direction = ParameterDirection.Output };
            cmd.Parameters.AddRange(new SqlParameter[] {
                studentsNumber,
                teacherssNumber,
                coursesNumber,
                examsNumber
            });

            Reposatory.select(cmd);
            HomeData homeData = new HomeData();
            homeData.StudentsNumber = studentsNumber.Value != DBNull.Value ? Convert.ToInt32(studentsNumber.Value) : 0;
            homeData.TeachersNumber = teacherssNumber.Value != DBNull.Value ? Convert.ToInt32(teacherssNumber.Value) : 0;
            homeData.CoursesNumber = coursesNumber.Value != DBNull.Value ? Convert.ToInt32(coursesNumber.Value) : 0;
            homeData.ExamsNumber = examsNumber.Value != DBNull.Value ? Convert.ToInt32(examsNumber.Value) : 0;

            return homeData;
        }
        public static DataTable GetAllCoursesStudentEnrolledIn(int studentId)
        {
            try
            {
                return UserRepository.GetAllCoursesStudentEnrolledIn(studentId);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetAllStudents()
        {
            return UserRepository.GetAllStudents();
        }

        public static DataTable GetAllStudentsByTeacherId(int teacherId)
        {
            return UserRepository.GetAllStudentsByTeacherId(teacherId);
        }

        public static DataTable GetStudentsByCourseId(int courseId)
        {
            return UserRepository.GetStudentsByCourseId(courseId);
        }

        public static DataTable GetStudentsByTeacherAndCourse(int courseId, int teacherId)
        {
            if (courseId == 0 && teacherId != 0)
            {
                return GetAllStudentsByTeacherId(teacherId);
            }
            else if (teacherId == 0 && courseId != 0)
            {
                return GetStudentsByCourseId(courseId);
            }
            else if (courseId != 0 & teacherId != 0)
            {
                return UserRepository.GetStudentsByTeacherAndCourse(courseId, teacherId);
            }
            else
            {
                return GetAllStudents();
            }
        }
        public static DataTable FilterStudents(int courseId, int teacherId)
        {
            return UserRepository.FilterStudents(teacherId, courseId);
        }

        public static User GetUsrById(int userId)
        {
            return UserRepository.GetUsrById(userId);
        }

        public static int DeleteUserById(int userId)
        {
            try
            {
                return UserRepository.DeleteUsrById(userId);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }
        public static DataTable getAllCoursesForTeacher(int teacherId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@$"
                    select Id, CourseName from Courses 
	                    where TeacherID = {teacherId}
	                    or TeacherID is null
                    "))
                {


                    return UserRepository.UserDAL(cmd);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static List<ActivityLog> GetRecentActivities()
        {
            DataTable dataTable = Reposatory.select(new SqlCommand($"  select top(5) * from ActivityLog order by ActivityID desc"));
            List<ActivityLog> logs = new List<ActivityLog>();
            foreach (DataRow row in dataTable.Rows)
            {
                ActivityLog log = new ActivityLog
                {
                    ActivityID = Convert.ToInt32(row["ActivityID"]),
                    TableName = row["TableName"].ToString(),
                    RecordID = Convert.ToInt32(row["RecordID"]),
                    ActionType = row["ActionType"].ToString(),
                    ActionTimestamp = row["ActionTimestamp"] != DBNull.Value ? (DateTime?)row["ActionTimestamp"] : null,
                    Details = row["Details"] != DBNull.Value ? row["Details"].ToString() : null,
                    UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : null
                };

                logs.Add(log);
            }
            return logs;
        }

        public static List<ActivityLog> GetRecentAllActivities()
        {
            DataTable dataTable = Reposatory.select(new SqlCommand($"  select * from ActivityLog order by ActivityID desc"));
            List<ActivityLog> logs = new List<ActivityLog>();
            foreach (DataRow row in dataTable.Rows)
            {
                ActivityLog log = new ActivityLog
                {
                    ActivityID = Convert.ToInt32(row["ActivityID"]),
                    TableName = row["TableName"].ToString(),
                    RecordID = Convert.ToInt32(row["RecordID"]),
                    ActionType = row["ActionType"].ToString(),
                    ActionTimestamp = row["ActionTimestamp"] != DBNull.Value ? (DateTime?)row["ActionTimestamp"] : null,
                    Details = row["Details"] != DBNull.Value ? row["Details"].ToString() : null,
                    UserName = row["UserName"] != DBNull.Value ? row["UserName"].ToString() : null
                };

                logs.Add(log);
            }
            return logs;
        }
        public static DataTable GetTeacherCourses(int teacherId)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(@$"
                    select Id, CourseName from Courses 
	                    where TeacherID = {teacherId}
	                    
                    "))
                {


                    return UserRepository.UserDAL(cmd);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static int CreateUpdateUser(User user, List<int> coursesIds, OperationMode operationMode)
        {
            try
            {
                return UserRepository.CreateUpdateUser(user, coursesIds, operationMode);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public static DataTable GetStudentCourses(int studentId)
        {
            SqlCommand cmd = new SqlCommand($"select c.Id, c.CourseName, u.FirstName +' '+ u.LastName as [TeacherName], c.Grade, c.Duration from Courses c\r\n  join StudentCourses sc \r\n  on sc.CourseID = c.ID\r\n  join Users u \r\n  on u.id = c.TeacherID\r\n  where sc.StudentID = {studentId}");
            return UserRepository.UserDAL(cmd);
        }

        public static DataTable GetStudentExams(int studentId, int courseId)
        {
            SqlCommand cmd = new SqlCommand($"select E.Id as ExamId,\r\n  case \r\n\twhen E.ExamType = 0 then 'Practice Exam' \r\n\telse 'Final Exam'\r\n\tend as [Exam Type],\r\n  c.CourseName, \r\n  E.StartTime,\r\n  E.EndTime,\r\n  E.Duration,\r\n  E.NoOFQuestions,\r\n  case\r\n\twhen E.Status = 0 then 'Pending'\r\n\twhen E.Status = 1 then 'Started'\r\n\telse 'Finished' end as [Exam Status]\r\n\r\n  from Exam E\r\n  join StudentCourses sc \r\n  join Courses C\r\n  on C.id = sc.CourseID\r\n  on sc.CourseID = E.CourseID\r\n  join Users u \r\n  on u.ID = sc.StudentID\r\n  where u.id = {studentId} and c.ID = {courseId}");
            return UserRepository.UserDAL(cmd);
        }

        public static DataTable GetStudentExamQuestions(int studentId, int examId)
        {
            string query = @"SELECT DISTINCT Q.*, EQ.ExamID 
                     FROM Questions Q
                     JOIN ExamQuestion EQ ON Q.ID = EQ.QuestionID
                     JOIN StudentCourses SC ON Q.CourseID = SC.CourseID
                     JOIN Exam E ON EQ.ExamID = E.ID
                     WHERE SC.StudentID = @studentId 
                     AND EQ.ExamID = @examId 
                     ";  // Ensure the exam is active (assuming 1 = active)

            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@studentId", studentId);
            cmd.Parameters.AddWithValue("@examId", examId);

            return UserRepository.UserDAL(cmd);
        }

        public static DataTable GetAllAvialableCourses()
        {
            SqlCommand cmd = new SqlCommand($"select ID,  CourseName from Courses where teacherid is null");
            return UserRepository.UserDAL(cmd);
        }
        public static DataTable GetStudentExamQuestionAnswers(int questionId)
        {
            SqlCommand cmd = new SqlCommand($"select * from Answers where QuestionID = {questionId}");
            return UserRepository.UserDAL(cmd);
        }

    }
}