using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using XboxAPI;

namespace XboxLiveData
{
    //****Number of API requests for each method******
    //GetXUID() : 1
    //GetInfo() : 2
    //GetGamerTag() : 0
    //GetScreenShotThumbnails() : 2
    //GetXboxOneGames() : 2+
    //GetGameImg() : 1
    //GetGameClips() : 1

    public class Methods
    {
        private const string token = "XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX";
        private const string baseAddress = "https://xboxapi.com/";

        public static string GetXUID()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Auth", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync("/v2/xuid/" + Credentials.GamerTag).Result;
                ProfileInfo data = JsonConvert.DeserializeObject<ProfileInfo>(response.Content.ReadAsStringAsync().Result);
                string xuid = data.XUID.ToString();
                return xuid;
            }
        }

        public static string GetInfo()
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Auth", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("v2/" + Credentials.XUID + "/profile").Result;
                HttpResponseMessage response2 = client.GetAsync("v2/" + Credentials.XUID + "/gamercard").Result;

                ProfileInfo data = JsonConvert.DeserializeObject<ProfileInfo>(response.Content.ReadAsStringAsync().Result);
                Gamercard data2 = JsonConvert.DeserializeObject<Gamercard>(response2.Content.ReadAsStringAsync().Result);

                string noPlayerFound = "No info was found for that gamertag";
                string gamerTag = data.Gamertag;
                string gamerScore = data.Gamerscore.ToString();
                string name = data.GameDisplayName;
                string xboxOneRep = data.XboxOneRep;
                string tenureLevel = data.TenureLevel.ToString();
                string accountTier = data.AccountTier;
                string bio = data2.bio;
                string motto = data2.motto;
                string gamerPic = data.GameDisplayPicRaw;

                if (bio == null || bio == "Code of Conduct")
                {
                    bio = "Data Not Found";
                }

                if (motto == null || motto == "Code of Conduct")
                {
                    motto = "Data Not Found";
                }

                string final = $"GamerTag:\t{gamerTag}\n" +
                               $"Gamer Score:\t{gamerScore}\n" +
                               $"Account Tier:\t{accountTier}\n" +
                               $"Reputation:\t{xboxOneRep}\n" +
                               $"Tenure Level:\t{tenureLevel}\n" +
                               $"Bio:\t\t{bio}\n" +
                               $"Motto:\t\t{motto}\n" +
                               $"Gamer Pic:\n{gamerPic}";

                if (string.IsNullOrEmpty(gamerTag))
                {
                    return noPlayerFound;
                }

                else
                {
                    return final;
                }
            }
        }

        public static string GetGamerTag()
        {
            string gamerTag, gamerTag2;
            Console.WriteLine("Please Enter your GamerTag");
            gamerTag = Console.ReadLine();
            gamerTag2 = gamerTag.Replace(" ", "%20");
            Console.WriteLine("Searching...");
            return gamerTag2;
        }

        public static List<string> GetGameClips()
        {
            List<string> thumbnails = new List<string>();
            List<string> gameClips = new List<string>();
            List<string> thumbnailsAndGameClips = new List<string>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Auth", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("v2/" + Credentials.XUID + "/game-clips").Result;

                GameClip[] data = JsonConvert.DeserializeObject<GameClip[]>(response.Content.ReadAsStringAsync().Result);

                foreach (var item in data)
                {
                    TimeSpan temp = TimeSpan.FromSeconds(item.durationInSeconds);
                    string time = temp.ToString(@"hh\:mm\:ss");
                    string caption = item.userCaption;

                    if (string.IsNullOrEmpty(caption))
                    {
                        caption = "[No Caption]";
                    }

                    thumbnailsAndGameClips.Add("Title: " + item.titleName);
                    thumbnailsAndGameClips.Add("Views: " + item.views);
                    thumbnailsAndGameClips.Add("Caption: " + caption);
                    thumbnailsAndGameClips.Add("Length: " + time);
                    thumbnailsAndGameClips.Add("Thumbnail: " + item.thumbnails[0].uri);
                    thumbnailsAndGameClips.Add("Game Clip URI: " + item.gameClipUris[0].uri + "\n");
                }
            }

            return thumbnailsAndGameClips;
        }

        public static string GetGameImg(int gameID)
        {
            string imageUrl;

            List<string> images = new List<string>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Auth", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                string hexID = gameID.ToString("X");

                HttpResponseMessage response = client.GetAsync("v2/game-details-hex/" + hexID).Result;

                RootObject image = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);

                foreach (var item in image.Items)
                {
                    foreach (var url in item.Images)
                    {
                        images.Add(url.ResizeUrl);
                    }
                }
            }

            imageUrl = images[2];

            return imageUrl;
        }

        public static List<string> GetXboxOneGames()
        {
            List<string> titles = new List<string>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Auth", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("v2/" + Credentials.XUID + "/xboxonegames").Result;

                Games gameData = JsonConvert.DeserializeObject<Games>(response.Content.ReadAsStringAsync().Result);

                foreach (var item in gameData.titles)
                {
                    titles.Add("ID:" + item.titleId);
                    titles.Add("Title: " + item.name);
                    titles.Add("Earned achievements: " + item.earnedAchievements.ToString());
                    titles.Add("Gamerscore: " + item.currentGamerscore + " out of " + item.maxGamerscore + "\n");
                    //titles.Add("Img URL: " + GetGameImg(item.titleId) + "\n");

                    //*****WARNING******
                    //Uncommenting the above line of code will return Image URLs for each game that is returned
                    //when calling the GetGames() method. This is NOT recommended. Very slow and uses high
                    //amount of API requests. (One request per game returned).
                }
            }

            return titles;
        }

        public static List<string> GetXbox360Games()
        {
            List<string> titles = new List<string>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Auth", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("v2/" + Credentials.XUID + "/xbox360games").Result;

                Games360 gameData360 = JsonConvert.DeserializeObject<Games360>(response.Content.ReadAsStringAsync().Result);

                foreach (var item in gameData360.titles)
                {
                    titles.Add("ID:" + item.titleId);
                    titles.Add("Title: " + item.name);
                    titles.Add("Earned achievements: " + item.currentAchievements.ToString());
                    titles.Add("Gamerscore: " + item.currentGamerscore + " out of " + item.totalGamerscore + "\n");
                }
            }

            return titles;
        }

        public static List<string> GetScreenShots()
        {
            List<string> thumbnailURIs = new List<string>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(baseAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Add("X-Auth", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = client.GetAsync("v2/" + Credentials.XUID + "/screenshots").Result;

                Screenshot[] data = JsonConvert.DeserializeObject<Screenshot[]>(response.Content.ReadAsStringAsync().Result);

                foreach (var item in data)
                {
                    thumbnailURIs.Add("Game: " + item.titleName);
                    thumbnailURIs.Add("Date Taken: " + item.dateTaken);
                    thumbnailURIs.Add("Thumbnail: " + item.thumbnails[0].uri + "\n");
                    thumbnailURIs.Add("ScreenShot: " + item.screenshotUris[0].uri);
                }
            }

            return thumbnailURIs;
        }


    }
}
