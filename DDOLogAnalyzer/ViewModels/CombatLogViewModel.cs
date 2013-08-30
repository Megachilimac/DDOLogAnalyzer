using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Input;
using DDOLogAnalyzer.Helpers;
using DDOLogAnalyzer.Models;
using Microsoft.Win32;

namespace DDOLogAnalyzer.ViewModels
{
    class CombatLogViewModel : BaseViewModel
    {
        private ObservableCollection<CombatMessage> _chatMessages;
        public ObservableCollection<CombatMessage> ChatMessages
        {
            get
            {
                return _chatMessages;
            }
            set 
            { 
                _chatMessages = value;
                RaisePropertyChanged(() => ChatMessages);
            }
        }

        public CombatLogViewModel()
        {
            
        }

        public ICommand RefreshDataCommand { get { return new DelegateCommand(OnLoadData); } }

        private void OnLoadData()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            bool? result = fileDialog.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document 
                string filename = fileDialog.FileName;
                FileLoader loadCrap = new FileLoader(filename);
                ChatMessages = new ObservableCollection<CombatMessage>(loadCrap.DoIt());
            }
        }
    }
}
