using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Models;
using AVFoundation;

namespace AppRpgEtec.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request request;
        private const string apiUrlBase = "https://xyz.azurewebsites.net/Usuarios";

        public UsuarioService()
        {
            request = new Request();
        }

        public async Task<Usuario> PostRegistrarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Registrar";
            u.Id = await request.PostReturnIntAsync(apiUrlBase + urlComplementar, u, string.Empty);

            return u;
        }

        public async Task<Usuario> PostAtenticarUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Autenticar";
            u = await request.PostAsync(apiUrlBase + urlComplementar, u, string.Empty);

            return u; 
        }
    }
}
