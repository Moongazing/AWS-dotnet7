using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3BucketOperations
{
    public class Operations : IDisposable
    {
        AmazonS3Client client;
        const string bucketName = "tunahanbucket";
        public BasicAWSCredentials credentials = new (ConfigurationManager.AppSettings["accessId"],
                                                    ConfigurationManager.AppSettings["secretKey"]);


        public Operations()
        {
            client = new AmazonS3Client(credentials,Amazon.RegionEndpoint.EUWest1);
        }
        public async Task CreateBucket(string bucketName)
        {
            var bucketRequest = new PutBucketRequest
            {
                BucketName = bucketName,
                UseClientRegion = true,
            };
            if (AmazonS3Util.DoesS3BucketExistAsync(client, bucketRequest.BucketName).Result)
            {
                Console.WriteLine("This bucket already exists.");

            }
            else
            {
                var bucketResponse = await client.PutBucketAsync(bucketRequest);

                if (bucketResponse.HttpStatusCode == System.Net.HttpStatusCode.OK)
                {
                    Console.WriteLine("Bucket created successfully.");
                }
            }
        }
        public async Task UploadFile(string path,string bucketName)
        {
            var transferUtility = new TransferUtility(client);
            await transferUtility.UploadAsync(path, bucketName);
            Console.WriteLine("File will upload.");
        
        }

        public void Dispose()
        {
            client.Dispose();
        }
    }
}
