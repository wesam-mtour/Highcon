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
using System.Reflection;

namespace Highcon.Infra
{
    internal class TestLogger
    {
        // Private instance of the logger to implement the singleton pattern
        private static TestLogger instance = null;
        // ILog object that will be used for logging messages
        public static ILog logger;
        // Counter to keep track of the number of steps taken in the test
        private static int counter = 1;

        // Private constructor to prevent instantiation from outside the class
        private TestLogger()
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

            logger = LogManager.GetLogger(typeof(TestLogger));
        }

        // GetInstance function to implement the singleton pattern
        public static TestLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new TestLogger();
            }
            return instance;
        }

        // STEP function for logging a step in the test with the calling method and step number
        public static void STEP(string message)
        {
            instance = GetInstance();
            var stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            System.Reflection.MethodBase callingMethod = stackFrame.GetMethod();
            string className = callingMethod.DeclaringType.Name;
            string methodName = callingMethod.Name;

            logger.Info($"STEP {className}.{methodName}: {counter}" + ". " + $"{message}\r\n" +
                $"\t\t\t\t\t STEP {className}.{methodName}: ------------------------------------------------------------\r\n" +
                $"\t\t\t\t\t STEP {className}.{methodName}: ------------------------------------------------------------");
        counter++;
        }

        // INFO function for logging a message with the calling method
        public static void INFO(string message)
        {
            instance = GetInstance();
            var stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            System.Reflection.MethodBase callingMethod = stackFrame.GetMethod();
            string className = callingMethod.DeclaringType.Name;
            string methodName = callingMethod.Name;

            logger.Info($"INFO {className}.{methodName}: {message}\r\n" +
                $"\t\t\t\t\t INFO {className}.{methodName}: ------------------------------------------------------------\r\n" +
                $"\t\t\t\t\t INFO {className}.{methodName}: ------------------------------------------------------------");
        }
        public static void ERROR(string message)
        {
            instance = GetInstance();
            var stackTrace = new StackTrace();
            StackFrame stackFrame = stackTrace.GetFrame(1);
            System.Reflection.MethodBase callingMethod = stackFrame.GetMethod();
            string className = callingMethod.DeclaringType.Name;
            string methodName = callingMethod.Name;

            logger.Error($"ERROR {className}.{methodName}: {message}\r\n" +
                $"\t\t\t\t\t ERROR {className}.{methodName}: ------------------------------------------------------------\r\n" +
                $"\t\t\t\t\t ERROR {className}.{methodName}: ------------------------------------------------------------");
        }
    }
}
