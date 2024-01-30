﻿using Buchnat.LaptopsApp.Interfaces;

namespace Buchnat.LaptopsApp.DAOMock2.BO
{
    public class Producer : IProducer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

}
