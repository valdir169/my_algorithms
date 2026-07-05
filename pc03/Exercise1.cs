using System.Text.RegularExpressions;

public class Program1
{
    public static void Main(string[] args)
    {
        Console.WriteLine("===============================================");
        Console.WriteLine("========VALIDAR COMPROBANTE ELECTRONICO========");
        Console.WriteLine("===============================================\n");
        Console.WriteLine("Ingrese el numero de comprabante electronico: ");
        string receipt_number = Console.ReadLine();
       
        bool result =  ValidateElectronicReceipt(receipt_number);
        
        Console.WriteLine(result);    
    }
       

    public static bool ValidateElectronicReceipt(string number)
    {
        if(Regex.IsMatch(number, @"^[BF]\d{3}-\d{8}$"))
        {
            return true;
        } else
        {
            Console.WriteLine("======Formato incorrecto======");
        }
        return false;
    }
}  