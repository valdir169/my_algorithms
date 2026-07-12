internal static class Demo
{
    public static void DemoValueVsReference()
    {
        Message.ShowError("=== PASO POR VALOR ===");

        double price = 100.00;

        Message.ShowInfo($"Antes del método: {price}");

        ChangePrice(price);

        Message.ShowSuccess($"Después del método: {price}");

        Console.WriteLine();

        Message.ShowError("=== PASO POR REFERENCIA (ARREGLO) ===");

        double[] prices = { 100.00, 200.00, 300.00 };

        Message.ShowInfo($"Antes del método: {prices[1]}");

        ChangeArrayPrice(prices);

        Message.ShowSuccess($"Después del método: {prices[1]}");
    }

    private static void ChangePrice(double price)
    {
        price = 999.99;

        Message.ShowInfo($"Dentro del método: {price}");
    }

    private static void ChangeArrayPrice(double[] prices)
    {
        prices[1] = 999.99;

        Message.ShowInfo($"Dentro del método: {prices[1]}");
    }
}