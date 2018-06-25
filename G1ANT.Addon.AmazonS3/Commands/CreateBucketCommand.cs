using System;
using G1ANT.Language;

namespace G1ANT.Addon.AmazonS3
{
    [Command(Name = "amazons3.createbucket", Tooltip = "Create AWS S3 bucket")]
    public class CreateBucketCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Bucket name")]
            public TextStructure bucketName { get; set; } = new TextStructure(string.Empty);

        }

        public CreateBucketCommand(AbstractScripter scripter) : base(scripter)
        {
        }


        public void Execute(Arguments arguments)
        {
            try
            {
                S3Settings.GetInstance().awsS3.CreateBucket(arguments.bucketName.Value);
            }
            catch (Exception exc)
            {
                throw new ApplicationException(exc.Message);
            }
        }
    }
}
