using System.Data;
using System.Runtime.Serialization;
using WebApplication1.DAL.Entities;

namespace WebApplication1.DAL
{
    public class SeederDB
    {
        private readonly DataBaseContext _context;

        public SeederDB(DataBaseContext context)
        {
            _context = context;
        }

        //metoso llamado seederasync es una especie de metodo main()
        //este metodo tiene la responsabilidad de prepoblar las tablas de la base de datos

        public async Task SeederAsync()
        {
            // primero se agrega un metodo propop de entitty framework que hace las veces del comando de ipdateDataBase
            // es un metodo que creara la base de datos automaticamente
            await _context.Database.EnsureCreatedAsync();

            // a partir de aqui se van creando metodos que sirvern para prepoblar la base de datod
            await PopulateCountriesAsync();
            await _context.SaveChangesAsync();  //esta linea me guarda los datos en base de datos

        }

        #region Private Methos

        private async Task PopulateCountriesAsync()
        {
            if (!_context.Countries.Any())
            {
                //asi se crea un objeto pais con sus estados
                _context.Countries.Add(new Country
                {
                    CreateDate = DateTime.Now,
                    Name = "Colombia",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreateDate = DateTime.Now,
                            Name = "Antioquia"
                        },

                        new State
                        {
                            CreateDate = DateTime.Now,
                            Name = "Sucre"
                        },

                        new State
                        {
                            CreateDate = DateTime.Now,
                            Name = "Atlantico"
                        }
                    }
                });

                //asi se crea otro objeto pais con sus estados
                _context.Countries.Add(new Country
                {
                    CreateDate = DateTime.Now,
                    Name = "Argentina",
                    States = new List<State>()
                    {
                        new State
                        {
                            CreateDate = DateTime.Now,
                            Name = "Buenos Aires"
                        }
                    }
                });

            }

        }

        #endregion

    }
}
