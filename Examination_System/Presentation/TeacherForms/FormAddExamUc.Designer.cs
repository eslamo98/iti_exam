namespace Examination_System.Presentation.TeacherForms
{
    partial class FormAddExamUc
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddExamUc));
            rdoPracticeExam = new RadioButton();
            rdoFinalExam = new RadioButton();
            sqlCommand1 = new Microsoft.Data.SqlClient.SqlCommand();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label5 = new Label();
            combinedDateTimePickerStart = new ExaminationSystem.CombinedDateTimePicker();
            label3 = new Label();
            numDuration = new NumericUpDown();
            label6 = new Label();
            combinedDateTimePickerEnd = new ExaminationSystem.CombinedDateTimePicker();
            NoOfQuestionsUpDown = new Label();
            UpDownNoOFQuestions = new NumericUpDown();
            label2 = new Label();
            cmbCourseName = new ComboBox();
            customPanel1 = new CustomControls.CustomPanel();
            label1 = new Label();
            btnProceedToQuestions = new Button();
            btn_back = new Button();
            pictureBox1 = new PictureBox();
            btnGenerateExam = new Button();
            panel1 = new Panel();
            label9 = new Label();
            flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numDuration).BeginInit();
            ((System.ComponentModel.ISupportInitialize)UpDownNoOFQuestions).BeginInit();
            customPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // rdoPracticeExam
            // 
            rdoPracticeExam.AutoSize = true;
            rdoPracticeExam.Font = new Font("Times New Roman", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            rdoPracticeExam.Location = new Point(144, 136);
            rdoPracticeExam.Margin = new Padding(3, 2, 3, 2);
            rdoPracticeExam.Name = "rdoPracticeExam";
            rdoPracticeExam.Size = new Size(108, 20);
            rdoPracticeExam.TabIndex = 26;
            rdoPracticeExam.TabStop = true;
            rdoPracticeExam.Text = "Practice Exam";
            rdoPracticeExam.UseVisualStyleBackColor = true;
            // 
            // rdoFinalExam
            // 
            rdoFinalExam.AutoSize = true;
            rdoFinalExam.Font = new Font("Times New Roman", 10.2F, FontStyle.Italic, GraphicsUnit.Point, 0);
            rdoFinalExam.Location = new Point(144, 106);
            rdoFinalExam.Margin = new Padding(3, 2, 3, 2);
            rdoFinalExam.Name = "rdoFinalExam";
            rdoFinalExam.Size = new Size(92, 20);
            rdoFinalExam.TabIndex = 25;
            rdoFinalExam.TabStop = true;
            rdoFinalExam.Text = "Final Exam";
            rdoFinalExam.UseVisualStyleBackColor = true;
            // 
            // sqlCommand1
            // 
            sqlCommand1.CommandTimeout = 30;
            sqlCommand1.EnableOptimizedParameterBinding = false;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.BackColor = Color.Transparent;
            flowLayoutPanel1.Controls.Add(label5);
            flowLayoutPanel1.Controls.Add(combinedDateTimePickerStart);
            flowLayoutPanel1.Controls.Add(label3);
            flowLayoutPanel1.Controls.Add(numDuration);
            flowLayoutPanel1.Controls.Add(label6);
            flowLayoutPanel1.Controls.Add(combinedDateTimePickerEnd);
            flowLayoutPanel1.Location = new Point(12, 158);
            flowLayoutPanel1.Margin = new Padding(3, 2, 3, 2);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(357, 208);
            flowLayoutPanel1.TabIndex = 23;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(68, 17);
            label5.TabIndex = 11;
            label5.Text = "StartDate";
            // 
            // combinedDateTimePickerStart
            // 
            combinedDateTimePickerStart.Location = new Point(77, 2);
            combinedDateTimePickerStart.Margin = new Padding(3, 2, 3, 2);
            combinedDateTimePickerStart.Name = "combinedDateTimePickerStart";
            combinedDateTimePickerStart.Size = new Size(248, 76);
            combinedDateTimePickerStart.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label3.Location = new Point(3, 80);
            label3.Name = "label3";
            label3.Size = new Size(87, 17);
            label3.TabIndex = 5;
            label3.Text = "Duration      ";
            // 
            // numDuration
            // 
            numDuration.Location = new Point(96, 82);
            numDuration.Margin = new Padding(3, 2, 3, 2);
            numDuration.Maximum = new decimal(new int[] { 500, 0, 0, 0 });
            numDuration.Name = "numDuration";
            numDuration.Size = new Size(219, 23);
            numDuration.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label6.Location = new Point(3, 107);
            label6.Name = "label6";
            label6.Size = new Size(68, 17);
            label6.TabIndex = 13;
            label6.Text = "End Date ";
            // 
            // combinedDateTimePickerEnd
            // 
            combinedDateTimePickerEnd.Location = new Point(77, 109);
            combinedDateTimePickerEnd.Margin = new Padding(3, 2, 3, 2);
            combinedDateTimePickerEnd.Name = "combinedDateTimePickerEnd";
            combinedDateTimePickerEnd.Size = new Size(276, 99);
            combinedDateTimePickerEnd.TabIndex = 16;
            // 
            // NoOfQuestionsUpDown
            // 
            NoOfQuestionsUpDown.AutoSize = true;
            NoOfQuestionsUpDown.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            NoOfQuestionsUpDown.Location = new Point(13, 61);
            NoOfQuestionsUpDown.Name = "NoOfQuestionsUpDown";
            NoOfQuestionsUpDown.Size = new Size(106, 17);
            NoOfQuestionsUpDown.TabIndex = 22;
            NoOfQuestionsUpDown.Text = "No of Questions";
            // 
            // UpDownNoOFQuestions
            // 
            UpDownNoOFQuestions.Location = new Point(144, 61);
            UpDownNoOFQuestions.Margin = new Padding(3, 2, 3, 2);
            UpDownNoOFQuestions.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            UpDownNoOFQuestions.Name = "UpDownNoOFQuestions";
            UpDownNoOFQuestions.Size = new Size(183, 23);
            UpDownNoOFQuestions.TabIndex = 21;
            UpDownNoOFQuestions.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label2.Location = new Point(13, 106);
            label2.Name = "label2";
            label2.Size = new Size(74, 17);
            label2.TabIndex = 20;
            label2.Text = "Exam Type";
            // 
            // cmbCourseName
            // 
            cmbCourseName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            cmbCourseName.FormattingEnabled = true;
            cmbCourseName.Location = new Point(144, 12);
            cmbCourseName.Margin = new Padding(3, 2, 3, 2);
            cmbCourseName.Name = "cmbCourseName";
            cmbCourseName.Size = new Size(183, 23);
            cmbCourseName.TabIndex = 18;
            // 
            // customPanel1
            // 
            customPanel1.BackColor = Color.Transparent;
            customPanel1.BorderRadius = 30;
            customPanel1.Controls.Add(label1);
            customPanel1.Controls.Add(btnProceedToQuestions);
            customPanel1.Controls.Add(btn_back);
            customPanel1.Controls.Add(pictureBox1);
            customPanel1.Controls.Add(btnGenerateExam);
            customPanel1.Controls.Add(panel1);
            customPanel1.ForeColor = Color.White;
            customPanel1.GradientBottomColor = Color.LightCyan;
            customPanel1.GradientTopColor = Color.SlateGray;
            customPanel1.GrediantAngle = 90F;
            customPanel1.Location = new Point(12, 10);
            customPanel1.Name = "customPanel1";
            customPanel1.Size = new Size(828, 533);
            customPanel1.TabIndex = 28;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold);
            label1.Location = new Point(262, 22);
            label1.Name = "label1";
            label1.Size = new Size(262, 36);
            label1.TabIndex = 26;
            label1.Text = "Create New Exam";
            // 
            // btnProceedToQuestions
            // 
            btnProceedToQuestions.BackColor = Color.Black;
            btnProceedToQuestions.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnProceedToQuestions.ForeColor = Color.White;
            btnProceedToQuestions.Location = new Point(508, 384);
            btnProceedToQuestions.Name = "btnProceedToQuestions";
            btnProceedToQuestions.Size = new Size(271, 40);
            btnProceedToQuestions.TabIndex = 25;
            btnProceedToQuestions.Text = "Customize Exam";
            btnProceedToQuestions.UseVisualStyleBackColor = false;
            btnProceedToQuestions.Click += btnHandleExamCreation;
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.Black;
            btn_back.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(80, 454);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(271, 40);
            btn_back.TabIndex = 3;
            btn_back.Text = "Back";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += btn_back_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(497, 68);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(290, 292);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // btnGenerateExam
            // 
            btnGenerateExam.BackColor = Color.Black;
            btnGenerateExam.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerateExam.ForeColor = Color.White;
            btnGenerateExam.Location = new Point(508, 454);
            btnGenerateExam.Name = "btnGenerateExam";
            btnGenerateExam.Size = new Size(271, 40);
            btnGenerateExam.TabIndex = 2;
            btnGenerateExam.Text = "Generate Exam";
            btnGenerateExam.UseVisualStyleBackColor = false;
            btnGenerateExam.Click += btnHandleExamCreation;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.Controls.Add(label9);
            panel1.Controls.Add(cmbCourseName);
            panel1.Controls.Add(rdoPracticeExam);
            panel1.Controls.Add(flowLayoutPanel1);
            panel1.Controls.Add(UpDownNoOFQuestions);
            panel1.Controls.Add(rdoFinalExam);
            panel1.Controls.Add(NoOfQuestionsUpDown);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(37, 68);
            panel1.Name = "panel1";
            panel1.Size = new Size(415, 380);
            panel1.TabIndex = 1;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Times New Roman", 10.2F, FontStyle.Bold);
            label9.ForeColor = Color.White;
            label9.Location = new Point(15, 14);
            label9.Name = "label9";
            label9.Size = new Size(91, 17);
            label9.TabIndex = 0;
            label9.Text = "Course Name";
            // 
            // FormAddExamUc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            AutoScrollMinSize = new Size(986, 749);
            Controls.Add(customPanel1);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(863, 562);
            MinimumSize = new Size(863, 562);
            Name = "FormAddExamUc";
            Size = new Size(846, 545);
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numDuration).EndInit();
            ((System.ComponentModel.ISupportInitialize)UpDownNoOFQuestions).EndInit();
            customPanel1.ResumeLayout(false);
            customPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private RadioButton rdoPracticeExam;
        private RadioButton rdoFinalExam;
        private Microsoft.Data.SqlClient.SqlCommand sqlCommand1;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label5;
        private ExaminationSystem.CombinedDateTimePicker combinedDateTimePickerStart;
        private Label label3;
        private NumericUpDown numDuration;
        private Label label6;
        private ExaminationSystem.CombinedDateTimePicker combinedDateTimePickerEnd;
        private Label NoOfQuestionsUpDown;
        private NumericUpDown UpDownNoOFQuestions;
        private Label label2;
        private ComboBox cmbCourseName;
        private CustomControls.CustomPanel customPanel1;
        private Button btn_back;
        private Panel panel1;
        private Label label9;
        private PictureBox pictureBox1;
        private Label label1;
        private Button btnProceedToQuestions;
        private Button btnGenerateExam;
    }
}
