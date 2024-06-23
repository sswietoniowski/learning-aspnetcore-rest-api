using Microsoft.EntityFrameworkCore;
using mvc.DataAccess.Entities;
using mvc.DataAccess.Repository.Interfaces;

namespace mvc.DataAccess.Repository;

public class LanguageRepository : Repository<Language>, ILanguageRepository
{
    public LanguageRepository(DbContext context) : base(context)
    {
    }
}