using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGNValidator.Service.Dto
{
    /// <summary>
    /// Base class for all special Value objects
    /// </summary>
    public abstract class ValueObjectBase
    {
        public abstract void FromString(string data);

        public abstract string Stringify(ValueObjectBase data);

        public abstract bool Validate();
    }
}