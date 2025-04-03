using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Model;

namespace Data.TableRepository
{
    interface ITableRepository
    {
        Table GetTableById(int id); 
    }
}
