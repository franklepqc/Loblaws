using System.Collections.Generic;

namespace Loblaws.Biz.Interfaces
{
    public interface ICalculSousTotal
    {
        decimal Calculer(IEnumerable<IArticle> articles);
    }
}
