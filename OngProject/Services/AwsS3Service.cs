using Amazon.S3;
using Amazon.S3.Model;
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
        private String bucketName;
        private IAmazonS3 awsclient;

        public AwsS3Service(IAmazonS3 amazonS3, IConfiguration configuration)
        {
            this.awsclient = amazonS3;
            this.bucketName = configuration["AWSS3:BucketName"];
        }
        public async Task<Stream> GetFile(String filename)
        {
            GetObjectResponse response = await this.awsclient.GetObjectAsync(this.bucketName, filename);

            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return response.ResponseStream;
            }
            else
            {
                return null;
            }
        }

        public async Task<bool> UploadFileinBucket(Stream stream, String filename)
        {
            PutObjectRequest request = new PutObjectRequest()
            {
                InputStream = stream,
                Key = filename,
                BucketName = this.bucketName
            };

            PutObjectResponse response = await this.awsclient.PutObjectAsync(request);
            if (response.HttpStatusCode == HttpStatusCode.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> DeleteFile(String filename)
        {
            DeleteObjectResponse response = await this.awsclient.DeleteObjectAsync(this.bucketName, filename);

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
