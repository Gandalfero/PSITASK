using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestConsoleApp
{
    public class FileLogger: Logger
    {
        public override void ChangeOutputColor(ConsoleColor color)
        {
            throw new NotImplementedException();
        }
        public override void Log(string message)
        {
            string dir = @"C:\payrolls";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (StreamWriter writetext = new StreamWriter(@"C:\payrolls\payroll.txt", true))
            {
                writetext.WriteLine(message);
            }
        }
        public override void ErrorLog(string errorMessage)
        {
            string dir = @"C:\logs";

            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
            using (StreamWriter writetext = new StreamWriter(@"C:\logs\log.txt", true)) //  c:\logs\log.txt because access to "c:\"  is denied 
            {
                writetext.WriteLine(DateTime.Now.ToString() +" " +errorMessage);
            }
        }
        public override void ClearFile(string dir)
        {
            File.WriteAllText(dir, String.Empty);
        }
        
    }
}
