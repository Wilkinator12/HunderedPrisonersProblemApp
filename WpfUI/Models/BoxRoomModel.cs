using System.Collections.ObjectModel;
using WpfUI.Bases;

namespace WpfUI.Models
{
    public class BoxRoomModel : BindableBase
    {
        private ObservableCollection<BoxModel> _boxes = new ObservableCollection<BoxModel>();
        public ObservableCollection<BoxModel> Boxes
        {
            get => _boxes;
            set 
            { 
                SetProperty(ref _boxes, value);
            }
        }
    }
}
