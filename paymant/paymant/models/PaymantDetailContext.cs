using Microsoft.EntityFrameworkCore;
using paymant.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paymant.Models
{
    public class PaymantDetailContext:DbContext
    {
        public PaymantDetailContext(DbContextOptions<PaymantDetailContext> options):base (options)

        {

        }
        
    }
    public DbSet<PaymantDetail> paymantDetails { get; set; }



}