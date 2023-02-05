namespace DependencyInjectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
        }
    }

    public class UserInterface
    {
        public void GetData()
        {
            Console.Write("Enter Username:");
            var userName = Console.ReadLine();

            Console.Write("Enter Password:");
            var password = Console.ReadLine();
             
            IBusiness business = new BusinessV2();
            business.SignUp(userName, password);

        }
    }

    public class Business : IBusiness
    {
        private readonly IDataAccess _dataAccess;
        public Business(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }
        public void SignUp(string userName, string password)
        {
            // validation
            _dataAccess.Store(userName, password);
        }
    }

    public class BusinessV2 : IBusiness
    {
        public void SignUp(string userName, string password)
        {
            
        }

        public void SpecialSignUp(string userName, string password)
        {
            Console.WriteLine($"Successful for {userName}");
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
        void SignUp(string userName, string password);
    }

    public interface IDataAccess
    {
        void Store(string userName, string password);
    }
}