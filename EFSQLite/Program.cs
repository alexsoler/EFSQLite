using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFSQLite
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (var context = new ApplicationDbContext())
            {
                context.Personas.AddRange(new List<Persona>()
                {
                    new Persona{ Nombre = "Alex", Edad = 25, FechaDeNacimiento = new DateTime(1995, 3, 8) },
                    new Persona{ Nombre = "Ana", Edad = 37, FechaDeNacimiento = new DateTime(1980, 6, 23) },
                    new Persona{ Nombre = "Laura", Edad = 20, FechaDeNacimiento = new DateTime(1996, 2, 1) }
                });

                context.SaveChanges();

                var personas = context.Personas.ToList();

                foreach (var per in personas)
                {
                    Console.WriteLine($"Nombre = {per.Nombre}, Edad = {per.Edad}, Fecha de Nacimiento = {per.FechaDeNacimiento}");
                }
            }

            Console.ReadKey();
        }
    }

    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public List<Direcciones> Direcciones { get; set; }
    }

    public class Direcciones
    {
        public int Id { get; set; }
        public string Ciudad { get; set; }
        public string Calle { get; set; }
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }

    }

    public class ApplicationDbContext : DbContext
    {
        //private static bool _created = false;

        public ApplicationDbContext()
        {
            //if (!_created)
            //{
            //    _created = true;
            //    Database.EnsureDeleted();
            //    Database.EnsureCreated();
            //}
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=d:\Sample.db");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Persona> Personas { get; set; }
    }
}
