// Importa namespaces necessários para funcionalidades básicas, coleções, notificação de mudanças, etc.
using System;
using System.Collections.Generic;
using System.ComponentModel; // Necessário para INotifyPropertyChanged
using System.Linq;
using System.Runtime.CompilerServices; // Necessário para [CallerMemberName]
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.ViewModels
{
    // Classe base para ViewModels que implementa o padrão de notificação de mudança de propriedade
    public class BaseViewModel : INotifyPropertyChanged
    {
        // Evento que será disparado quando uma propriedade for alterada
        public event PropertyChangedEventHandler? PropertyChanged;

        // Método que dispara o evento PropertyChanged
        // O atributo [CallerMemberName] permite que o nome da propriedade que chamou este método
        // seja passado automaticamente, sem precisar especificar manualmente
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            // Verifica se há algum assinante do evento e dispara a notificação de mudança
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
