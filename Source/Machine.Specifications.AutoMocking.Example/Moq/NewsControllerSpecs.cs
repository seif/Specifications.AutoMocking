using Machine.Specifications.AutoMocking.Moq;
using Moq;

namespace Machine.Specifications.AutoMocking.Example.Moq
{
    /// <summary>
    /// Example specification for a class without a contract that uses constructor based DI
    /// </summary>
    public abstract class context_for_news_controller : Specification<NewsController>
    {
        protected static INewsService newsService;
        
        Establish context = () =>
            {
                newsService = DependencyOf<INewsService>(); // DependencyOf creates and registers a mock instance of the dependency
            };
    }

    [Subject(typeof(NewsController))]
    public class when_the_news_controller_is_told_to_display_the_default_view : context_for_news_controller
    {
        static string result;

        Establish context = () => Mock.Get(newsService).Setup(x => x.GetLatestHeadline()).Returns("The latest headline");

        Because of = () => result = subject.Index(); // the subject has been created for us automatically, with all registered dependencies

        It should_ask_the_news_service_for_the_latest_headline =
            () => Mock.Get(newsService).Verify(x => x.GetLatestHeadline());

        It should_display_the_latest_headline = () => result.ShouldEqual("The latest headline");
    }
}