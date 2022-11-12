using FitTalksDemo.DualContainer.Common.Data;
using FitTalksDemo.DualContainer.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitTalksDemo.DualContainer.Data.Abstactions
{
    public interface ICustomerRepository: IEntityRepository<Customer>
    {
    }
}
