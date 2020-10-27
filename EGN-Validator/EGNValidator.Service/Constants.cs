using System;
using System.Collections.Generic;

namespace EGNValidator.Service
{
    internal static class Constants
    {
        public const string DtoValidationErrorFormat = "Error in field {0} = \"{1}\" because of {2}";
        public const string DtoValidationErrorSeparator = ". ";
        public const string DtoValidationErrorMissing = "Error not found. Programming error!";
        public const string DtoValidationErrorsArgumentExceptionMessage = "The request failed in validation of the data: {0}. Request: {1}";

        public const string EGNName = "EGN";
        public const string DigitsAlphabet = "0123456789";
    }
}
