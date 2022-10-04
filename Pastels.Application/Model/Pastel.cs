namespace Pastels.Api.Resources
{
    public class Pastel
    {
        public string? Name { get; set; }
        public IList<string> Ingredients { get; set; } = new List<string>();
    }
}
