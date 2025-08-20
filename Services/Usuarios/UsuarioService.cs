using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;

namespace AppRpgEtec.Services.Usuarios
{ // define a classe UsuarioService que herda da classe Request
    public class UsuarioService : Request
    {
        // cria uma instância privada da classe Request para fazer chamadas HTTP
        private readonly Request _request;

        // define a URL base da API 
        private const string _apiurlBase = "http://rpgsaramarcely.azurewebsites.netUsuarios";

        // construtor da classe, inicializa o objeto _request
        public UsuarioService()
        {
            _request = new Request();
        }

        // método assíncrono para registrar um novo usuário
        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            // define o complemento da URL para o endpoint de registro
            string urlComplementar = "/Registrar";

            // envia os dados do usuário para a API usando POST e espera um inteiro como retorno
            await _request.PostReturnIntAsync(_apiurlBase + urlComplementar, u, string.Empty);

            // retorna o objeto usuário recebido como parâmetro
            return u;
        }

        // método assíncrono para autenticar um usuário
        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            // define o complemento da URL para o endpoint de autenticação
            string urlComplementar = "/Autenticar";

            // envia os dados do usuário para a API usando POST e recebe um objeto Usuario como resposta
            u = await _request.PostAsync(_apiurlBase + urlComplementar, u, string.Empty);

            // retorna o objeto usuário atualizado com os dados recebidos da API
            return u;
        }
    }
}
