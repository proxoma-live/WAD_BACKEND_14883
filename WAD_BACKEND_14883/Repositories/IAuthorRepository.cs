using WAD_BACKEND_14883.Models;

namespace WAD_BACKEND_14883.Repositories
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAuthors();
        Task<Author> GetAuthorById(int id);
        Task CreateAuthor(Author author);
        Task UpdateAuthor(Author author);
        Task DeleteAuthor(int id);
        bool AuthorExists(int id);
    }
}
