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

            IBusines business = new Business();
            business.SignUp(userName, password);
        }
    }

    public class Business : IBusines
    {
        public void SignUp(string userName, string password)
        {
            // validation
            var dataAccess = new DataAccess();
            dataAccess.Store(userName, password);
        }
    }

    public class DataAccess : IDataAccess
    {
        public void Store(string userName, string password)
        {
            // write the data for the db
        }
    }

    public interface IBusines
    {
        void SignUp(string userName, string password);
    }

    public interface IDataAccess
    {
        void Store(string userName, string password);
    }
}