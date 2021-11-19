using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;

namespace ConsoleUI
{
    public class Program
	{
		public async static Task Main(string[] args)
		{
			HttpClient httpClient = new HttpClient();

			var output = await httpClient.GetAsync("https://sdw-wsrest.ecb.europa.eu/service/data/EXR/D...SP00.A?detail=dataonly&startPeriod=2020-03-01&endPeriod=2020-03-02");

			var message = await output.Content.ReadAsStringAsync();

			XmlDocument doc = new XmlDocument();
			doc.LoadXml(message);

			string json = JsonConvert.SerializeXmlNode(doc);

			Console.WriteLine(json);
		}
	}

	public class DataSet
    {
        public List<DailyRaport> DailyRaports { get; set; }
    }

	public class DailyRaport
    {

    }

	public class DataSetHeader
	{

	}
}