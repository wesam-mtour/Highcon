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
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Highcon.Infra
{
    public class NLogger
    {
        private static NLogger instance = null;
        public ILog logger;
        private NLogger()
        {
            var layout = new PatternLayout
            {
                ConversionPattern = "%date{dd-MMM-yyyy HH:mm:ss} %-5level %method: %message%newline" +
                "%date{dd-MMM-yyyy HH:mm:ss} %-5level %method:----------------------------------------" +
                "--------------------" +
                "%newline%date{dd-MMM-yyyy HH:mm:ss} %-5level %method:--------------------------------" +
                "----------------------------%newline"
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

            this.logger = LogManager.GetLogger(typeof(NLogger));
        }

        public static NLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new NLogger();
            }
            return instance;            
        }
    }
}
