﻿using System;
using System.Collections.Generic;
using Plasticore.DataAccessLayer;
using ValidationManager;

namespace Plasticore
{
    /// <summary>
    /// Base of all Products
    /// </summary>
    [Serializable]
    public abstract class Product
    {
        internal enum ProductType : short
        {
            LooseBag = 10,
            LooseSheet = 20,
            PtoBag = 30,
            PtoSheet = 40,
            PtoSleeve = 50,
            Sheeting = 60,
            Tubing = 70,
            Cgp = 80,
        }
        #region Private Properties --------------------------------------------------

        //		private Bundle _bundle;

        private readonly DataAccessLayer.Product _productData;

        private ChemicalAdditives _chemicalAdditives;
        private ColorInfo _colorInfo;
        private FoldingInfo _foldingInfo;
        private Gauge _gauge;
        private Gusset _gusset;
        private Holes _holes;
        private LipHood _lipHood;
        private Microvents _microvents;
        private Packaging _packaging;
        private Printing _printing;

        #endregion

        protected Product(DataAccessLayer.Product productData)
        {
            _productData = productData;
            if (_productData.ChemicalAdditive != null)
                _chemicalAdditives = new ChemicalAdditives(_productData.ChemicalAdditive);

            if (_productData.ColorInfo != null)
                _colorInfo = new ColorInfo(_productData.ColorInfo);

            if (_productData.FoldingInfo != null)
                _foldingInfo = new FoldingInfo(_productData.FoldingInfo);

            if (_productData.Gauge != null)
                _gauge = new Gauge(_productData.Gauge);

            if (_productData.Gusset != null)
                _gusset = new Gusset(_productData.Gusset);

            if (_productData.Hole != null)
                _holes = new Holes(_productData.Hole);

            if (_productData.LipHood != null)
                _lipHood = new LipHood(_productData.LipHood);

            if (_productData.Microvent != null)
                _microvents = new Microvents(_productData.Microvent);

            if (_productData.Packaging != null)
                _packaging = new Packaging(_productData.Packaging);

            if (_productData.PrintingInfo != null)
                _printing = new Printing(_productData.PrintingInfo);
        }

        /// <summary>
        /// Represents all the printing info related to this product
        /// </summary>	
        // todo: Hamed, Printing is a struct. Please check the behavior of it and let me know if we need to change all above items too
        protected internal Gusset Gusset
        {
            get { return _gusset ?? (_gusset = new Gusset(_productData.Gusset = new DataAccessLayer.Gusset())); }
        }

        public Printing Printing
        {
            get { return _printing ?? (_printing = new Printing(_productData.PrintingInfo = new PrintingInfo())); }
        }

        protected decimal HeaderSize
        {
            get { return _productData.HeaderSize; }
            set { _productData.HeaderSize = value; }
        }

        protected decimal Length { get { return _productData.Length; } set { _productData.Length = value; } }
        protected bool LeakProof { get { return _productData.LeakProof; } set { _productData.LeakProof = value; } }

        protected LipHood LipHood
        {
            get { return _lipHood ?? (_lipHood = new LipHood(_productData.LipHood = new DataAccessLayer.LipHood())); }
        }

        protected short RollsPerSkid { get { return _productData.RollsPerSkid; } set { _productData.RollsPerSkid = value; } }

        protected SealedFirstType SealedFirst { get { return (SealedFirstType)_productData.SealedFirstType; } set { _productData.SealedFirstType = (short) value; } }

        /// <summary>
        /// Indicates which slip type the product is of
        /// Refer to <see cref="SlipType"/> for the possible options
        /// </summary>
        public SlipType Slip { get { return (SlipType)_productData.SlipType; } set { _productData.SlipType = (short) value; } }

        protected SlitPosition Slit { get { return (SlitPosition)_productData.SlitPosition; } set { _productData.SlitPosition = (short) value; } }

        /// <summary>
        /// gets/set number of months that Product can resist under the UVI
        /// </summary>
        public byte UviMonths { get { return _productData.UviMonth; } set { _productData.UviMonth = value; } }

        /// <summary>
        /// chemical additives that can be added to the product
        /// </summary>
        public ChemicalAdditives ChemicalAdditives
        {
            get { return _chemicalAdditives ?? (_chemicalAdditives = new ChemicalAdditives(_productData.ChemicalAdditive = new ChemicalAdditive())); }
        }

        /// <summary>
        /// Keeps information about the transparency and color of the product
        /// </summary>
        public ColorInfo ColorInfo
        {
            get { return _colorInfo ?? (_colorInfo = new ColorInfo(_productData.ColorInfo = new DataAccessLayer.ColorInfo())); }
        }

        /// <summary>
        /// gets the default UOM of the Product
        /// <seealso cref="ValidUoms"/>
        /// </summary>
        public abstract Uom DefaultUom { get; }

        /// <summary>
        /// provides the folding information of the product
        /// </summary>
        protected FoldingInfo Folding
        {
            get { return _foldingInfo ?? (_foldingInfo = new FoldingInfo(_productData.FoldingInfo = new DataAccessLayer.FoldingInfo())); }
        }

        /// <summary>
        /// gauge of the product<br />
        /// Refer to <see cref="Gauge">Gauge</see> class for more detail
        /// </summary>
        public Gauge Gauge
        {
            get { return _gauge ?? (_gauge = new Gauge(_productData.Gauge = new DataAccessLayer.Gauge())); }
        }

        /// <summary>
        /// indicates if the product has a gusset
        /// </summary>
        public bool HasGusset
        {
            get
            {
                if (this is IGussetable)
                    return Gusset.Orientation != GussetOrientation.NoGusset;

                return false;
            }
        }

        /// <summary>
        /// indicates if the product has microvents
        /// </summary>
        public bool HasMicrovents
        {
            get { return Microvents.Type != MicroventType.NoMicrovents; }
        }

        /// <summary>
        /// indicates if the product has holes
        /// </summary>
        public bool HasHoles
        {
            get { return Holes.HoleSize != HoleSize.NoHoles; }
        }

        /// <summary>
        /// indicates if the product has printing 
        /// </summary>
        public bool HasPrinting
        {
            get
            {
                return Printing.InnerSide != PrintingColoring.NoPrinting ||
                       Printing.OuterSide != PrintingColoring.NoPrinting;
            }
        }

        /// <summary>
        /// Represents the holes properties on the product (if any)
        /// Refer to Holes class for more detail
        /// </summary>
        public Holes Holes
        {
            get { return _holes ?? (_holes = new Holes(_productData.Hole = new Hole())); }
        }

        // todo: what is this for? who needs this from this layer?
        /// <summary>
        /// Unique ID of the product
        /// </summary>
        public int Id
        {
            get { return _productData.ID; }
        }

        /// <summary>
        /// Represents the microvents properties on the product (if any)
        /// Refer to Microvents class for more information
        /// </summary>
        public Microvents Microvents
        {
            get { return _microvents ?? (_microvents = new Microvents(_productData.Microvent = new Microvent())); }
        }

        /// <summary>
        /// Calculated net weight of the product.  <br />
        /// net weight is weight * 0.9 unless the product is a full gauge which in this condition net weight and weight are the same.
        /// </summary>
        /// <seealso cref="Weight"/>
        public decimal NetWeight
        {
            get
            {
                if (Gauge.FullGauge)
                    return Weight;
                return Weight*0.9m;
            }
        }

        /// <summary>
        /// Optional comments on the product
        /// </summary>
        public string Notes
        {
            get { return _productData.Notes; }
            set { _productData.Notes = value; }
        }

        /// <summary>
        /// Indicates different possibilities on packaging the product. 
        /// For example BagsPerCarton or LbsPerCarton
        /// Refer to options in order to get different possibilities for this property
        /// </summary>
        public Packaging Packaging
        {
            get {
                return _packaging ??
                       (_packaging = new Packaging(_productData.Packaging = new DataAccessLayer.Packaging())); }
        }

        /// <summary>
        /// Optional name tag that can be given to the product. 
        /// If this has value in it the product would be treated as a predefined product
        /// </summary>
        public string PartNumber { get { return _productData.PartNumber; } set { _productData.PartNumber = value; } }

        /// <summary>
        /// gets the sizing signature of the product.
        /// </summary>
        /// <remarks>This is a method to compare similar products with their sizings.</remarks>
        public string Signature
        {
            get { return string.Format("{0}; {1}", "GetName()", "GetSizing()"); }
        }

        /// <summary>
        /// list of valid UOMs that can be used for ordering the Product
        /// <seealso cref="DefaultUom"/>
        /// </summary>
        public abstract List<Uom> ValidUoms { get; }

        /// <summary>
        /// returns the weigth of the product.
        /// <seealso cref="NetWeight"/>
        /// </summary>
        public abstract decimal Weight { get; }

        /// <summary>
        /// Width of the product
        /// </summary>
        public decimal Width { get { return _productData.Width; } set { _productData.Width = value; } }

        /// <summary>
        /// Saves the product
        /// </summary>
        /// <param name="overwritePartNumber">Indicates whether the product should overwrite the 
        /// existing product with the same PartNumber (if any) or not</param>
        private void Save(bool overwritePartNumber)
        {
        }


        /// <summary>
        /// Sets the predefined to false and then saves the product
        /// </summary>
        public void Delete()
        {
        }

        /// <summary>
        /// Gets a list of allowable PackagingType for the product; <br/>
        /// use when type is a parameter
        /// </summary>
        public abstract PackagingType[] GetValidPackages();

        /// <summary>
        /// Saves the product without overwriting the existing predefined product. 
        /// It causes an exception (DuplicateProduct) if a product already exists with the same PartNumber
        /// </summary>
        public void Save()
        {
            Save(false);
        }

        /// <summary>
        /// Saves the product with a PartNumber. 
        /// This won't attempt to overwrite the existing product with the same PartNumber (if any)
        /// It causes an exception (DuplicateProduct) if PartNumber already exist
        /// </summary>
        /// <param name="newPartNumber">PartNumber of the product to be saved</param>
        public void Save(string newPartNumber)
        {
        }

        ///<summary>
        ///</summary>
        ///<param name="format"></param>
        ///<returns></returns>
        public string ToString(string format)
        {
            return ToString();
        }

        #region Validation Rules

        // ReSharper disable UnusedMember.Local

        [ValidationRule("", "Composite rules failed")]
        private bool CompositeRules()
        {
            ValidatorEngine.Validate(ChemicalAdditives);
            ValidatorEngine.Validate(Gauge);
            ValidatorEngine.Validate(Gusset);

            return false;
        }

        [ValidationRule("", "Shrink option is not applicable on products thinner than 1.5mil")]
        private bool Rule1()
        {
            return (!ChemicalAdditives.Shrink || Gauge.Size >= .00125m);
        }

        [ValidationRule("", "Shrink option is not applicable on products thinner than 1.5mil")]
        private bool Rule2()
        {
            return (!ChemicalAdditives.Shrink || Gauge.Size >= .00125m);
        }

        [ValidationRule("", "HighClarity option is not applicable on products thicker than or equal to 6mil")]
        private bool Rule3()
        {
            return (ColorInfo.Transparency != TransparencyType.HighClarity || Gauge.Size < .006m);
        }

        [ValidationRule("", "HighClarity option is not applicable on products thicker than or equal to 6mil")]
        private bool Rule4()
        {
            return (ColorInfo.Transparency != TransparencyType.HighClarity || Gauge.Size < .006m);
        }

        [ValidationRule("", "Color has to be defined for the Tint or Opaque transparency")]
        private bool Rule5()
        {
            return (ColorInfo.Transparency == TransparencyType.RegularClarity ||
                    ColorInfo.Transparency == TransparencyType.HighClarity ||
                    ColorInfo.ProductColor != ProductColor.Clear);
        }

        [ValidationRule("", "clear transparency cannot have color")]
        private bool Rule6()
        {
            return (ColorInfo.Transparency == TransparencyType.RegularClarity ||
                    ColorInfo.Transparency == TransparencyType.HighClarity ||
                    ColorInfo.ProductColor != ProductColor.Clear);
        }

        // ReSharper restore UnusedMember.Local

        #endregion
    }
}