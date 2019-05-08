namespace DistinguishOcr
{
    partial class UserControlFile
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

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnTrans = new System.Windows.Forms.Button();
            this.BtnChoice = new System.Windows.Forms.Button();
            this.TextBoxPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textFile = new System.Windows.Forms.TextBox();
            this.RadioGeneralBasic = new System.Windows.Forms.RadioButton();
            this.RadioHandwriting = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnTrans
            // 
            this.BtnTrans.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnTrans.Location = new System.Drawing.Point(694, 69);
            this.BtnTrans.Name = "BtnTrans";
            this.BtnTrans.Size = new System.Drawing.Size(75, 23);
            this.BtnTrans.TabIndex = 9;
            this.BtnTrans.Text = "转换";
            this.BtnTrans.UseVisualStyleBackColor = true;
            this.BtnTrans.Click += new System.EventHandler(this.BtnTrans_Click);
            // 
            // BtnChoice
            // 
            this.BtnChoice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnChoice.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.BtnChoice.Location = new System.Drawing.Point(694, 10);
            this.BtnChoice.Name = "BtnChoice";
            this.BtnChoice.Size = new System.Drawing.Size(75, 23);
            this.BtnChoice.TabIndex = 8;
            this.BtnChoice.Text = "选择";
            this.BtnChoice.UseVisualStyleBackColor = true;
            this.BtnChoice.Click += new System.EventHandler(this.BtnChoice_Click);
            // 
            // TextBoxPath
            // 
            this.TextBoxPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBoxPath.Location = new System.Drawing.Point(86, 12);
            this.TextBoxPath.Name = "TextBoxPath";
            this.TextBoxPath.ReadOnly = true;
            this.TextBoxPath.Size = new System.Drawing.Size(602, 21);
            this.TextBoxPath.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 6;
            this.label1.Text = "选择文件：";
            // 
            // textFile
            // 
            this.textFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textFile.Location = new System.Drawing.Point(17, 111);
            this.textFile.Multiline = true;
            this.textFile.Name = "textFile";
            this.textFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textFile.Size = new System.Drawing.Size(752, 307);
            this.textFile.TabIndex = 10;
            // 
            // RadioGeneralBasic
            // 
            this.RadioGeneralBasic.AutoSize = true;
            this.RadioGeneralBasic.Checked = true;
            this.RadioGeneralBasic.Location = new System.Drawing.Point(6, 24);
            this.RadioGeneralBasic.Name = "RadioGeneralBasic";
            this.RadioGeneralBasic.Size = new System.Drawing.Size(77, 16);
            this.RadioGeneralBasic.TabIndex = 11;
            this.RadioGeneralBasic.TabStop = true;
            this.RadioGeneralBasic.Text = " 通用文字";
            this.RadioGeneralBasic.UseVisualStyleBackColor = true;
            // 
            // RadioHandwriting
            // 
            this.RadioHandwriting.AutoSize = true;
            this.RadioHandwriting.Location = new System.Drawing.Point(115, 24);
            this.RadioHandwriting.Name = "RadioHandwriting";
            this.RadioHandwriting.Size = new System.Drawing.Size(77, 16);
            this.RadioHandwriting.TabIndex = 12;
            this.RadioHandwriting.Text = " 手写文字";
            this.RadioHandwriting.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.RadioGeneralBasic);
            this.groupBox1.Controls.Add(this.RadioHandwriting);
            this.groupBox1.Location = new System.Drawing.Point(17, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 48);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " 识别类型";
            // 
            // UserControlFile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.textFile);
            this.Controls.Add(this.BtnTrans);
            this.Controls.Add(this.BtnChoice);
            this.Controls.Add(this.TextBoxPath);
            this.Controls.Add(this.label1);
            this.Name = "UserControlFile";
            this.Size = new System.Drawing.Size(781, 434);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnTrans;
        private System.Windows.Forms.Button BtnChoice;
        private System.Windows.Forms.TextBox TextBoxPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textFile;
        private System.Windows.Forms.RadioButton RadioGeneralBasic;
        private System.Windows.Forms.RadioButton RadioHandwriting;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}
