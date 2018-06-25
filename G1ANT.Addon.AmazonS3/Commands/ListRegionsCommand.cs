using System;
using System.Collections.Generic;
using G1ANT.Language;

namespace G1ANT.Addon.AmazonS3
{
    [Command(Name = "amazons3.listregions", Tooltip = "List endpoints regions for AWS")]
    public class ListRegionsCommand : Command
    {
        public class Arguments : CommandArguments
        {
            [Argument]
            public VariableStructure Result { get; set; } = new VariableStructure("result");
        }

        public ListRegionsCommand(AbstractScripter scripter) : base(scripter)
        {
        }


        public void Execute(Arguments arguments)
        {
            try
            {
                ListStructure result = new ListStructure(new System.Collections.Generic.List<object>());
                List<String> regions = AmazonS3Helper.GetRegionsList();
                foreach(string region in regions)
                {
                    result.Value.Add(region);
                }
                Scripter.Variables.SetVariableValue(arguments.Result.Value, result);
            }
            catch (Exception exc)
            {
                throw new ApplicationException(exc.Message);
            }
        }
    }
}
