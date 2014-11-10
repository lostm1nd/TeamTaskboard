namespace TeamTaskboard.Web.Infrastructure.Json
{
    using Newtonsoft.Json.Serialization;

    public class LowercaseContractResolver : DefaultContractResolver
    {
        protected override string ResolvePropertyName(string propertyName)
        {
            return propertyName.ToLower();
        }
    }
}
