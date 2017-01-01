namespace Plasticore
{
    /// <summary>
    /// Represents a Packaging option and its value
    /// </summary>
    public class Packaging
    {
        private readonly DataAccessLayer.Packaging _packagingData;

        public Packaging(DataAccessLayer.Packaging packagingData)
        {
            _packagingData = packagingData;
        }

        /// <summary>
        /// Represents the <see cref="PackagingType"/>
        /// Some example can be LbPerRoll, LnFtPerRoll, ...
        /// </summary>
        public PackagingType Type
        {
            get { return (PackagingType) _packagingData.Type; }
            set { _packagingData.Type = (short) value; }
        }

        /// <summary>
        /// The value of the user request
        /// For example this indicate how many pound per roll (if the userRequestOption is LbPerRoll)
        /// </summary>
        public decimal Value
        {
            get { return _packagingData.Value; }
            set { _packagingData.Value = value; }
        }

        /// <summary>
        /// Returns a string that should be saved on the database as Packaging
        /// </summary>
        /// <returns>A string that represents the Packaging object on database.</returns>
        public override string ToString()
        {
            if (Type == PackagingType.NoPreferences)
                return "";

            return string.Format("{0:###.####} {1} ",
                                 Value,
                                 RichEnum.GetDescription(Type));
        }
    }
}