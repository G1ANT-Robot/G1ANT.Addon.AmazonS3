using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.AmazonS3
{
    [Command(Name = "amazons3.writeobjecttext", Tooltip = "Save text into object on AWS S3 bucket")]
    public class WriteObjectFromTextCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Bucket name")]
            public TextStructure bucketName { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Key name in bucket")]
            public TextStructure keyName { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Object's content")]
            public TextStructure content { get; set; } = new TextStructure(string.Empty);

        }

        public WriteObjectFromTextCommand(AbstractScripter scripter) : base(scripter)
        {
        }


        public void Execute(Arguments arguments)
        {
            try
            {
                S3Settings.GetInstance().awsS3.WritingObjectContent(arguments.bucketName.Value, arguments.keyName.Value, arguments.content.Value, null);
            }
            catch (Exception exc)
            {
                throw new ApplicationException(exc.Message);
            }
        }
    }
}
