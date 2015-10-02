namespace ExpressProfiler
{
    partial class FindForm
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
			this.edPattern = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnFindNext = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.chkCase = new System.Windows.Forms.CheckBox();
			this.chkWholeWord = new System.Windows.Forms.CheckBox();
			this.btnFindPrevious = new System.Windows.Forms.Button();
			this.chkWrapAround = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// edPattern
			// 
			this.edPattern.Location = new System.Drawing.Point(4, 20);
			this.edPattern.Name = "edPattern";
			this.edPattern.Size = new System.Drawing.Size(300, 20);
			this.edPattern.TabIndex = 1;
			this.edPattern.TextChanged += new System.EventHandler(this.edPattern_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 3);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "&Find what:";
			// 
			// btnFindNext
			// 
			this.btnFindNext.Location = new System.Drawing.Point(309, 19);
			this.btnFindNext.Name = "btnFindNext";
			this.btnFindNext.Size = new System.Drawing.Size(78, 23);
			this.btnFindNext.TabIndex = 2;
			this.btnFindNext.Text = "Find &next";
			this.btnFindNext.UseVisualStyleBackColor = true;
			this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
			// 
			// btnClose
			// 
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(309, 77);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(78, 23);
			this.btnClose.TabIndex = 4;
			this.btnClose.Text = "Close";
			this.btnClose.UseVisualStyleBackColor = true;
			// 
			// chkCase
			// 
			this.chkCase.AutoSize = true;
			this.chkCase.Location = new System.Drawing.Point(6, 48);
			this.chkCase.Name = "chkCase";
			this.chkCase.Size = new System.Drawing.Size(83, 17);
			this.chkCase.TabIndex = 5;
			this.chkCase.Text = "&Match Case";
			this.chkCase.UseVisualStyleBackColor = true;
			// 
			// chkWholeWord
			// 
			this.chkWholeWord.AutoSize = true;
			this.chkWholeWord.Location = new System.Drawing.Point(6, 71);
			this.chkWholeWord.Name = "chkWholeWord";
			this.chkWholeWord.Size = new System.Drawing.Size(86, 17);
			this.chkWholeWord.TabIndex = 6;
			this.chkWholeWord.Text = "&Whole Word";
			this.chkWholeWord.UseVisualStyleBackColor = true;
			// 
			// btnFindPrevious
			// 
			this.btnFindPrevious.Location = new System.Drawing.Point(309, 48);
			this.btnFindPrevious.Name = "btnFindPrevious";
			this.btnFindPrevious.Size = new System.Drawing.Size(78, 23);
			this.btnFindPrevious.TabIndex = 3;
			this.btnFindPrevious.Text = "Find &previous";
			this.btnFindPrevious.UseVisualStyleBackColor = true;
			this.btnFindPrevious.Click += new System.EventHandler(this.btnFindPrevious_Click);
			// 
			// chkWrapAround
			// 
			this.chkWrapAround.AutoSize = true;
			this.chkWrapAround.Location = new System.Drawing.Point(6, 94);
			this.chkWrapAround.Name = "chkWrapAround";
			this.chkWrapAround.Size = new System.Drawing.Size(89, 17);
			this.chkWrapAround.TabIndex = 7;
			this.chkWrapAround.Text = "Wrap Around";
			this.chkWrapAround.UseVisualStyleBackColor = true;
			// 
			// FindForm
			// 
			this.AcceptButton = this.btnFindNext;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(399, 135);
			this.ControlBox = false;
			this.Controls.Add(this.chkWrapAround);
			this.Controls.Add(this.btnFindPrevious);
			this.Controls.Add(this.chkWholeWord);
			this.Controls.Add(this.chkCase);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnFindNext);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.edPattern);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FindForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Find";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox edPattern;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFindNext;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.CheckBox chkCase;
        private System.Windows.Forms.CheckBox chkWholeWord;
        private System.Windows.Forms.Button btnFindPrevious;
		private System.Windows.Forms.CheckBox chkWrapAround;
    }
}