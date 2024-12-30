using System.Collections.Generic;
using System.Linq;

namespace HunderedPrisonersProblemLibrary.Models
{
    public class BoxRoom
    {
        public List<Box> Boxes { get; set; } = new List<Box>();

		private Dictionary<int, Box> _boxLabelDictionary;
		public Dictionary<int, Box> BoxLabelDictionary
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
