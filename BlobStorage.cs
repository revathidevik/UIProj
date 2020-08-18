using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Blob;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EventHubTest
{
    public class BlobStorage
    {

        public static async Task SavePdf(string blobConnection, string filePath)
        {
            //upload file blob azure storage

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse((blobConnection));
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("BlobStorageContainername");
            CloudBlockBlob blockBlob = container.GetBlockBlobReference("JNCASR APPLICATION FORM");
            using (var fileStream = System.IO.File.OpenRead(filePath))
            {
               await blockBlob.UploadFromStreamAsync(fileStream);
            }
        }
    }
    
}
