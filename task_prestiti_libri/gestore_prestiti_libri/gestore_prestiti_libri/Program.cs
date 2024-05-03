using gestore_prestiti_libri.Utilities;

namespace gestore_prestiti_libri
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Config.getIstanza().GetConnectionString());
        }
    }
}
