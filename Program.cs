namespace DependencyInjectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataAccess dal = new DataAccess();
            IBusiness business = new Business();
            business.SetDataAccess(dal);
            var userInterface = new UserInterface();
            userInterface.SetBusiness(business);
            userInterface.GetData();
        }
    }

    public class UserInterface
    {
        public IBusiness? Business { get; set; }
        public void SetBusiness(IBusiness business)
        {
            Business = business;
        }
        
        public void GetData()
        {
            Console.Write("Enter Username:");
            var userName = Console.ReadLine();

            Console.Write("Enter Password:");
            var password = Console.ReadLine();

            Business.SignUp(userName, password);
        }
    }

    public class Business : IBusiness
    {
        public IDataAccess? DataAccess { get; set; }
        public void SetDataAccess(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public void SignUp(string userName, string password)
        {
            // validation
            DataAccess?.Store(userName, password);
        }
    }

    public class BusinessV2 : IBusiness
    {
        public IDataAccess? DataAccess { get; set; }

        public void SetDataAccess(IDataAccess dataAccess)
        {
            DataAccess = dataAccess;
        }

        public void SignUp(string userName, string password)
        {
            
        }
    }

    public class DataAccess : IDataAccess
    {
        public void Store(string userName, string password)
        {
            // write the data for the db
        }
    }

    public interface IBusiness
    {
        void SetDataAccess(IDataAccess dataAccess);
        void SignUp(string userName, string password);
    }

    public interface IDataAccess
    {
        void Store(string userName, string password);
    }
}