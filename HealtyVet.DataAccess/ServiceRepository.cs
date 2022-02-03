using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealtyVet.DataAccess
{
    public class ServiceRepository : BaseRepository<Servicii>, IServiceRepository
    {

        public ServiceRepository(HealtyVetDbContext dbContext) : base(dbContext)
        {

        }

        public Servicii GetServiceById(Guid serviceId)
        {
            return dbContext.Services
                            .Where(service => service.Id == serviceId)
                            .FirstOrDefault();
        }
        

    }

}
