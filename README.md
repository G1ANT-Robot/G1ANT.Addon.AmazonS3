# G1ANT.Addon.AmazonS3
 
**Amazon S3 Addon for G1ANT.Robot** 

First of all you, must configure access for using S3 in AWS.
See more information at [AWS access key best practices](https://docs.aws.amazon.com/general/latest/gr/aws-access-keys-best-practices.html)

Then prepare credential file in format described below:

```
[profile_name]
aws_access_key_id = XXXXXXXXXXXXXXXXXX
aws_secret_access_key = YYYYYYYYYYYYYYYYYYYYYYY
```
and save into local file

**Simple usage** 

```
amazons3.init profilename ‴profile_name‴ credentialfilename ‴c:\test\aws.txt‴ regionendpoint ‴eu-central-1‴

amazons3.createbucket bucketname ‴g1ant-addon-test‴

amazons3.writeobjecttext bucketname ‴g1ant-addon-test‴ keyname ‴hello.txt‴ content ‴Hello world!‴

amazons3.readobject bucketname ‴g1ant-addon-test‴ keyname ‴hello.txt‴ localfilename ‴c:\test\hello.txt‴

amazons3.listobjects bucketname ‴g1ant-addon-test‴ result ♥res

```
