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
            if (filePath.EndsWith(".db"))
                LoadSql(filePath);
        }
        public void LoadSql(string dbPath)
        {
            dao = new DAOSQL.DAOSQL();
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
            if (laptop.Id == null)
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
            if (producer.Id == null)
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