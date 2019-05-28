using System.Collections.Generic;

namespace Loblaws.Biz.Interfaces
{
    public interface ICalculTotal
    {
        decimal Calculer(IEnumerable<IArticle> articles);
    }
}
