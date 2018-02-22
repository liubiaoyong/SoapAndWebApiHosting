using System.Collections.Generic;
using System.ServiceModel;


namespace SoapAndWebApiHostingInSameHost.Soap
{
    [ServiceContract]
    public interface IValuesService
    {
        [OperationContract]
        string GetById(int id);

        [OperationContract]
        IEnumerable<string> GetAll();
    }
}