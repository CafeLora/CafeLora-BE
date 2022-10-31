using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Aplicacion.helpers
{
    public class BlobStorage
    {
        private readonly string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=normativaresourcestorage;AccountKey=TOH141KEGHLCHLBOMQBjXMdlD4L+8MpCYK2NQTPG+iZqxYgXeJFIIG+Ys73LnkutmK4+C/arCo/aHXjXRC6EqA==;EndpointSuffix=core.windows.net";
        private readonly CloudStorageAccount storageAccount;
        private readonly CloudBlobClient cloudBlobClient;
        private CloudBlockBlob cloudBlockBlob;
        private readonly CloudBlobContainer cloudBlobContainer;

        public BlobStorage()
        {
            if (CloudStorageAccount.TryParse(storageConnectionString, out storageAccount))
            {
                cloudBlobClient = storageAccount.CreateCloudBlobClient();

                cloudBlobContainer = cloudBlobClient.GetContainerReference("file-storage");
            }
        }

        public async Task<bool> Upload(Stream stream, string filePath)
        {
            try 
            {
                cloudBlockBlob = cloudBlobContainer.GetBlockBlobReference(filePath);

                await Task.Run(() => cloudBlockBlob.UploadFromStreamAsync(stream));

                Console.WriteLine("Upload done!");

                return true;
            }
            catch (Exception e)
            {
                throw new Exception("Ha ocurrido un error con la carga de archivos", e);
            }

        }

        public async Task<byte[]> GetFileByte(string filePath)
        {
            var blob = cloudBlobContainer.GetBlockBlobReference(filePath);

            var stream = await blob.OpenReadAsync();

            byte[] file = new byte[stream.Length];

            for (int i = 0; i < stream.Length; i++)
            {
                file[i] = (byte)stream.ReadByte();
            }

            return file;
        }
    }
}
