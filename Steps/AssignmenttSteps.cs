using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using SNOW.Steps;
using AutomationLib;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;
using System.Windows.Threading;
using System.IO;
using OfficeOpenXml;

namespace SNOW.Steps
{
    [Binding]
    public sealed class AssignmenttSteps
    {
        private readonly ScenarioContext _scenarioContext;

        public AssignmenttSteps(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I find prime number from (.*) in (.*) min")]
        public void GivenIFindPrimeNumberFromIn(int source, int time)
        {
            List<int> primeNumbers = new List<int>();
            double interval = 0;
            DateTime startTime = DateTime.Now;
            do
            {
                source = nextPrime(source);
                primeNumbers.Add(source);
                interval = (DateTime.Now - startTime).TotalMilliseconds;
            } while (interval < time * 1 * 1000);
            AddPrimeInFile(primeNumbers);
            _scenarioContext["primeNumbers"] = primeNumbers;
            Allure.Commons.AllureLifecycle.Instance.AddAttachment(@"C:\Users\DELL\source\repos\Assignment_muinmos\Assignment\PrimeNumbers.xlsx");

        }

        [Then(@"I test results are all prime numbers")]
        public void ThenITestResultsAreAllPrimeNumbers()
        {
            FileInfo existingFile = new FileInfo(@"C:\Users\DELL\source\repos\Assignment_muinmos\Assignment\PrimeNumbers.xlsx");
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the first worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets["PrimeNumbers"];
                int colCount = worksheet.Dimension.End.Column;  //get Column Count
                int rowCount = worksheet.Dimension.End.Row;     //get row count
                for (int row = 1; row <= rowCount; row++)
                {
                    for (int col = 1; col <= colCount; col++)
                    {
                        int value = Convert.ToInt32(worksheet.Cells[row, col].Value);
                        if (isPrime(value))
                            File.AppendAllText(@"C:\Users\DELL\source\repos\Assignment_muinmos\Assignment\PrimeNumbers.txt", value + Environment.NewLine);
                        else
                            File.AppendAllText(@"C:\Users\DELL\source\repos\Assignment_muinmos\Assignment\NotPrimeNumbers.txt", value + Environment.NewLine);
                    }
                }
                Allure.Commons.AllureLifecycle.Instance.AddAttachment(@"C:\Users\DELL\source\repos\Assignment_muinmos\Assignment\PrimeNumbers.txt","PrimeNumbers");
                Allure.Commons.AllureLifecycle.Instance.AddAttachment(@"C:\Users\DELL\source\repos\Assignment_muinmos\Assignment\NotPrimeNumbers.txt","NotPrimeNumbers");
            }
        }

        [Then(@"The count of prime number")]
        public void ThenTheCoundOfPrimeNumber()
        {
            IList<int> primeNum = (IList<int>)_scenarioContext["primeNumbers"];
            Console.WriteLine(primeNum.Count);
        }

        [Given(@"I find prime number from Test(.*) in (.*)")]
        public void GivenIFindPrimeNumberFromTestIn(int p0, int p1)
        {

        }

        static bool isPrime(int n)
        {
            if (n <= 1) return false;
            if (n <= 3) return true;

            // This is checked so that we can skip
            // middle five numbers in below loop
            if (n % 2 == 0 || n % 3 == 0)
                return false;

            for (int i = 5; i * i <= n; i = i + 6)
                if (n % i == 0 ||
                    n % (i + 2) == 0)
                    return false;

            return true;
        }

        private static int nextPrime(int N)
        {
            // Base case
            if (N <= 1)
                return 2;

            int prime = N;
            bool found = false;

            // Loop continuously until isPrime
            // returns true for a number
            // greater than n
            while (!found)
            {
                prime++;
                if (isPrime(prime))
                    found = true;
            }
            return prime;
        }


        public void AddPrimeInFile(List<int> source)
        {
            ExcelPackage package = new ExcelPackage();
            ExcelWorksheet worksheet;

            //Check if excel file exist or not
            if (!File.Exists(@"C:\Users\DELL\source\repos\Assignment_muinmos\Assignment\PrimeNumbers.xlsx"))
            {
                worksheet = package.Workbook.Worksheets.Add("PrimeNumbers");
                package.SaveAs(new FileInfo(@"C:\Users\DELL\source\repos\Assignment_muinmos\Assignment\PrimeNumbers.xlsx"));

            }
            else
            {
                //load excel file
                package.Load(File.OpenRead(@"C:\Users\DELL\source\repos\Assignment_muinmos\Assignment\PrimeNumbers.xlsx"));
                worksheet = package.Workbook.Worksheets["PrimeNumbers"];
            }
            //add data in excel file
            worksheet.Cells["A1"].LoadFromCollection(source);
            package.Save();
        }
    }
}
