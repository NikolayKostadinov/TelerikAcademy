using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DependencyProperties.Commands;
using System.Collections.ObjectModel;

namespace DependencyProperties.ViewModels
{
    public class MainViewModel:ViewModelBase
    {        
        private ICommand raiseMessageCommand;

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(MainViewModel));
        

        public ObservableCollection<MessageViewModel> Messages
        {
            get { return (ObservableCollection<MessageViewModel>)GetValue(MessagesProperty); }
            set { SetValue(MessagesProperty, value); }
        }

        public static readonly DependencyProperty MessagesProperty =
            DependencyProperty.Register("Messages", typeof(ObservableCollection<MessageViewModel>), typeof(MainViewModel));


        public ICommand RaiseMessage
        {
            get
            {
                if (this.raiseMessageCommand == null)
                {
                    this.raiseMessageCommand = new RelayCommand(this.HandleRaiseMessage);
                }
                return this.raiseMessageCommand;
            }
        }


        public MainViewModel()
        {
            this.Messages = new ObservableCollection<MessageViewModel>();
        }


        private void HandleRaiseMessage(object obj)
        {
            if (!string.IsNullOrEmpty(this.Message))
            {
                this.Messages.Add(new MessageViewModel()
                {
                    Text = this.Message
                });                
            }
            this.Message = "new Message at " + DateTime.Now;
        }


    }
}
