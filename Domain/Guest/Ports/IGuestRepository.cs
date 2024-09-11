using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Ports
{
    public interface IGuestRepository
    {
        Task<Entities.Guest> Get(int Id);
        Task<int> Create(Entities.Guest guest);
    }
}
