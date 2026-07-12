internal class ProductService
{
    private static Product[] products = new Product[100];
    private static int productCount = 0;

    public static void AddProduct()
    {
        Product product = ReadProduct();

        products[productCount] = product;
        productCount++;

        Message.ShowSuccess("✅ Producto creado con éxito ✅");
    }

    public static void ListProduct()
    {
        if (IsCatalogEmpty())
            return;

        Menu.PrintHeader();

        for (int i = 0; i < productCount; i++)
        {
            Menu.PrintProduct(products[i]);
        }
    }

    public static void SearchProduct()
    {
        int index = FindProduct();

        if (index == -1)
        {
            Message.ShowError("❌ PRODUCTO NO ENCONTRADO ❌");
            return;
        }

        Menu.PrintHeader();
        Menu.PrintProduct(products[index]);
    }

    public static void UpdateStock()
    {
        int index = FindProduct();

        if (index == -1)
        {
            Message.ShowError("❌ PRODUCTO NO ENCONTRADO ❌");
            return;
        }

        products[index].StockInitial = ReadStockInitial();

        Message.ShowSuccess("✅ Stock actualizado correctamente ✅");
    }

    public static void SortByPrice()
    {
        BubbleSort((a, b) => a.Price.CompareTo(b.Price));

        Message.ShowSuccess("Catálogo ordenado por precio.");
        ListProduct();
    }

    public static void SortByName()
    {
        BubbleSort((a, b) =>
            string.Compare(a.Name, b.Name, StringComparison.OrdinalIgnoreCase));

        Message.ShowSuccess("Catálogo ordenado por nombre.");
        ListProduct();
    }

    public static void InsertProduct()
    {
        if (productCount >= products.Length)
        {
            Message.ShowWarning("No hay espacio para agregar más productos.");
            return;
        }

        int position;

        do
        {
            Console.Write($"Ingrese la posición (0 - {productCount}): ");
        }
        while (!int.TryParse(Console.ReadLine(), out position) ||
               position < 0 ||
               position > productCount);

        for (int i = productCount; i > position; i--)
        {
            products[i] = products[i - 1];
        }

        products[position] = ReadProduct();
        productCount++;

        Message.ShowSuccess("Producto insertado correctamente.");
    }

    public static void DeleteProductByCode()
    {
        if (IsCatalogEmpty())
            return;

        int index = FindProduct();

        if (index == -1)
        {
            Message.ShowWarning("Producto no encontrado.");
            return;
        }

        for (int i = index; i < productCount - 1; i++)
        {
            products[i] = products[i + 1];
        }

        products[productCount - 1] = null;
        productCount--;

        Message.ShowSuccess("Producto eliminado correctamente.");
    }

    // =======================
    // Métodos auxiliares
    // =======================

    private static Product ReadProduct()
    {
        return new Product(
            ReadProductCode(),
            ReadName(),
            ReadPrice(),
            ReadStockInitial());
    }

    private static int FindProduct()
    {
        string code = ReadSearchCode();
        return SearchProductByIndex(code);
    }

    private static string ReadProductCode()
    {
        while (true)
        {
            Console.Write("Código del producto: ");
            string code = Console.ReadLine()!;

            if (!ProductValidator.IsValidCodeProduct(code))
            {
                Message.ShowWarning("El código debe tener un formato válido.");
                continue;
            }

            if (ExistProductCode(code))
            {
                Message.ShowError("❌ El código ya existe ❌");
                continue;
            }

            return code;
        }
    }

    private static string ReadSearchCode()
    {
        Console.Write("Código del producto: ");
        return Console.ReadLine()!;
    }

    private static string ReadName()
    {
        while (true)
        {
            Console.Write("Nombre del producto: ");
            string name = Console.ReadLine()!;

            if (ProductValidator.IsValidName(name))
                return name;

            Message.ShowWarning("Nombre inválido.");
        }
    }

    private static double ReadPrice()
    {
        double price;

        while (true)
        {
            Console.Write("Precio: ");

            if (double.TryParse(Console.ReadLine(), out price) &&
                ProductValidator.IsValidPrice(price))
            {
                return price;
            }

            Message.ShowWarning("Precio inválido.");
        }
    }

    private static int ReadStockInitial()
    {
        int stock;

        while (true)
        {
            Console.Write("Stock: ");

            if (int.TryParse(Console.ReadLine(), out stock) &&
                ProductValidator.IsValidStock(stock))
            {
                return stock;
            }

            Message.ShowWarning("Stock inválido.");
        }
    }

    private static bool ExistProductCode(string code)
    {
        return SearchProductByIndex(code) != -1;
    }

    private static int SearchProductByIndex(string code)
    {
        for (int i = 0; i < productCount; i++)
        {
            if (products[i] != null &&
                products[i].ProductCode.Equals(code, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }

        return -1;
    }
    private static void SwapProducts(int first, int second)
    {
        Product temp = products[first];
        products[first] = products[second];
        products[second] = temp;
    }

    private static void BubbleSort(Comparison<Product> comparison)
    {
        for (int i = 0; i < productCount - 1; i++)
        {
            for (int j = 0; j < productCount - i - 1; j++)
            {
                if (comparison(products[j], products[j + 1]) > 0)
                {
                    SwapProducts(j, j + 1);
                }
            }
        }
    }

    private static bool IsCatalogEmpty()
    {
        if (productCount == 0)
        {
            Message.ShowWarning("No hay productos registrados.");
            return true;
        }

        return false;
    }
}