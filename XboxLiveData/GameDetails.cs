using System;
using System.Collections.Generic;
using System.Text;

namespace XboxLiveData
{
    public class Genre
    {
        public string Name { get; set; }
    }

    public class Image
    {
        public string ID { get; set; }
        public string Url { get; set; }
        public string ResizeUrl { get; set; }
        public List<string> Purposes { get; set; }
        public string Purpose { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public int? Order { get; set; }
    }

    public class Capability
    {
        public string NonLocalizedName { get; set; }
        public int Value { get; set; }
    }

    public class LegacyId
    {
        public string IdType { get; set; }
        public object Value { get; set; }
    }

    public class Device
    {
        public string Name { get; set; }
    }

    public class Availability
    {
        public string AvailabilityID { get; set; }
        public string ContentId { get; set; }
        public List<Device> Devices { get; set; }
        public string OfferDisplayData { get; set; }
        public string SignedOffer { get; set; }
    }

    public class RatingImage
    {
        public string Url { get; set; }
    }

    public class LocalizedDetails
    {
        public string ShortName { get; set; }
        public string LongName { get; set; }
        public List<RatingImage> RatingImages { get; set; }
    }

    public class RatingDescriptor
    {
        public string NonLocalizedDescriptor { get; set; }
        public int Id { get; set; }
    }

    public class RatingDisclaimer
    {
        public string Text { get; set; }
    }

    public class ParentalRating
    {
        public string RatingId { get; set; }
        public int LegacyRatingId { get; set; }
        public string Rating { get; set; }
        public string RatingSystem { get; set; }
        public int RatingMinimumAge { get; set; }
        public LocalizedDetails LocalizedDetails { get; set; }
        public List<RatingDescriptor> RatingDescriptors { get; set; }
        public List<RatingDisclaimer> RatingDisclaimers { get; set; }
    }

    public class Item
    {
        public string MediaGroup { get; set; }
        public string MediaItemType { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ReducedDescription { get; set; }
        public string ReducedName { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int TitleId { get; set; }
        public string VuiDisplayName { get; set; }
        public List<Genre> Genres { get; set; }
        public string DeveloperName { get; set; }
        public List<Image> Images { get; set; }
        public string PublisherName { get; set; }
        public DateTime Updated { get; set; }
        public string ParentalRating { get; set; }
        public string ParentalRatingSystem { get; set; }
        public string SortName { get; set; }
        public List<Capability> Capabilities { get; set; }
        public int KValue { get; set; }
        public string KValueNamespace { get; set; }
        public int HexTitleId { get; set; }
        public int AllTimeRatingCount { get; set; }
        public int ThirtyDaysRatingCount { get; set; }
        public int SevenDaysRatingCount { get; set; }
        public double AllTimeAverageRating { get; set; }
        public double ThirtyDaysAverageRating { get; set; }
        public double SevenDaysAverageRating { get; set; }
        public List<LegacyId> LegacyIds { get; set; }
        public List<Availability> Availabilities { get; set; }
        public string ResourceAccess { get; set; }
        public bool IsRetail { get; set; }
        public string ManualUrl { get; set; }
        public List<ParentalRating> ParentalRatings { get; set; }
    }

    public class RootObject
    {
        public List<Item> Items { get; set; }
        public string ImpressionGuid { get; set; }
    }
}
