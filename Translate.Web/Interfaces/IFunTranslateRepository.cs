using Translate.Web.Models;

namespace Translate.Web.Interfaces
{
    public interface IFunTranslateRepository
    {
        List<FunTranslate> GetAll();

        bool Add(FunTranslate translate);

        bool Save();
    }
}
