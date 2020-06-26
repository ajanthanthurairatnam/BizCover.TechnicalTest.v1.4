using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BizCover.Cars.Contract
{
    /// <summary>
    /// The tolerance values here will verify 
    /// number of cars selected does not exceed the tolerance value.
    /// This is to prevent a ping of death attack leading to denial-of-service (DoS) 
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateCarsIdsToleranceAttribute : ValidationAttribute
    {
        private int Tolerance { get;}
        public ValidateCarsIdsToleranceAttribute(int tolerance)
        {
            Tolerance = tolerance;
        }
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var Ids = (List<int>)value;
            return Ids.Distinct().Count() >0 && Ids.Distinct().Count()<= Tolerance;
        }
    }
}
