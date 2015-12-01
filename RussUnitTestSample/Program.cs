using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RussUnitTestSample.Business;
using RussUnitTestSample.Business.Database;

namespace RussUnitTestSample
{
    class Program
    {

        #region consts
        const string CONNECTION_STRING = "Data Source=192.168.50.4,1515;Initial Catalog=MBES;Persist Security Info=True;Integrated Security=true;";
        #endregion consts

        #region Entry

        static void Main(string[] args)
        {
            GetNumbersAndAddThem obj = new GetNumbersAndAddThem(
                new DbGetSomeNumbers(new BaseDbConnection(CONNECTION_STRING)),
                new NumberFunctions()
            );

            Console.WriteLine("\n");
            Console.WriteLine(obj.Execute());
            Console.WriteLine("\n");

            ServiceReference1.Service1Client client = new ServiceReference1.Service1Client();

            Console.WriteLine("\n");
            Console.WriteLine("{0}", client.GetData(42));
            Console.WriteLine("\n");

        }

        #endregion Entry
    }
}
