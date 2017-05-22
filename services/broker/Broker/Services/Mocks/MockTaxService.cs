using System;
using System.Threading.Tasks;
using Interfaces;
using Models;

namespace Services.Mocks
{
    public class MockTaxService : ITaxService
    {
        public MockTaxService(string value) { }

        public Task<bool> InformTaxTobin(TaxNotifyObject taxNotifyObject)
        {
            throw new NotImplementedException();
        }
    }
}
