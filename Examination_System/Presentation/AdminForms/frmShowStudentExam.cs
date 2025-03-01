using Examination_System.Business;
using Examination_System.Business.Enums;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.Data;
using System.Windows.Forms;
using ExaminationSystem.Business.ExamService;

namespace Examination_System.Presentation.AdminForms
{
    public partial class frmShowStudentExam : Form
    {
        private int studentId;
        private int examId;
        private DataTable dtStudentAnswers;

        public frmShowStudentExam( int _examId)
        {
            InitializeComponent();
            examId = _examId;
            //here you need to create a method that getExamQuestionsByExamId
            DataTable dtQuestions = UserService.GetStudentExamQuestions(studentId, examId);
            LoadExamDetails();
            LoadStudentAnswers();
            LoadQuestions(dtQuestions);
        }
        public frmShowStudentExam(int _studentId, int _examId)
        {
            InitializeComponent();
            studentId = _studentId;
            examId = _examId;
            DataTable dtQuestions = UserService.GetStudentExamQuestions(studentId, examId);
            LoadExamDetails();
            LoadStudentAnswers();
            LoadQuestions(dtQuestions);
        }


        private int totalMarks;

        private void LoadExamDetails()
        {
            DataTable exam = ExamService.GetExamById(examId);
            var student = UserService.GetUsrById(studentId);
            lb_examtitle.Text = $"Student: {student.Fullname}";

            // Fetch and store the total marks for the exam
            if (exam.Rows.Count > 0)                                             
            {
                totalMarks = Convert.ToInt32(exam.Rows[0]["TotalMarks"]);
            }
        }

        private void LoadStudentAnswers()
        {
            // Fetch student answers from the Submit table
            dtStudentAnswers = UserService.GetStudentAnswers(studentId, examId);
        }

        private void LoadQuestions(DataTable dtQuestions)
        {
            
            foreach (DataRow row in dtQuestions.Rows)
            {
                int questionId = Convert.ToInt32(row["Id"]);
                string questionText = row["Body"].ToString();
                QuestionType questionType = (QuestionType)(Byte)row["QuestionType"];

                Label lblQuestion = new Label();
                lblQuestion.Text = questionText;
                lblQuestion.AutoSize = true;
                lblQuestion.Margin = new Padding(10);

                FlowLayoutPanel panel = new FlowLayoutPanel();
                panel.FlowDirection = FlowDirection.TopDown;
                panel.AutoSize = true;
                panel.Width = flowLayoutPanelQuestions.Width - 20;
                panel.Controls.Add(lblQuestion);

                LoadAnswers(questionId, questionType, panel);

                flowLayoutPanelQuestions.Controls.Add(panel);

                // Add a horizontal separator
                Label separator = new Label();
                separator.BorderStyle = BorderStyle.Fixed3D;
                separator.Height = 2;
                separator.Width = flowLayoutPanelQuestions.Width - 20;
                separator.Margin = new Padding(0, 10, 0, 10);
                flowLayoutPanelQuestions.Controls.Add(separator);
            }

            // Calculate and display the result
            int studentMarks = ExamService.GetScore(examId, studentId);
            lb_result.Text = $"Marks Obtained: {studentMarks} / Total Marks: {totalMarks}";
        }

        private void LoadAnswers(int questionId, QuestionType questionType, FlowLayoutPanel panel)
        {
            DataTable dtAnswers = UserService.GetStudentExamQuestionAnswers(questionId);

            // Get the correct answer(s) for the question
            DataRow[] correctAnswerRows = dtAnswers.Select("IsCorrect = true");

            // Get the student's answer for the question
            DataRow[] studentAnswerRows = dtStudentAnswers.Select($"QuestionId = {questionId}");

            if (questionType == QuestionType.SingleChoice || questionType == QuestionType.TrueOrFalse)
            {
                RadioButton[] radioButtons = new RadioButton[dtAnswers.Rows.Count];
                for (int i = 0; i < dtAnswers.Rows.Count; i++)
                {
                    radioButtons[i] = new RadioButton
                    {
                        Text = dtAnswers.Rows[i]["AnswerText"].ToString(),
                        AutoSize = true,
                        Enabled = false // Disable the control
                    };

                    // Check if this answer is the student's answer
                    if (studentAnswerRows.Length > 0 && studentAnswerRows[0]["AnswerId"].ToString() == dtAnswers.Rows[i]["Id"].ToString())
                    {
                        radioButtons[i].Checked = true;

                        // Check if the student's answer is correct
                        bool isCorrect = correctAnswerRows.Any(row => row["Id"].ToString() == dtAnswers.Rows[i]["Id"].ToString());
                        if (!isCorrect)
                        {
                            // Mark incorrect student answer in red
                            Label lblIncorrect = new Label
                            {
                                Text = "✗",
                                ForeColor = Color.Red,
                                AutoSize = true,
                                Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold)
                            };
                            panel.Controls.Add(lblIncorrect);
                        }
                    }

                    panel.Controls.Add(radioButtons[i]);
                }
            }
            else if (questionType == QuestionType.MultipleChoice)
            {
                CheckBox[] checkBoxes = new CheckBox[dtAnswers.Rows.Count];
                for (int i = 0; i < dtAnswers.Rows.Count; i++)
                {
                    checkBoxes[i] = new CheckBox
                    {
                        Text = dtAnswers.Rows[i]["AnswerText"].ToString(),
                        AutoSize = true,
                        Enabled = false // Disable the control
                    };

                    // Check if this answer is the student's answer
                    if (studentAnswerRows.Length > 0 && studentAnswerRows[0]["AnswerId"].ToString() == dtAnswers.Rows[i]["Id"].ToString())
                    {
                        checkBoxes[i].Checked = true;

                        // Check if the student's answer is correct
                        bool isCorrect = correctAnswerRows.Any(row => row["Id"].ToString() == dtAnswers.Rows[i]["Id"].ToString());
                        if (!isCorrect)
                        {
                            // Mark incorrect student answer in red
                            Label lblIncorrect = new Label
                            {
                                Text = "✗",
                                ForeColor = Color.Red,
                                AutoSize = true,
                                Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold)
                            };
                            panel.Controls.Add(lblIncorrect);
                        }
                    }

                    panel.Controls.Add(checkBoxes[i]);
                }
            }

            // Add correct answer indicator in green
            foreach (DataRow correctRow in correctAnswerRows)
            {
                Label lblCorrectAnswer = new Label
                {
                    Text = $"✓ {correctRow["AnswerText"].ToString()}",
                    ForeColor = Color.Green,
                    AutoSize = true,
                    Font = new System.Drawing.Font("Arial", 12, FontStyle.Bold),
                    Margin = new Padding(10, 0, 0, 0)
                };
                panel.Controls.Add(lblCorrectAnswer);
            }
        }

        private int CalculateStudentMarks()
        {
            int studentMarks = 0;

            // Loop through all questions
            DataTable dtQuestions = UserService.GetStudentExamQuestions(studentId, examId);
            foreach (DataRow questionRow in dtQuestions.Rows)
            {
                int questionId = Convert.ToInt32(questionRow["Id"]);
                QuestionType questionType = (QuestionType)(Byte)questionRow["QuestionType"];

                // Get the correct answers for the question
                DataTable dtAnswers = UserService.GetStudentExamQuestionAnswers(questionId);
                DataRow[] correctAnswerRows = dtAnswers.Select("IsCorrect = true");

                // Get the student's answer for the question
                DataRow[] studentAnswerRows = dtStudentAnswers.Select($"QuestionId = {questionId}");

                if (studentAnswerRows.Length > 0)
                {
                    // Check if the student's answer is correct
                    bool isCorrect = false;
                    if (questionType == QuestionType.SingleChoice || questionType == QuestionType.TrueOrFalse)
                    {
                        // For single-choice or true/false questions, check if the student's answer matches any correct answer
                        isCorrect = correctAnswerRows.Any(row => row["Id"].ToString() == studentAnswerRows[0]["AnswerId"].ToString());
                    }
                    else if (questionType == QuestionType.MultipleChoice)
                    {
                        // For multiple-choice questions, ensure all selected answers are correct
                        var studentAnswerIds = studentAnswerRows.Select(row => row["AnswerId"].ToString()).ToList();
                        var correctAnswerIds = correctAnswerRows.Select(row => row["Id"].ToString()).ToList();
                        isCorrect = studentAnswerIds.All(id => correctAnswerIds.Contains(id)) &&
                                    correctAnswerIds.All(id => studentAnswerIds.Contains(id));
                    }

                    // If the answer is correct, add marks
                    if (isCorrect)
                    {
                        studentMarks += 1; // Assuming each question carries 1 mark
                    }
                }
            }

            return studentMarks;
        }
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "PDF Files|*.pdf";
            saveFileDialog.Title = "Save Exam as PDF";
            saveFileDialog.FileName = "Exam.pdf";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.Create))
                    {
                        Document pdfDoc = new Document(PageSize.A4);
                        PdfWriter writer = PdfWriter.GetInstance(pdfDoc, stream);
                        pdfDoc.Open();

                        // Add Title
                        iTextSharp.text.Font titleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                        Paragraph title = new Paragraph("Student Exam", titleFont);
                        title.Alignment = Element.ALIGN_CENTER;
                        pdfDoc.Add(title);

                        pdfDoc.Add(new Paragraph("\n"));

                        // Loop through the questions
                        foreach (Control control in flowLayoutPanelQuestions.Controls)
                        {
                            if (control is FlowLayoutPanel panel)
                            {
                                foreach (Control innerControl in panel.Controls)
                                {
                                    if (innerControl is Label lblQuestion)
                                    {
                                        iTextSharp.text.Font questionFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 14);
                                        pdfDoc.Add(new Paragraph(lblQuestion.Text, questionFont));
                                    }
                                    else if (innerControl is RadioButton radio)
                                    {
                                        pdfDoc.Add(new Paragraph("  ○ " + radio.Text));
                                    }
                                    else if (innerControl is CheckBox checkBox)
                                    {
                                        pdfDoc.Add(new Paragraph("  ☑ " + checkBox.Text));
                                    }
                                }
                                pdfDoc.Add(new Paragraph("\n"));
                            }
                        }

                        pdfDoc.Close();
                    }

                    MessageBox.Show("Exam exported successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message, "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}