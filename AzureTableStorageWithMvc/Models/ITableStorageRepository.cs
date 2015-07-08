using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureTableStorageWithMvc.Models
{
    public interface ITableStorageRepository<T> where T : TableEntity
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetByPartition(string partitionKey);
    }
}
