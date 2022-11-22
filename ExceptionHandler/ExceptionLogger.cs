using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionHandler
{
    public static class ExceptionLogger
    {
        private static readonly string filePath = "logs/exceptions.txt";

        public static void LogException(Exception exception)
        {
            if (!File.Exists(filePath))
            {
                using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
                {

                }
            }

            using (StreamWriter sw = new(filePath, true))
            {
                sw.WriteLine("[EXCEPTION DATE : " + DateTime.Now.ToString() + "]");
                sw.WriteLine(exception.ToString());
                sw.WriteLine("");
            }
        }
    }
}
