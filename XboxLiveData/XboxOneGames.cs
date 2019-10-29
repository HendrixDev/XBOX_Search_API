using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using XboxAPI;

namespace XboxLiveData
{
    public class Title
    {
        public DateTime lastUnlock { get; set; }
        public int titleId { get; set; }
        public string serviceConfigId { get; set; }
        public string titleType { get; set; }
        public string platform { get; set; }
        public string name { get; set; }
        public int earnedAchievements { get; set; }
        public int currentGamerscore { get; set; }
        public int maxGamerscore { get; set; }
    }

    public class PagingInfo
    {
        public object continuationToken { get; set; }
        public int totalRecords { get; set; }
    }

    public class Games
    {
        public List<Title> titles { get; set; }
        public PagingInfo pagingInfo { get; set; }
    }


}