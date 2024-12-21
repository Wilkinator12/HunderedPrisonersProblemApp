using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfUI.Bases
{
    public class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string? propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        protected virtual void SetProperty<T>(ref T member, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(member, value)) return;

            member = value;

            OnPropertyChanged(propertyName);
        }
    }
}
