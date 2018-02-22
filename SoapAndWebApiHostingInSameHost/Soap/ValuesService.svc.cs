using System.Collections.Generic;

namespace SoapAndWebApiHostingInSameHost.Soap
{
    public class ValuesService : IValuesService
    {
        public IEnumerable<string> GetAll()
        {
            return new string[] { "value1", "value2" };
        }

        public string GetById(int id)
        {
            return "value";
        }
    }
}
