using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Data.Table;

namespace Data.Repositories
{
    interface ITableRepository
    {
        ITable GetTableById(int id); 
    }
}
