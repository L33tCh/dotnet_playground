namespace WebApi.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public bool Sold { get; set; }
    public int Priority { get; set; }
    public string Description { get; set; }
}
