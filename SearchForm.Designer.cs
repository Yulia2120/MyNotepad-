namespace MyNotepad__
{
    partial class SearchForm
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
            this.lab1 = new System.Windows.Forms.Label();
            this.lab2 = new System.Windows.Forms.Label();
            this.tbFind = new System.Windows.Forms.TextBox();
            this.tbReplace = new System.Windows.Forms.TextBox();
            this.cbReg = new System.Windows.Forms.CheckBox();
            this.btFind = new System.Windows.Forms.Button();
            this.btReplace = new System.Windows.Forms.Button();
            this.btReplaceAll = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lab1
            // 
            this.lab1.AutoSize = true;
            this.lab1.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab1.Location = new System.Drawing.Point(41, 27);
            this.lab1.Name = "lab1";
            this.lab1.Size = new System.Drawing.Size(35, 17);
            this.lab1.TabIndex = 0;
            this.lab1.Text = "Find:";
            // 
            // lab2
            // 
            this.lab2.AutoSize = true;
            this.lab2.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lab2.Location = new System.Drawing.Point(41, 80);
            this.lab2.Name = "lab2";
            this.lab2.Size = new System.Drawing.Size(57, 17);
            this.lab2.TabIndex = 1;
            this.lab2.Text = "Replace:";
            // 
            // tbFind
            // 
            this.tbFind.Location = new System.Drawing.Point(132, 27);
            this.tbFind.Name = "tbFind";
            this.tbFind.Size = new System.Drawing.Size(397, 20);
            this.tbFind.TabIndex = 2;
            // 
            // tbReplace
            // 
            this.tbReplace.Location = new System.Drawing.Point(132, 77);
            this.tbReplace.Name = "tbReplace";
            this.tbReplace.Size = new System.Drawing.Size(397, 20);
            this.tbReplace.TabIndex = 3;
            // 
            // cbReg
            // 
            this.cbReg.AutoSize = true;
            this.cbReg.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.cbReg.Location = new System.Drawing.Point(44, 122);
            this.cbReg.Name = "cbReg";
            this.cbReg.Size = new System.Drawing.Size(75, 21);
            this.cbReg.TabIndex = 4;
            this.cbReg.Text = "Register";
            this.cbReg.UseVisualStyleBackColor = true;
            // 
            // btFind
            // 
            this.btFind.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btFind.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btFind.Location = new System.Drawing.Point(132, 169);
            this.btFind.Name = "btFind";
            this.btFind.Size = new System.Drawing.Size(75, 23);
            this.btFind.TabIndex = 5;
            this.btFind.Text = "Find";
            this.btFind.UseVisualStyleBackColor = false;
            // 
            // btReplace
            // 
            this.btReplace.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btReplace.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btReplace.Location = new System.Drawing.Point(239, 168);
            this.btReplace.Name = "btReplace";
            this.btReplace.Size = new System.Drawing.Size(75, 23);
            this.btReplace.TabIndex = 6;
            this.btReplace.Text = "Replace";
            this.btReplace.UseVisualStyleBackColor = false;
            // 
            // btReplaceAll
            // 
            this.btReplaceAll.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btReplaceAll.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btReplaceAll.Location = new System.Drawing.Point(346, 168);
            this.btReplaceAll.Name = "btReplaceAll";
            this.btReplaceAll.Size = new System.Drawing.Size(75, 23);
            this.btReplaceAll.TabIndex = 7;
            this.btReplaceAll.Text = "Replace All";
            this.btReplaceAll.UseVisualStyleBackColor = false;
            // 
            // btCancel
            // 
            this.btCancel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btCancel.Font = new System.Drawing.Font("Yu Gothic UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btCancel.Location = new System.Drawing.Point(453, 168);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(75, 23);
            this.btCancel.TabIndex = 8;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = false;
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(606, 206);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btReplaceAll);
            this.Controls.Add(this.btReplace);
            this.Controls.Add(this.btFind);
            this.Controls.Add(this.cbReg);
            this.Controls.Add(this.tbReplace);
            this.Controls.Add(this.tbFind);
            this.Controls.Add(this.lab2);
            this.Controls.Add(this.lab1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Find and Replace";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lab1;
        private System.Windows.Forms.Label lab2;
        private System.Windows.Forms.TextBox tbFind;
        private System.Windows.Forms.TextBox tbReplace;
        private System.Windows.Forms.CheckBox cbReg;
        private System.Windows.Forms.Button btFind;
        private System.Windows.Forms.Button btReplace;
        private System.Windows.Forms.Button btReplaceAll;
        private System.Windows.Forms.Button btCancel;
    }
}