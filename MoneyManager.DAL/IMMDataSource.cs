using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyManager.DAL
{
    public interface IMMDataSource
    {
        IQueryable<Record> Records { get; }
        IQueryable<Category> Categories { get; }

    }
}
