using System;
using System.Collections.Generic;
using System.Text;
using Data.Table;

namespace Logic.Factories.TableFactory
{
    public interface ITableFactory
    {
        ITable MakeTable(int id, string color, int width, int height, int minWidth, int minHeight);
    }
}
