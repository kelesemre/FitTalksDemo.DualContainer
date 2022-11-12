using FitTalksDemo.DualContainer.Common.Data;
using FitTalksDemo.DualContainer.Data.Abstactions;
using FitTalksDemo.DualContainer.Data.Contexts;
using FitTalksDemo.DualContainer.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTalksDemo.DualContainer.Data.Repositories
{
    public class CustomerRepository : EntityRepositoryBase<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerDbContext dbContext) : base(dbContext)
        {

        }
    }
}
