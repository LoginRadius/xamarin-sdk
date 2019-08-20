using System.Collections.Generic;


namespace XamarinSDK.Models.UserProfile
{
    public class UserIdentityCreateModel 
    {
        public string Prefix { get; set; }
        public string FirstName { get; set; }
        public object MiddleName { get; set; }
        public string LastName { get; set; }
        public object Suffix { get; set; }
        public string FullName { get; set; }
        public object NickName { get; set; }
        public object ProfileName { get; set; }
        public string BirthDate { get; set; }
        public string Gender { get; set; }
        public object Website { get; set; }
        public List<Email> Email { get; set; }
        public Country Country { get; set; }
        public object ThumbnailImageUrl { get; set; }
        public object ImageUrl { get; set; }
        public object Favicon { get; set; }
        public object ProfileUrl { get; set; }
        public object HomeTown { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public object Industry { get; set; }
        public object About { get; set; }
        public object TimeZone { get; set; }
        public object LocalLanguage { get; set; }
        public object CoverPhoto { get; set; }
        public object TagLine { get; set; }
        public List<Position> Positions { get; set; }
        public List<Education> Educations { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<IMAccount> IMAccounts { get; set; }
        public List<Address> Addresses { get; set; }
        public object MainAddress { get; set; }
        public object LocalCity { get; set; }
        public string ProfileCity { get; set; }
        public object LocalCountry { get; set; }
        public string ProfileCountry { get; set; }
        public bool IsProtected { get; set; }
        public object RelationshipStatus { get; set; }
        public object Quota { get; set; }
        public object Quote { get; set; }
        public List<string> InterestedIn { get; set; }
        public List<Interest> Interests { get; set; }
        public object Religion { get; set; }
        public object Political { get; set; }
        public List<Sport> Sports { get; set; }
        public List<InspirationalPeople> InspirationalPeople { get; set; }
        public object HttpsImageUrl { get; set; }
        public int FollowersCount { get; set; }
        public int FriendsCount { get; set; }
        public object IsGeoEnabled { get; set; }
        public int TotalStatusesCount { get; set; }
        public object Associations { get; set; }
        public int NumRecommenders { get; set; }
        public object Honors { get; set; }
        public object Awards { get; set; }
        public object Skills { get; set; }
        public object CurrentStatus { get; set; }
        public object Certifications { get; set; }
        public object Courses { get; set; }
        public object Volunteer { get; set; }
        public object RecommendationsReceived { get; set; }
        public object Languages { get; set; }
        public object Projects { get; set; }
        public object Games { get; set; }
        public object Family { get; set; }
        public object TeleVisionShow { get; set; }
        public object MutualFriends { get; set; }
        public object Movies { get; set; }
        public object Books { get; set; }
        public object AgeRange { get; set; }
        public object PublicRepository { get; set; }
        public bool Hireable { get; set; }
        public object RepositoryUrl { get; set; }
        public object Age { get; set; }
        public object Patents { get; set; }
        public object FavoriteThings { get; set; }
        public object ProfessionalHeadline { get; set; }
        public object ProviderAccessCredential { get; set; }
        public object RelatedProfileViews { get; set; }
        public object KloutScore { get; set; }
        public object LRUserID { get; set; }
        public object PlacesLived { get; set; }
        public object Publications { get; set; }
        public object JobBookmarks { get; set; }
        public object Suggestions { get; set; }
        public object Badges { get; set; }
        public object MemberUrlResources { get; set; }
        public int TotalPrivateRepository { get; set; }
        public object Currency { get; set; }
        public object StarredUrl { get; set; }
        public object GistsUrl { get; set; }
        public int PublicGists { get; set; }
        public int PrivateGists { get; set; }
        public object Subscription { get; set; }
        public object Company { get; set; }
        public object GravatarImageUrl { get; set; }
        public object ProfileImageUrls { get; set; }
        public WebProfiles WebProfiles { get; set; }
        public string Password { get; set; }
        public string Uid { get; set; }
        public object CustomFields { get; set; }
        public bool IsEmailSubscribed { get; set; }
        public object UserName { get; set; }
        public string PhoneId { get; set; }
    }

    public class Email
    {
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }

    public class Company
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Industry { get; set; }
    }

    public class Position
    {
        public string Positions { get; set; }
        public string Summary { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string IsCurrent { get; set; }
        public string Location { get; set; }
        public Company Company { get; set; }
    }

    public class Education
    {
        public object School { get; set; }
        public object year { get; set; }
        public object type { get; set; }
        public object notes { get; set; }
        public object activities { get; set; }
        public object degree { get; set; }
        public object fieldofstudy { get; set; }
        public object StartDate { get; set; }
        public object EndDate { get; set; }
    }

    public class PhoneNumber
    {
        public string PhoneType { get; set; }

        private string phoneNumber;

        public string GetPhoneNumber()
        {
            return phoneNumber;
        }

        public void SetPhoneNumber(string value)
        {
            phoneNumber = value;
        }
    }

    public class IMAccount
    {
        public string AccountType { get; set; }
        public string AccountName { get; set; }
    }

    public class Address
    {
        public string Type { get; set; }
        public object Address1 { get; set; }
        public object Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public object PostalCode { get; set; }
        public object Region { get; set; }
        public string Country { get; set; }
    }

    public class Interest
    {
        public object InterestedType { get; set; }
        public object InterestedName { get; set; }
    }

    public class Sport
    {
        public object Id { get; set; }
        public object Name { get; set; }
    }

    public class InspirationalPeople
    {
        public object Id { get; set; }
        public object Name { get; set; }
    }

    public class WebProfiles
    {
        public string Small { get; set; }
        public string Square { get; set; }
        public string Large { get; set; }
        public string Profile { get; set; }
    }

}