namespace FinalExam.BL.Exceptions;

public class BaseException : Exception
{
    public BaseException(string message) : base(message) { }

    public BaseException() : base("Something went wrong!") { }
}
