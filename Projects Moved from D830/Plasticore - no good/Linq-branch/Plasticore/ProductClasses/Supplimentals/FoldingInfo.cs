using System.Collections.Generic;

namespace Plasticore
{
    /// <summary>
    /// Includes all the information on folding 
    /// </summary>
    public class FoldingInfo
    {
        private readonly DataAccessLayer.FoldingInfo _foldingInfoData;

        public FoldingInfo(DataAccessLayer.FoldingInfo foldingInfoData)
        {
            _foldingInfoData = foldingInfoData;
        }

        /// <summary>
        /// Indicates the type of folding
        /// For possible values refer to <see cref="FoldType"/>
        /// </summary>
        public FoldType FoldType
        {
            get { return (FoldType) _foldingInfoData.FoldType; }
            set { _foldingInfoData.FoldType = (short) value; } 
        }

        /// <summary>
        /// Indicates the position on the product that slitting should be applied
        /// </summary>
        public SlitPosition Slit
        {
            get { return (SlitPosition) _foldingInfoData.SlitPosition; }
            set { _foldingInfoData.SlitPosition = (short) value; }
        }

        /// <summary>
        /// Indicates whether the product should be trimmed or not
        /// </summary>
        public bool Trimmed
        {
            get { return _foldingInfoData.Trimmed; }
            set { _foldingInfoData.Trimmed = value; }
        }

        public override string ToString()
        {
            var list = new List<string>();

            //if (FoldType != FoldType.Unknown)
            list.Add(RichEnum.GetDescription(FoldType));

            if (Slit != SlitPosition.RegencyDecides)
                list.Add(RichEnum.GetDescription(Slit));

            if (Trimmed)
                list.Add("Trimmed");

            return string.Join(", ", list.ToArray());
        }
    }
}