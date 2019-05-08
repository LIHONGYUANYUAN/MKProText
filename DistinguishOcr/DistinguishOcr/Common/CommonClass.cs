using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace DistinguishOcr.Common
{
    public static class CommonClass
    {
        private static Baidu.Aip.Ocr.Ocr _OcrClient = null;

        private static string _LogPath = null;

        private static string _ConfigPath = null;


        //private static string API_KEY = "E14d83be468890b78b031c557b9a53f1";
        //private static string SECRET_KEY = "9d90cc9c770214465837002e43b37734";

        public static string API_KEY
        {
            get
            {
                DistinguishConfig config = new DistinguishConfig(ConfigPath);
                string api_key = config.IniReadValue("BAIDU.API", "API_KEY");
                return api_key;
            }
            set
            {
                DistinguishConfig config = new DistinguishConfig(ConfigPath);
                config.IniWriteValue("BAIDU.API", "API_KEY", value);
            }
        }

        public static string SECRET_KEY
        {
            get
            {
                DistinguishConfig config = new DistinguishConfig(ConfigPath);
                string secret_key = config.IniReadValue("BAIDU.API", "SECRET_KEY");
                return secret_key;
            }
            set
            {
                DistinguishConfig config = new DistinguishConfig(ConfigPath);
                config.IniWriteValue("BAIDU.API", "SECRET_KEY", value);
            }
        }

        public static Baidu.Aip.Ocr.Ocr OcrClient
        {
            get
            {
                _OcrClient = new Baidu.Aip.Ocr.Ocr(API_KEY, SECRET_KEY)
                {
                    Timeout = 60000  // 修改超时时间
                };

                return _OcrClient;
            }
        }


        public static string LogPath
        {
            get
            {
                if (string.IsNullOrEmpty(_LogPath))
                {
                    _LogPath = AppDomain.CurrentDomain.BaseDirectory + "log\\log_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
                }
                return _LogPath;
            }

        }


        public static string ConfigPath
        {
            get
            {
                if (string.IsNullOrEmpty(_ConfigPath))
                {
                    _ConfigPath = Application.StartupPath + @"\DistinguishConfig.INI";
                }
                return _ConfigPath;
            }
        }

        public enum Message
        {
            error,
            success
        }




        public static string WriteLog(string text)
        {
            string message = "";


            string logDirectoryPath = Path.GetDirectoryName(Common.CommonClass.LogPath);

            if (!Directory.Exists(logDirectoryPath)) { Directory.CreateDirectory(logDirectoryPath); }

            System.IO.FileStream sfile = new System.IO.FileStream(Common.CommonClass.LogPath, FileMode.Append, FileAccess.Write);
            StreamWriter myfile = new StreamWriter(sfile);
            try
            {
                myfile.WriteLine(text);
                myfile.Flush();
                myfile.Close();
                sfile.Close();
            }
            catch (Exception ex)
            {
                if (myfile != null)
                {
                    myfile.Flush();
                    myfile.Close();
                }
                if (sfile != null)
                {
                    sfile.Close();
                }
                message += ex.Source + ex.Message;
            }
            return message;
        }
        public static string WriteLog(List<string> l_text)
        {
            string message = "";

            string logDirectoryPath = Path.GetDirectoryName(Common.CommonClass.LogPath);

            if (!Directory.Exists(logDirectoryPath)) { Directory.CreateDirectory(logDirectoryPath); }

            System.IO.FileStream sfile = new System.IO.FileStream(Common.CommonClass.LogPath, FileMode.Append, FileAccess.Write);
            StreamWriter myfile = new StreamWriter(sfile);
            try
            {
                for (int i = 0; i < l_text.Count; i++)
                {
                    myfile.WriteLine(l_text[i]);
                }
                myfile.Flush();
                myfile.Close();
                sfile.Close();
            }
            catch (Exception ex)
            {
                if (myfile != null)
                {
                    myfile.Flush();
                    myfile.Close();
                }
                if (sfile != null)
                {
                    sfile.Close();
                }
                message += ex.Source + ex.Message;
            }
            return message;
        }

    }
}
