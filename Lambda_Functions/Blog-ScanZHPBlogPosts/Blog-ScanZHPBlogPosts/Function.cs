using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Blog_ScanZHPBlogPosts
{
    public class Function
    {

        /// <summary>
        /// A simple scan of the blog posts to find posts by blog prefix
        /// (Blog posts are indexed by <blog-name>-<blog-post-date>, so a scan of
        /// indexes that begin w/ the blog-name will surface all blog posts.
        /// </summary>
        /// <param name="context"></param>
        /// <returns>
        /// Returns a list of blog posts for the zhp blog.
        /// </returns>
        public async Task<List<Dictionary<string, AttributeValue>>> FunctionHandler(ILambdaContext context)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();//Initializing the DDB Client
  
            //Creating the request to filter for blog posts who's index begins with 'zhp-'
                //Which within our projects naming scheme equates to finding posts to the zhp blog
            var request = new ScanRequest
            {
                TableName = "zhp-blog_posts",
                FilterExpression = "begins_with(#blog, :blog_name)",
                ExpressionAttributeNames = new Dictionary<string, string>{
                    { "#blog", "blog_name-date"}
                },
                ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
                    {":blog_name", new AttributeValue { S =  "zhp-" }}
                }
            };

            var response = await client.ScanAsync(request);//Retrieving the response

            return response.Items;//Returning blog post documents from DDB
        }
    }
}
