using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using CallCenter.Client.ViewModel.Helpers;
using CallCenter.Client.ViewModel.ViewModels;
using CallCenter.Client.Windows;

namespace CallCenter.Client
{
    //TODO: correct implementation is needed.
    public class WindowService:IWindowService
    {
        private readonly IDictionary<int, Window> windows;

        public WindowService()
        {
            this.windows = new Dictionary<int, Window>();
        }

        private int index;

        private KeyValuePair<int, Window> CreateWindow(ViewModelType type, IViewModel viewModel)
        {
            this.index++;
            Window window;
            
            switch (type)
            {
                case ViewModelType.LoginWindow:
                    window = new LoginWindow();
                    break;
                case ViewModelType.MainWindow:
                    window = new MainWindow();
                    break;
                case ViewModelType.SettingsWindow:
                    window = new SettignsWindow();
                    break;
                default:
                    window = new Window();
                    break;
            }

            window.DataContext = viewModel;

            KeyValuePair<int, Window> keyValuePair = new KeyValuePair<int, Window>(this.index, window);
            this.windows.Add(keyValuePair);
            return keyValuePair;
        }

        public int ShowWindow(ViewModelType type, IViewModel viewModel)
        {
            KeyValuePair<int, Window> k = this.CreateWindow(type, viewModel);
            viewModel.WindowId = k.Key;
            k.Value.Show();
            return k.Key;
        }

        public void ShowDialogWindow(ViewModelType type, IViewModel viewModel)
        {
            KeyValuePair<int, Window> res = this.CreateWindow(type, viewModel);
            viewModel.WindowId = res.Key;
            res.Value.ShowDialog();
        }

        public void Close(int windowId)
        {
            KeyValuePair<int, Window> foundWindow = this.windows.FirstOrDefault(pair => pair.Key == windowId);
            if (foundWindow.Value != null)
            {
                foundWindow.Value.Close();
                this.windows.Remove(foundWindow);
            }
        }

        public void ShowMessage(string caption, string text, MessageType type)
        {
            MessageBox.Show(text);
        }

        public bool AskUser(string caption, string question)
        {
            MessageBoxResult res = MessageBox.Show(question, caption, MessageBoxButton.YesNo);
            return res == MessageBoxResult.OK;
        }
    }
}
