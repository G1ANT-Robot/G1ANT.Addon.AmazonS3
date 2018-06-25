using System;
using G1ANT.Language;

namespace G1ANT.Addon.AmazonS3
{
    [Command(Name = "amazons3.deleteobject", Tooltip = "Delete object from AWS S3 bucket")]
    public class DeleteObjectCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Bucket name")]
            public TextStructure bucketName { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Key name")]
            public TextStructure keyName { get; set; } = new TextStructure(string.Empty);
        }

        public DeleteObjectCommand(AbstractScripter scripter) : base(scripter)
        {
        }


        public void Execute(Arguments arguments)
        {
            try
            {
                S3Settings.GetInstance().awsS3.DeletingObject(arguments.bucketName.Value, arguments.keyName.Value);
            }
            catch (Exception exc)
            {
                throw new ApplicationException(exc.Message);
            }
        }
    }
}
