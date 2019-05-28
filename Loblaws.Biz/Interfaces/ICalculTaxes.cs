using System.Collections.Generic;

namespace Loblaws.Biz.Interfaces
{
    public interface ICalculTaxes
    {
        decimal Calculer(IEnumerable<IArticle> articles);
    }
}
