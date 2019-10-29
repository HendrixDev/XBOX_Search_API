using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XboxLiveData
{
    public class Title360
    {
        public DateTime lastPlayed { get; set; }
        public int currentAchievements { get; set; }
        public int currentGamerscore { get; set; }
        public int sequence { get; set; }
        public int titleId { get; set; }
        public int titleType { get; set; }
        public List<int> platforms { get; set; }
        public string name { get; set; }
        public int totalAchievements { get; set; }
        public int totalGamerscore { get; set; }
    }

    public class PagingInfo360
    {
        public object continuationToken { get; set; }
        public int totalRecords { get; set; }
    }

    public class Games360
    {
        public List<Title360> titles { get; set; }
        public DateTime version { get; set; }
        public PagingInfo360 pagingInfo { get; set; }
    }
}