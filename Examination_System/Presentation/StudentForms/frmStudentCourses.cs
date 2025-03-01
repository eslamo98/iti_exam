using Examination_System.Business.Enums;
using Examination_System.Business.StudentCoursesService;
using Examination_System.Business.StudentExamHistory;
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

namespace Examination_System.Presentation
{
    public partial class frmStudentCourses : Form
    {
        private int stdID = General.LoggedUser.ID;
        private StudentCoursesService _courceService;
        public frmStudentCourses()
        {
            InitializeComponent();
            _courceService = new StudentCoursesService();
        }
        public frmStudentCourses(int stdID)
        {
            InitializeComponent();
            this.stdID = stdID;
            _courceService = new StudentCoursesService();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            frmStudentProfile frmStudentProfile = new frmStudentProfile();
            frmStudentProfile.Show();
        }
        private void LoadStudentCourses()
        {
            try
            {
                DataTable dt = _courceService.GetStudentCources(stdID);
                dgvStudentCourses.DataSource = dt;
                dgvStudentCourses.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvStudentCourses.ColumnHeadersDefaultCellStyle.BackColor = Color.Navy;
                dgvStudentCourses.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                dgvStudentCourses.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvStudentCourses.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                dgvStudentCourses.DefaultCellStyle.BackColor = Color.WhiteSmoke;
                dgvStudentCourses.DefaultCellStyle.ForeColor = Color.Black;
                dgvStudentCourses.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
                dgvStudentCourses.DefaultCellStyle.SelectionForeColor = Color.Black;
                dgvStudentCourses.EnableHeadersVisualStyles = false;
                dgvStudentCourses.BorderStyle = BorderStyle.None;
                dgvStudentCourses.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
                dgvStudentCourses.RowHeadersVisible = false;
                dgvStudentCourses.BackgroundColor = Color.White;
                dgvStudentCourses.RowTemplate.Height = 30;
            }
            catch (Exception ex)
            {
                new ToastForm(ToastType.Error, ex.Message).Show();
            }
        }

        private void frmStudentCourses_Load(object sender, EventArgs e)
        {
            LoadStudentCourses();
        }
    }
}
