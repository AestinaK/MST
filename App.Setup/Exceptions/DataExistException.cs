namespace App.Setup.Exceptions;

public class DataExistException : Exception
{
    public DataExistException(string msg ="Data already exists!") : base(msg){}
}