namespace EGNValidator.Service.Validators
{
    public class DtoValidationError
    {
        public string Property { get; set; }

        public string StringValue { get; set; }

        public object Value { get; set; }

        public string Message { get; set; }
    }
}