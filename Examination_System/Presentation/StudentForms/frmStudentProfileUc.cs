using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examination_System.Business.Enums;
using Examination_System.Business;
using Examination_System.Presentation.Common;
using Examination_System.Data_Access.Models;
using Examination_System.Presentation.AdminForms;

namespace Examination_System.Presentation.StudentForms
{
    public partial class frmStudentProfileUc : UserControl
    {
        public static event EventHandler UserDataChanged;
        private readonly ReturnForm returnForm;
        private readonly User user = new User();

        public frmStudentProfileUc()
        {
            InitializeComponent();

            com_gender.DataSource = Enum.GetValues(typeof(Gender));
        }

        public frmStudentProfileUc(User _user) : this()
        {
            user = _user;
            UserService.SetUserImage(pic_userImg, user);
            tx_username.Text = user.Username;
            tx_email.Text = user.Email;
            tx_firstname.Text = user.FirstName;
            tx_lastname.Text = user.LastName;
            tx_password.Text = user.PasswordHash;
            tx_ssn.Text = user.SSN;
            tx_username.Text = user.Username;
            com_gender.DataSource = Enum.GetValues(typeof(Gender));
            com_gender.SelectedItem = user.Gender;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            User updatedUser = new User()
            {
                ID = user.ID,
                Email = tx_email.Text.Trim(),
                FirstName = tx_firstname.Text.Trim(),
                Gender = (Gender)com_gender.SelectedItem,
                LastName = tx_lastname.Text.Trim(),
                PasswordHash = tx_password.Text.Trim(),
                SSN = tx_ssn.Text.Trim(),

                Username = tx_username.Text.Trim(),
                UserRole = user.ID == General.LoggedUser.ID ? UserRole.Admin : user.UserRole,
            };
            if (pic_userImg.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                pic_userImg.Image.Save(stream, pic_userImg.Image.RawFormat);
                updatedUser.UserImg = stream.GetBuffer();
            }
            //not fount
            Tuple<string, int> result = new Tuple<string, int>("User not found", -1);
            try
            {
                result = UserService.UpdateUserData(updatedUser);
                if (result.Item2 == ((int)UserErrorMessage.Suceeded))
                {
                    if (user.ID == General.LoggedUser.ID)
                    {
                        General.LoggedUser = updatedUser;
                    }
                    new ToastForm(ToastType.Success, result.Item1).Show();
                    // Fire the static event after successfully saving user data
                    UserDataChanged?.Invoke(this, EventArgs.Empty);

                }
                else
                {
                    new ToastForm(ToastType.Error, result.Item1).Show();

                    //this.Close();
                    //if(returnForm == ReturnForm.frmAdminProfile)
                    //{
                    //    new frmAdminProfile().Show();
                    //} else if(returnForm == ReturnForm.frmAdminManageStudents)
                    //{
                    //    new frmAdminManageStudents().Show();
                    //}
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }


        private void UpdateeStudent()
        {
            User updatedUser = new User()
            {
                ID = user.ID,
                Email = tx_email.Text.Trim(),
                FirstName = tx_firstname.Text.Trim(),
                Gender = (Gender)com_gender.SelectedItem,
                LastName = tx_lastname.Text.Trim(),
                PasswordHash = tx_password.Text.Trim(),
                SSN = tx_ssn.Text.Trim(),
                Username = tx_username.Text.Trim(),
                UserRole = UserRole.Student,
            };
            if (pic_userImg.Image != null)
            {
                MemoryStream stream = new MemoryStream();
                pic_userImg.Image.Save(stream, pic_userImg.Image.RawFormat);
                updatedUser.UserImg = stream.GetBuffer();
            }
            List<int> selectedCourses = new();

            int result = UserService.CreateUpdateUser(updatedUser, selectedCourses, OperationMode.Edit);
            if (result == 1)
            {
                MessageBox.Show("Student was created successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (returnForm == ReturnForm.frmAdminManageStudents)
                {
                    General.LoadUserControl(new frmAdminManageStudentUc());
                }
            }
            else
            {

                MessageBox.Show("Student was", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_browse_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = ".png|*.png|.jpg|*.jpg|.jpeg|*.jpeg";

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                pic_userImg.Image = new Bitmap(fileDialog.FileName);
            }
        }
    }
}
