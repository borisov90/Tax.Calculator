using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;
using Tax.Calculator.Helpers.Common;

namespace Tax.Calculator.Helpers
{
    public class Logger
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public Logger()
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
        }

        public void Info(string message)
        {
            log.Info(message);
        }

        public void Warn(string message)
        {
            log.Warn(message);
        }

        public void Error(string message)
        {
            log.Error(message);
        }

        public void EnterSalaryMessage()
        {
            log.Debug(GlobalConstants.ENTER_SALARY_MESSAGE);
        }

        public void ExitMessage()
        {
            log.Debug(GlobalConstants.EXIT_MESSAGE);
        }

        public void NoTaxMessage(decimal grossSalary)
        {
            log.Warn($"No taxes would be paid since this is below the taxation threshold and the net income is also {grossSalary} IDR");
        }

        public void InvalidDecimalError()
        {
            log.Error(GlobalConstants.INVALID_DECIMAL_ERROR_MESSAGE);

            throw new Exception(GlobalConstants.INVALID_DECIMAL_ERROR_MESSAGE);
        }
    }
}
