
namespace Api {
    using System.Text.Json.Serialization;
    using System.Text.Json;
    using System.Net;
    public class Root
    {
        [JsonPropertyName("count")]
        public int count { get; set; }

        [JsonPropertyName("name")]
        public string? name { get; set; }

        [JsonPropertyName("gender")]
        public string? gender { get; set; }

        [JsonPropertyName("probability")]
        public double probability { get; set; }

    }

    public static class RuneArc {
        public static double RuneArcProbability() {
            double probability = 0; 
            var url = $"https://api.genderize.io/?name=luc";
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "GET";
            request.ContentType = "*/*";
            request.Accept = "*/*";
            try {
                using(HttpWebResponse response = (HttpWebResponse)request.GetResponse()){
                    using(StreamReader stream = new StreamReader(response.GetResponseStream())) {
                        var text = stream.ReadToEnd();
                        Root? root = JsonSerializer.Deserialize<Root>(text);
                        if(root != null) { probability = root.count; }
                    }
                }
            } catch(WebException e) {
                Console.WriteLine(e.Message);
            }
            return probability;
        }
    }
}