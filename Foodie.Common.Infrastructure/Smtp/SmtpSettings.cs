namespace Foodie.Common.Infrastructure.Smtp
{
    public class SmtpSettings
    {
        public string DisplayName { get; set; }
        public string From { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool UseSsl { get; set; }
        public bool UseStartTls { get; set; }
    }
}
