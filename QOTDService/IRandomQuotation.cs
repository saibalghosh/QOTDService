using System.ServiceModel;

namespace QOTDService
{
    [ServiceContract]
    public interface IRandomQuotation
    {
        [OperationContract]
        string[][] GetRandomQuotation();
    }
}