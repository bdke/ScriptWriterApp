namespace ScriptWriterApp.Functions
{
    public class Logging
    {
        private readonly ILogger logger;
        private string? IP;

        public Logging(ILogger logger, string? IP = null)
        {
            this.logger = logger;
            this.IP = (IP) ?? "Unknown IP";
        }

        public void Info(string message)
        {
            logger.LogInformation($"[{IP}] {message}");
        }

        public void Debug(string message)
        {
            logger.LogDebug($"[{IP}] {message}");
        }

        public void Critical(string message)
        {
            logger.LogCritical($"[{IP}] {message}");
        }
    }
}
