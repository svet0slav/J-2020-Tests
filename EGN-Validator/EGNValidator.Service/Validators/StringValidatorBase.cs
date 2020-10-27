using System;
using System.Collections.Generic;
using EGNValidator.Service.Dto;
using EGNValidator.Service.Interfaces;

namespace EGNValidator.Service.Validators
{
    /// <summary>
    /// Validate some data.
    /// </summary>
    public class StringValidatorBase : IStringValidatorBase
    {
        public virtual bool Validate(string data)
        {
            throw new NotImplementedException("Validation not implemented");
        }

        public DtoValidation Validation { get; private set; } = null;

        internal bool Validate(string name, DtoValidationError problem)
        {
            if (Validation == null)
            {
                Validation = new DtoValidation();
            }
            if (problem != null)
            {
                problem.Property = name;
                problem.Message = string.Format(problem.Message, name);
                Validation.Add(problem);
                return false;
            }

            return true;
        }

        public void ClearValidation()
        {
            if (Validation != null)
            {
                Validation.Errors.Clear();
            }
        }

        public bool HasValidationErrors
        {
            get
            {
                return this.Validation != null && (this.Validation.HasErrors);
            }
        }

        public bool ValidateList(string name, List<string> list, int minSize, int maxSize)
        {
            if (list == null || list.Count == 0)
            {
                return true;
            }

            foreach (var item in list)
            {
                Validate($"{name}[\"{item}\"]", item?.Sizes(minSize, maxSize));
            }

            return (Validation == null);
        }

        public bool ValidateList<T>(string name, List<T> list)
            where T : ValueObjectBase
        {
            if (list == null || list.Count == 0)
            {
                return true;
            }

            foreach (var item in list)
            {
                item.Validate();
                AggregateValidation(item);
            }

            return (Validation == null);
        }

        public void AggregateValidation(ValueObjectBase childDto)
        {
            //TODO: When composition of Dto's appears.
            //if (childDto.Validation == null || (childDto.Validation.HasErrors == false))
            //{
            //    return;
            //}
            //else if (Validation == null)
            //{
            //    Validation = new DtoValidation();
            //    Validation.Aggregate(childDto.Validation);
            //}
            //else
            //{
            //    Validation.Aggregate(childDto.Validation);
            //}
        }

        /// <summary>
        /// Validate all fields in the Dto
        /// </summary>
        /// <returns>True if ok and false if fails.</returns>
        public virtual bool Validate()
        {
            throw new NotImplementedException("Validation not implemented");
        }
    }
}
