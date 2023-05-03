using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework.Models
{
    /// <summary>
    /// This class provides logging functionality to the application. It can log messages to both console and a log file.
    /// </summary>
    public class Logger
    {
        private static readonly string _logFilePath = "D:\\4th sem\\ASC\\MandatoryAssignment\\GameFramework\\log.txt";

        /// <summary>
        /// Logs the specified message to both console and a log file.
        /// </summary>
        /// <param name="message">The message to be logged.</param>
        public static void Log(string message)
        {

            Console.WriteLine(message); 

            using (StreamWriter writer = new StreamWriter(_logFilePath, true) { AutoFlush = true } ) 
            {
                writer.WriteLine($"Logged At - {DateTime.Now}: {message}");
            }
        }

    }
}
