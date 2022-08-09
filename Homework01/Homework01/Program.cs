using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Homework01
{
    internal class Program
    {
        private static readonly HttpClient client = new();

        public static async Task Main(string[] args)
        {
            List<Task<string>> tasks = new();
            for (int i = 4; i <= 13; i++)
                tasks.Add(GetPost(i));
            await Task.WhenAll(tasks);
            using StreamWriter sw = File.AppendText("file.txt");
            foreach (Task<string> task in tasks)
            {
                if (task.Result != null)
                {
                    await sw.WriteLineAsync(task.Result);
                    await sw.WriteLineAsync();
                }
            }
        }

        private static async Task<string> GetPost(int id)
        {
            try
            {
                HttpResponseMessage httpResponse = await client.GetAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
                httpResponse.EnsureSuccessStatusCode();
                Response response = await JsonSerializer.DeserializeAsync<Response>(await httpResponse.Content.ReadAsStreamAsync());
                return response.ToString();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine($"\nException Caught! id = {id}");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }
    }
}
