//2.	(Investigue sobre la clase DateTime de C# y use sus funciones para solucionar el
// siguiente problema) Calcule los Acuerdos de Nivel de Servicio (SLA) para un sistema de
//  tickets de soporte.

public class Program2
{
    public static void Main(string[] args)
    {
        string detail;
        DateTime creation_date = ReadDate("Ingrese fecha de creación de ticket (yyyy-MM-dd): ");
        DateTime resolution_date = ReadDate("Ingrese fecha de resolución de ticket (yyyy-MM-dd): ");

        if(resolution_date < creation_date)
        {
            Console.WriteLine("Error: La fecha de resolución no puede ser anterior a la fecha de creación.");
            return;
        }

        double result = CountBusinessDays(creation_date, resolution_date, out detail);
        
        if(result <= 8){
            Console.WriteLine($"\nCumplido: Horas laborales: {detail}");
        }
        else
        {
            Console.WriteLine($"Incumplido: {result - 8} horas de más");
        }
    }

    public static DateTime ReadDate(string message)
    {
        DateTime date;
        while (true)
        {
            Console.WriteLine(message);

            if (DateTime.TryParse(Console.ReadLine(), out date))
            {
                return date;
            }
            else
            {
                Console.WriteLine("==================================================================");
                Console.WriteLine("Fecha inválida, ingrese una fecha válida en el formato yyyy-MM-dd.");
                Console.WriteLine("==================================================================\n");
            }
        }
    }

    public static double CountBusinessDays(DateTime start_date, DateTime end_date, out string detail)
{
    double total_hours = 0;
    detail = "";

    for (DateTime day = start_date.Date; day <= end_date.Date; day = day.AddDays(1))
    {
        if(day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
        {
            continue;
        }

        DateTime work_start = day.AddHours(9);
        DateTime work_end = day.AddHours(17);

        if(day == start_date.Date && start_date > work_start)
        {
            work_start = start_date;
        }

        if(day == end_date.Date && end_date < work_end)
        {
            work_end = end_date;
        }

        if(work_end > work_start)
        {
            double hours = (work_end - work_start).TotalHours;
            total_hours += hours;

            if(detail != "") 
                detail += " + ";

            detail += $"{hours}h el {day:dddd}";
        }
    }

    detail += $" = {total_hours}h";
    return  total_hours;
}
}  