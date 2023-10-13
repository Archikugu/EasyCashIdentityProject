using DataAccess.Abstract;
using DataAccess.Concrete;
using DataAccess.Repositories;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.EntityFramework
{
    public class EfCustomerAccountProcessDal : GenericRepository<CustomerAccountProcess>, ICustomerAccountProcessDal
    {
        public List<CustomerAccountProcess> MyLastProcess(int id)
        {
            using var context = new Context();
            var values = context.CustomerAccountProcesses.Include(z => z.SenderCustomer).Include(z => z.ReceiverCustomer).ThenInclude(z => z.AppUser).Where(x => x.ReceiverID == id || x.SenderID == id).ToList();
            return values;
        }
    }
}
