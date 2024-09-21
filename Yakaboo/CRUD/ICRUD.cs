using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yakaboo.Models;

namespace Yakaboo.CRUD
{
    public interface ICRUD
    {
        void Add(Context context, AddOrEdit addOrEditForm);
        object Select(Context context, string text);
        void Update(Context context, AddOrEdit addOrEditForm);
        void Delete(Context context);
    }
}