using Examination_System.Business;
using Examination_System.Business.Enums;
using Examination_System.Data_Access.Models;
using Examination_System.Presentation.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examination_System.Presentation.AdminForms
{
    public partial class frmAdminActivityUc : UserControl
    {

        public frmAdminActivityUc()
        {
            InitializeComponent();


            // Clear existing columns (if needed)
            dgv_logs.Columns.Clear();

            // Add a single column that fills the entire DataGridView width
            DataGridViewColumn logColumn = new DataGridViewTextBoxColumn();
            logColumn.Name = "Log";
            logColumn.HeaderText = "Log";
            logColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; // Full width
            dgv_logs.Columns.Add(logColumn);

            // Get and add data
            List<ActivityLog> activityLogs = UserService.GetRecentAllActivities();
            foreach (ActivityLog item in activityLogs)
            {
                dgv_logs.Rows.Add(item.ToString());
            }
        }


        
    }
}
