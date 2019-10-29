using System;
using System.Collections.Generic;
using System.Text;

namespace XboxLiveData
{
    public class Thumbnail
    {
        public string uri { get; set; }
        public int fileSize { get; set; }
        public string thumbnailType { get; set; }
    }

    public class ScreenshotUri
    {
        public string uri { get; set; }
        public int fileSize { get; set; }
        public string uriType { get; set; }
        public string expiration { get; set; }
    }

    public class Screenshot
    {
        public string screenshotId { get; set; }
        public int resolutionHeight { get; set; }
        public int resolutionWidth { get; set; }
        public string state { get; set; }
        public DateTime datePublished { get; set; }
        public string dateTaken { get; set; }
        public DateTime lastModified { get; set; }
        public string userCaption { get; set; }
        public string type { get; set; }
        public string scid { get; set; }
        public int titleId { get; set; }
        public int rating { get; set; }
        public int ratingCount { get; set; }
        public int views { get; set; }
        public string titleData { get; set; }
        public string systemProperties { get; set; }
        public bool savedByUser { get; set; }
        public string achievementId { get; set; }
        public object greatestMomentId { get; set; }
        public List<Thumbnail> thumbnails { get; set; }
        public List<ScreenshotUri> screenshotUris { get; set; }
        public object xuid { get; set; }
        public string screenshotName { get; set; }
        public string titleName { get; set; }
        public string screenshotLocale { get; set; }
        public string screenshotContentAttributes { get; set; }
        public string deviceType { get; set; }
        public string screenshotDetails { get; set; }
    }
}
