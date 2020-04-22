namespace TokenizerProject
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.InsertLabel = new System.Windows.Forms.Label();
            this.InputTextBox = new System.Windows.Forms.TextBox();
            this.ButtonStartCalculation = new System.Windows.Forms.Button();
            this.ResultText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // InsertLabel
            // 
            this.InsertLabel.AutoSize = true;
            this.InsertLabel.Location = new System.Drawing.Point(18, 30);
            this.InsertLabel.Name = "InsertLabel";
            this.InsertLabel.Size = new System.Drawing.Size(60, 13);
            this.InsertLabel.TabIndex = 0;
            this.InsertLabel.Text = "Insert Text:";
            // 
            // InputTextBox
            // 
            this.InputTextBox.Location = new System.Drawing.Point(84, 30);
            this.InputTextBox.Multiline = true;
            this.InputTextBox.Name = "InputTextBox";
            this.InputTextBox.Size = new System.Drawing.Size(240, 73);
            this.InputTextBox.TabIndex = 1;
            // 
            // ButtonStartCalculation
            // 
            this.ButtonStartCalculation.Location = new System.Drawing.Point(147, 109);
            this.ButtonStartCalculation.Name = "ButtonStartCalculation";
            this.ButtonStartCalculation.Size = new System.Drawing.Size(103, 23);
            this.ButtonStartCalculation.TabIndex = 2;
            this.ButtonStartCalculation.Text = "Start";
            this.ButtonStartCalculation.UseVisualStyleBackColor = true;
            this.ButtonStartCalculation.Click += new System.EventHandler(this.ButtonStartCalculation_Click);
            // 
            // ResultText
            // 
            this.ResultText.AutoSize = true;
            this.ResultText.Location = new System.Drawing.Point(81, 168);
            this.ResultText.Name = "ResultText";
            this.ResultText.Size = new System.Drawing.Size(0, 13);
            this.ResultText.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 386);
            this.Controls.Add(this.ResultText);
            this.Controls.Add(this.ButtonStartCalculation);
            this.Controls.Add(this.InputTextBox);
            this.Controls.Add(this.InsertLabel);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label InsertLabel;
        private System.Windows.Forms.TextBox InputTextBox;
        private System.Windows.Forms.Button ButtonStartCalculation;
        private System.Windows.Forms.Label ResultText;
    }
}

