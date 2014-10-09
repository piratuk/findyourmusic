using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace FindSimilarMusic.Models.LastFM
{
    public class LastFMApi
    {
        private string _apiRoot = "http://ws.audioscrobbler.com/2.0/";
        private string _getSimilar = "?method=artist.getsimilar&artist={0}&api_key=95ba6f9f2e46a04bbe9ce19633fc47e4&format=json";
        private string _getInfo = "?method=artist.getinfo&artist={0}&api_key=95ba6f9f2e46a04bbe9ce19633fc47e4&format=json";

        private Artist[] GetSimilarArtistsForSingleArtist(Artist inArtist)
        {
            var webClient = new WebClient();
            var response = webClient.DownloadString(_apiRoot + string.Format(_getSimilar, inArtist.Name));
            dynamic result = JsonConvert.DeserializeObject(response);
            if (result["error"] != null)
            {
                return new Artist[0];
            }
            var artists = new List<Artist>();

            foreach (var artist in result.similarartists.artist)
            {
                var newArt = new Artist { Name = artist.name, Url = artist.url, PercentageSimilarity = artist.match, ImageUrl = artist.image[4]["#text"] };
                newArt.PercentageSimilarity *= 100;
                //SO SLOW
                //dynamic desc =
                //    JsonConvert.DeserializeObject(
                //        webClient.DownloadString(_apiRoot + string.Format(_getInfo, inArtist.Name)));
                //newArt.Description = desc.artist.bio.summary;
                artists.Add(newArt);
            }
            return artists.ToArray();
        }

        public Artist[] GetSimilarArtists(Artist[] artistNames)
        {
            var inputSimilarArtists = new Dictionary<Artist, Artist[]>();
            foreach (var inputArtist in artistNames)
            {
                inputSimilarArtists.Add(inputArtist, GetSimilarArtistsForSingleArtist(inputArtist));
            }
            var result = new List<Artist>();
            foreach (var artList in inputSimilarArtists.Values)
            {
                result.AddRange(artList);
            }
            return result.ToArray();
        }
    }
}