using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShowRoomForm.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName]string propertyName = null)
        {
            // フィールド値、セット値
            if(Equals(field, value))
            {
                // 等しい場合は、false
                return false;
            }

            // 等しくない場合、値をセット
            field = value;

            // イベントを発生
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            // 等しくない場合、true
            return true;
        }
    
    }
}
