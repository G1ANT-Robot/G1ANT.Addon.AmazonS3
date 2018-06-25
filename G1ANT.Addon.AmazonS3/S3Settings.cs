using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1ANT.Addon.AmazonS3
{
    public sealed class S3Settings
    {

        public AmazonS3Operations awsS3 { get; set; }

        private S3Settings()
        {
        }

        private static readonly S3Settings instance = null;
        static S3Settings()
        {
            instance = new S3Settings();
        }

        public static S3Settings GetInstance()
        {
            return instance;
        }

    }
}
