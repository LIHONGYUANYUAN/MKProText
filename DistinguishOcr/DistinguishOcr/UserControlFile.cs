using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DistinguishOcr.Common;

namespace DistinguishOcr
{
    public partial class UserControlFile : UserControl
    {
        public UserControlFile()
        {
            InitializeComponent();
        }

        private void BtnChoice_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;//该值确定是否可以选择多个文件
            dialog.Title = "请选择文件夹";
            dialog.Filter = "所有文件(*.*)|*.*";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.TextBoxPath.Text = dialog.FileName;
            }
        }

        private void BtnTrans_Click(object sender, EventArgs e)
        {

            string filePath = this.TextBoxPath.Text;

            if (string.IsNullOrEmpty(filePath))
            {
                MessageBox.Show("请选择有效的文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!File.Exists(filePath))
            {
                MessageBox.Show("文件不存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var image = File.ReadAllBytes(filePath);

                Newtonsoft.Json.Linq.JObject vv;

                if (RadioHandwriting.Checked) { vv = CommonClass.OcrClient.Handwriting(image); }
                else { vv = CommonClass.OcrClient.GeneralBasic(image); }
                　
                bool hasErr = vv.Properties().Any(p => p.Name == "error_code");

                if (hasErr)
                {
                    PrintMessage(CommonClass.Message.error, filePath + " -- 错误信息：" + vv["error_code"].ToString() + ":" + vv["error_msg"].ToString());
                }
                else
                {
                    var words = vv["words_result"];

                    foreach (var line in words)
                    {
                        this.textFile.Text += line["words"].ToString() + "\r\n";
                    }
                }

                //                  {
                //                      "log_id": 4840398461412215909,
                //"words_result_num": 42,
                //"words_result": [
                //  {
                //    "words": "00e"
                //  },
                //  {

                PrintMessage(CommonClass.Message.success, filePath);
            }
            catch (Exception ex)
            {
                PrintMessage(CommonClass.Message.error, "错误信息：" + ex.Message);
            }
        }

        private void PrintMessage(CommonClass.Message cMes, string message)
        {
            Common.CommonClass.WriteLog(cMes + ": " + message);
        }


    }
}
