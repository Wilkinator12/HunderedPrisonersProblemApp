using WpfUI.Bases;

namespace WpfUI.Models
{
    public class BoxWpfModel : BindableBase
	{
		private int _labelNumber;
		public int LabelNumber
		{
			get => _labelNumber;
			set 
			{ 
				SetProperty(ref _labelNumber, value);
			}
		}

        private int _slipNumber;
        public int SlipNumber
        {
            get => _slipNumber;
            set
            {
                SetProperty(ref _slipNumber, value);
            }
        }
    }
}
