using System;
using System.Collections.Generic;
using System.Text;

namespace TKBase.Framework.Dapper
{
    public class TransactionEntity 
    {
        internal List<dynamic> AddEntity = new List<dynamic>();

        internal List<dynamic> UpdateEntity = new List<dynamic>();

        public void AddTs<T>(T entity)
        {
            this.AddEntity.Add(entity);
        }
        public void UpdateTs<T>(T entity)
        {
            this.UpdateEntity.Add(entity);
        }
    }
}
