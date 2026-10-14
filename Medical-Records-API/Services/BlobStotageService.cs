using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using ClinicalHistory.Models;
using ClinicalHistory.Interfaces;

namespace MedicalRecordsAPI.Services
{
    public class BlobStorageService : IBlobStorageService
    {
        private readonly BlobContainerClient _containerClient;

        public BlobStorageService(IConfiguration configuration)
        {
            string accountName =
                configuration["AzureStorage:AccountName"]!;

            string accountKey =
                configuration["AzureStorage:AccountKey"]!;

            string containerName =
                configuration["AzureStorage:ContainerName"]!;

            string connectionString =
                $"DefaultEndpointsProtocol=https;" +
                $"AccountName={accountName};" +
                $"AccountKey={accountKey};" +
                $"EndpointSuffix=core.windows.net";

            BlobServiceClient blobServiceClient =
                new BlobServiceClient(connectionString);

            _containerClient =
                blobServiceClient.GetBlobContainerClient(containerName);
        }

        public async Task<List<MedicalRecord>> GetMedicalRecordsBySSNAsync(
    string ssn)
        {
            var records = new List<MedicalRecord>();

            string prefix = $"{ssn}/";

            await foreach (var blobItem in _containerClient.GetBlobsAsync(
                traits: BlobTraits.None,
                states: BlobStates.None,
                prefix: prefix,
                cancellationToken: CancellationToken.None))
            {
                BlobClient blobClient =
                    _containerClient.GetBlobClient(blobItem.Name);

                string sasUrl = blobClient.GenerateSasUri(
                    BlobSasPermissions.Read,
                    DateTimeOffset.UtcNow.AddMinutes(30)
                ).ToString();

                records.Add(new MedicalRecord
                {
                    FileName = Path.GetFileName(blobItem.Name),
                    BlobName = blobItem.Name,
                    Url = sasUrl
                });
            }

            return records;
        }
    }
}