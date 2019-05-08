using Aspose.OCR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DistinguishOcr
{
    public partial class FormBase : Form
    {
        public FormBase()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.labelTitle.Text = "发票操作";

            this.PanelBase.Controls.Clear();
            this.PanelBase.Controls.Add(new UserControlInvoice() { Width = this.PanelBase.Width, Height = this.PanelBase.Height });
             
        }


        /// <summary>
        /// 发票操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ToolStripMenuItem_Invoice_Click(object sender, EventArgs e)
        {
            this.labelTitle.Text = sender.ToString();

            if (!this.PanelBase.Controls.ContainsKey("UserControlInvoice"))
            {
                this.PanelBase.Controls.Clear();
                this.PanelBase.Controls.Add(new UserControlInvoice() { Width = this.PanelBase.Width, Height = this.PanelBase.Height });
            }
        }

        private void ToolStripMenuItem_File_Click(object sender, EventArgs e)
        {
            this.labelTitle.Text = sender.ToString();

            if (!this.PanelBase.Controls.ContainsKey("UserControlFile"))
            {
                this.PanelBase.Controls.Clear();
                this.PanelBase.Controls.Add(new UserControlFile() { Width = this.PanelBase.Width, Height = this.PanelBase.Height });
            }
        }


        private void ToolStripMenuItem_Log_Click(object sender, EventArgs e)
        {

            //System.Diagnostics.Process.Start("ExpLore", Common.CommonClass.LogPath);
        }

        private void ToolStripMenuItem_Register_Click(object sender, EventArgs e)
        {
            this.labelTitle.Text = sender.ToString();

            if (!this.PanelBase.Controls.ContainsKey("UserControlRegister"))
            {
                this.PanelBase.Controls.Clear();
                this.PanelBase.Controls.Add(new UserControlRegister() { Width = this.PanelBase.Width, Height = this.PanelBase.Height });
            }
        }

    }
}
