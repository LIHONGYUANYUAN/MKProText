namespace DistinguishOcr
{
    partial class UserControlInvoice
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.TextBoxPath = new System.Windows.Forms.TextBox();
            this.BtnChoice = new System.Windows.Forms.Button();
            this.ListMessageBox = new System.Windows.Forms.ListBox();
            this.BtnTrans = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "选择文件夹：";
            // 
            // TextBoxPath
            // 
            this.TextBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPath.Location = new System.Drawing.Point(86, 11);
            this.TextBoxPath.Name = "TextBoxPath";
            this.TextBoxPath.ReadOnly = true;
            this.TextBoxPath.Size = new System.Drawing.Size(492, 21);
            this.TextBoxPath.TabIndex = 2;
            // 
            // BtnChoice
            // 
            this.BtnChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnChoice.Location = new System.Drawing.Point(596, 9);
            this.BtnChoice.Name = "BtnChoice";
            this.BtnChoice.Size = new System.Drawing.Size(75, 23);
            this.BtnChoice.TabIndex = 3;
            this.BtnChoice.Text = "选择";
            this.BtnChoice.UseVisualStyleBackColor = true;
            this.BtnChoice.Click += new System.EventHandler(this.BtnChoice_Click);
            // 
            // ListMessageBox
            // 
            this.ListMessageBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ListMessageBox.FormattingEnabled = true;
            this.ListMessageBox.ItemHeight = 12;
            this.ListMessageBox.Location = new System.Drawing.Point(12, 91);
            this.ListMessageBox.Name = "ListMessageBox";
            this.ListMessageBox.Size = new System.Drawing.Size(659, 268);
            this.ListMessageBox.TabIndex = 4;
            // 
            // BtnTrans
            // 
            this.BtnTrans.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnTrans.Location = new System.Drawing.Point(15, 51);
            this.BtnTrans.Name = "BtnTrans";
            this.BtnTrans.Size = new System.Drawing.Size(75, 23);
            this.BtnTrans.TabIndex = 5;
            this.BtnTrans.Text = "转换";
            this.BtnTrans.UseVisualStyleBackColor = true;
            this.BtnTrans.Click += new System.EventHandler(this.BtnTrans_Click);
            // 
            // UserControlInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.BtnTrans);
            this.Controls.Add(this.BtnChoice);
            this.Controls.Add(this.TextBoxPath);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ListMessageBox);
            this.Name = "UserControlInvoice";
            this.Size = new System.Drawing.Size(683, 372);
            this.Load += new System.EventHandler(this.FormIoc_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBoxPath;
        private System.Windows.Forms.Button BtnChoice;
        private System.Windows.Forms.ListBox ListMessageBox;
        private System.Windows.Forms.Button BtnTrans;
    }
}
