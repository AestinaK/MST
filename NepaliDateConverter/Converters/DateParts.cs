namespace DateConverter.Converters;

public class DateParts
{
    public int Year { get; set; }
    public int  Month { get; set; }
    public int Day { get; set; }

    public DateParts(int Year, int month, int day)
    {
        Year = Year;
        Month = Month;
        Day = Day;
    }
        
}