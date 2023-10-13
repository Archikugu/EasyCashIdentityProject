using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerAccountService : IGenericService<CustomerAccount>
    {
        public List<CustomerAccount> TGetCustomerAccountsList(int id);
    }
}
