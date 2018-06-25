using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using G1ANT.Addon.AmazonS3;

namespace Amazons3_test
{
    class Program
    {
        static void Main(string[] args)
        {
            String profileName = "test";
            String credentialFileName = @"c:\test\aws.txt";

            try
            {
                OpenCommand.Arguments arg = new OpenCommand.Arguments();
                arg.profileName = new G1ANT.Language.TextStructure(profileName);
                arg.credentialFileName = new G1ANT.Language.TextStructure(credentialFileName);
                arg.regionEndpoint = new G1ANT.Language.TextStructure("eu-central-1");
                OpenCommand oc = new OpenCommand(null);
                oc.Execute(arg);
            } catch (Exception exc) { }

            /*
            try
            {
                ListObjectsCommand.Arguments arg1 = new ListObjectsCommand.Arguments();
                arg1.bucketName = new G1ANT.Language.TextStructure("islay-mariadb-backup");
                ListObjectsCommand loc = new ListObjectsCommand(null);
                loc.Execute(arg1);
            } catch (Exception exc) { }

            try
            {
                CreateBucketCommand.Arguments arg2 = new CreateBucketCommand.Arguments();
                arg2.bucketName = new G1ANT.Language.TextStructure("giant-test2");
                CreateBucketCommand cb = new CreateBucketCommand(null);
                cb.Execute(arg2);
            } catch (Exception exc) { }


            try
            {
                WriteObjectFromTextCommand.Arguments arg3 = new WriteObjectFromTextCommand.Arguments();
                arg3.bucketName = new G1ANT.Language.TextStructure("giant-test2");
                arg3.keyName = new G1ANT.Language.TextStructure("test2.txt");
                arg3.content = new G1ANT.Language.TextStructure("Tralala lalalal lalalal!");
                WriteObjectFromTextCommand woft = new WriteObjectFromTextCommand(null);
                woft.Execute(arg3);
            }
            catch (Exception exc) { }
            */

            try
            {
                DeleteObjectCommand.Arguments arg4 = new DeleteObjectCommand.Arguments();
                arg4.bucketName = new G1ANT.Language.TextStructure("giant-test2");
                arg4.keyName = new G1ANT.Language.TextStructure("test2.txt");
                DeleteObjectCommand doc = new DeleteObjectCommand(null);
                doc.Execute(arg4);
            } catch (Exception exc)
            {

            }


            /*
            ListRegionsCommand.Arguments arg = new ListRegionsCommand.Arguments();
            ListRegionsCommand lrc = new ListRegionsCommand(null);
            lrc.Execute(arg);
            */

        }
    }
}
