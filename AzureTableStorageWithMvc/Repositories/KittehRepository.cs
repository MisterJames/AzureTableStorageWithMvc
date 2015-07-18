using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AzureTableStorageWithMvc.Models;
using Microsoft.WindowsAzure;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureTableStorageWithMvc.Repositories
{
    public class KittehRepository : ITableStorageRepository<KittehEntity>
    {
        private readonly CloudTableClient _client;

        public KittehRepository()
        {
            var storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("StorageConnectionString"));
            _client = storageAccount.CreateCloudTableClient();
        }

        public void Insert(KittehEntity entity)
        {
            var kittehTable = _client.GetTableReference("PicturesOfKittehs");
            var insert = TableOperation.Insert(entity);
            kittehTable.Execute(insert);
        }

        public void Update(KittehEntity entity)
        {
            var kittehTable = _client.GetTableReference("PicturesOfKittehs");
            var insert = TableOperation.Replace(entity);
            kittehTable.Execute(insert);
        }

        public void Delete(KittehEntity entity)
        {
            var kittehTable = _client.GetTableReference("PicturesOfKittehs");
            var insert = TableOperation.Delete(entity);
            kittehTable.Execute(insert);
        }

        public IEnumerable<KittehEntity> GetByPartition(string partitionKey)
        {
            var kittehTable = _client.GetTableReference("PicturesOfKittehs");
            var kittehQuery = new TableQuery<KittehEntity>()
                            .Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, partitionKey));
            var kittehs = kittehTable.ExecuteQuery(kittehQuery).ToList();

            return kittehs;
        }
    }
}