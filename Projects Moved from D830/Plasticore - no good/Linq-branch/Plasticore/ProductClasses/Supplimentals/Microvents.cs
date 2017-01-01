using Plasticore.DataAccessLayer;

namespace Plasticore
{
    /// <summary>
    /// Microvents class
    /// </summary>
    public class Microvents
    {
        private readonly Microvent _microventData;

        public Microvents(Microvent microventData)
        {
            _microventData = microventData;
        }

        /// <summary>
        /// gets/sets the type of the Microvents
        /// </summary>
        public MicroventType Type
        {
            get { return (MicroventType) _microventData.Type; }
            set { _microventData.Type = (short) value; } 
        }

        /// <summary>
        /// additional comments in regards to Microvents
        /// </summary>
        public string Comments
        {
            get { return _microventData.Comments; }
            set { _microventData.Comments = value; }
        }

        /// <summary>
        /// string representation of the Microvents
        /// </summary>
        public override string ToString()
        {
            if (Type == MicroventType.NoMicrovents)
                return "";
            return string.Format("[{0} Microvents; {1}], ", Type, Comments);
        }
    }
}