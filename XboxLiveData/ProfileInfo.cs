using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace XboxAPI
{
    //public class ProfileInfo
    //{
    //    public long XUID { get; set; }
    //    public long id { get; set; }
    //    public long hostId { get; set; }
    //    public string Gamertag { get; set; }
    //    public string GameDisplayName { get; set; }
    //    public string AppDisplayName { get; set; }
    //    public int Gamerscore { get; set; }
    //    public string GameDisplayPicRaw { get; set; }
    //    public string AppDisplayPicRaw { get; set; }
    //    public string AccountTier { get; set; }
    //    public string XboxOneRep { get; set; }
    //    public string PreferredColor { get; set; }
    //    public int TenureLevel { get; set; }
    //    public bool isSponsoredUser { get; set; }
    //}

    public class MultiplayerSummary
    {
        public int InMultiplayerSession { get; set; }
        public int InParty { get; set; }
    }

    public class PreferredColor
    {
        public string primaryColor { get; set; }
        public int secondaryColor { get; set; }
        public int tertiaryColor { get; set; }
    }

    public class PresenceDetail
    {
        public bool IsBroadcasting { get; set; }
        public string Device { get; set; }
        public string PresenceText { get; set; }
        public string State { get; set; }
        public int TitleId { get; set; }
        public object TitleType { get; set; }
        public bool IsPrimary { get; set; }
        public bool IsGame { get; set; }
        public object RichPresenceText { get; set; }
    }

    public class Detail
    {
        public string accountTier { get; set; }
        public object bio { get; set; }
        public bool isVerified { get; set; }
        public object location { get; set; }
        public object tenure { get; set; }
        public List<object> watermarks { get; set; }
        public bool blocked { get; set; }
        public bool mute { get; set; }
        public int followerCount { get; set; }
        public int followingCount { get; set; }
        public bool hasGamePass { get; set; }
    }

    public class ProfileInfo
    {
        public long xuid { get; set; }
        public bool isFavorite { get; set; }
        public bool isFollowingCaller { get; set; }
        public bool isFollowedByCaller { get; set; }
        public bool isIdentityShared { get; set; }
        public object addedDateTimeUtc { get; set; }
        public object displayName { get; set; }
        public string realName { get; set; }
        public string displayPicRaw { get; set; }
        public int showUserAsAvatar { get; set; }
        public string gamertag { get; set; }
        public int gamerScore { get; set; }
        public string modernGamertag { get; set; }
        public string modernGamertagSuffix { get; set; }
        public string uniqueModernGamertag { get; set; }
        public string xboxOneRep { get; set; }
        public string presenceState { get; set; }
        public string presenceText { get; set; }
        public object presenceDevices { get; set; }
        public bool isBroadcasting { get; set; }
        public bool isCloaked { get; set; }
        public bool isQuarantined { get; set; }
        public bool isXbox360Gamerpic { get; set; }
        public DateTime lastSeenDateTimeUtc { get; set; }
        public object suggestion { get; set; }
        public object recommendation { get; set; }
        public object search { get; set; }
        public object titleHistory { get; set; }
        public MultiplayerSummary multiplayerSummary { get; set; }
        public object recentPlayer { get; set; }
        public object follower { get; set; }
        public PreferredColor preferredColor { get; set; }
        public List<PresenceDetail> presenceDetails { get; set; }
        public object titlePresence { get; set; }
        public object titleSummaries { get; set; }
        public object presenceTitleIds { get; set; }
        public Detail detail { get; set; }
        public object communityManagerTitles { get; set; }
        public object socialManager { get; set; }
        public object broadcast { get; set; }
        public object tournamentSummary { get; set; }
        public object avatar { get; set; }
        public List<object> linkedAccounts { get; set; }
        public string colorTheme { get; set; }
        public string preferredFlag { get; set; }
        public List<object> preferredPlatforms { get; set; }
    }
}
