using Translate.Web.Data;
using Translate.Web.Interfaces;
using Translate.Web.Models;

namespace Translate.Web.Repository
{
    public class FunTranslateRepository : IFunTranslateRepository
    {
        private readonly ApplicationDbContext _context;

        public FunTranslateRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public bool Add(FunTranslate translate)
        {
            _context.FunTranslates.Add(translate);
            return Save();
        }

        public List<FunTranslate> GetAll()
        {
            return _context.FunTranslates.ToList();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }
    }
}
