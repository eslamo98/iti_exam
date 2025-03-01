namespace Examination_System.Presentation.StudentForms
{
    partial class frmStudentCourcesUc
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
            dgvStudentCourses = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvStudentCourses).BeginInit();
            SuspendLayout();
            // 
            // dgvStudentCourses
            // 
            dgvStudentCourses.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvStudentCourses.Location = new Point(393, 85);
            dgvStudentCourses.Margin = new Padding(5, 6, 5, 6);
            dgvStudentCourses.Name = "dgvStudentCourses";
            dgvStudentCourses.RowHeadersWidth = 72;
            dgvStudentCourses.Size = new Size(1191, 572);
            dgvStudentCourses.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(255, 85);
            button1.Margin = new Padding(5, 6, 5, 6);
            button1.Name = "button1";
            button1.Size = new Size(129, 46);
            button1.TabIndex = 2;
            button1.Text = "back";
            button1.UseVisualStyleBackColor = true;
            // 
            // frmStudentCourcesUc
            // 
            AutoScaleDimensions = new SizeF(12F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvStudentCourses);
            Controls.Add(button1);
            Name = "frmStudentCourcesUc";
            Size = new Size(1619, 842);
            ((System.ComponentModel.ISupportInitialize)dgvStudentCourses).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvStudentCourses;
        private Button button1;
    }
}
