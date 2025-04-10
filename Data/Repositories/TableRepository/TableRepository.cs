using System;
using System.Collections.Generic;
using System.Xml;
using Data.Table;

namespace Data.Repositories
{
    public class TableRepository: ITableRepository
    {
        private List<ITable> tables;

        public TableRepository(List<ITable> Tables)
        {
            this.Tables = Tables;
        }

        public List<ITable> Tables { get => Tables; set => Tables = value; }

        public ITable GetTableById(int id)
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
