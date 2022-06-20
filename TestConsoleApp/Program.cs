using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TestConsoleApp
{
    //TODO: Implement new Employment type: "Intern" #done 
    //TODO: Import new employee file: employees2.csv #done 
    //TODO: Intern employee is payed fixed rate 1000$ #done 
    //TODO: Implement logging errors to file "c:\log.txt"
    //TODO: Implement exporting payroll .txt file to folder "c:\payrolls\" #done 
    class Program
    {
        static void Main(string[] args)
        {
            Logger l = new ConsoleLogger();
            Logger f = new FileLogger();
            f.ClearFile(@"C:\payrolls\payroll.txt"); //clearing file payroll.txt
            var list = new List<Employee>();
            string readText = File.ReadAllText(Path.Combine(Environment.CurrentDirectory, "employees2.csv"));  //changed to employee2.csv
            List<string> listStrLineElements = readText.Split(new string[] { Environment.NewLine }, StringSplitOptions.None).ToList();
            List<string> rowList = listStrLineElements.SelectMany(s => s.Split(';','\n')).ToList(); //added \n to Split 

            for (int i = 8; i < rowList.Count - 8; i += 8)
            {
                try
                {
                    list.Add(new Employee()
                    {
                        Id = int.Parse(rowList[i + 0]),
                        FirstName = rowList[i + 1],
                        LastName = rowList[i + 2],
                        JobType = rowList[i + 3],
                        Email = rowList[i + 6],
                        Gender = (Gender)Enum.Parse(typeof(Gender), rowList[i + 5], true),
                        HourlyRate = decimal.Parse(rowList[i + 6]),
                        EmploymentType = (EmploymentType)Enum.Parse(typeof(EmploymentType), rowList[i + 7], true)
                    });
                }
                catch (FormatException)
                {
                    f.ErrorLog("Wrong data format or data is empty");
                }
            }

            l.Log("## Payroll:");
            foreach (var item in list)
            {
                item.CalculateSalary(new DateTime(2019, 10, 1), new DateTime(2019, 10, 31));
               
            }
            
            
        }
    }
}
