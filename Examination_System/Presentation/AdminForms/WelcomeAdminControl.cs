using Examination_System.Business;
using Examination_System.CustomControls;
using Examination_System.Data_Access.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System.Presentation.AdminForms
{
    public partial class WelcomeAdminControl : UserControl
    {
        public WelcomeAdminControl(User user)
        {
            InitializeComponent();
            lblWelcome.Text = $"Welcome, {user.Fullname}!";
            LoadHomePage(user);
        }

        private void LoadHomePage(User user)
        {
            this.Controls.Clear();

            Panel homePanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            Label lblWelcome = new Label
            {
                Text = $"Welcome, {user.Fullname}!",
                Font = new Font("Segoe UI", 18, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                AutoSize = true,
                Location = new Point(30, 20)
            };

            Label lblSubHeading = new Label
            {
                Text = "Manage students, teachers, exams, and courses efficiently.",
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                ForeColor = Color.Gray,
                AutoSize = true,
                Location = new Point(30, 55)
            };
            HomeData homeData = UserService.GetHomeData();
            CustomPanel studentsCard = CreateInfoCard("Total Students", $"{homeData.StudentsNumber}", 30, 100);
            CustomPanel teachersCard = CreateInfoCard("Total Teachers", $"{homeData.TeachersNumber}", 250, 100);
            CustomPanel examsCard = CreateInfoCard("Total Exams", $"{homeData.ExamsNumber}", 470, 100);
            CustomPanel coursesCard = CreateInfoCard("Total Courses", $"{homeData.CoursesNumber}", 30, 225);

            Label lblRecent = new Label
            {
                Text = "Recent Activities",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.DarkSlateGray,
                AutoSize = true,
                Location = new Point(30, 355)
            };

            ListBox lstRecentActivities = new ListBox
            {
                Location = new Point(30, 395),
                Size = new Size(660, 150),
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                IntegralHeight = false,
                HorizontalScrollbar = true // Enable horizontal scrolling
            };
            List<ActivityLog> logs = UserService.GetRecentActivities();
            foreach (ActivityLog item in logs)
            {

                lstRecentActivities.Items.Add($"📌 {item}");
            }
            homePanel.Controls.Add(lblWelcome);
            homePanel.Controls.Add(lblSubHeading);
            homePanel.Controls.Add(studentsCard);
            homePanel.Controls.Add(teachersCard);
            homePanel.Controls.Add(examsCard);
            homePanel.Controls.Add(coursesCard);
            homePanel.Controls.Add(lblRecent);
            homePanel.Controls.Add(lstRecentActivities);

            this.Controls.Add(homePanel);
        }

        private CustomPanel CreateInfoCard(string title, string count, int x, int y)
        {
            CustomPanel card = new CustomPanel
            {
                Size = new Size(180, 90), // Reduced size to prevent overflow
                Location = new Point(x, y),
                GradientTopColor = Color.LightBlue,
                GradientBottomColor = Color.CadetBlue,
                BorderRadius = 20
            };

            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(15, 15),
                ForeColor = Color.Black,
                BackColor = Color.Transparent
            };

            Label lblCount = new Label
            {
                Text = count,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.DarkBlue,
                AutoSize = true,
                Location = new Point(15, 50),
                 BackColor = Color.Transparent
            };

            card.Controls.Add(lblTitle);
            card.Controls.Add(lblCount);

            return card;
        }
    }
}
