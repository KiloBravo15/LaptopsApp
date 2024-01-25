﻿using Buchnat.LaptopsApp.BLC;
using Buchnat.LaptopsApp.Interfaces;
using LaptopsApp.Web.Models;

namespace LaptopsApp.Web.Services
{
    public class ProducerService
    {
        private readonly BLC _blc;

        public ProducerService(BLC blc, string dataSource)
        {
            _blc = blc;
            _blc.LoadDatasource(dataSource);
        }

        public IEnumerable<Producer> GetAllProducers()
        {
            return _blc.GetProducers().Select(p => ConvertProducerToModel(p));
        }

        public Producer GetProducerById(Guid id)
        {
            return ConvertProducerToModel(_blc.GetProducer(id));
        }

        public void RemoveProducer(Guid id)
        {
            _blc.RemoveProducer(id);
        }

        public void CreateOrUpdateProducer(Producer producer)
        {
            var producerInterface = ConvertToInterface(producer);
            _blc.CreateOrUpdateProducer(producerInterface);
        }

        public static Producer? ConvertProducerToModel(IProducer producer)
        {
            return producer == null ? null : new Producer
            {
                Id = producer.Id,
                Name = producer.Name,
                Description = producer.Description
            };
        }

        private static IProducer ConvertToInterface(Producer producer)
        {
            return producer == null ? null : new Producer
            {
                Id = producer.Id,
                Name = producer.Name,
                Description = producer.Description
            };
        }
    }

}
