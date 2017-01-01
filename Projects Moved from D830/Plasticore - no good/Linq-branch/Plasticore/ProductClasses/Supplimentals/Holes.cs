using Plasticore.DataAccessLayer;

namespace Plasticore
{
    /// <summary>
    /// Holes is an object that takes care of the holes quantity, size and position on a product like 
    /// plastics bags. The holes could be sized holes or shaped holes.
    /// </summary>
    public class Holes
    {
        private readonly Hole _holeData;

        public Holes(Hole holeData)
        {
            _holeData = holeData;
        }

        /// <summary>
        /// gets/set the size/shape of the holes
        /// </summary>
        public HoleSize HoleSize
        {
            get { return (HoleSize) _holeData.HoleSize; }
            set { _holeData.HoleSize = (short) value; }
        }

        /// <summary>
        /// gets/set the quantity of the holes on the products
        /// </summary>
        public short Quantity
        {
            get { return _holeData.Quantity; }
            set { _holeData.Quantity = value; }
        }

        /// <summary>
        /// gets/sets additional comments in regards to the Holes
        /// </summary>
        public string Comments
        {
            get { return _holeData.Comments; }
            set { _holeData.Comments = value; }
        }

        /// <summary>
        /// overridden string representation of the Holes
        /// </summary>
        public override string ToString()
        {
            if (HoleSize == HoleSize.NoHoles)
                return "";

            string quantityString = "";

            if (Quantity > 0) quantityString = string.Format("{0} ", Quantity);

            return string.Format("[{3}{0} hole{1} {2}], ",
                                 RichEnum.GetDescription(HoleSize),
                                 (Quantity == 1 ? "" : "s"),
                                 Comments,
                                 quantityString
                );
        }
    }
}