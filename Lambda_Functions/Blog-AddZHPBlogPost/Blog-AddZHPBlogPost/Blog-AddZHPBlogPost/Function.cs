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

        /// <summary>
        /// A function to Add a ZHP Blog Post
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// 
        private static void CreateItem()
        {
            var request = new PutItemRequest
            {
                TableName = tableName,
                Item = new Dictionary<string, AttributeValue>()
            {
                { "blog_name-date", new AttributeValue {
                      N = "1000"
                  }},
                { "author-post_name", new AttributeValue {
                      S = "Book 201 Title"
                  }},
                { "content", new AttributeValue {
                      S = "11-11-11-11"
                  }}
            }
            };
            client.PutItem(request);
        }
        public string FunctionHandler(string input, ILambdaContext context)
        {
            return input?.ToUpper();
        }
    }
}
