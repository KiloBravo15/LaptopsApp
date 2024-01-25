namespace Buchnat.LaptopsApp.Interfaces
{
    public interface IProducer
    {
        Guid Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }

    }
}
