using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataBase.Entity
{
    public class CategoryTranslation
    {
        public int Id { get; set; }
        public int CategoryId { get; set; } //FK
        public string Name { get; set; }
        public string SeoDesCription { get; set; }
        public string SeoTile { get; set; }
        public string LanguageId { get; set; } //FK
        public string SeoAlias { get; set; }

        // Di Đến Entiy Category và Language  Xét Khóa Ngoại
        public Category Category { get; set; }
        public Language Language { get; set; }
    }
}
