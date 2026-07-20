using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Domain.Ports.Services
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
