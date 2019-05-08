namespace DistinguishOcr
{
    partial class UserControlRegister
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_api_key = new System.Windows.Forms.TextBox();
            this.textBox_secret_key = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnSure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "API_KEY:";
            // 
            // textBox_api_key
            // 
            this.textBox_api_key.Location = new System.Drawing.Point(95, 41);
            this.textBox_api_key.Name = "textBox_api_key";
            this.textBox_api_key.Size = new System.Drawing.Size(548, 21);
            this.textBox_api_key.TabIndex = 1;
            // 
            // textBox_secret_key
            // 
            this.textBox_secret_key.Location = new System.Drawing.Point(95, 81);
            this.textBox_secret_key.Name = "textBox_secret_key";
            this.textBox_secret_key.Size = new System.Drawing.Size(548, 21);
            this.textBox_secret_key.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "SECRET_KEY:";
            // 
            // BtnSure
            // 
            this.BtnSure.Location = new System.Drawing.Point(557, 137);
            this.BtnSure.Name = "BtnSure";
            this.BtnSure.Size = new System.Drawing.Size(75, 23);
            this.BtnSure.TabIndex = 4;
            this.BtnSure.Text = "更新";
            this.BtnSure.UseVisualStyleBackColor = true;
            this.BtnSure.Click += new System.EventHandler(this.BtnSure_Click);
            // 
            // UserControlRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.BtnSure);
            this.Controls.Add(this.textBox_secret_key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_api_key);
            this.Controls.Add(this.label1);
            this.Name = "UserControlRegister";
            this.Size = new System.Drawing.Size(674, 241);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_api_key;
        private System.Windows.Forms.TextBox textBox_secret_key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnSure;
    }
}
