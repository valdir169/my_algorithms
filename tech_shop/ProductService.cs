using System.Collections.ObjectModel;

internal class ProductService
{
    private static Product[] products = new Product[100];
    private static int product_count = 0;

    public static void AddProduct()
    {
        string code = ReadProductCode();
        string name = ReadName();
        double price = ReadPrice();
        int stock = ReadStockInitial();

        Product product = new Product(code, name, price, stock);
        products[product_count] = product;
        product_count++;

        Message.ShowSuccess("!Producto creado con éxito!");
    }

    public static void ListProduct()
    {
        if (product_count == 0)
        {
            Message.ShowInfo("No hay productos registrados.");
            return;
        }

        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine($"{"Codigo",-10} {"Nombre",-20} {"Precio",10} {"Stock",8}");
        Console.WriteLine("---------------------------------------------------------------");

        for (int i = 0; i < product_count; i++)
        {
            Console.WriteLine(
                $"{products[i].ProductCode,-10} " +
                $"{products[i].Name,-20} " +
                $"{products[i].Price,10:F2} " +
                $"{products[i].StockInitial,8}");
        }
    }

    private static string ReadProductCode()
    {
        while (true)
        {
            Console.Write("Codigo del producto: ");
            string code = Console.ReadLine()!;

            if (!ProductValidator.IsValidCodeProduct(code))
            {
                Message.ShowWarning("El código debe ser en formato númerico (XXX).");
                continue;
            }

            if (ProductService.ExistProductCode(code))
            {
                Message.ShowWarning("¡El código ya existe!");
                continue;
            }
        
        return code;
        }
    }

    private static string ReadName()
    {
        while (true)
        {
            Console.Write("Nombre de producto: ");
            string name = Console.ReadLine()!;

            if (ProductValidator.IsValidName(name))
            {
                return name;
            }
        }
    }

    private static double ReadPrice()
    {
        double price;

        do
        {
            Console.Write("Precio: ");

            if (double.TryParse(Console.ReadLine(), out price) &&
                ProductValidator.IsValidPrice(price))
            {
                return price;
            }

            Message.ShowWarning("Precio inválido.");
        }
        while (true);
    }

    private static int ReadStockInitial()
    {
        int stock;

        do
        {
            Console.Write("Stock: ");

            if (int.TryParse(Console.ReadLine(), out stock) &&
                ProductValidator.IsValidStock(stock))
            {
                return stock;
            }

            Message.ShowWarning("Stock inválido.");
        }
        while (true);
    }

    private static bool ExistProductCode(string code)
    {
        for (int i = 0; i < product_count; i++ )
        {
            if(products[i].ProductCode.Equals(code, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

}