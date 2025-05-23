using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace notePad.main
{
    internal class Judge0CodeRunnerService : ICodeRunnerService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://judge0-ce.p.rapidapi.com";
        private const int CSharpLanguageId = 51;

        public Judge0CodeRunnerService(string rapidApiKey)
        {
            _httpClient = new HttpClient { BaseAddress = new Uri(BaseUrl) };
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Host", "judge0-ce.p.rapidapi.com");
            _httpClient.DefaultRequestHeaders.Add("X-RapidAPI-Key", rapidApiKey);
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<string> RunCSharpCodeAsync(string code)
        {
            var payload = new
            {
                source_code = code,
                language_id = CSharpLanguageId
            };

            var content = new StringContent(JsonConvert.SerializeObject(payload));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            var response = await _httpClient.PostAsync("/submissions?base64_encoded=false&wait=true", content);

            if (!response.IsSuccessStatusCode)
            {
                throw new Exception($"API call failed with status code {response.StatusCode}");
            }

            var jsonResponse = await response.Content.ReadAsStringAsync();
            dynamic result = JsonConvert.DeserializeObject(jsonResponse);

            string output = result.stdout ?? result.compile_output ?? result.stderr ?? "No output";

            return output;
        }
    }
}
