using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ValidationAttributes
{
    public class CurrentMaxValueAttribute : ValidationAttribute
    {
        public CurrentMaxValueAttribute(int minYear)
        {
            this.MinYear = minYear;
            this.ErrorMessage = $"Year should be between {minYear} and {DateTime.UtcNow.Year}.";
        }

        public int MinYear { get; set; }

        public override bool IsValid(object value)
        {
            if (value is int intValue)
            {
                if (intValue <= DateTime.UtcNow.Day
                    && intValue >= this.MinYear)
                {
                    return true;
                }
            }


            return false;
        }
    }
}
