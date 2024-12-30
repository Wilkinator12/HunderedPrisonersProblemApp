using WpfUI.Bases;

namespace WpfUI.Models
{
    public class PrisonerModel : BindableBase
    {
		private int _identityNumber;
		public int IdentityNumber
		{
			get => _identityNumber;
			set 
			{ 
				SetProperty(ref _identityNumber, value);
			}
		}
	}
}
