using System;

namespace Microsoft.Extensions.Logging.File
{
    public class FileLoggerOptions
    {
        public Func<string, LogLevel, bool> Filter { get; set; }

        public string Path { get; set; }
    }
}