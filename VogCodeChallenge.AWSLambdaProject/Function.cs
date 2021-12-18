using System;
using System.IO;
using System.Text;

using Amazon.Lambda.Core;
using Amazon.Lambda.DynamoDBEvents;
using Amazon.DynamoDBv2.Model;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using System.Collections.Generic;
using Amazon.Runtime;
using Amazon;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.SystemTextJson.DefaultLambdaJsonSerializer))]

namespace VogCodeChallenge.AWSLambdaProject
{
  /// <summary>
  /// Lambda Function - To Create a table if not exist then insert a record. Monitor DB event. Log the Keys of each item.
  /// </summary>
    public class Function
    {
    public async Task FunctionHandler(DynamoDBEvent dynamoEvent, ILambdaContext context)
    {
      context.Logger.LogLine($"Beginning to process {dynamoEvent.Records.Count} records...");

      // Create  dynamodb client  
      //NOTE: We can provide the AccessKey and SecretKey to access the DynamoDB.
      var dynamoDbClient = new AmazonDynamoDBClient(
          new BasicAWSCredentials("", ""),
          new AmazonDynamoDBConfig
          {
            RegionEndpoint = RegionEndpoint.APSoutheast2
          });

      //Create Table if it Does Not Exists. Providing some sample value like "EmployeeLog" as a table name.
      await CreateTable(dynamoDbClient, "EmployeeLog");

      // Insert Test record in dynamodbtable
      LambdaLogger.Log("Insert record in the table");
      await dynamoDbClient.PutItemAsync("EmployeeLog", new Dictionary<string, AttributeValue>
    {
        { "FirstName", new AttributeValue("TestEmployee1FirstName") },
        { "LastName", new AttributeValue("TestEmployee2FirstName") },
     });

      //Logging the DynamoDB event.Logging the primary key value in the dynamoDB.
      foreach (var record in dynamoEvent.Records)
      {
        context.Logger.LogLine($"Event ID: {record.EventID}");
        context.Logger.LogLine($"Key: {record.Dynamodb.Keys}");
      }
      context.Logger.LogLine("Stream processing complete.");
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