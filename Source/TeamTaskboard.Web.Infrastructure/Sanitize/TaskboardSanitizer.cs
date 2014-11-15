namespace TeamTaskboard.Web.Infrastructure.Sanitize
{
    using Html;

    public class TaskboardSanitizer : ISanitizer
    {
        public string Sanitize(string html)
        {
            var sanitizer = new HtmlSanitizer();
            var sanitizedHtml = sanitizer.Sanitize(html);

            return sanitizedHtml;
        }
    }
}
