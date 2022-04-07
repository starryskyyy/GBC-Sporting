namespace GBCSporting_Flip_Framework.Models.DataLayer.Repositories
{
    public class GBCSportingUnitOfWork
    {
        private GBCSportingContext context { get; set; }
        public GBCSportingUnitOfWork(GBCSportingContext ctx) => context = ctx;

        private Repository<Product> productData;
        public Repository<Product> Products
        {
            get
            {
                if (productData == null)
                    productData = new Repository<Product>(context);
                return productData;
            }
        }

        private Repository<Customer> customerData;
        public Repository<Customer> Customers
        {
            get
            {
                if (customerData == null)
                    customerData = new Repository<Customer>(context);
                return customerData;
            }
        }

        private Repository<Registration> registrationData;
        public Repository<Registration> Registrations
        {
            get
            {
                if (registrationData == null)
                    registrationData = new Repository<Registration>(context);
                return registrationData;
            }
        }
    }
}
