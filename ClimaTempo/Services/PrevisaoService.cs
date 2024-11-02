using ClimaTempo.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ClimaTempo.Services
{
    public class PrevisaoService
    {
        private HttpClient client;
        private Previsao previsao;
        private JsonSerializerOptions options;

        Uri uri = new Uri("https://brasilapi.com.br/api/cptec/v1/clima/previsao/244");
        public PrevisaoService()
        { 
            client = new HttpClient(); 
            options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            }; 
            /* Construtor com as opções */
        }

        public async Task<Previsao> GetPrevisaoById(int cityCode) 
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(uri);
                if (response.IsSuccessStatusCode) { 
                    string content = await response.Content.ReadAsStringAsync();
                    previsao = JsonSerializer.Deserialize<Previsao>(content, options);
                }            
            }
            catch (Exception ex) {
                Debug.WriteLine(ex.Message);
            }
            return previsao;
        }
    }
}
