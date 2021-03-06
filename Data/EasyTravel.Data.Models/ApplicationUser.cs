// ReSharper disable VirtualMemberCallInConstructor
namespace EasyTravel.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EasyTravel.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Bookings = new HashSet<Booking>();
            this.Ratings = new HashSet<Rating>();
            this.Reviews = new HashSet<Review>();
            this.ContactForms = new HashSet<ContactForm>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public byte[] ProfilePicture { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public virtual ICollection<Rating> Ratings { get; set; }

        public virtual ICollection<ContactForm> ContactForms { get; set; }

        public static implicit operator ApplicationUser(Task<ApplicationUser> v)
        {
            throw new NotImplementedException();
        }
    }
}
