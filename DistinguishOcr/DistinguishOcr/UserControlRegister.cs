using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DistinguishOcr
{
    public partial class UserControlRegister : UserControl
    {
        public UserControlRegister()
        {
            InitializeComponent();
        }

        private void BtnSure_Click(object sender, EventArgs e)
        {
            Common.CommonClass.API_KEY = this.textBox_api_key.Text;
            Common.CommonClass.SECRET_KEY = this.textBox_secret_key.Text;

            MessageBox.Show("修改完成！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
    }
}
