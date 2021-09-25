using System;
using System.ComponentModel.DataAnnotations;

namespace PersonEditor.Model.Enums
{
    public class GenderValidationAttribute : RequiredAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null) return false;

            var type = value.GetType();

            return type.IsEnum && Enum.IsDefined(type, value); ;
        }
    }
}
