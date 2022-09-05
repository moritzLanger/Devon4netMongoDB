using Devon4Net.Application.WebAPI.Implementation.Domain.Entities;
using Devon4Net.Application.WebAPI.Implementation.Domain.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Devon4Net.Application.WebAPI.Implementation.Business.DishNosqlManagement.Service
{
    public class DishNosqlService : IDishNosqlService

    {
        private readonly IDishNosqlRepository _dishNosqlRepository;



        public DishNosqlService(IDishNosqlRepository dishNosqlRepository)

        {

            _dishNosqlRepository = dishNosqlRepository;

        }

        public async Task<List<Dish>> GetAsync() => await _dishNosqlRepository.GetAll();

    }
}
