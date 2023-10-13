using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICustomerAccountProcessService : IGenericService<CustomerAccountProcess>
    {
        List<CustomerAccountProcess> TMyLastProcess(int id);
    }
}
