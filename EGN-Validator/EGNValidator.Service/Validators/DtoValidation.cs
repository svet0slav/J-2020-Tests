namespace EGNValidator.Service.Validators
{
    using System.Collections.Generic;
    using System.Text;

    /// <summary>
    /// Base class for Dto validation errors.
    /// </summary>
    public class DtoValidation
    {
        public List<DtoValidationError> Errors { get; private set; }

        public DtoValidation()
        {
            Errors = new List<DtoValidationError>();
        }

        public void Add(string property, object value, string message)
        {
            Errors.Add(new DtoValidationError()
            { Property = property, Value = value, StringValue = value?.ToString(), Message = message });
        }

        public void Add(DtoValidationError error)
        {
            Errors.Add(error);
        }

        public void Aggregate(DtoValidation validation)
        {
            if (validation != null && (validation.HasErrors))
            {
                Errors.AddRange(validation.Errors);
            }
        }

        public bool HasErrors
        {
            get { return (Errors != null) && (Errors.Count > 0); }
        }

        public string FormatErrors(string format, string separator)
        {
            if (!HasErrors)
            {
                return string.Empty;
            }

            var s = new StringBuilder();
            foreach (var err in Errors)
            {
                s.Append(FormatError(err, format));
                s.Append(separator);
            }
            return s.ToString();
        }

        protected string FormatError(DtoValidationError error, string format)
        {
            if (error != null)
            {
                return string.Format(format, error.Property, error.StringValue, error.Message);
            }
            else
            {
                return Constants.DtoValidationErrorMissing;
            }
        }
    }
}