namespace EGNValidator.Service.Validators
{
    using System.Collections.Generic;

    /// <summary>
    /// Extension for Validation methods about various field types and cases.
    /// </summary>
    internal static class DtoValidationMethods
    {
        public static DtoValidationError MinSize(this string value, int minSize)
        {
            if ((string.IsNullOrEmpty(value) && minSize > 0) || (minSize > 0 && value.Length < minSize))
            {
                return new DtoValidationError()
                {
                    Value = value,
                    StringValue = value,
                    Message = $"{{0}} should have minimum size of {minSize} symbols."
                };
            }
            return null;
        }

        public static DtoValidationError MaxSize(this string value, int maxSize)
        {
            if ((!string.IsNullOrEmpty(value)) && (maxSize > 0) && value.Length > maxSize)
            {
                return new DtoValidationError()
                {
                    Value = value,
                    StringValue = value,
                    Message = $"{{0}} should have maximum size of {maxSize} symbols."
                };
            }
            return null;
        }

        public static DtoValidationError Sizes(this string value, int minSize, int maxSize)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            var result = value.MinSize(minSize);
            if (result == null)
            {
                result = value.MaxSize(maxSize);
            }
            return result;
        }

        public static DtoValidationError SizesRequired(this string value, int minSize, int maxSize)
        {
            var result = value.MinSize(minSize);
            if (result == null)
            {
                result = value.MaxSize(maxSize);
            }
            return result;
        }

        public static DtoValidationError Required(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return new DtoValidationError()
                {
                    Value = value,
                    StringValue = value,
                    Message = $"{{0}} is required field. It should have value."
                };
            }
            return null;
        }

        public static DtoValidationError DigitsOnly(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            for(int i = 0; i < value.Length; i++)
            {
                if (Constants.DigitsAlphabet.IndexOf(value[i]) < 0)
                {
                    return new DtoValidationError()
                    {
                        Value = value,
                        StringValue = value,
                        Message = $"{{0}} should be a string with digits, only."
                    };
                }
            }

            return null;
        }

        public static DtoValidationError Between(this int value, int from, int to)
        {
            if (value < from || value > to)
            {
                return new DtoValidationError()
                {
                    Value = value,
                    StringValue = value.ToString(),
                    Message = $"{{0}} should be between {from} and {to}."
                };
            }
            return null;
        }

        public static DtoValidationError SameValue(this int value, int testValue)
        {
            if (value != testValue)
            {
                return new DtoValidationError()
                {
                    Value = value,
                    StringValue = value.ToString(),
                    Message = $"{{0}} should be exactly {testValue}."
                };
            }
            return null;
        }
        

        public static DtoValidationError HasPrefix(this string value, string startValue)
        {
            if (!string.IsNullOrEmpty(value))
            {
                if (!value.StartsWith(startValue))
                {
                    return new DtoValidationError()
                    {
                        Value = value,
                        StringValue = value,
                        Message = $"{{0}} should be as a string with \"{startValue}\" prefix."
                    };
                }
            }
            return null;
        }

        public static DtoValidationError ListCount<T>(this List<T> list, int minSize, int maxSize)
        {
            if ((list == null && minSize > 0) || (list.Count < minSize))
            {
                return new DtoValidationError()
                {
                    Value = list,
                    StringValue = "list",
                    Message = $"The list of {{0}} should have minimum size of {maxSize} items."
                };
            }

            if (list != null && (maxSize > 0) && list.Count > maxSize)
            {
                return new DtoValidationError()
                {
                    Value = list,
                    StringValue = "list",
                    Message = $"The list of {{0}} should have maximum size of {maxSize} symbols."
                };
            }

            return null;
        }

        public static DtoValidationError Required(this double value)
        {
            if (double.IsNaN(value) || double.IsNegativeInfinity(value) || double.IsPositiveInfinity(value))
            {
                return new DtoValidationError()
                {
                    Value = value,
                    StringValue = value.ToString(),
                    Message = $"{{0}} is required field. It should have value."
                };
            }
            return null;
        }

        public static DtoValidationError RequiredNonZero(this double value)
        {
            if (value == 0 || double.IsNaN(value) || double.IsNegativeInfinity(value) || double.IsPositiveInfinity(value))
            {
                return new DtoValidationError()
                {
                    Value = value,
                    StringValue = value.ToString(),
                    Message = $"{{0}} is required field. It should have value that is not zero."
                };
            }
            return null;
        }

        public static string GetSubString(this string s, int start, int length)
        {
            if (s == null)
            {
                return null;
            }
            if (string.IsNullOrWhiteSpace(s))
            {
                return string.Empty;
            }
            if (s.Length < start)
            {
                return string.Empty;
            }

            return s.Substring(start, length);
        }
    }
}