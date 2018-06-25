using System;
using G1ANT.Language;

namespace G1ANT.Addon.AmazonS3
{
    [Command(Name = "amazons3.writeobjectfile", Tooltip = "Load local file and save into object on AWS S3 bucket")]
    public class WriteObjectFromFileCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Bucket name")]
            public TextStructure bucketName { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Local file name")]
            public TextStructure localFileName { get; set; } = new TextStructure(string.Empty);
        }

        public WriteObjectFromFileCommand(AbstractScripter scripter) : base(scripter)
        {
        }


        public void Execute(Arguments arguments)
        {
            try
            {
                S3Settings.GetInstance().awsS3.WritingObjectFile(arguments.bucketName.Value, arguments.localFileName.Value, null);
            }
            catch (Exception exc)
            {
                throw new ApplicationException(exc.Message);
            }
        }
    }
}
