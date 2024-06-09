namespace Foodie.Common.Application.Requests.Commands.Interfaces
{
    public interface IAuditableCommand
    {
        public int ApplicationUserId { get; set; }

        public string ApplicationUserEmail { get; set; }
    }
}
