using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;

namespace AppRpgEtec.Services.Usuarios
{ // Define a classe UsuarioService que herda da classe Request
    public class UsuarioService : Request
    {
        // Cria uma instância privada da classe Request para fazer chamadas HTTP
        private readonly Request _request;

        // Define a URL base da API (⚠️ contém erro: "https//:" deve ser "https://")
        private const string _apiurlBase = "https://xyz.azurewebsites.net/Usuarios";

        // Construtor da classe, inicializa o objeto _request
        public UsuarioService()
        {
            _request = new Request();
        }

        // Método assíncrono para registrar um novo usuário
        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            // Define o complemento da URL para o endpoint de registro
            string urlComplementar = "/Registrar";

            // Envia os dados do usuário para a API usando POST e espera um inteiro como retorno
            await _request.PostReturnIntAsync(_apiurlBase + urlComplementar, u, string.Empty);

            // Retorna o objeto usuário recebido como parâmetro
            return u;
        }

        // Método assíncrono para autenticar um usuário
        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            // Define o complemento da URL para o endpoint de autenticação
            string urlComplementar = "/Autenticar";

            // Envia os dados do usuário para a API usando POST e recebe um objeto Usuario como resposta
            u = await _request.PostAsync(_apiurlBase + urlComplementar, u, string.Empty);

            // Retorna o objeto usuário atualizado com os dados recebidos da API
            return u;
        }
    }
}
