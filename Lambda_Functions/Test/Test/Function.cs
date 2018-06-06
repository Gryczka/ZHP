using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace Test
{
    public class Function
    {
        
        /// <summary>
        /// A simple function that takes a string and does a ToUpper
        /// </summary>
        /// <param name="input"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string input, ILambdaContext context)
        {
            AmazonDynamoDBClient client = new AmazonDynamoDBClient();
            string tableName = "zhp-blog_posts";

            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "Id", new AttributeValue { S = "202" } } },
            };
            var response = client.GetItemAsync(request);

            // Check the response.
            var result = response.Result;
            var attributeMap = result.Item; // Attribute list in the response.
            return attributeMap["Id"].S;
        }
    }
}
