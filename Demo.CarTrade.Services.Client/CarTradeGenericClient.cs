using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Demo.CarTrade.Services.Client
{
    public abstract class CarTradeServiceClient<T> : ClientBase<T> where T:class
    {
        public CarTradeServiceClient()
        {

        }
        protected CarTradeServiceClient(string endpointConfigurationName) : base(endpointConfigurationName)
        {

        }
        protected CarTradeServiceClient(string endpointConfigurationName, string remoteAddress) : base(endpointConfigurationName, remoteAddress)
        {

        }
      
        protected CarTradeServiceClient(string endpointConfigurationName, EndpointAddress remoteAddress)
        {

        }
    }
}
