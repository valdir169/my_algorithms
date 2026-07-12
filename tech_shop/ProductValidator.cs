using System.Text.RegularExpressions;

internal static class ProductValidator
{
    public static bool IsValidPrice(double price)
    {
        return price > 0;
    }

    public static bool IsValidCodeProduct(string product_code)
    {
        return Regex.IsMatch(product_code, @"^\d{3}$");
    }

    public static bool IsValidName(string name)
    {
        return Regex.IsMatch(name, @"^[a-zA-ZáéíóúÁÉÍÓÚñÑ0-9 ]+$");
    }

    public static bool IsValidStock(int stock_initial)
    {
        return stock_initial >= 0;
    }
}