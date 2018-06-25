using System;
using System.Collections.Generic;
using System.IO;
using Amazon;
using Amazon.Runtime;
using Amazon.S3;
using Amazon.S3.Model;

namespace G1ANT.Addon.AmazonS3
{
    public class AmazonS3Operations
    {
        private AmazonS3Client client;

        public AmazonS3Operations(String profileName, String credentialFileName, String region)
        {
            /*
             * Morea about AWS Access Keys best practices
             * https://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html
             * 
             */
            var credentials = new StoredProfileAWSCredentials(profileName, credentialFileName);
            client = new AmazonS3Client(credentials, RegionEndpoint.GetBySystemName(region));
        }

        
        public List<String> ListingObjects(String bucketName)
        {
            List<String> objects = new List<string>(100);
            try
            {
                ListObjectsRequest request = new ListObjectsRequest();
                request.BucketName = bucketName;

                ListObjectsResponse listResponse;
                do
                {
                    listResponse = client.ListObjects(request);
                    foreach (S3Object obj in listResponse.S3Objects)
                    {
                        //Console.WriteLine("Object - " + obj.Key);
                        //Console.WriteLine(" Size - " + obj.Size);
                        //Console.WriteLine(" LastModified - " + obj.LastModified);
                        //Console.WriteLine(" Storage class - " + obj.StorageClass);
                        objects.Add(obj.Key);
                    }
                    request.Marker = listResponse.NextMarker;
                } while (listResponse.IsTruncated);
                return objects;
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Please check the provided AWS Credentials.\r\nIf you haven't signed up for Amazon S3, please visit http://aws.amazon.com/s3");
                }
                else
                {
                    throw new Exception(String.Format("An error occurred with the message '{0}' when listing objects ", amazonS3Exception.Message));
                }
            }
        }

        public void ReadingObject(String bucketName, String keyName, String dest = null)
        {
            try
            {
                GetObjectRequest request = new GetObjectRequest()
                {
                    BucketName = bucketName,
                    Key = keyName
                };

                using (GetObjectResponse response = client.GetObject(request))
                {
                    string title = response.Metadata["x-amz-meta-title"];
                    Console.WriteLine("The object's title is {0}", title);
                    if (dest == null)
                    {
                        dest = keyName;
                    }
                    if (File.Exists(dest))
                    {
                        File.Delete(dest);
                    }
                    response.WriteResponseStreamToFile(dest);
                }
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Please check the provided AWS Credentials.\r\nIf you haven't signed up for Amazon S3, please visit http://aws.amazon.com/s3");
                }
                else
                {
                    throw new Exception(String.Format("An error occurred with the message '{0}' when reading an object", amazonS3Exception.Message));
                }
            }
        }


        public void DeletingObject(String bucketName, String keyName)
        {
            try
            {
                DeleteObjectRequest request = new DeleteObjectRequest()
                {
                    BucketName = bucketName,
                    Key = keyName
                };

                client.DeleteObject(request);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Please check the provided AWS Credentials.\r\nIf you haven't signed up for Amazon S3, please visit http://aws.amazon.com/s3");
                }
                else
                {
                    throw new Exception(String.Format("An error occurred with the message '{0}' when deleting an object", amazonS3Exception.Message));
                }
            }
        }


        public void WritingObjectContent(String bucketName, String keyName, string contentBody, List<KeyValuePair<string, string>> extraMetadata = null)
        {
            try
            {
                PutObjectRequest request = new PutObjectRequest()
                {
                    ContentBody = contentBody,
                    BucketName = bucketName,
                    Key = keyName
                };
                PutObjectResponse response = client.PutObject(request);

                if (extraMetadata != null && extraMetadata.Count > 0)
                {
                    // put a more complex object with some metadata and http headers.
                    PutObjectRequest titledRequest = new PutObjectRequest()
                    {
                        BucketName = bucketName,
                        Key = keyName
                    };
                    foreach (KeyValuePair<string, string> md in extraMetadata)
                    {
                        titledRequest.Metadata.Add(md.Key, md.Value);
                    }
                    client.PutObject(titledRequest);
                }

            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Please check the provided AWS Credentials.\r\nIf you haven't signed up for Amazon S3, please visit http://aws.amazon.com/s3");
                }
                else
                {
                    throw new Exception(String.Format("An error occurred with the message '{0}' when writing an object", amazonS3Exception.Message));
                }
            }
        }



        public void WritingObjectFile(String bucketName, string filePath, List<KeyValuePair<string, string>> extraMetadata = null)
        {
            try
            {
                PutObjectRequest request = new PutObjectRequest()
                {
                    FilePath = filePath,
                    BucketName = bucketName,
                    Key = Path.GetFileName(filePath)
                };
                PutObjectResponse response = client.PutObject(request);

                if (extraMetadata != null && extraMetadata.Count > 0)
                {
                    // put a more complex object with some metadata and http headers.
                    PutObjectRequest titledRequest = new PutObjectRequest()
                    {
                        BucketName = bucketName,
                        Key = Path.GetFileName(filePath)
                    };
                    foreach (KeyValuePair<string, string> md in extraMetadata)
                    {
                        titledRequest.Metadata.Add(md.Key, md.Value);
                    }
                    client.PutObject(titledRequest);
                }

            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null &&
                    (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") ||
                    amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Please check the provided AWS Credentials.\r\nIf you haven't signed up for Amazon S3, please visit http://aws.amazon.com/s3");
                }
                else
                {
                    throw new Exception(String.Format("An error occurred with the message '{0}' when writing an object", amazonS3Exception.Message));
                }
            }
        }


        public void CreateBucket(String bucketName)
        {
            try
            {
                PutBucketRequest request = new PutBucketRequest();
                request.BucketName = bucketName;
                client.PutBucket(request);
            }
            catch (AmazonS3Exception amazonS3Exception)
            {
                if (amazonS3Exception.ErrorCode != null && (amazonS3Exception.ErrorCode.Equals("InvalidAccessKeyId") || amazonS3Exception.ErrorCode.Equals("InvalidSecurity")))
                {
                    throw new Exception("Please check the provided AWS Credentials.\r\nIf you haven't signed up for Amazon S3, please visit http://aws.amazon.com/s3");
                }
                else
                {
                    throw new Exception(String.Format("An error, number {0}, occurred when creating a bucket with the message '{1}", amazonS3Exception.ErrorCode, amazonS3Exception.Message));
                }
            }
        }


    }
}
