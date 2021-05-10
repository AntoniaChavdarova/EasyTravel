namespace EasyTravel.Data.Models
{
    using System;

    using EasyTravel.Data.Common.Models;

    public class Image : BaseModel<string>
    {
        public Image()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public int PropertyId { get; set; }

        public virtual Property Property { get; set; }

        public string Extension { get; set; }

        //// The contents of the image is in the file system

        public string RemoteImageUrl { get; set; }
    }
}
