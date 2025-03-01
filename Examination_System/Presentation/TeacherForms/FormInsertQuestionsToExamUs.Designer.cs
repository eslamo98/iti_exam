namespace Examination_System.Presentation.TeacherForms
{
    partial class FormInsertQuestionsToExamUs
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            QuestionTypes = new CheckedListBox();
            label7 = new Label();
            customPanel1 = new CustomControls.CustomPanel();
            dgvQuestions = new DataGridView();
            customPanel2 = new CustomControls.CustomPanel();
            dgvExams = new DataGridView();
            label1 = new Label();
            btn_back = new Button();
            customPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).BeginInit();
            customPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvExams).BeginInit();
            SuspendLayout();
            // 
            // QuestionTypes
            // 
            QuestionTypes.FormattingEnabled = true;
            QuestionTypes.Location = new Point(52, 46);
            QuestionTypes.Margin = new Padding(3, 2, 3, 2);
            QuestionTypes.Name = "QuestionTypes";
            QuestionTypes.Size = new Size(220, 76);
            QuestionTypes.TabIndex = 52;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(52, 9);
            label7.Name = "label7";
            label7.Size = new Size(144, 25);
            label7.TabIndex = 48;
            label7.Text = "Question Type ";
            // 
            // customPanel1
            // 
            customPanel1.AutoSize = true;
            customPanel1.BackColor = Color.Black;
            customPanel1.BorderRadius = 30;
            customPanel1.Controls.Add(dgvQuestions);
            customPanel1.ForeColor = Color.Black;
            customPanel1.GradientBottomColor = SystemColors.HotTrack;
            customPanel1.GradientTopColor = Color.LightCyan;
            customPanel1.GrediantAngle = 90F;
            customPanel1.Location = new Point(5, 138);
            customPanel1.Margin = new Padding(3, 4, 3, 4);
            customPanel1.Name = "customPanel1";
            customPanel1.Padding = new Padding(0, 0, 0, 13);
            customPanel1.Size = new Size(488, 338);
            customPanel1.TabIndex = 53;
            // 
            // dgvQuestions
            // 
            dgvQuestions.AllowUserToAddRows = false;
            dgvQuestions.AllowUserToDeleteRows = false;
            dgvQuestions.AllowUserToResizeColumns = false;
            dgvQuestions.AllowUserToResizeRows = false;
            dgvQuestions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvQuestions.BackgroundColor = Color.White;
            dgvQuestions.BorderStyle = BorderStyle.None;
            dgvQuestions.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.Black;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(235, 230, 255);
            dataGridViewCellStyle1.Padding = new Padding(15);
            dataGridViewCellStyle1.SelectionBackColor = Color.Black;
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(235, 230, 255);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvQuestions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvQuestions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvQuestions.DefaultCellStyle = dataGridViewCellStyle2;
            dgvQuestions.Dock = DockStyle.Fill;
            dgvQuestions.EnableHeadersVisualStyles = false;
            dgvQuestions.Location = new Point(0, 0);
            dgvQuestions.Margin = new Padding(3, 4, 3, 4);
            dgvQuestions.Name = "dgvQuestions";
            dgvQuestions.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Control;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvQuestions.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvQuestions.RowHeadersVisible = false;
            dgvQuestions.RowHeadersWidth = 25;
            dgvQuestions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvQuestions.Size = new Size(488, 325);
            dgvQuestions.TabIndex = 0;
            // 
            // customPanel2
            // 
            customPanel2.AutoSize = true;
            customPanel2.BackColor = Color.Black;
            customPanel2.BorderRadius = 30;
            customPanel2.Controls.Add(dgvExams);
            customPanel2.ForeColor = Color.Black;
            customPanel2.GradientBottomColor = SystemColors.HotTrack;
            customPanel2.GradientTopColor = Color.LightCyan;
            customPanel2.GrediantAngle = 90F;
            customPanel2.Location = new Point(507, 138);
            customPanel2.Margin = new Padding(3, 4, 3, 4);
            customPanel2.Name = "customPanel2";
            customPanel2.Padding = new Padding(0, 0, 0, 13);
            customPanel2.Size = new Size(477, 338);
            customPanel2.TabIndex = 54;
            // 
            // dgvExams
            // 
            dgvExams.AllowUserToAddRows = false;
            dgvExams.AllowUserToDeleteRows = false;
            dgvExams.AllowUserToResizeColumns = false;
            dgvExams.AllowUserToResizeRows = false;
            dgvExams.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgvExams.BackgroundColor = Color.White;
            dgvExams.BorderStyle = BorderStyle.None;
            dgvExams.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = Color.Black;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(235, 230, 255);
            dataGridViewCellStyle4.Padding = new Padding(15);
            dataGridViewCellStyle4.SelectionBackColor = Color.Black;
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(235, 230, 255);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvExams.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvExams.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle5.ForeColor = Color.Black;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.GradientActiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = Color.Black;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            dgvExams.DefaultCellStyle = dataGridViewCellStyle5;
            dgvExams.Dock = DockStyle.Fill;
            dgvExams.EnableHeadersVisualStyles = false;
            dgvExams.Location = new Point(0, 0);
            dgvExams.Margin = new Padding(3, 4, 3, 4);
            dgvExams.Name = "dgvExams";
            dgvExams.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = SystemColors.Control;
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            dgvExams.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            dgvExams.RowHeadersVisible = false;
            dgvExams.RowHeadersWidth = 25;
            dgvExams.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvExams.Size = new Size(477, 325);
            dgvExams.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Times New Roman", 24F, FontStyle.Bold);
            label1.ForeColor = SystemColors.HotTrack;
            label1.Location = new Point(248, 32);
            label1.Name = "label1";
            label1.Size = new Size(367, 36);
            label1.TabIndex = 55;
            label1.Text = "Insert Questions To Exam";
            // 
            // btn_back
            // 
            btn_back.BackColor = Color.Black;
            btn_back.Font = new Font("Times New Roman", 13.8F, FontStyle.Bold);
            btn_back.ForeColor = Color.White;
            btn_back.Location = new Point(328, 494);
            btn_back.Margin = new Padding(3, 4, 3, 4);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(310, 53);
            btn_back.TabIndex = 56;
            btn_back.Text = "Save Exam";
            btn_back.UseVisualStyleBackColor = false;
            btn_back.Click += BtnSave_Click;
            // 
            // FormInsertQuestionsToExamUs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_back);
            Controls.Add(label1);
            Controls.Add(customPanel2);
            Controls.Add(customPanel1);
            Controls.Add(QuestionTypes);
            Controls.Add(label7);
            Margin = new Padding(3, 2, 3, 2);
            MaximumSize = new Size(863, 562);
            MinimumSize = new Size(863, 562);
            Name = "FormInsertQuestionsToExamUs";
            Size = new Size(863, 562);
            customPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvQuestions).EndInit();
            customPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvExams).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckedListBox QuestionTypes;
        private Label label7;
        private CustomControls.CustomPanel customPanel1;
        private DataGridView dgvQuestions;
        private CustomControls.CustomPanel customPanel2;
        private DataGridView dgvExams;
        private Label label1;
        private Button btnContinue;
        private Button btn_back;
    }
}
