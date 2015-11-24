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

            Console.WriteLine(obj.Execute());
        }

        #endregion Entry
    }
}
