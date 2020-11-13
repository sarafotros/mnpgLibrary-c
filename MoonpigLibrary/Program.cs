using System.Globalization;
using System.Threading;

namespace MoonpigLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            CultureInfo cultureInfo = new CultureInfo("en-GB"); 
            Thread.CurrentThread.CurrentCulture = cultureInfo;
            Reception reception = new Reception();
            reception.Open();
        }
    }
}