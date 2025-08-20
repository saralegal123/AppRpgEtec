﻿using System;
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
        //ctor + tab: para criar um construtor
        public UsuarioViewModel()
        {
            uService = new UsuarioService(); // inicializa o serviço que fará a chamada de autenticação
            InicializarCommands(); // configura os comandos que serão usados na interface
        }

        //quer dizer que eu to falando que um async ta chamando um await de AutenticarUsuario
        public void InicializarCommands()
        {
            AutenticarCommand = new Command(async () => await AutenticarUsuario()); // comando que executa a autenticação
        }

        private UsuarioService uService; // instância do serviço de usuário

        public ICommand AutenticarCommand { get; set; } // comando que será vinculado ao botão de login

        #region AtributosPropriedades

        private string login = string.Empty;
        private string senha = string.Empty;

        // propriedade que armazena o login digitado pelo usuário
        public string Login
        {
            get => login;
            set
            {
                login = value;
                OnPropertyChanged(); // notifica a interface sobre a mudança
            }
        }

        // propriedade que armazena a senha digitada pelo usuário
        public string Senha
        {
            get => senha;
            set
            {
                senha = value;
                OnPropertyChanged(); // notifica a interface sobre a mudança
            }
        }

        #endregion

        // segunda region

        #region Metodos

        public async Task AutenticarUsuario()
        {
            try
            {
                Usuario u = new Usuario(); // cria objeto com dados de login
                u.Username = login;
                u.PassowordString = senha;

                Usuario uAutenticado = await uService.PostAutenticarUsuarioAsync(u); // envia dados para API e aguarda resposta

                //! - garante que o token não seja null ou vazio antes de prosseguir. Caso contrário, nao vai rolar logar no negocio
                if (!string.IsNullOrEmpty(uAutenticado.Token))
                {
                    string mensagem = $"Bem-vindo(a) {uAutenticado.Username}";

                    //guardando dados para uso futuro
                    Preferences.Set("UsuarioId", uAutenticado.Id);
                    Preferences.Set("UsuarioUsername", uAutenticado.Username);
                    Preferences.Set("UsuarioPerfil", uAutenticado.Perfil);
                    Preferences.Set("UsuarioToken", uAutenticado.Token);

                    await Application.Current.MainPage.DisplayAlert("Informação", mensagem, "Ok"); // exibe mensagem de boas-vindas

                    Application.Current.MainPage = new MainPage(); // redireciona para a tela principal
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Informação", "Dados incorretos. (¬_¬ )", "Ok"); // exibe erro de login
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Informação", ex.Message + ex.InnerException, "Ok"); // exibe erro técnico
            }
        }

        #endregion
    }
}
