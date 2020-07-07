using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExemploMvc.Models
{
    public class Contexto: DbContext
    {

        // virtual keyword is a declaration modifier needed to say that a method, property, etc, can be replaced 
        // in any class that inherits it
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {
            optionsBuilder.UseSqlServer(connectionString:@"Server=(localdb)\mssqllocaldb;Database=ExemploMvc;Integrated Security=True");
        }

        public virtual void SetModified(object entity) {

            Entry(entity).State = EntityState.Modified;

        }

    }
}
