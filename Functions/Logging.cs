namespace ScriptWriterApp.Functions
{
    public class Logging
    {
        private readonly ILogger logger;
        private string? IP;
        private string? URI;

        public Logging(ILogger logger, string? URI = null ,string? IP = null)
        {
            this.logger = logger;
            this.IP = (IP) ?? "Unknown IP";
            this.URI = (URI != null) ? $":{URI}:" : "";
        }

        public void Info(string message)
        {
            logger.LogInformation($"{URI} [{IP}] {message}");
        }

        public void Trace(string message)
        {
            logger.LogTrace($"{URI} [{IP}] {message}");
        }

        public void Debug(string message)
        {
            logger.LogDebug($"{URI} [{IP}] {message}");
        }

        public void Critical(string message)
        {
            logger.LogCritical($"{URI} [{IP}] {message}");
        }
    }
}
