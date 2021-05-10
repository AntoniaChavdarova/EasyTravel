﻿namespace EasyTravel.Data.Models
{
    using EasyTravel.Data.Common.Models;

    public class Rating : BaseModel<int>
    {
        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public byte Value { get; set; }
    }
}
