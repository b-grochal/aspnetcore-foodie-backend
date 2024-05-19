namespace Foodie.Common.Application.Requests.Commands.Abstractions
{
    public interface IAuditableCommand
    {
        public string User { get; set; }
    }
}
