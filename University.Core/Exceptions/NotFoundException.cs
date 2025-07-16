namespace University.Core.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() : base("The requested record was not found.")
        {}

        public NotFoundException(string message) : base(message)
        { }
    }
}
