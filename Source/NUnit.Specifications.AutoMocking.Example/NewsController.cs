namespace NUnit.Specifications.AutoMocking.Example
{
    public class NewsController
    {
        #region Constants and Fields

        private readonly INewsService newsService;

        #endregion

        #region Constructors and Destructors

        public NewsController(INewsService newsService)
        {
            this.newsService = newsService;
        }

        #endregion

        #region Public Methods

        public string Index()
        {
            return this.newsService.GetLatestHeadline();
        }

        #endregion
    }
}