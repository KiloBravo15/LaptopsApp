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
        IProducer CreateNewProducer(IProducer producer);
        ILaptop CreateNewLaptop(ILaptop laptop);
        void UpdateLaptop(ILaptop laptop);
        void UpdateProducer(IProducer producer);
        void RemoveLaptop(Guid id);
        void RemoveProducer(Guid id);
        ILaptop GetLaptop(Guid id);
        IProducer GetProducer(Guid id);
    }
}
