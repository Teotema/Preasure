using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;
using DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DynamicDbService : IDynamicDbService
    {
        private readonly AmazonDynamoDBClient _client;
        public DynamicDbService()
        {
            AWSCredentials credentials =
              new BasicAWSCredentials("AKIAUOMXFRQA7VTVSUHC", "7hsN9YIkHwpi7fgMU4pLDb+mgDDEzxRo4wh54nDG");
            RegionEndpoint endpoint = RegionEndpoint.USEast1;
            _client = new AmazonDynamoDBClient(credentials, endpoint);
        }
        public async Task<PresureDto[]> GetPresuares()
        {
            var preassuresQueryResponse = await _client.ScanAsync(new ScanRequest()
            {
                TableName = "PreassuresNew"
            });

            var k = preassuresQueryResponse.Items.Select(x => x["device_data "].M).Select(x => new PresureDto()
            {
                Start = DateTime.Parse(x["Start"].S),
                End = DateTime.Parse(x["End"].S),
                Presures = x["Presures"].L.Select(e => float.Parse(e.N, CultureInfo.InvariantCulture.NumberFormat)).ToList()

            }).ToArray();

            return k;
           
        }
    }
}
