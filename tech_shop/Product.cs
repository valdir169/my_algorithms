internal class Product
{
    public string ProductCode { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int StockInitial { get; set; }

    public Product(string product_code, string name, double price, int stock_initial)
    {
        ProductCode = product_code;
        Name = name;
        Price = price;
        StockInitial = stock_initial;
    }
}