namespace Cubic_Bezier_Splines
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            button1 = new Button();
            checkBoxDraw = new CheckBox();
            checkBoxSelect = new CheckBox();
            panel = new Panel();
            button2 = new Button();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            panel.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Location = new Point(218, 12);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(652, 629);
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            pictureBox.MouseDown += pictureBox_MouseDown;
            // 
            // button1
            // 
            button1.Location = new Point(3, 93);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 1;
            button1.Text = "Delete";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // checkBoxDraw
            // 
            checkBoxDraw.AutoSize = true;
            checkBoxDraw.Checked = true;
            checkBoxDraw.CheckState = CheckState.Checked;
            checkBoxDraw.Enabled = false;
            checkBoxDraw.Location = new Point(12, 12);
            checkBoxDraw.Name = "checkBoxDraw";
            checkBoxDraw.Size = new Size(66, 24);
            checkBoxDraw.TabIndex = 3;
            checkBoxDraw.Text = "Draw";
            checkBoxDraw.UseVisualStyleBackColor = true;
            checkBoxDraw.CheckedChanged += DrawChanged;
            // 
            // checkBoxSelect
            // 
            checkBoxSelect.AutoSize = true;
            checkBoxSelect.Location = new Point(84, 12);
            checkBoxSelect.Name = "checkBoxSelect";
            checkBoxSelect.Size = new Size(71, 24);
            checkBoxSelect.TabIndex = 4;
            checkBoxSelect.Text = "Select";
            checkBoxSelect.UseVisualStyleBackColor = true;
            checkBoxSelect.CheckedChanged += SelectChanged;
            // 
            // panel
            // 
            panel.Controls.Add(button2);
            panel.Controls.Add(textBox2);
            panel.Controls.Add(textBox1);
            panel.Controls.Add(button1);
            panel.Enabled = false;
            panel.Location = new Point(12, 42);
            panel.Name = "panel";
            panel.Size = new Size(200, 125);
            panel.TabIndex = 5;
            // 
            // button2
            // 
            button2.Location = new Point(103, 93);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 4;
            button2.Text = "Ok";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(3, 36);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(125, 27);
            textBox2.TabIndex = 3;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(3, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 2;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(882, 653);
            Controls.Add(panel);
            Controls.Add(checkBoxSelect);
            Controls.Add(checkBoxDraw);
            Controls.Add(pictureBox);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            panel.ResumeLayout(false);
            panel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private Button button1;
        private CheckBox checkBoxDraw;
        private CheckBox checkBoxSelect;
        private Panel panel;
        private TextBox textBox2;
        private TextBox textBox1;
        private Button button2;
    }
}