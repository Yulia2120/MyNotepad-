namespace MyNotepad__
{
    partial class GoToForm
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
            this.tbLineNum = new System.Windows.Forms.NumericUpDown();
            this.labGo = new System.Windows.Forms.Label();
            this.butGo = new System.Windows.Forms.Button();
            this.butCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tbLineNum)).BeginInit();
            this.SuspendLayout();
            // 
            // tbLineNum
            // 
            this.tbLineNum.Location = new System.Drawing.Point(84, 45);
            this.tbLineNum.Name = "tbLineNum";
            this.tbLineNum.Size = new System.Drawing.Size(120, 20);
            this.tbLineNum.TabIndex = 0;
            // 
            // labGo
            // 
            this.labGo.AutoSize = true;
            this.labGo.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labGo.ForeColor = System.Drawing.Color.Black;
            this.labGo.Location = new System.Drawing.Point(77, 16);
            this.labGo.Name = "labGo";
            this.labGo.Size = new System.Drawing.Size(133, 17);
            this.labGo.TabIndex = 1;
            this.labGo.Text = "Enter the line number";
            // 
            // butGo
            // 
            this.butGo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butGo.CausesValidation = false;
            this.butGo.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.butGo.Location = new System.Drawing.Point(43, 85);
            this.butGo.Name = "butGo";
            this.butGo.Size = new System.Drawing.Size(75, 23);
            this.butGo.TabIndex = 2;
            this.butGo.Text = "Go";
            this.butGo.UseVisualStyleBackColor = false;
            // 
            // butCancel
            // 
            this.butCancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butCancel.Location = new System.Drawing.Point(176, 85);
            this.butCancel.Name = "butCancel";
            this.butCancel.Size = new System.Drawing.Size(75, 23);
            this.butCancel.TabIndex = 3;
            this.butCancel.Text = "Cancel";
            this.butCancel.UseVisualStyleBackColor = false;
            // 
            // GoToForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(300, 136);
            this.Controls.Add(this.butCancel);
            this.Controls.Add(this.butGo);
            this.Controls.Add(this.labGo);
            this.Controls.Add(this.tbLineNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GoToForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Go";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.tbLineNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown tbLineNum;
        private System.Windows.Forms.Label labGo;
        private System.Windows.Forms.Button butGo;
        private System.Windows.Forms.Button butCancel;
    }
}