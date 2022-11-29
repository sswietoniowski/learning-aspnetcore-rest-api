using Microsoft.EntityFrameworkCore;
using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;

namespace mvc.DataAccess.Repository;

public class AuthorRepository : Repository<Author>, IAuthorRepository
{
    public AuthorRepository(DbContext context) : base(context)
    {
    }
}