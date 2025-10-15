using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private const string _apiUrlBase = "https://rpgsaramarcely.azurewebsites.net/Usuarios";
        
        // construtor da classe, inicializa o objeto _request
        public UsuarioService()
        {
            _request = new Request();
        }

        private string _token;
        public UsuarioService(string token)
        {
            _request = new Request();
            _token = token;
        }

        // método assíncrono para registrar um novo usuário
        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            // define o complemento da URL para o endpoint de registro
            string urlComplementar = "/Registrar";

            // envia os dados do usuário para a API usando POST e espera um inteiro como retorno
           u.Id = await _request.PostReturnIntAsync(_apiUrlBase + urlComplementar, u, string.Empty);

            // retorna o objeto usuário recebido como parâmetro
            return u;
        }

        // método assíncrono para autenticar um usuário
        public async Task<Usuario> PostAutenticarUsuarioAsync(Usuario u)
        {
            // define o complemento da URL para o endpoint de autenticação
            string urlComplementar = "/Autenticar";

            // envia os dados do usuário para a API usando POST e recebe um objeto Usuario como resposta
            u = await _request.PostAsync(_apiUrlBase + urlComplementar, u, string.Empty);

            // retorna o objeto usuário atualizado com os dados recebidos da API
            return u;
        }
        public async Task<int> PutAtualizarLocalizacaoAsync(Usuario u)
        {
            string urlComplementar = "/AtualizarLocalizacao";
            var result = await _request.PutAsync(_apiUrlBase + urlComplementar, u, _token);
            return result;
        }
        //using System.Collections.ObjectModel
        public async Task<ObservableCollection<Usuario>> GetUsuariosAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Usuario> listaUsuarios = await
            _request.GetAsync<ObservableCollection<Models.Usuario>>(_apiUrlBase + urlComplementar,
            _token);
            return listaUsuarios;
        }
    }
}
