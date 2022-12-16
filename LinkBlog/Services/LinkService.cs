using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LinkBlog.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkService : ControllerBase
    {
        private readonly HttpClient _http;

        public LinkService(HttpClient http)
        {
            _http = http;
        }

        [HttpPost]
        public async Task<List<string>> GetLinks([FromForm] string url)
        {
            var result = new List<string>();
            try
            {
                var req = await _http.GetAsync(url);
                var stream = req.Content.ReadAsStreamAsync();
                var html = new HtmlDocument();
                html.Load(stream.Result);
                var selections = html.DocumentNode.SelectNodes("//a[@href]");

                foreach (var x in selections)
                {
                    result.Add(GetUrl(url, x.Attributes["href"].Value));
                }
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return result;
        }

        public string GetUrl(string baseaurl, string url)
        {
            var uri = new Uri(url, UriKind.RelativeOrAbsolute);
            if (!uri.IsAbsoluteUri)
                uri = new Uri(new Uri(baseaurl), uri);
            return uri.ToString();
        }
    }

}
