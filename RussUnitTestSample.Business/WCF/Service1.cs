using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using RussUnitTestSample.Business.ServiceReference1;

namespace RussUnitTestSample.Business.WCF
{

    /// <summary>
    /// Communication with the WCF Service1
    /// </summary>
    public class Service1
    {

        #region Private
        private IService1 _service;
        #endregion Private

        #region ctor

        /// <summary>
        /// Constructor - new up IService1 with client
        /// </summary>
        public Service1()
        {
            this._service = new Service1Client();
        }

        /// <summary>
        /// Constructor - takes in implementation of IService1
        /// </summary>
        /// <param name="service">The IService1 implementation</param>
        public Service1(IService1 service)
        {
            if (service == null)
                throw new ArgumentNullException(nameof(service));

            this._service = service;
        }

        #endregion ctor

        #region Public methods

        /// <summary>
        /// Call service GetData
        /// </summary>
        /// <param name="value">The value to pass to the WCF service</param>
        /// <returns>The returned value from the WCF service call</returns>
        public string GetData(int value)
        {
            return this._service.GetData(value);
        }

        #endregion Public methods

    }
}
