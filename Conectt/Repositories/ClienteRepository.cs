using Conectt.Models;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Conectt.Repositories
{
    public class ClienteRepository : EfRepository<Cliente>
    {
        public ClienteRepository(ConecttContext context) : base(context)
        {

        }

        public async Task<bool> CpfExistente(string cpf)
        {
            if (String.IsNullOrEmpty(cpf))
            {
                return false;
            }

            cpf = cpf.Trim();
            var cliente = await Where(x => x.Cpf == cpf)
                   .AsNoTracking()
                   .FirstOrDefaultAsync();

            if (cliente == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
