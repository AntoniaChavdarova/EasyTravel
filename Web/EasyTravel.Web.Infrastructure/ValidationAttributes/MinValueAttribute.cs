namespace EasyTravel.Web.Infrastructure.ValidationAttributes
{
    using System.ComponentModel.DataAnnotations;

    public class MinValueAttribute : ValidationAttribute
    {
        public MinValueAttribute(int minValue)
        {
            this.MinValue = minValue;
            this.ErrorMessage = $"The Count should be bigger than {minValue}.";
        }

        public int MinValue { get; set; }

        public override bool IsValid(object value)
        {
            if (value is int intValue)
            {
                if (intValue >= this.MinValue)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
