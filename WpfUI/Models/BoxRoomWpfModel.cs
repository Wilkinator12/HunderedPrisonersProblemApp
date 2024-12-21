using System.Collections.ObjectModel;
using WpfUI.Bases;

namespace WpfUI.Models
{
    public class BoxRoomWpfModel : BindableBase
    {
        private ObservableCollection<BoxWpfModel> _boxes = new ObservableCollection<BoxWpfModel>();
        public ObservableCollection<BoxWpfModel> Boxes
        {
            get => _boxes;
            set 
            { 
                SetProperty(ref _boxes, value);
            }
        }
    }
}
