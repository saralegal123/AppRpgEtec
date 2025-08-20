using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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

            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", ex.Message + ex.InnerException, "Ok");
            }
        }

#endregion







    }
}
