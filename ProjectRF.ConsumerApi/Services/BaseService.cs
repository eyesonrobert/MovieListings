namespace ProjectRF.ConsumerApi.Services
{
    public abstract class BaseService
    {
        public IDataProvider DataProvider { get; set; }

        public BaseService() // our constructor - name name is the same as the case
        {
            this.DataProvider = new SqlDataProvider("Data Source=(local); Initial Catalog=MediaBook; Integrated Security=SSPI");
        }
    }
}