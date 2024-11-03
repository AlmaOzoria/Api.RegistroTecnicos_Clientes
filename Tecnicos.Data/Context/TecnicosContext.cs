using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tecnicos.Data.Models;

namespace Tecnicos.Data.Context;

public class TecnicosContext : DbContext
{
    public TecnicosContext(DbContextOptions<TecnicosContext> options) : base(options) { }
    public DbSet<Clientes> Clientes { get; set; }
}