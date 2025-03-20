using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Model;

namespace Dane.TableRepository
{
    interface ITableRepository
    {
        Table GetTableById(int id); 
    }
}
