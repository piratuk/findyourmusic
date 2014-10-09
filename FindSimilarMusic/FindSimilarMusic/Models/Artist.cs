namespace FindSimilarMusic.Models
{
    public class Artist
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public double PercentageSimilarity { get; set; }
    }
}