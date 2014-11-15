namespace TeamTaskboard.Web.Infrastructure.Sanitize
{
    public interface ISanitizer
    {
        string Sanitize(string html);
    }
}
