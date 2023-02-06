namespace DependencyInjectionDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IDataAccess dal = new DataAccess();
            IBusiness business = new Business();
            business.DataAccess = dal;
            var userInterface = new UserInterface();
            userInterface.Business = business;
            userInterface.GetData();
        }
    }

    public class UserInterface
    {
        private IBusiness _business;
        public IBusiness Business
        {
            set { _business = value; }
            get 
            {
                if (_business == null)
                {
                    throw new Exception("dataAccess is not initialized");
                }
                return _business;
            }
        }
        public void GetData()
        {
            Console.Write("Enter Username:");
            var userName = Console.ReadLine();

            Console.Write("Enter Password:");
            var password = Console.ReadLine();

            _business.SignUp(userName, password);
        }
    }

    public class Business : IBusiness
    {
        private IDataAccess? _dataAccess;
        public IDataAccess DataAccess
        {
            set { _dataAccess = value; }
            get
            {
                if(_dataAccess == null)
                {
                    throw new Exception("dataAccess is not initialized");
                }
                return _dataAccess;
            }
        }
        public void SignUp(string userName, string password)
        {
            // validation
            _dataAccess?.Store(userName, password);
        }
    }

    public class BusinessV2 : IBusiness
    {
        private IDataAccess? _dataAccess;
        public IDataAccess DataAccess
        {
            set { _dataAccess = value; }
            get
            {
                if (_dataAccess == null)
                {
                    throw new Exception("dataAccess is not initialized");
                }
                return _dataAccess;
            }
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
        public IDataAccess DataAccess { get; set; }
        void SignUp(string userName, string password);
    }

    public interface IDataAccess
    {
        public 
        void Store(string userName, string password);
    }
}