using Microsoft.EntityFrameworkCore;
using WAD_BACKEND_14883.Data.Migrations;
using WAD_BACKEND_14883.Models;

namespace WAD_BACKEND_14883.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly NewspaperAppDbContext _dbContext;

        public ArticleRepository(NewspaperAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Article>> GetAllArticles(bool includeAuthors = false)
        {
            try
            {
                if (includeAuthors)
                {
                    return await _dbContext.Articles.Include(a => a.Author).ToListAsync();
                }
                else
                {
                    return await _dbContext.Articles.ToListAsync();
                }
            }
            catch (Exception ex)
            {
               
                throw new Exception("Error occurred while retrieving articles.", ex);
            }
        }

        public async Task<Article> GetArticleById(int id, bool includeAuthors = false)
        {
            try
            {
                if (includeAuthors)
                {
                    return await _dbContext.Articles.Include(a => a.Author).FirstOrDefaultAsync(a => a.Id == id);
                }
                else
                {
                    return await _dbContext.Articles.FirstOrDefaultAsync(a => a.Id == id);
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error occurred while retrieving article with ID {id}.", ex);
            }
        }

        public async Task CreateArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            try
            {
                await _dbContext.Articles.AddAsync(article);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception("Failed to create article. Please check the provided data.", ex);
            }
        }

        public async Task UpdateArticle(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            try
            {
                _dbContext.Entry(article).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error occurred while updating article with ID {article.Id}.", ex);
            }
        }

        public async Task DeleteArticle(int id)
        {
            try
            {
                var article = await _dbContext.Articles.FirstOrDefaultAsync(a => a.Id == id);
                if (article != null)
                {
                    _dbContext.Articles.Remove(article);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Article with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error occurred while deleting article with ID {id}.", ex);
            }
        }

        public bool ArticleExists(int id)
        {
            return _dbContext.Articles.Any(e => e.Id == id);
        }

        public async Task LoadArticleAuthor(Article article)
        {
            if (article == null)
            {
                throw new ArgumentNullException(nameof(article));
            }

            try
            {
                await _dbContext.Entry(article).Reference(a => a.Author).LoadAsync();
            }
            catch (Exception ex)
            {
                // Handle exception
                throw new Exception($"Error occurred while loading author for article ID {article.Id}.", ex);
            }
        }
    }
}
