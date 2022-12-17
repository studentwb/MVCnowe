using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCnowe.QueryforAPI.Category
{
    public class GetCategoryReadModel
    {
        public string CategoryCombined { get; set; }
        public List<Category> Categories { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int DisplayOrder { get; set;}
        public DateTime CreatedDateTime { get; set;}

    }
}
 