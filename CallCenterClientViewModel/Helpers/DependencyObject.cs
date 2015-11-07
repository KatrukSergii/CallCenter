using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CallCenter.Client.ViewModel.Helpers
{
    public abstract class DependencyObject:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (this.PropertyChanged != null)
                this.PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
