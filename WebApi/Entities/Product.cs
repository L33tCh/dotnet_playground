namespace WebApi.Entities;

public class Product
{
    public int id { get; set; }
    public string name { get; set; }
    public double price { get; set; }
    public bool sold { get; set; }
    public int priority { get; set; }
    public string description { get; set; }
}
