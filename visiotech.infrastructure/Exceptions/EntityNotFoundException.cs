namespace visiotech.infrastructure.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string mensaje) : base(mensaje)
        { }
    }
}
