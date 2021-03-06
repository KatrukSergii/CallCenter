﻿namespace CallCenter.Client.ViewModel.Helpers
{
    public abstract class ViewModelBase : DependencyObject, IViewModel
    {
        private bool isVisible;
        protected readonly IWindowService WindowService;

        protected ViewModelBase(IWindowService windowService)
        {
            this.WindowService = windowService;
        }

        public bool IsVisible
        {
            get
            {
                return this.isVisible;
            }
            set
            {
                if (this.isVisible == value)
                    return;
                this.isVisible = value;
                this.RaisePropertyChanged();
            }
        }

        public int WindowId { get; set; }

        public void Show()
        {
            if (this.WindowId == 0)
            {
                this.WindowService.ShowWindow(this.Type, this);
            }
        }

        public void ShowDialog()
        {
            if (this.WindowId == 0)
                this.WindowService.ShowDialogWindow(this.Type, this);
        }

        public void Close()
        {
            if (this.WindowId > 0)
            {
                this.WindowService.Close(this.WindowId);
            }
        }

        public void ShowMessage(string caption, string text, MessageType type)
        {
            this.WindowService.ShowMessage(caption, text, type);
        }

        public bool AskUser(string caption, string question)
        {
            return this.WindowService.AskUser(caption, question);
        }

        public abstract ViewModelType Type { get; }

        public void Init()
        {
        }
    }
}