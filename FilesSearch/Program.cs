using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FilesSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            string poisk = "*.png";
            poisk = poisk.Replace('.'.ToString(), "\\.").Replace('*'.ToString(), ".+").Replace('?', '.');
            Regex match = new Regex(@poisk);
            //Console.WriteLine(match);
            string[] Drives = Environment.GetLogicalDrives();
            for(int i=0;i<Drives.Length;i++)
            {
                Directo(@Drives[i], match);
            }
        }

        static void Directo(string sdir, Regex reg)
        {
            string[] file;
            try {
                string[] directories = Directory.GetDirectories(sdir);
                file = Directory.GetFiles(sdir);
                //Console.WriteLine(file[0]);
                Match ad = reg.Match("");
                for (int io = 0; io < file.Length; io++)
                {
                    ad = reg.Match(file[io]);
                    if (ad.Length > 0) Console.WriteLine(file[io]);
                }
                for (int i = 0; i < directories.Length+1; i++)
                {
                    Directo(@directories[i], reg);
                }
            }
            catch(Exception e)
            {

            }
        } 

    }
}
