using Microsoft.SqlServer.Server;
using Microsoft.VisualBasic;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Nencer.Helpers
{
    public class ApiHelper
    {
        private static readonly Random random = new Random();

        public static string GenerateExamOrdinal(int num, int max)
        {
            // Pad with zeroes on the left
            string paddedNumber = num.ToString().PadLeft(max, '0');
            return DateTime.Now.ToString("yyyyMMdd") + paddedNumber; //2023101700001
        }

        public static string GetBarCode(int num, int max)
        {
            string paddedNumber = num.ToString().PadLeft(max, '0');
            return paddedNumber; //00001
        }

        public static int GetRandomNumber(int min, int max)
        {
            lock (random) // synchronize
            {
                return random.Next(min, max);
            }
        }

        public static DateTime? SafeToDate2(string? obj)
        {
            if (obj == null) return null;
            DateTime result;
            DateTime.TryParseExact(obj, "dd/MM/yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out result);
            return result;
        }

        public static string GenerateCheckinTakeNumber(int num, string key)
        {
            string paddedNumber = num.ToString().PadLeft(6, '0');
            return key + DateTime.Now.ToString("yyyyMMdd") + paddedNumber;
        }

    }
}
