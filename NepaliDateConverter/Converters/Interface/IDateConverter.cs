namespace DateConverter.Converters.Interface;

 interface IDateConverter
{
 /// <summary>
 /// Getter and Setter for Year
 /// </summary>
 /// <value>2017</value>
 int Year { get; }
 /// <summary>
 /// Getter and setter for Month
 /// </summary>
 /// <value>11</value>
int Month { get; }
 
 /// <summary>
 /// Getter and setter for Day
 /// </summary>
 /// <value>32</value>
 int Day { get; }
 
 /// <summary>
 /// Getter and setter for week day name
 /// </summary>
 /// <value>Sunday</value>
 string WeekNameDay { get; }
 
 /// <summary>
 /// Getter and setter for Month name
 /// </summary>
 /// <value>January/Baishakh</value>
 string MonthName { get; }
 
 /// <summary>
 /// Getter and setter for Week Day
 /// </summary>
 /// <value>1</value>
 int WeekDay { get; }
}