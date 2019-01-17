using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesterInterface
{
    class Program
    {
        static void Main(string[] args)
        {
            ContactInsertTest test = new ContactInsertTest();
            test.execute();
            Console.WriteLine("Execute Complete");
            Console.ReadLine();
        }
    }
}
