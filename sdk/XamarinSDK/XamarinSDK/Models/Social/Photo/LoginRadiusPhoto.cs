using System.Collections.Generic;

namespace XamarinSDK.Models.Photo
{
    public class LoginRadiusPhoto
    {
        public string ID { get; set; }
        public string AlbumId { get; set; }
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Name { get; set; }
        public string DirectUrl { get; set; }
        public string ImageUrl { get; set; }
        public string Location { get; set; }
        public string Link { get; set; }
        public object Description { get; set; }
        public string Height { get; set; }
        public string Width { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedDate { get; set; }
        public List<AllImage> Images { get; set; }
    }

    public class AllImage
    {
        public string Dimensions { get; set; }
        public string Image { get; set; }
    }
}
