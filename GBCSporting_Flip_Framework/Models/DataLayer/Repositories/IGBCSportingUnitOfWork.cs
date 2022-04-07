namespace GBCSporting_Flip_Framework.Models.DataLayer.Repositories
{
    public interface IGBCSportingUnitOfWork
    {
        Repository<Customer> Customers { get; }
        Repository<Product> Products { get; }
        Repository<Registration> Registrations { get; }

    }
}
