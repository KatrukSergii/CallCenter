namespace CallCenter.Client.ViewModel.Helpers
{
    public interface IWindowService
    {
        int ShowWindow(ViewModelType type, IViewModel viewModel);
        void ShowDialogWindow(ViewModelType type, IViewModel viewModel);
        void Close(int windowId);
        void ShowMessage(string caption, string text, MessageType type);
        bool AskUser(string caption, string question);
    }
}
