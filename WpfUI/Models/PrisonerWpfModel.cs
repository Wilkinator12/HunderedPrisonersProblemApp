using WpfUI.Bases;

namespace WpfUI.Models
{
    public class PrisonerWpfModel : BindableBase
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
