using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace BizCover.Cars.Contract
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidateUniqueCarsIdsAttribute:ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var Ids =(List<int>)value;
            return Ids.Distinct().Count() == Ids.Count();
        }
    }
}
