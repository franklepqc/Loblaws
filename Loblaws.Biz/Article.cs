using System;

namespace Loblaws.Biz
{
    public class Article : Interfaces.IArticle
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public bool SujetTaxes { get; set; }

        public decimal Prix { get; set; }
    }
}
