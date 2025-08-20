using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;

namespace AppRpgEtec.Services.Usuario
{
    public class UsuarioService : Request
    {
        private readonly Request _request;
        private const string _apiurlBase = "https//:xyz.azurewebsites.net/Usuarios";

        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Registrar";
            await _request.PostReturnIntAsync(_apiurlBase + urlComplementar, u, string.Empty);

            return u;   
        }
    }
}
