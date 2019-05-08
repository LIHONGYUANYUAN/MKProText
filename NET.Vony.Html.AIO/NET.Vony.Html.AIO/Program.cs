using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NET.Vony.Html.AIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------");

            DoAio doAio = new DoAio();
             
            doAio.Grasp();

            Console.Read();
        }
    }
}
