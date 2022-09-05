using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces
{
    public interface IDishNosqlRepository

    {

        Task<List<Dish>> GetAll();

    }
}
