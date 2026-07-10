internal class Menu
{
    public static void Run()
    {

        Console.WriteLine("Welcome to TechShop!");
        while (true)
        {
            Console.Clear();
            DisplayMenu();
            SelectOption();
        }
    }

    private static void DisplayMenu()
    {
        Message.ShowInfo("1. Registrar un producto (validando datos)");
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
                Console.WriteLine("Registrar un producto ");
                break;
            case "2":
                Console.WriteLine("Mostrar el catálogo completo");
                break;
            case "3":
                Console.WriteLine("Buscar un producto por código");
                break;
            case "4":
                Console.WriteLine("Actualizar el stock (sumar o restar)");
                break;
            case "5":
                Console.WriteLine("Ordenar el catálogo por precio (burbuja)");
                break;
            case "6":
                Console.WriteLine("Insertar un producto en una posición específica");
                break;
            case "7":
                Console.WriteLine("Eliminar un producto por código");
                break;
            case "8":
                Console.WriteLine("Ordenar el catálogo por nombre (alfabético)");
                break;
            case "9":
                Console.WriteLine("Demostración: parámetro por valor vs. por referencia");
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

}