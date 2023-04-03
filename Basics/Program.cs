using Amazon.Runtime;
using Amazon.S3;
using System.Configuration;
using System.Drawing;

internal class Program
{
    public static async Task Main(string[] args)
    {
        await ListBucketsAsync();
    }
    public static async Task ListBucketsAsync()
    {
        var s3Client = new AmazonS3Client(ConfigurationManager.AppSettings["accessId"],
                                          ConfigurationManager.AppSettings["secretKey"],
                                          Amazon.RegionEndpoint.EUWest1);

        var response = await s3Client.ListBucketsAsync();

        foreach (var bucket in response.Buckets)
        {
            Console.WriteLine($"Bucket Name: {bucket.BucketName}\nCreationDate:{bucket.CreationDate.ToString()}");
        }
    }
}