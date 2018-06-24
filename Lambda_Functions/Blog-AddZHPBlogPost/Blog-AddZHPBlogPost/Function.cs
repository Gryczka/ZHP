using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using Amazon.SecurityToken;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Blog_AddZHPBlogPost
{
    public class Function
    {
        private static AmazonDynamoDBClient client = new AmazonDynamoDBClient();
        private static string tableName = "zhp-blog_posts";
        private static string blogPrefix = "zhp-";
        private static string date = DateTime.Today.ToString("yyyymmdd");
        /// <summary>
        /// A function to Add a ZHP Blog Post
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// 
        private static void CreateItem(string author, string postName, string content)
        {
            var request = new PutItemRequest
            {
                TableName = tableName,
                Item = new Dictionary<string, AttributeValue>()
            {
                { "blog_name-date", new AttributeValue {
                      S = blogPrefix + date
                  }},
                { "author-post_name", new AttributeValue {
                      S = author + "-" + postName
                  }},
                { "content", new AttributeValue {
                      S = content
                  }}
            }
            };
            client.PutItem(request);
        }
        public string FunctionHandler(object input, ILambdaContext context)
        {
            CreateItem(input["author"], input["postName"], input["content"]);
            return "success";
        }
    }
}
