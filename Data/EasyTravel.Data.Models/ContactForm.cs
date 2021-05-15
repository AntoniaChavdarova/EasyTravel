namespace EasyTravel.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using EasyTravel.Common;
    using EasyTravel.Data.Common.Models;

    public class ContactForm : BaseModel<int>
    {

        [Required]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [Required]
        [MinLength(GlobalConstants.DataValidations.NameMinLength)]
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

       
    }
}
