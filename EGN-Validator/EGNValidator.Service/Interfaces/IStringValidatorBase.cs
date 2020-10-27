namespace EGNValidator.Service.Interfaces
{
    /// <summary>
    /// Validate some data.
    /// </summary>
    public interface IStringValidatorBase
    {
        bool Validate(string data);
    }
}
