using System;
using System.Collections.Generic;
using System.Text;

namespace XboxLiveData
{
    public class GameClipThumbnail
    {
        public string uri { get; set; }
        public int fileSize { get; set; }
        public string thumbnailType { get; set; }
    }

    public class GameClipUri
    {
        public string uri { get; set; }
        public int fileSize { get; set; }
        public string uriType { get; set; }
        public string expiration { get; set; }
    }

    public class GameClip
    {
        public string gameClipId { get; set; }
        public string state { get; set; }
        public DateTime datePublished { get; set; }
        public string dateRecorded { get; set; }
        public object lastModified { get; set; }
        public string userCaption { get; set; }
        public string type { get; set; }
        public int durationInSeconds { get; set; }
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
        public List<GameClipUri> gameClipUris { get; set; }
        public object xuid { get; set; }
        public string clipName { get; set; }
        public string titleName { get; set; }
        public string gameClipLocale { get; set; }
        public string clipContentAttributes { get; set; }
        public string deviceType { get; set; }
        public int commentCount { get; set; }
        public int likeCount { get; set; }
        public int shareCount { get; set; }
        public int partialViews { get; set; }
        public string gameClipDetails { get; set; }
    }
}
