using ClimaTempo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClimaTempo.Services
{
    public class CidadeService
    {
        private HttpClient client;
        private List<Cidade> cidades;
        private JsonSerializerOptions options;

        Uri uri = new Uri("https://brasilapi.com.br/api/cptec/v1/cidade/");

        public CidadeService()
        {
            client = new HttpClient(); 
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task<List<Cidade>> GetCidadesByName(string name)
        {
            try
            {
                Uri uri = new Uri($"https://brasilapi.com.br/api/cptec/v1/cidade/{name}");
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    cidades = JsonSerializer.Deserialize<List<Cidade>>(content, options);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return cidades;
        }

    }
}
