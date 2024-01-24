using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LaptopsApp.Core.Models;

namespace LaptopsApp.Data.Repositories
{
    private readonly List<Laptop> _laptops = new List<Laptop>();

    public void AddLaptop(Laptop laptop)
    {
        _laptops.Add(laptop);
    }

    public IEnumerable<Laptop> GetAllLaptops()
    {
        return _laptops;
    }
    // Metody aktualizacji i usuwania laptopów
}
