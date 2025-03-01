using Examination_System.CustomControls;
using Examination_System.Presentation;
using Examination_System.Presentation.AdminForms;
using Examination_System.Presentation.StudentForms;
using Examination_System.Presentation.TeacherForms;
using ExaminationSystem;
using ExaminationSystem.Data_Access.Models;

namespace Examination_System
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>nb
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            General.frmLogin = new frmLogin();




            Application.Run(General.frmLogin);
            //Application.Run(new frmExam());
            //Application.Run(new frmStudentExamsHistory(20));
            //Application.Run(new frmAdminDashboard());

        }
    }
}