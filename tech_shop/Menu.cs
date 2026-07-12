internal class Menu
{
    public static void Run()
    {
        while (true)
        {
            Console.Clear();
            DisplayMenu();
            SelectOption();
        }
    }

    private static void DisplayMenu()
    {
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine("|                          TECH SHOP                          |");
        Console.WriteLine("---------------------------------------------------------------\n");


        Message.ShowInfo("1. Registrar un producto.");
        Message.ShowInfo("2. Mostrar el catálogo completo");
        Message.ShowInfo("3. Buscar un producto por código");
        Message.ShowInfo("4. Actualizar el stock (sumar o restar)");
        Message.ShowInfo("5. Ordenar el catálogo por precio (burbuja)");
        Message.ShowInfo("6. Insertar un producto en una posición específica");
        Message.ShowInfo("7. Eliminar un producto por código");
        Message.ShowInfo("8. Ordenar el catálogo por nombre (alfabético)");
        Message.ShowInfo("9. Demostración: parámetro por valor vs. por referencia");
        Message.ShowInfo("0. Salir del programa");

        Console.Write("\nSeleccione una opción: ");
    }

    private static void SelectOption()
    {

        string option = Console.ReadLine();
        Console.Clear();

        switch (option)
        {
            case "1":
                ProductService.AddProduct();
                break;
            case "2":
                ProductService.ListProduct();
                break;
            case "3":
                ProductService.SearchProduct();
                break;
            case "4":
                ProductService.UpdateStock();
                break;
            case "5":
                ProductService.SortByPrice();
                break;
            case "6":
                ProductService.InsertProduct();
                break;
            case "7":
                ProductService.DeleteProductByCode();
                break;
            case "8":
                ProductService.SortByName();
                break;
            case "9":
                Demo.DemoValueVsReference();
                break;
            case "0":
                Exit();
                break;
            default:
                Message.ShowError("Opción inválida. Por favor, seleccione una opción válida.");
                break;
        }
        Pause();
    }

    private static void Exit()
    {
        Message.ShowWarning("Gracias por usar TechShop. ¡Hasta luego!");
        System.Environment.Exit(0);
    }

    private static void Pause()
    {
        Console.WriteLine();
        Console.Write("Presione cualquier tecla para volver al menú...");
        Console.ReadKey(true);
    }

    public static void PrintHeader()
    {
        Console.WriteLine("---------------------------------------------------------------");
        Console.WriteLine($"{"Codigo",-10} {"Nombre",-20} {"Precio",10} {"Stock",8}");
        Console.WriteLine("---------------------------------------------------------------");
    }

    public static void PrintProduct(Product product)
    {
        Console.WriteLine(
            $"{product.ProductCode,-10} " +
            $"{product.Name,-20} " +
            $"{product.Price,10:F2} " +
            $"{product.StockInitial,8}");
    }
}