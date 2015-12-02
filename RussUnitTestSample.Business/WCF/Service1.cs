using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RussUnitTestSample.Business.WCF
{

    /// <summary>
    /// Communication with the WCF Service1
    /// </summary>
    public class Service1
    {

        #region Private
        private ServiceReference1.Service1Client _service;
        #endregion Private

        public Service1()
        {
            this._service = new ServiceReference1.Service1Client();
        }

        public string GetData(int value)
        {
            return this._service.GetData(value);
        }

    }
}
