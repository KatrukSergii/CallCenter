using CallCenter.Client.ViewModel.ViewModels;

namespace CallCenter.Client.ViewModel.Helpers
{
    public interface IViewModel:IViewModelBase
    {
        void Show();
        void ShowDialog();
        int WindowId { get; set; }
        void Close();
        void ShowMessage(string caption, string text, MessageType type);
        bool AskUser(string caption, string question);
        ViewModelType Type { get; }
    }
}