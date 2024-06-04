using WAD_BACKEND_14883.Models;

namespace WAD_BACKEND_14883.Repositories
{
    public interface IArticleRepository
    {
        Task<IEnumerable<Article>> GetAllArticles(bool includeAuthors = false);
        Task<Article> GetArticleById(int id, bool includeAuthors = false);
        Task CreateArticle(Article article);
        Task UpdateArticle(Article article);
        Task DeleteArticle(int id);
        bool ArticleExists(int id);
        Task LoadArticleAuthor(Article article);
    }
}
