namespace CMSChallenge.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual List<ArticleKeyword> ArticleKeywords { get; set; }
    }
}
