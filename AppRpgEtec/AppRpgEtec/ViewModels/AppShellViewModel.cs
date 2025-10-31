using AppRpgEtec.Services.Usuarios;
using Azure.Storage.Blobs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        private UsuarioService uService;
        private static string conexaoAzureStorage = "DefaultEndpointsProtocol=https;AccountName=rpgstorage;AccountKey=5lICnm3gQd9O49dC0y072ADvS/upL2mtE/TznGKfOjlmgCzowNzmhfxB5sfzpOR9IfHyGKbeht5X+AStEpvukQ==;EndpointSuffix=core.windows.net";
        private static string container = "arquivos";
        public AppShellViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            uService = new UsuarioService(token);
            CarregarUsuarioAzure();
        }

        private byte[] foto;
        public byte[] Foto
        {
            get => foto;
            set
            {
                foto = value;
                OnPropertyChanged();
            }
        }

        public async void CarregarUsuarioAzure()
        {
            try
            {
                int usuarioId = Preferences.Get("UsuarioId", 0);
                string filename = $"{usuarioId}.jpg";
                var blobClient = new BlobClient(conexaoAzureStorage, container, filename);

                if (blobClient.Exists())
                {
                    Byte[] fileBytes;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        blobClient.OpenRead().CopyTo(ms);
                        fileBytes = ms.ToArray();
                    }
                    Foto = fileBytes;
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + "Detelhes: " + ex.InnerException, "Ok");
            }
        }
    }
}
