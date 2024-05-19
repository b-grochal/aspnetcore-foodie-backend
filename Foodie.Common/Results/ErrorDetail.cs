namespace Foodie.Common.Results
{
    public class ErrorDetail
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public ErrorDetail(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
