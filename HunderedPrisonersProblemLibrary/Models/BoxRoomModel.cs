using System.Collections.Generic;
using System.Linq;

namespace HunderedPrisonersProblemLibrary.Models
{
    public class BoxRoomModel
    {
        public List<BoxModel> Boxes { get; set; } = new List<BoxModel>();

		private Dictionary<int, BoxModel> _boxLabelDictionary;
		public Dictionary<int, BoxModel> BoxLabelDictionary
		{
			get
			{
                if (_boxLabelDictionary == null)
                {
                    _boxLabelDictionary = Boxes.ToDictionary(b => b.LabelNumber);
                }

                return _boxLabelDictionary;
            }
		}

	}
}
