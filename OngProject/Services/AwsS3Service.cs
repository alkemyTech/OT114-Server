using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace OngProject.Services
{
    public class AwsS3Service
    {
        private String bucket;
        private string accessKeyId;
        private string secretAccessKey;
        private string region;
        public AwsS3Service()
        {

        }
        public AwsS3Service(IConfiguration configuration)
        {
            this.bucket = configuration["AWSS3:BUCKET"];
            this.accessKeyId = configuration["AWSS3:ACCESS_KEY_ID"];
            this.secretAccessKey = configuration["AWSS3:SECRET_ACCESS_KEY"];
            this.region = configuration["AWSS3:REGION"];
        }
        public async Task<Stream> GetFile(String filename)
        {
            var client = new AmazonS3Client(this.accessKeyId, this.secretAccessKey, this.region);
            GetObjectResponse response = await client.GetObjectAsync(this.bucket, filename);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return response.ResponseStream;
            }
            else
            {
                return null;
            }
        }
        public async Task<string> UploadFileinBucket(IFormFile image)
        {
            var client = new AmazonS3Client(this.accessKeyId, this.secretAccessKey, this.region);

            using (MemoryStream m = new MemoryStream())
            {
                await image.CopyToAsync(m);
                PutObjectRequest request = new PutObjectRequest()
                {
                    InputStream = m,
                    Key = image.FileName,
                    BucketName = this.bucket,
                    CannedACL = S3CannedACL.PublicRead
                };
                await client.PutObjectAsync(request);
            }
            string url = $"https://{this.bucket}.s3.amazonaws.com/{image.FileName}";

            return url;
        }
        public async Task<bool> DeleteFile(String filename)
        {
            var client = new AmazonS3Client(this.accessKeyId, this.secretAccessKey, this.region);
            DeleteObjectResponse response = await client.DeleteObjectAsync(this.bucket, filename);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

