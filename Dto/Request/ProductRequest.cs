namespace WebStockManagement.Dto.Request;

public class ProductRequest
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int CategroyId { get; set; }
}
