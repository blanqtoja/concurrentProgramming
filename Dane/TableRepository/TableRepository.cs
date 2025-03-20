using System;
using System.Collections.Generic;
using System.Xml;
using Model;

namespace Dane.TableRepository
{
    public class TableRepository: ITableRepository
    {
        private List<Table> tables;

        public TableRepository(List<Table> Tables)
        {
            this.Tables = Tables;
        }

        public List<Table> Tables { get => Tables; set => Tables = value; }

        public Table GetTableById(int id)
        {
            for (int i = 0; i < Tables.Count; i++)
            {
                if (Tables[i].Id == id)
                {
                    return Tables[i];
                }
            }

            return null;
        }
    }
}
