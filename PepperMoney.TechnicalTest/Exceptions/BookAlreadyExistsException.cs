namespace PepperMoney.TechnicalTest.Exceptions
{
    public class BookAlreadyExistsException : Exception
    {
        public BookAlreadyExistsException(string message) : base(message)
        {
        }
    }
}
