using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace TestConsoleApp
{
    public abstract class Logger
    {
        public abstract void Log(string message);
        public abstract void ChangeOutputColor(ConsoleColor color);

        public abstract void ErrorLog(string errorMessage);
        public abstract void ClearFile(string dir);
    }
}
