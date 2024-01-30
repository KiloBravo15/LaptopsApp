using Buchnat.LaptopsApp.DAOSQL;
using Buchnat.LaptopsApp.Interfaces;
using System.Reflection;

namespace Buchnat.LaptopsApp.BLC
{
    public class BLC
    {
        private IDAO dao;

        public BLC(string filePath)
        {
            LoadDatasource(filePath);
        }

        public void LoadDatasource(string filePath)
        {
            if (filePath.EndsWith(".dll"))
                LoadLibrary(filePath);
            else if (filePath.EndsWith(".db"))
                LoadSql(filePath);
        }
        public void LoadSql(string dbPath)
        {
            dao = new DAOSQL.DAOSQL();
        }
        public void LoadLibrary(string dllPath)
        {
            var typeToCreate = FindDAOType(dllPath);

            if (typeToCreate != null)
            {
                dao = CreateDAOInstance(typeToCreate);
            }
            else
            {
                throw new InvalidOperationException("No compatible IDAO type found in assembly.");
            }
        }

        private Type FindDAOType(string dllPath)
        {
            try
            {
                var assembly = Assembly.UnsafeLoadFrom(dllPath);
                foreach (var type in assembly.GetTypes())
                {
                    if (typeof(IDAO).IsAssignableFrom(type))
                    {
                        return type;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to load assembly or find IDAO: " + ex.Message);
                throw;
            }

            return null;
        }

        private IDAO CreateDAOInstance(Type daoType)
        {
            try
            {
                return (IDAO)Activator.CreateInstance(daoType);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create instance of IDAO: {daoType.Name}\n{ex.Message}");
                throw;
            }
        }

        public IEnumerable<IProducer> GetProducers()
        {
            return dao.GetAllProducers();
        }

        public IEnumerable<ILaptop> GetLaptops()
        {
            return dao.GetAllLaptops();
        }
        public ILaptop GetLaptopById(Guid id)
        {
            return dao.GetLaptop(id);
        }
        public IProducer GetProducer(Guid id)
        {
            return dao.GetProducer(id);
        }

        public IProducer GetProducer(string name)
        {
            return dao.GetProducer(name);
        }
        public void RemoveLaptop(Guid id)
        {
            dao.RemoveLaptop(id);
        }
        public void RemoveProducer(Guid id)
        {
            dao.RemoveProducer(id);
        }
        public void CreateOrUpdateLaptop(ILaptop laptop)
        {
            if (laptop.Id == Guid.Empty)
            {
                laptop.Id = Guid.NewGuid();
                dao.CreateNewLaptop(laptop);
            }
            else
            {
                dao.UpdateLaptop(laptop);
            }
        }

        public void CreateOrUpdateProducer(IProducer producer)
        {
            if (producer.Id == Guid.Empty)
            {
                producer.Id = Guid.NewGuid();
                dao.CreateNewProducer(producer);
            }
            else
            {
                dao.UpdateProducer(producer);
            }
        }
    }
}