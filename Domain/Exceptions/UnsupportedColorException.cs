namespace Domain.Exceptions;

public class UnsupportedColorException : Exception
{
    public UnsupportedColorException(int code) : base($"Color \"{code}\" is unsupported")
    {
    }
}