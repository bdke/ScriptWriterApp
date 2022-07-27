namespace ScriptWriterApp.Functions
{
    public class Logging
    {
        private readonly ILogger logger;
        private string? IP;

        public Logging(ILogger logger, string? IP = null)
        {
            this.logger = logger;
            this.IP = IP;
        }

        public void Info(string message)
        {
            logger.LogInformation($"[{(IP)??"Unknown IP"}] {message}");
        }
    }
}
