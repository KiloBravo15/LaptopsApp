using Buchnat.LaptopsApp.Interfaces;
using System.Reflection;

namespace Buchnat.LaptopsApp.BLC
{
    public class BLC
    {
        private IDAO dao;

        public BLC(string libraryName)
        {
            Type? typeToCreate = null;

            Assembly assembly = Assembly.UnsafeLoadFrom(libraryName);
            // tu trzeba jeszcze sprawdzić niezbędne warunki
            foreach (Type type in assembly.GetTypes())
            {
                if ((type.IsAssignableTo(typeof(IDAO))))
                {
                    typeToCreate = type;
                    break;
                }
            }
            //trzeba sprawdzić czy obiekt ktory znalazlem nie jest rowny null
            dao = (IDAO)Activator.CreateInstance(typeToCreate, null);
        }

        public IEnumerable<IProducer> GetProducers()
        {
            return dao.GetAllProducers();
        }

        public IEnumerable<ILaptop> GetLaptops()
        {
            return dao.GetAllLaptops();
        }
    }
}