using System;
using G1ANT.Language;

namespace G1ANT.Addon.AmazonS3
{
    [Command(Name = "amazons3.init", Tooltip = "Init S3 client connection")]
    public class OpenCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument(Required = true, Tooltip = "Profile name")]
            public TextStructure profileName { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Credential file name")]
            public TextStructure credentialFileName { get; set; } = new TextStructure(string.Empty);

            [Argument(Required = true, Tooltip = "Region")]
            public TextStructure regionEndpoint { get; set; } = new TextStructure(string.Empty);

        }

        public OpenCommand(AbstractScripter scripter) : base(scripter)
        {
        }


        public void Execute(Arguments arguments)
        {
            try
            {
                S3Settings.GetInstance().awsS3 = new AmazonS3Operations(arguments.profileName.Value, arguments.credentialFileName.Value, arguments.regionEndpoint.Value);
            }
            catch (Exception exc)
            {
                throw new ApplicationException($"Error occured while connecting to AWS S3", exc);
            }
        }
    }
}
