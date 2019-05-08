namespace DistinguishOcr
{
    partial class FormBase
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.发票操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.注册ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Log = new System.Windows.Forms.ToolStripMenuItem();
            this.注册ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PanelBase = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.发票操作ToolStripMenuItem,
            this.ToolStripMenuItem_File,
            this.注册ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 发票操作ToolStripMenuItem
            // 
            this.发票操作ToolStripMenuItem.Name = "发票操作ToolStripMenuItem";
            this.发票操作ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.发票操作ToolStripMenuItem.Text = "发票操作";
            this.发票操作ToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Invoice_Click);
            // 
            // ToolStripMenuItem_File
            // 
            this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
            this.ToolStripMenuItem_File.Size = new System.Drawing.Size(68, 21);
            this.ToolStripMenuItem_File.Text = "文件操作";
            this.ToolStripMenuItem_File.Click += new System.EventHandler(this.ToolStripMenuItem_File_Click);
            // 
            // 注册ToolStripMenuItem
            // 
            this.注册ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Log,
            this.注册ToolStripMenuItem1,
            this.说明ToolStripMenuItem});
            this.注册ToolStripMenuItem.Name = "注册ToolStripMenuItem";
            this.注册ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.注册ToolStripMenuItem.Text = "信息";
            // 
            // ToolStripMenuItem_Log
            // 
            this.ToolStripMenuItem_Log.Name = "ToolStripMenuItem_Log";
            this.ToolStripMenuItem_Log.Size = new System.Drawing.Size(180, 22);
            this.ToolStripMenuItem_Log.Text = "日志";
            this.ToolStripMenuItem_Log.Click += new System.EventHandler(this.ToolStripMenuItem_Log_Click);
            // 
            // 注册ToolStripMenuItem1
            // 
            this.注册ToolStripMenuItem1.Name = "注册ToolStripMenuItem1";
            this.注册ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.注册ToolStripMenuItem1.Text = "注册";
            this.注册ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem_Register_Click);
            // 
            // 说明ToolStripMenuItem
            // 
            this.说明ToolStripMenuItem.Name = "说明ToolStripMenuItem";
            this.说明ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.说明ToolStripMenuItem.Text = "说明";
            // 
            // PanelBase
            // 
            this.PanelBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelBase.BackColor = System.Drawing.SystemColors.Control;
            this.PanelBase.Location = new System.Drawing.Point(12, 69);
            this.PanelBase.Name = "PanelBase";
            this.PanelBase.Size = new System.Drawing.Size(776, 369);
            this.PanelBase.TabIndex = 2;
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(355, 36);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(82, 22);
            this.labelTitle.TabIndex = 3;
            this.labelTitle.Text = "label1";
            // 
            // FormBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.PanelBase);
            this.Controls.Add(this.menuStrip1);
            this.Name = "FormBase";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OCR";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 注册ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Log;
        private System.Windows.Forms.ToolStripMenuItem 注册ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 说明ToolStripMenuItem;
        private System.Windows.Forms.Panel PanelBase;
        private System.Windows.Forms.ToolStripMenuItem 发票操作ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
        private System.Windows.Forms.Label labelTitle;
    }
}