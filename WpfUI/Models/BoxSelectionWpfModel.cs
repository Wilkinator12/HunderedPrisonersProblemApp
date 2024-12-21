using WpfUI.Bases;

namespace WpfUI.Models
{
    public class BoxSelectionWpfModel : BindableBase
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

        private BoxWpfModel _selectedBox = null!;
        public BoxWpfModel SelectedBox
        {
            get => _selectedBox;
            set
            {
                SetProperty(ref _selectedBox, value);
            }
        }
    }
}
