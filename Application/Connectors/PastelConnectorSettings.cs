namespace Application.Connectors
{
    public class PastelConnectorSettings
    {
        public string BaseUrl { get; set; }

        public PastelConnectorSettings(string baseUrl)
        {
            BaseUrl = baseUrl;
        }
    }
}
