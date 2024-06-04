using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WAD_BACKEND_14883.Data.Migrations;
using WAD_BACKEND_14883.Models;

namespace WAD_BACKEND_14883.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly NewspaperAppDbContext _dbContext;

        public AuthorRepository(NewspaperAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Author>> GetAllAuthors()
        {
            try
            {
                return await _dbContext.Authors.ToListAsync();
            }
            catch (Exception ex)
            {
                
                throw new Exception("Error occurred while retrieving authors.", ex);
            }
        }

        public async Task<Author> GetAuthorById(int id)
        {
            try
            {
                return await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            }
            catch (Exception ex)
            {
                
                throw new Exception($"Error occurred while retrieving author with ID {id}.", ex);
            }
        }

        public async Task CreateAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            try
            {
                await _dbContext.Authors.AddAsync(author);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               
                throw new Exception("Failed to create author. Please check the provided data.", ex);
            }
        }

        public async Task UpdateAuthor(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            try
            {
                _dbContext.Entry(author).State = EntityState.Modified;
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               
                throw new Exception($"Error occurred while updating author with ID {author.Id}.", ex);
            }
        }

        public async Task DeleteAuthor(int id)
        {
            try
            {
                var author = await _dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
                if (author != null)
                {
                    _dbContext.Authors.Remove(author);
                    await _dbContext.SaveChangesAsync();
                }
                else
                {
                    throw new Exception($"Author with ID {id} not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error occurred while deleting author with ID {id}.", ex);
            }
        }

        public bool AuthorExists(int id)
        {
            return _dbContext.Authors.Any(e => e.Id == id);
        }
    }
}
