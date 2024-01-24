using Buchnat.LaptopsApp.BLC;
using Buchnat.LaptopsApp.Interfaces;

namespace Buchnat.LaptopsApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string libraryName = System.Configuration.ConfigurationManager.AppSettings["DAOLibraryName"];
            BLC.BLC blc = new BLC.BLC(libraryName);

            foreach (IProducer p in blc.GetProducers())
            {
                Console.WriteLine($"{p.Id} {p.Name}");
            }
            Console.WriteLine("---------------------");

            foreach(ILaptop l in blc.GetLaptops())
            {
                Console.WriteLine( $"{l.Id}: {l.Producer.Name} {l.Model} {l.Processor} {l.RAM} {l.StorageInGB}");
            }
        }
    }
}
