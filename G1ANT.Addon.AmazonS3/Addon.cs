using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Language;

namespace G1ANT.Addon.AmazonS3
{
    [Addon(Name = "AmazonS3", Tooltip = "Addon for Amazon Web Services Simple Storage Service operations")]
    [Copyright(Author = "Marian Witkowski", Copyright = "(c) 2018 Marian Witkowski", Email = "marian.witkowski@gmail.com")]
    [License(Type = "LGPL", ResourceName = "License.txt")]
    [CommandGroup(Name = "amazons3", Tooltip = "Command connected with AWS S3 operations")]
    public class Addon : Language.Addon
    {
            public override void Initialize()
            {
                base.Initialize();
            }
    }
}
