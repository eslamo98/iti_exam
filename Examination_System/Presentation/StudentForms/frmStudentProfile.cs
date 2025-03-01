using Examination_System.Business;
using Examination_System.Data_Access.Models;
using Examination_System.Business.Enums;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Examination_System.Presentation
{
    public partial class frmStudentProfile : Form
    {
        // تغيير تعريف المستخدم لجعله غير readonly بحيث يمكن تحديثه إذا لزم الأمر
        private User user;

        public frmStudentProfile()
        {
            InitializeComponent();
        }

        public frmStudentProfile(frmLogin _frmLogin)
        {
            InitializeComponent();
        }

        // المُنشئ الرئيسي الذي يستقبل كائن المستخدم
        public frmStudentProfile(User _user)
        {
            InitializeComponent();
            if (_user == null)
            {
                MessageBox.Show("لم يتم تمرير بيانات المستخدم بشكل صحيح", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            user = _user;
            InitializeProfile();
        }

        // دالة تهيئة بيانات الملف الشخصي
        private void InitializeProfile()
        {
            // ضبط صورة المستخدم من خلال دالة الخدمة
            UserService.SetUserImage(pic_userImg, user);

            // تعبئة الحقول ببيانات المستخدم
            tx_username.Text = user.Username;
            // عدم عرض كلمة المرور الحالية لأسباب أمنية، ونترك الحقل فارغًا لتحديثها فقط عند الحاجة
            tx_password.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            General.frmLogin.Show();
        }

        private void btn_history_Click(object sender, EventArgs e)
        {
            this.Close();
            frmStudentExamsHistory frmStudentExamsHistory = new frmStudentExamsHistory();
            frmStudentExamsHistory.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            UserService.Logout();
            General.frmLogin.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmStudentCourses().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            new frmStudentExam().Show();
        }
       
    }
}
