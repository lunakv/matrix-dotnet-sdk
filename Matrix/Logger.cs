using Microsoft.Extensions.Logging;

namespace Matrix
{
    public static class Logger
    {
        static ILoggerFactory factory;

        /// <summary>
        /// Needs to be externally set, one typical use case would be it's set during Startup configuration
        /// </summary>
		public static ILoggerFactory Factory {
			get { return factory ?? new LoggerFactory(); }
            set { factory = value; }
        }
    }
}