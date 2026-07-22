using EM.Planilla.Domain.Entities;
using EM.Planilla.Domain.Ports.Repositories;
using EM.Planilla.Infraestructure.Configuration.Repositories.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace EM.Planilla.Infraestructure.Adapters.Repositories
{
    public class LoanRepository(PlanillaDbContext context) : BaseRepository<Loan>(context), ILoanRepository
    {
    }
}
