using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.Services.Disputas
{
    public class DisputaService : Request
    {
        private readonly Request _request;
        private string _token;

        private const string _apiUrlBase = "https://rpgraphael-dvejarfmgyfycwba.brazilsouth-01.azurewebsites.net/Disputas";

        public DisputaService(string token)
        {
            _request = new Request();
            _token = token;
        }

        public async Task<Disputa> PostDisputaComArmaAsync(DisputaService d)
        {
            string urlComplementar = "/Arma";
            return await _request.PostAsync(_apiUrlBase + urlComplementar, d, _token);
        }

        public async Task<Disputa> PostDisputaComHabilidadeAsync(DisputaService d)
        {
            string urlComplementar = "/Habilidade";
            return await _request.PostAsync(_apiUrlBase + urlComplementar, d, _token);
        }

        public async Task<Disputa> PostDisputaGeralAsync(DisputaService d)
        {
            string urlComplementar = "/DisputaEmGrupo";
            return await _request.PostAsync(_apiUrlBase + urlComplementar, d, _token);
        }
    }
}
