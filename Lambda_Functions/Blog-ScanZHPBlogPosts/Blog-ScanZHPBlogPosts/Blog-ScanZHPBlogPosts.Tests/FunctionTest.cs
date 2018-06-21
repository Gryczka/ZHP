using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using Blog_ScanZHPBlogPosts;

namespace Blog_ScanZHPBlogPosts.Tests
{
    public class FunctionTest
    {
        [Fact]
        public async Task TestToUpperFunction()
        {

            // Invoke the lambda function and confirm that objects were retrieved with the scan.
            var function = new Function();
            var context = new TestLambdaContext();
            var scanResult = await function.FunctionHandler(context);

            Assert.NotEmpty(scanResult);
        }
    }
}
