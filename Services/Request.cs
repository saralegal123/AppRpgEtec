using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AppRpgEtec.Services
{
    public class Request
    {
        // Envia uma requisição POST com um objeto e retorna um inteiro como resposta
        public async Task<int> PostReturnIntAsync<TResult>(string uri, TResult data, string token)
        {
            HttpClient httpClient = new HttpClient();

            // Adiciona o token de autenticação no header
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Serializa o objeto para JSON e define o tipo de conteúdo
            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Envia a requisição POST
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            // Lê o conteúdo da resposta como string
            string serialized = await response.Content.ReadAsStringAsync();

            // Se a resposta for OK, converte a string para inteiro
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                return int.Parse(serialized);
            else
                // Se não for OK, lança exceção com o conteúdo da resposta
                throw new Exception(serialized);
        }

        // Envia uma requisição POST com um objeto e retorna um objeto desserializado como resposta
        public async Task<TResult> PostAsync<TResult>(string uri, TResult data, string token)
        {
            HttpClient httpClient = new HttpClient();

            // Adiciona o token de autenticação no header
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            // Serializa o objeto para JSON e define o tipo de conteúdo
            var content = new StringContent(JsonConvert.SerializeObject(data));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            // Envia a requisição POST
            HttpResponseMessage response = await httpClient.PostAsync(uri, content);

            // Lê o conteúdo da resposta como string
            string serialized = await response.Content.ReadAsStringAsync();
            TResult result = data;

            // Se a resposta for OK, desserializa o conteúdo para o tipo TResult
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
                result = await Task.Run(() => JsonConvert.DeserializeObject<TResult>(serialized));
            else
                // Se não for OK, lança exceção com o conteúdo da resposta
                throw new Exception(serialized);

            return result;
        }

    }

}
}
