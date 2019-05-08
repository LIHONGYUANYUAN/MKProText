using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using DistinguishOcr.Common;
using Microsoft.VisualBasic.Devices;

namespace DistinguishOcr
{
    public partial class UserControlInvoice : UserControl
    {
        public UserControlInvoice()
        {
            InitializeComponent();
        }



        private void FormIoc_Load(object sender, EventArgs e)
        {
        }

        private void BtnChoice_Click(object sender, EventArgs e)
        {
            DistinguishConfig config = new DistinguishConfig(Common.CommonClass.ConfigPath);

            System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
            dialog.Description = "请选择文件夹";

            string selectedPath = config.IniReadValue("File", "SelectedPath");

            if (!string.IsNullOrEmpty(selectedPath) && Directory.Exists(selectedPath))
            {
                dialog.SelectedPath = selectedPath;
            }


            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.TextBoxPath.Text = dialog.SelectedPath;

                config.IniWriteValue("File", "SelectedPath", dialog.SelectedPath);
            }

        }

        private void BtnTrans_Click(object sender, EventArgs e)
        {

            string folderPath = this.TextBoxPath.Text;

            if (string.IsNullOrEmpty(folderPath))
            {
                MessageBox.Show("请选择带有发票的文件夹！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Directory.Exists(folderPath))
            {
                MessageBox.Show("文件目录不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);

                List<string> lExtension = new List<string>() { ".bpm", ".jpg", ".jpeg", ".png" };

                FileInfo[] files = directoryInfo.GetFiles("*.*", SearchOption.TopDirectoryOnly).Where(t => lExtension.Contains(t.Extension.ToLower())).ToArray();

                for (int i = 0; i < files.Length; i++)
                {
                    Application.DoEvents();

                    //读取发票类图片
                    var image = File.ReadAllBytes(files[i].FullName);

                    //分析图片
                    var vv = Common.CommonClass.OcrClient.VatInvoice(image);

                    bool hasErr = vv.Properties().Any(p => p.Name == "error_code");

                    if (hasErr)
                    {
                        PrintMessage(CommonClass.Message.error, files[i].FullName + " -- 错误信息：" + vv["error_code"].ToString() + ":" + vv["error_msg"].ToString());
                    }
                    else
                    {
                        string invoiceNum = vv["words_result"]["InvoiceNum"].ToString();//发票号


                        string newFileName = invoiceNum + Path.GetExtension(files[i].FullName);

                        if (invoiceNum != Path.GetFileNameWithoutExtension(files[i].FullName))
                        {
                            Computer MyComputer = new Computer();
                            MyComputer.FileSystem.RenameFile(files[i].FullName, newFileName);
                        }

                        PrintMessage(CommonClass.Message.success, invoiceNum + " -- " + files[i].FullName);
                    }
                }
            }
            catch (Exception ex)
            {
                PrintMessage(CommonClass.Message.error, "错误信息：" + ex.Message);
            }

            PrintMessage(CommonClass.Message.success, "END!");

        }

        private void PrintMessage(CommonClass.Message cMes, string message)
        {
            Common.CommonClass.WriteLog(cMes + ": " + message);

            this.ListMessageBox.Items.Add(cMes + ": " + message);

            this.ListMessageBox.SelectedIndex = this.ListMessageBox.Items.Count - 1;

        }
















    }
}
