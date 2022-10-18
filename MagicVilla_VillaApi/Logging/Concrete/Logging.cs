using MagicVilla_VillaApi.Logging.Abstract;

namespace MagicVilla_VillaApi.Logging.Concrete
{
    public class Logging<T> : ILogging<T>
    {
        public void Log(string message, string type)
        {
           
            if (type== "Info")
            {
                Console.WriteLine(type+": "+message);
                Console.BackgroundColor = ConsoleColor.Green;
            }
            if (type == "Error")
            {
                Console.WriteLine(type + ": " + message);
                Console.BackgroundColor = ConsoleColor.Red;
            }

        }
    }
}
