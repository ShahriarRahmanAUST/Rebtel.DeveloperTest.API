namespace Rebtel.DeveloperTest.API.Logger
{
    public interface ILogMessage
    {
        void LogInof(string message);
        void LogError(string message);


    }
    public class ConsoleLogger : ILogMessage
    {
        public void LogError(string message)
        {
            Console.WriteLine($"Time : {DateTime.Now} : [ERROR] {message}");
        }

        public void LogInof(string message)
        {
            Console.WriteLine($"Time : {DateTime.Now} : [INFO] {message}");
        }
    }
}
