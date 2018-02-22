using System;
using System.Diagnostics.CodeAnalysis;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;

namespace SoapAndWebApiHostingInSameHost.Soap
{
    /// <summary>
    /// The CustomServiceHost class.
    /// </summary>
    /// <seealso cref="System.ServiceModel.ServiceHost" />
    public class PaymentSearchServiceHost : ServiceHost
    {
        /// <summary>
        /// Max Received Message Size
        /// </summary>
        private static int MaxReceivedMessageSize = 2147483647;

        /// <summary>
        /// Max Buffer Size
        /// </summary>
        private static int MaxBufferSize = 2147483647;

        /// <summary>
        /// Max Buffer Pool Size
        /// </summary>
        private static int MaxBufferPoolSize = 65536;

        /// <summary>
        /// Initializes a new instance of the <see cref="PcnvExtractServiceHost"/> class.
        /// </summary>
        /// <param name="serviceType">The type of hosted service.</param>
        /// <param name="baseAddresses">An array of type <see cref="T:System.Uri" /> that contains the base addresses for the hosted service.</param>
        [ExcludeFromCodeCoverage]
        public PaymentSearchServiceHost(Type serviceType, params Uri[] baseAddresses)
            : base(serviceType, baseAddresses)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PcnvExtractServiceHost"/> class.
        /// </summary>
        /// <param name="singletonInstance"></param>
        /// <param name="baseAddresses">An array of type <see cref="T:System.Uri" /> that contains the base addresses for the hosted service.</param>
        internal PaymentSearchServiceHost(object singletonInstance, params Uri[] baseAddresses)
            : base(singletonInstance, baseAddresses)
        {
        }

        /// <summary>
        /// Loads the service description from the configuration file and applies it to the runtime being constructed.
        /// </summary>
        protected override void ApplyConfiguration()
        {
            base.ApplyConfiguration();
            var mexBehavior = Description.Behaviors.Find<ServiceMetadataBehavior>();

            if (mexBehavior == null)
            {
                mexBehavior = new ServiceMetadataBehavior();
                Description.Behaviors.Add(mexBehavior);
            }

            mexBehavior.HttpGetEnabled = true;
          //  mexBehavior.HttpsGetEnabled = true;

            var debugBehavior = Description.Behaviors.Find<ServiceDebugBehavior>();
            debugBehavior.IncludeExceptionDetailInFaults = true;

            AddServiceEndpoint(typeof(IPaymentSearchService), GetBasicHttpBinding(), "");
           // AddServiceEndpoint(typeof(IPcnvExtractService), GetBasicHttpsBinding(), "");
        }

        private static BasicHttpBinding GetBasicHttpBinding()
        {
            return new BasicHttpBinding
            {
                MaxReceivedMessageSize = MaxReceivedMessageSize,
                MaxBufferSize = MaxBufferSize,
                MaxBufferPoolSize = MaxBufferPoolSize,
                TransferMode = TransferMode.Buffered,
                BypassProxyOnLocal = false,
                HostNameComparisonMode = HostNameComparisonMode.StrongWildcard,
                UseDefaultWebProxy = true,
            };
        }


        /// <summary>
        /// Returns default Binding
        /// </summary>
        /// <returns></returns>
        private static BasicHttpsBinding GetBasicHttpsBinding()
        {
            var basicHttpsBinding = new BasicHttpsBinding
            {
                MaxReceivedMessageSize = MaxReceivedMessageSize,
                MaxBufferSize = MaxBufferSize,
                MaxBufferPoolSize = MaxBufferPoolSize,
                TransferMode = TransferMode.Buffered,
                BypassProxyOnLocal = false,
                HostNameComparisonMode = HostNameComparisonMode.StrongWildcard,
                UseDefaultWebProxy = true,
            };

            basicHttpsBinding.Security.Mode = BasicHttpsSecurityMode.Transport;
            basicHttpsBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.None;
            basicHttpsBinding.Security.Transport.ProxyCredentialType = HttpProxyCredentialType.None;

            return basicHttpsBinding;
        }
    }
}