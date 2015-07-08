using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.WindowsAzure.Storage.Table;

namespace AzureTableStorageWithMvc.Models
{
    public class KittehEntity : TableEntity
    {
        public KittehEntity(string kittehType, string kittehName)
        {
            this.PartitionKey = kittehType;
            this.RowKey = kittehName;
        }

        public KittehEntity() { }

        public string ImageUrl { get; set; }
    }

}