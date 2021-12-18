using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Lambda.Core;
using Amazon.Runtime;
using VogCodeChallenge.API.Model;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace VogCodeChallenge.AWSLambda
{
  public class Function
  {

    /// <summary>
    /// A simple function that takes employee model request and put an entry in a table.
    /// </summary>
    /// <param name="input"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public async Task FunctionHandler(Employee employee, ILambdaContext context)
    {
      //Write Log to Cloud Watch using Console.WriteLline.    
      Console.WriteLine("Execution started for function -  {0} at {1}",
                          context.FunctionName, DateTime.Now);

      // Create  dynamodb client  
      //NOTE: We can provider the AccessKey and SecretKey to access the DynamoDB.
      var dynamoDbClient = new AmazonDynamoDBClient(
          new BasicAWSCredentials("AKIAR7JNQR4L6NEKGY2F", "S9dEbmCRuj/apERydf/KVpqdnlqdzpztnDfsYPXf"),
          new AmazonDynamoDBConfig
          {
            RegionEndpoint = RegionEndpoint.APSoutheast2
          });

      //Create Table if it Does Not Exists  
      await CreateTable(dynamoDbClient, "EmployeeLog");

      // Insert record in dynamodbtable  
      LambdaLogger.Log("Insert record in the table");
      await dynamoDbClient.PutItemAsync("EmployeeLog", new Dictionary<string, AttributeValue>
    {
        { "FirstName", new AttributeValue(employee.FirstName) },
        { "LastName", new AttributeValue(employee.LastName) },
     });

      //Write Log to cloud watch using context.Logger.Log Method  
      Console.WriteLine(string.Format("Finished execution for function -- {0} at {1}",
                         context.FunctionName, DateTime.Now));
    }
    private async Task CreateTable(IAmazonDynamoDB amazonDynamoDBclient, string tableName)
    {
      //Write Log to Cloud Watch using LambdaLogger.Log Method  
      LambdaLogger.Log(string.Format("Creating {0} Table", tableName));

      var tableCollection = await amazonDynamoDBclient.ListTablesAsync();

      if (!tableCollection.TableNames.Contains(tableName))
        await amazonDynamoDBclient.CreateTableAsync(new CreateTableRequest
        {
          TableName = tableName,
          KeySchema = new List<KeySchemaElement> {
                      { new KeySchemaElement { AttributeName="FirstName",  KeyType= KeyType.HASH }},
                      new KeySchemaElement { AttributeName="LastName",  KeyType= KeyType.RANGE }
                  },
          AttributeDefinitions = new List<AttributeDefinition> {
                      new AttributeDefinition { AttributeName="FirstName", AttributeType="S" },
                      new AttributeDefinition { AttributeName ="LastName",AttributeType="S"}
               },
          ProvisionedThroughput = new ProvisionedThroughput
          {
            ReadCapacityUnits = 5,
            WriteCapacityUnits = 5
          },
        });
    }
  }
}
