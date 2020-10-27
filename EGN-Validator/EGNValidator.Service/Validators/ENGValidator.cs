using System;
using EGNValidator.Service.Dto;
using EGNValidator.Service.Interfaces;

namespace EGNValidator.Service.Validators
{
    public class ENGValidator : StringValidatorBase, IEGNValidator
    {
        //public override bool Validate(string data)
        //{
        //    throw new NotImplementedException();
        //}

        public override bool Validate(string data)
        {
            Validate(Constants.EGNName, (data ?? "").Required());
            Validate(Constants.EGNName, data?.Sizes(10, 10));
            Validate(Constants.EGNName, data?.DigitsOnly());

            if (this.HasValidationErrors)
            {
                return false;
            }

            var egn = new EGNValue();
            egn.FromString(data);
            return Validate(egn);
        }

        public virtual bool Validate(EGNValue egn)
        {
            if (egn == null)
            {
                return false;
            }
            //Test the birth date
            //Първите шест цифри съответстват на датата на раждане (ГГММДД). Тъй като за годината на раждане са отделени само две цифри, могат да се кодират единствено годините между 1900 и 1999. Останалите години се представят по следния начин:
            Validate(nameof(egn.Year), egn.Year.Between(1800, 2099));
            Validate(nameof(egn.MonthNumber), egn.MonthNumber.Between(1, 52));
            Validate(nameof(egn.Day), egn.Day.Between(1, 31));
            //за родените преди 1 януари 1900 г.към месеца се прибавя числото 20,
            //за родените след 31 декември 1999 г.до 31 декември 2099 г.към месеца се прибавя числото 40.
            if (egn.Year < 1900)
            {
                Validate(nameof(egn.MonthNumber), egn.MonthNumber.Between(21, 32));
            }
            else if (egn.Year >= 2000)
            {
                Validate(nameof(egn.MonthNumber), egn.MonthNumber.Between(41, 52));
            }
            else
            {
                Validate(nameof(egn.MonthNumber), egn.MonthNumber.Between(1, 12));
            }

            var controlDigit = CalculateControlDigit(egn);
            Validate("Control digit", egn.ControlDigit.SameValue(controlDigit));

            return !this.HasValidationErrors;
        }

        protected int CalculateControlDigit(EGNValue data)
        {
            int[] weights = new int[9] {2, 4, 8, 5, 10, 9, 7, 3, 6 };

            //Десетата цифра е контролна и се изчислява по следния алгоритъм:
            //        Всяка от първите девет цифри се умножава по съответното ѝ тегло(виж таблицата) и резултатите се сумират;
            //        Получената сума се дели на 11 с остатък;
            //        Ако остатъкът от делението е по-малък от 10, тогава той се взема като контролна цифра, иначе за контролна се взема цифрата 0.
            //Тегла на отделните цифри в ЕГН
            //Позиция	1	2	3	4	5	6	7	8	9
            //Тегло	2	4	8	5	10	9	7	3	6
            //(Теглата са съответната степен на двойката по модул 11.)

            int suma = 0;
            var y = data.Year % 100;
            suma += ((y / 10) * weights[0]) + ((y % 10) * weights[1]);

            var m = data.MonthNumber;
            suma += ((m / 10) * weights[2]) + ((m % 10) * weights[3]);

            var d = data.Day;
            suma += ((d / 10) * weights[4]) + ((d % 10) * weights[5]);

            var n = data.Region3;
            suma += ((n / 100) * weights[6]) + (((n % 100) / 10) * weights[7]) + ((n % 10) * weights[8]);

            int ostatyk = suma % 11;
            var result = (ostatyk == 10) ? 0 : ostatyk;
            return result;
        }

        protected bool IsValidDate(int year, int month, int day)
        {
            try
            {
                var x = new DateTime(year, month, day);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}