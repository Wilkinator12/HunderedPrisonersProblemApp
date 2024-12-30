using WpfUI.Bases;

namespace WpfUI.Models
{
    public class BoxSelectionModel : BindableBase
	{
        private int _selectionNumber;
        public int SelectionNumber
        {
            get => _selectionNumber;
            set
            {
                SetProperty(ref _selectionNumber, value);
            }
        }

        private BoxModel _selectedBox = null!;
        public BoxModel SelectedBox
        {
            get => _selectedBox;
            set
            {
                SetProperty(ref _selectedBox, value);
            }
        }
    }
}
