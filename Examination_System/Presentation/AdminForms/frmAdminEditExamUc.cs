using Examination_System.Business.AdminManageExamService;
using Examination_System.Business.Enums;
using Examination_System.Presentation.Common;
using ExaminationSystem.Business.Enums;
using ExaminationSystem.Data_Access.Models;
using ExaminationSystem.Data_Access;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examination_System.Presentation.TeacherForms;

namespace Examination_System.Presentation.AdminForms
{
    public partial class frmAdminEditExamUc : UserControl
    {
        private Exam currentExam = new Exam();
        ToastForm toastForm;
        public frmAdminEditExamUc(Exam exam)
        {

            //-------------------------------
            InitializeComponent();
            LoadCourses();
            combinedDateTimePickerStart.Enabled = false;
            combinedDateTimePickerEnd.Enabled = false;
            numDuration.Enabled = false;
            var textBox = numDuration.Controls.OfType<TextBox>().FirstOrDefault();
            if (textBox is not null)
            {
                textBox.TextChanged += SyncEndDateTimeWithDuration;
            }
            rdoFinalExam.CheckedChanged += ExamType_CheckedChanged;
            rdoPracticeExam.CheckedChanged += ExamType_CheckedChanged;
            combinedDateTimePickerStart.Value = DateTime.Now;
            combinedDateTimePickerEnd.Value = DateTime.Now;
            numDuration.ValueChanged += SyncEndDateTimeWithDuration;
            combinedDateTimePickerStart.ValueChanged += CombinedDateTimePickerStart_ValueChanged;
            combinedDateTimePickerEnd.ValueChanged += CombinedDateTimePickerEnd_ValueChanged;
            //-------------------------------
            currentExam = exam;
            LoadExamDetails();
        }



        private void frmAdminEditExam_Load(object sender, EventArgs e)
        {

        }
        private void SyncEndDateTimeWithDuration(object sender, EventArgs e)
        {
            if (double.TryParse(numDuration.Text, out double duration))
            {
                combinedDateTimePickerEnd.Value = combinedDateTimePickerStart.Value.AddMinutes(duration);
            }
        }
        private void CombinedDateTimePickerStart_ValueChanged(object sender, EventArgs e)
        {
            SyncEndDateTimeWithDuration(sender, e);
        }
        private void CombinedDateTimePickerEnd_ValueChanged(object sender, EventArgs e)
        {
            if (rdoPracticeExam.Checked)
            {
                if (double.TryParse(numDuration.Text, out double duration))
                {
                    var startDatewithDuration = combinedDateTimePickerStart.Value.AddMinutes(duration);
                    if (combinedDateTimePickerEnd.Value < startDatewithDuration)
                    {
                        combinedDateTimePickerEnd.Value = startDatewithDuration;
                    }
                }
            }
        }
        private void ExamType_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoFinalExam.Checked || rdoPracticeExam.Checked)
            {
                combinedDateTimePickerStart.Enabled = true;
                numDuration.Enabled = true;
                if (rdoFinalExam.Checked)
                {
                    combinedDateTimePickerEnd.Enabled = false;
                }
                else
                {
                    combinedDateTimePickerEnd.Enabled = true;
                }
                SyncEndDateTimeWithDuration(sender, e);
            }
            else
            {
                combinedDateTimePickerStart.Enabled = false;
                combinedDateTimePickerEnd.Enabled = false;
                numDuration.Enabled = false;
            }
        }
        private void PracticeExamEndDateTime_ValueChanged(object sender, EventArgs e)
        {
            if (rdoPracticeExam.Checked)
            {
                if (double.TryParse(numDuration.Text, out double duration))
                {
                    combinedDateTimePickerEnd.Value = combinedDateTimePickerStart.Value.AddMinutes(duration);
                    if (combinedDateTimePickerEnd.Value < combinedDateTimePickerStart.Value)
                    {
                        combinedDateTimePickerEnd.Value = combinedDateTimePickerStart.Value;
                    }
                }
            }
        }
        private void LoadCourses()
        {
            Course c = new Course();
            cmbCourseName.DataSource = AdminManageExamService.GetAll_Courses();
            cmbCourseName.DisplayMember = "CourseName";
            cmbCourseName.ValueMember = "ID";
            //cmbCourseName.SelectedIndex = -1;


        }

        private void ResetForm()
        {
            cmbCourseName.SelectedIndex = -1;
            rdoFinalExam.Checked = false;
            rdoPracticeExam.Checked = false;
            combinedDateTimePickerStart.Value = DateTime.Now;
            combinedDateTimePickerEnd.Value = DateTime.Now;
            numDuration.Value = 1;
            UpDownNoOFQuestions.Value = 1;
        }
        //--------------------------------------------------------------------------------------------
        public void EditExam(int _id)
        {
            try
            {
                Exam exam = AdminEditExamService.GetExamById(_id);


                if (exam != null)
                {
                    currentExam = exam;
                    LoadExamDetails();
                    if (currentExam.StartTime <= DateTime.Now)
                    {
                        toastForm = new ToastForm(ToastType.Error, "You cannot delete an exam that has already ended.");
                        //MessageBox.Show("Cannot be Update Old Exams.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("Exam not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public void LoadExamDetails()
        {
            // LoadCourses();


            cmbCourseName.SelectedValue = currentExam.CourseID;
            //cmbCourseName.SelectedItem =AdminEditExamService.GetCourseNameById(currentExam.CourseID);
            UpDownNoOFQuestions.Value = currentExam.NoOfQuestions;

            if (currentExam.Type == ExamType.FinalExam)
                rdoFinalExam.Checked = true;
            else
                rdoPracticeExam.Checked = true;

            combinedDateTimePickerStart.Value = currentExam.StartTime;
            numDuration.Value = currentExam.Duration;
            combinedDateTimePickerEnd.Value = currentExam.EndTime;
        }

        private void btn_EditQuestions_Click(object sender, EventArgs e)
        {
            if (currentExam.StartTime <= DateTime.Now)
            {
                toastForm = new ToastForm(ToastType.Error, "You cannot update an exam that has already ended.");
                toastForm.Show();
                //MessageBox.Show("Cannot be Update Old Exams.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbCourseName.SelectedItem == null || (!rdoFinalExam.Checked && !rdoPracticeExam.Checked))
            {
                MessageBox.Show("Please select a course and exam type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rdoPracticeExam.Checked && combinedDateTimePickerEnd.Value < combinedDateTimePickerStart.Value)
            {
                MessageBox.Show("End date/time cannot be earlier than start date/time for practice exams.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numDuration.Value == 0)
            {
                MessageBox.Show("Duration cannot be 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            currentExam.CourseID = (int)cmbCourseName.SelectedValue;
            currentExam.Type = rdoFinalExam.Checked ? ExamType.FinalExam : ExamType.PracticeExam;
            currentExam.StartTime = combinedDateTimePickerStart.Value;
            currentExam.EndTime = combinedDateTimePickerEnd.Value;
            currentExam.Duration = (int)numDuration.Value;
            currentExam.NoOfQuestions = (int)UpDownNoOFQuestions.Value;

            if (ExamRepository.EditExam(currentExam) > 0)
            {
                toastForm = new ToastForm(ToastType.Error, "Exam Updated Successfully! Now, Edit Questions.");
                toastForm.Show();
                //MessageBox.Show("Exam Updated Successfully! Now, Edit Questions.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (sender == btn_EditQuestions)
                {
                    General.LoadUserControl(new FormInsertQuestionsToExamUs(currentExam));
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to Update exam.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Back_Click(object sender, EventArgs e)
        {
            General.LoadUserControl(new frmAdminManageExamsUc());
        }

        private void btn_SaveChanges_Click(object sender, EventArgs e)
        {

            if (currentExam.StartTime <= DateTime.Now)
            {
                toastForm = new ToastForm(ToastType.Error, "You cannot delete an exam that has already ended.");
                toastForm.Show();
                //MessageBox.Show("Cannot be Update Old Exams.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if ((int)UpDownNoOFQuestions.Value != currentExam.NoOfQuestions)
            {
                MessageBox.Show("Number of Questions don not match already existing Questions.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbCourseName.SelectedItem == null || (!rdoFinalExam.Checked && !rdoPracticeExam.Checked))
            {
                MessageBox.Show("Please select a course and exam type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (rdoPracticeExam.Checked && combinedDateTimePickerEnd.Value < combinedDateTimePickerStart.Value)
            {
                MessageBox.Show("End date/time cannot be earlier than start date/time for practice exams.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numDuration.Value == 0)
            {
                MessageBox.Show("Duration cannot be 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            currentExam.CourseID = (int)cmbCourseName.SelectedValue;
            currentExam.Type = rdoFinalExam.Checked ? ExamType.FinalExam : ExamType.PracticeExam;
            currentExam.StartTime = combinedDateTimePickerStart.Value;
            currentExam.EndTime = combinedDateTimePickerEnd.Value;
            currentExam.Duration = (int)numDuration.Value;
            currentExam.NoOfQuestions = (int)UpDownNoOFQuestions.Value;

            if (ExamRepository.EditExam(currentExam) > 0)
            {
                toastForm = new ToastForm(ToastType.Success, "Exam Updated Successfully! Now, Edit Questions.");
                toastForm.Show();
                //MessageBox.Show("Exam Updated Successfully! Now, Edit Questions.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                if (sender == btn_EditQuestions)
                {
                    General.LoadUserControl(new FormInsertQuestionsToExamUs(currentExam));
                }
                this.Hide();
            }
            else
            {
                MessageBox.Show("Failed to Update exam.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}
