namespace CMSChallenge.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public virtual List<ArticleKeyword> ArticleKeywords { get; set; }
    }
}
