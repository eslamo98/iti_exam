using Examination_System.Data_Access.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Examination_System
{
    static class General
    {
        static public User LoggedUser { get; set; } = new User() { ID =11 };
        public static string connectionString { get; set; } = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appSettings.json")
                          .Build().GetSection("sqlConnection").Value;

        public static string rootPath =  Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName;
        public static frmLogin frmLogin { get; set; }
        public static Color primarycolor { get; set; } = Color.FromArgb(35, 40, 45);
        public static Panel pl_mainContent = new Panel();

        public static void LoadUserControl(UserControl userControl)
        {
            pl_mainContent.Controls.Clear(); // Clear previous control
            userControl.Dock = DockStyle.Fill; // Fit the panel
            pl_mainContent.Controls.Add(userControl); // Add new control
        }
    }
}
