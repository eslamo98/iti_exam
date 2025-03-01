using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Examination_System.Business;
using ExaminationSystem.Business.Enums;
using ExaminationSystem.Data_Access.Models;
using ExaminationSystem.Data_Access;
using Examination_System.Presentation.Common;
using Examination_System.Business.Enums;

namespace Examination_System.Presentation.TeacherForms
{
    public partial class FormAddExamUc : UserControl
    {
        public FormAddExamUc()
        {
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
            if(General.LoggedUser.UserRole == UserRole.Admin)
            {
                cmbCourseName.DataSource = CourseService.GetAllCourses();
                cmbCourseName.DisplayMember = "CourseName";
            } else
            {
                cmbCourseName.DataSource = CourseService.GetAllCoursesListWithTeacherID(General.LoggedUser.ID); ;
                cmbCourseName.DisplayMember = "Name";
            }
            
            cmbCourseName.ValueMember = "ID";
            cmbCourseName.SelectedIndex = -1;
        }
        private void btnHandleExamCreation(object sender, EventArgs e)
        {
            if (cmbCourseName.SelectedItem == null || (!rdoFinalExam.Checked && !rdoPracticeExam.Checked))
            {
                new ToastForm(ToastType.Warning, "Please select a course and exam type.").Show();
                return;
            }
            if (rdoPracticeExam.Checked && combinedDateTimePickerEnd.Value < combinedDateTimePickerStart.Value)
            {
                new ToastForm(ToastType.Warning, "End date/time cannot be earlier than start date/time for practice exams.").Show();
                return;
            }
            if (numDuration.Value == 0)
            {
                new ToastForm(ToastType.Warning, "Duration cannot be 0.").Show();
                return;
            }
            Exam newExam = new()
            {
                CourseID = (int)cmbCourseName.SelectedValue,
                Type = rdoFinalExam.Checked ? Enum.GetValues<ExamType>()[1] : Enum.GetValues<ExamType>()[0],
                StartTime = combinedDateTimePickerStart.Value,
                EndTime = combinedDateTimePickerEnd.Value,
                Duration = (int)numDuration.Value,
                NoOfQuestions = (int)UpDownNoOFQuestions.Value
            };
            int createdExamId = ExamRepository.CreateExam(newExam);

            newExam.ID = createdExamId;
            if (createdExamId > 0)
            {
                new ToastForm(ToastType.Success, "Exam Created Successfully! Now, Add Questions.").Show();
                ResetForm();
                if (sender == btnGenerateExam)
                {

                    General.LoadUserControl(new FormGenerateRandomExamUC(newExam));
                    
                }
                else if (sender == btnProceedToQuestions)
                {
                    General.LoadUserControl(new FormInsertQuestionsToExamUs(newExam));
                }
                Hide();
            }
            else
            {
                new ToastForm(ToastType.Error, "Failed to create exam.").Show();
            }
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

        private void btn_back_Click(object sender, EventArgs e)
        {
            this.Hide();
            //WelcomeUS w = new WelcomeUS();
            //General.LoadUserControl(w);
        }
    }
}
