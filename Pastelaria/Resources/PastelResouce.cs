namespace Pastelaria.Resources
{
    public class PastelResouce
    {
        public string? Name { get; set; }
        public string? Ingredients { get; set; }
        public decimal CurrentPrice { get; internal set; }
        public bool IsSweet { get; internal set; }
    }
}
