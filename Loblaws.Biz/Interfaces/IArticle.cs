using System;

namespace Loblaws.Biz.Interfaces
{
    public interface IArticle
    {
        Guid Id { get; }
        string Description { get; }
        bool SujetTaxes { get; }
        decimal Prix { get; }
    }
}
