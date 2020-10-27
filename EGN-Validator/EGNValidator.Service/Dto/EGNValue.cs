using System;
using EGNValidator.Service.Validators;

namespace EGNValidator.Service.Dto
{
    public class EGNValue : ValueObjectBase
    {
        public int Year { get; set; }
        public int Month { get; set; }

        /// <summary>
        /// The number for month in the EGN.
        /// </summary>
        public int MonthNumber { get; set; }

        public int Day { get; set; }
        public int Region3 { get; set; }
        public int ControlDigit { get; set; }

        public override void FromString(string data)
        {
            if (string.IsNullOrEmpty(data) || data.Length != 10)
            {
                throw new ArgumentException("EGN is 10 digits");
            }

            // List of digits.
            int[] digits = new int[10];
            for (int i = 0; i < 10; i++)
            {
                digits[i] = Constants.DigitsAlphabet.IndexOf(data[i]);
            }
            // Convert to meaningful structural data.
            this.MonthNumber = digits[2] * 10 + digits[3];
            if (this.MonthNumber < 20)
            {
                this.Year = 1900 + digits[0] * 10 + digits[1];
                this.Month = this.MonthNumber;
            }
            else if (this.MonthNumber < 40)
            {
                this.Year = 1800 + digits[0] * 10 + digits[1];
                this.Month = this.MonthNumber - 20;
            }
            else
            {
                this.Year = 2000 + digits[0] * 10 + digits[1];
                this.Month = this.MonthNumber - 40;
            }
            this.Day = digits[4] * 10 + digits[5];
            this.Region3 = digits[6] * 100 + digits[7] * 10 + digits[8];
            this.ControlDigit = digits[9];
        }

        public override string Stringify(ValueObjectBase data)
        {
            throw new NotImplementedException();
        }

        public override bool Validate()
        {
            var validator = new ENGValidator();
            var result = validator.Validate(this);

            return result;
        }
    }
}
