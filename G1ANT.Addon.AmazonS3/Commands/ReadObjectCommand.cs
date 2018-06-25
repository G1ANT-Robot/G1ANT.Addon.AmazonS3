using System;
using G1ANT.Language;

namespace G1ANT.Addon.AmazonS3
{
    [Command(Name = "amazons3.readobject", Tooltip = "Read object from AWS S3 bucket and save to local file")]
    public class ReadObjectCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Bucket name")]
            public TextStructure bucketName { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Key name")]
            public TextStructure keyName { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Local file name")]
            public TextStructure localFileName { get; set; } = new TextStructure(string.Empty);
        }

        public ReadObjectCommand(AbstractScripter scripter) : base(scripter)
        {
        }


        public void Execute(Arguments arguments)
        {
            try
            {
                S3Settings.GetInstance().awsS3.ReadingObject(arguments.bucketName.Value, arguments.keyName.Value, arguments.localFileName.Value);
            }
            catch (Exception exc)
            {
                throw new ApplicationException(exc.Message);
            }
        }
    }
}
