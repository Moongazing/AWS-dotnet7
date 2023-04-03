using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Amazon.S3.Util;
using System.Configuration;
using S3BucketOperations;
public class Program
{
    public static async Task Main(string[] args)
    {

        Operations operations = new Operations();

        #region CreateBucket
        await operations.CreateBucket("tunahanbucket");
        #endregion
        #region Upload
        Console.WriteLine("Insert file path:");
        string filePath = Console.ReadLine();
        if (filePath == "")
        {
            Console.WriteLine("Please add path.");
            return;
        }
        await operations.UploadFile(filePath, "tunahanbucket");
        #endregion




    }


}