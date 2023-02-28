using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Core;
using log4net.Layout;
using Highcon.pom;
using Highcon.webdriverinitializer;
using NUnit.Framework;
using OpenQA.Selenium;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace Highcon.Infra
{
    internal class NLogger
    {
        // Private instance of the logger to implement the singleton pattern
        private static NLogger instance = null;
        // ILog object that will be used for logging messages
        public static ILog logger;
        // Counter to keep track of the number of steps taken in the test
        private static int counter = 1;

        // Private constructor to prevent instantiation from outside the class
        private NLogger()
        {
            var layout = new PatternLayout
            {
                ConversionPattern = "%date{dd-MMM-yyyy HH:mm:ss} %message%newline"
            };
            layout.ActivateOptions();

            var consoleAppender = new ConsoleAppender()
            {
                Name = "ConsoleAppender",
                Layout = layout,
                Threshold = Level.All
            };
            consoleAppender.ActivateOptions();
            BasicConfigurator.Configure(consoleAppender);

            logger = LogManager.GetLogger(typeof(NLogger));
        }

        // GetInstance function to implement the singleton pattern
        public static NLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new NLogger();
            }
            return instance;
        }

        // STEP function for logging a step in the test with the calling method and step number
        public static void STEP(string message)
        {
            instance = GetInstance();
            var stackTrace = new StackTrace();
            var callingMethod = stackTrace.GetFrame(1).GetMethod().Name;
            logger.Info($"STEP {callingMethod}: {counter}" + ". " + $"{message}\r\n" +
                $"\t\t\t\t\t STEP {callingMethod}: ------------------------------------------------------------\r\n" +
                $"\t\t\t\t\t STEP {callingMethod}: ------------------------------------------------------------");
        counter++;
        }

        // INFO function for logging a message with the calling method
        public static void INFO(string message)
        {
            instance = GetInstance();
            var stackTrace = new StackTrace();
            var callingMethod = stackTrace.GetFrame(1).GetMethod().Name;
            logger.Info($"INFO {callingMethod}: {message}\r\n" +
                $"\t\t\t\t\t INFO {callingMethod}: ------------------------------------------------------------\r\n" +
                $"\t\t\t\t\t INFO {callingMethod}: ------------------------------------------------------------");
        }
    }
}
