using FluentEmail.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
	public class Program
	{
		public async static Task Main(string[] args)
		{
			List<string> names = new List<string>() { "Jakub", "Marek", "Paweł" };

			var output = names.Aggregate((a, b) => a = $"{a},{b}");

			string tags = "Jakub,Marek,Patryk";

			List<Tag> tagsList = tags.Split(',').Select(e => new Tag() { Name = e }).ToList();
		}
	}

	public class Tag
    {
        public string Name { get; set; }
    }
}