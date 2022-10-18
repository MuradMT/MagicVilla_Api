namespace MagicVilla_VillaApi.Logging.Abstract
{
    public interface ILogging<T>
    {
        void Log(string message,string type);   
    }
}
