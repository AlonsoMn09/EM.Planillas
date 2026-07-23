using EM.Planilla.Domain.Entities;
using EM.Planilla.Domain.Ports.Repositories;
using EM.Planilla.Infraestructure.Configuration.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Infraestructure.Adapters.Repositories
{
    public class PayrollRepository(PlanillaDbContext context) : BaseRepository<Payroll>(context), IPayrollRepository
    {
    }
}
