using Plasticore.DataAccessLayer;
using ValidationManager;

namespace Plasticore
{
    /// <summary>
    /// Contains the chemical additives that can be used in making the bag
    /// </summary>
    public class ChemicalAdditives
    {
        private readonly ChemicalAdditive _chemicalAdditiveData;

        internal ChemicalAdditives(ChemicalAdditive chemicalAdditiveData)
        {
            _chemicalAdditiveData = chemicalAdditiveData;
        }

        /// <summary>
        /// indicates if product is anti-block
        /// </summary>
        public bool AntiBlock
        {
            get { return _chemicalAdditiveData.AntiBlock; }
            set { _chemicalAdditiveData.AntiBlock = value; }
        }

        /// <summary>
        /// indicates if product is anti-static
        /// </summary>
        public bool AntiStatic
        {
            get { return _chemicalAdditiveData.AntiStatic; }
            set { _chemicalAdditiveData.AntiStatic = value; }
        }

        /// <summary>
        /// indicates if product is food-flex
        /// </summary>
        public bool FoodFlex
        {
            get { return _chemicalAdditiveData.FoodFlex; }
            set { _chemicalAdditiveData.FoodFlex = value; }
        }

        /// <summary>
        /// indicates if product is Shrink
        /// </summary>
        public bool Shrink
        {
            get { return _chemicalAdditiveData.Shrink; }
            set { _chemicalAdditiveData.Shrink = value; }
        }

        /// <summary>
        /// indicates if product uses virgin materials only
        /// </summary>
        public bool VirginMaterial
        {
            get { return _chemicalAdditiveData.VirginMaterial; }
            set { _chemicalAdditiveData.VirginMaterial = value; }
        }

        /// <summary>
        /// indicates if product is high-impact
        /// </summary>
        public bool HighImpact
        {
            get { return _chemicalAdditiveData.HighImpact; }
            set { _chemicalAdditiveData.HighImpact = value; }
        }

        /// <summary>
        /// indicates if product is utility
        /// </summary>
        public bool Utility
        {
            get { return _chemicalAdditiveData.Utility; }
            set { _chemicalAdditiveData.Utility = value; }
        }

        [ValidationRule("Usage", "Utility cannot be selected combined with other additives")]
        private bool MustHaveValidCombination()
        {
            return !((AntiBlock || AntiStatic || FoodFlex || Shrink || HighImpact) && Utility);
        }

        /// <summary>
        /// string representation of chemical additives
        /// </summary>
        public override string ToString()
        {
            return ((AntiBlock) ? "Anti Block, " : "") +
                   ((AntiStatic) ? "Anti Static, " : "") +
                   ((FoodFlex) ? "Food Flex, " : "") +
                   ((Shrink) ? "Shrink, " : "") +
                   ((VirginMaterial) ? "Virgin Material, " : "") +
                   ((HighImpact) ? "High Impact, " : "") +
                   ((Utility) ? "Utility, " : "");
        }
    }
}