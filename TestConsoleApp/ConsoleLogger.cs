using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestConsoleApp
{
    public class ConsoleLogger : Logger
    {
        public override void ChangeOutputColor(ConsoleColor color)
        {
            Console.ForegroundColor = color;
        }
        

        public override void Log(string message)
        {
            Console.WriteLine(message);
        }
        public override void ErrorLog(string errorMessage)
        {
            throw new NotImplementedException();
        }
        public override void ClearFile(string dir)
        {
            throw new NotImplementedException();
        }
    }
}
