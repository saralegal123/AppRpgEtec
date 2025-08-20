using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;

namespace AppRpgEtec.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;

        public ICommand AutenticarCommand { get; set; }
       

#region AtributosPropriedades

        private string login = string.Empty;
        private string senha = string.Empty;

         public string Login 
         { 
            get => login;
            set
            {
                login = value;
                OnPropertyChanged();
            }  
         }
        public string Senha 
        { 
            get => senha;
            set
            {
                senha = value;
                OnPropertyChanged();
            }
        }

#endregion

// segunda region

#region Metodos

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario();
                u.Username = login;
                u.PassowordString = senha;  

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u);
                
                //! - garante que o token não seja null ou vazio antes de prosseguir. Caso contrário, nao vai rolar
                if (!string.IsNullOrEmpty(uAutenticado.Token))
                {

                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Informação", "Dados incorretos. (¬_¬ )", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", ex.Message + ex.InnerException, "Ok");
            }
        }

#endregion







    }
}
