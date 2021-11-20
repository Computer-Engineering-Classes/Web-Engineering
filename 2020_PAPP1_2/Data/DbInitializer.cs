using _2020_PAPP1_2.Models;
using System.Linq;

namespace _2020_PAPP1_2.Data
{
    public class DbInitializer
    {
        public static void Initialize(_2020_PAPP1_2Context context)
        {
            context.Database.EnsureCreated();

            if (context.Carro.Any())
            {
                return;
            }

            var carros = new Carro[]
            {
                new Carro { Ano = 2005, Foto = "carro1.jpg", Marca = "Kia" },
                new Carro { Ano = 2010, Foto = "carro2.jpg", Marca = "Seat" },
                new Carro { Ano = 2007, Foto = "carro3.jpg", Marca = "Volkswagen" }
            };

            context.Carro.AddRange(carros);
            context.SaveChanges();
        }
    }
}
