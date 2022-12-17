using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace MVCnowe.QueryforAPI.Category
{
    public class GetCategoryQuery //: IRequest<GetCategoryReadModel>
    {
        public List<int> CategoryIds { get; set; }
    }
}
