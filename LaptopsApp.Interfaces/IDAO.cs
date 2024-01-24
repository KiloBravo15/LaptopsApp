using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buchnat.LaptopsApp.Interfaces
{
    public interface IDAO
    {
        IEnumerable<IProducer> GetAllProducers();
        IEnumerable<ILaptop> GetAllLaptops();
        IProducer CreateNewProducer();
        ILaptop CreateNewLaptop();
    }
}
