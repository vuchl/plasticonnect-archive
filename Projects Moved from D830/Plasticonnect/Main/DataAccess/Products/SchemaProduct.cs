using System;
using DataProvider;
using Mapping;
using Products;
using Regency;
using ROS.Schema.SchemaProductTableAdapters;

namespace ROS.Schema {
	public partial class SchemaProduct
	{
		partial class ProductsRow : IProductDataProvider
		{
			#region IProductDataProvider Members

			public CartonSize DataCartonSize
			{
				get { return (CartonSize) CartonSizeId; }
				set { CartonSizeId = (short) value; }
			}

			public CoreType DataCoreType
			{
				get { return (CoreType) CoreTypeId; }
				set { CoreTypeId = (short) value; }
			}

			public short DataDiameterPerRoll
			{
				get { throw new NotImplementedException("This is an obsolete member"); }
				set { throw new NotImplementedException("This is an obsolete member"); }
			}

			public decimal DataHeaderSize
			{
				get { return HeaderSize; }
				set { HeaderSize = value; }
			}

			public decimal DataLength
			{
				get { return Length; }
				set { Length = value; }
			}

			public bool DataLeakProof
			{
				get { return LeakProof; }
				set { LeakProof = value; }
			}

			public string DataProductComments
			{
				get { return Comments; }
				set { Comments = value; }
			}

			public int? DataOwnerAccountNumber
			{
				get { if (IsOwnerAccountNumberNull()) return null; return OwnerAccountNumber; }
				set
				{
					if (value == null)
						SetOwnerAccountNumberNull();
					else
						OwnerAccountNumber = (int) value;
				}
			}

			public bool DataIsPredefined
			{
				get { return Predefined; }
				set { Predefined = value; }
			}

			public ProductType DataProductType
			{
				get { return (ProductType) ProductTypeID; }
				set { ProductTypeID = (int) value; }
			}

			public short DataRollsPerSkid
			{
				get { return RollsPerSkid; }
				set { RollsPerSkid = value; }
			}

			public SealedFirstType DataSealedFirst
			{
				get { return (SealedFirstType) SealedFirst; }
				set { SealedFirst = (short) value; }
			}

			public SleeveColor DataSleeveColor
			{
				get { return (SleeveColor) SleeveColorId; }
				set { SleeveColorId = (short) value; }
			}

			public SlipType DataSlip
			{
				get { return (SlipType) SlipID; }
				set { SlipID = (short) value; }
			}

			public SpecialityResinTypes DataSpecialityResins
			{
				get { return (SpecialityResinTypes) SpecialityResinsID; }
				set { SpecialityResinsID = (short) value; }
			}

			public string DataPartNumber
			{
				get { return PartNumber; }
				set { PartNumber = value; }
			}

			public string DataTreatingLocation
			{
				get { throw new NotImplementedException("this is an obsolete member"); }
				set { throw new NotImplementedException("this is an obsolete member"); }
			}

			public byte DataUviMonths
			{
				get { return UVIMonths; }
				set { UVIMonths = value; }
			}

			public decimal DataWidth
			{
				get { return Width; }
				set { Width = value; }
			}

			public SealingType DataSealing
			{
				get { return (SealingType) SealingID; }
				set { SealingID = (short) value; }
			}

			#region Bundle

			private BundleDataFormatter _bundleDataFormatter;

			private BundleDataFormatter bundleDataFormatter
			{
				get
				{
					if (_bundleDataFormatter == null)
					{
						_bundleDataFormatter = new BundleDataFormatter(Bundle);
					}
					return _bundleDataFormatter;
				}
			}

			public BundleType DataBundleType
			{
				get { return bundleDataFormatter.BundleType; }
				set
				{
					bundleDataFormatter.BundleType = value;
					Bundle = bundleDataFormatter.DbString;
				}
			}

			public short DataBagCount
			{
				get { return bundleDataFormatter.BagCount; }
				set
				{
					bundleDataFormatter.BagCount = value;
					Bundle = bundleDataFormatter.DbString;
				}
			}

			public WicketSize DataWicketSize
			{
				get { return bundleDataFormatter.WicketSize; }
				set
				{
					bundleDataFormatter.WicketSize = value;
					Bundle = bundleDataFormatter.DbString;
				}
			}

			#endregion

			#region Holes

			private HolesDataFormatter _holesDataFormatter;

			private HolesDataFormatter holesDataFormatter
			{
				get
				{
					if (_holesDataFormatter == null)
					{
						_holesDataFormatter = new HolesDataFormatter(Holes);
					}
					return _holesDataFormatter;
				}
			}

			public HoleSize DataHoleSize
			{
				get { return holesDataFormatter.HoleSize; }
				set
				{
					holesDataFormatter.HoleSize = value;
					Holes = holesDataFormatter.DbString;
				}
			}

			public short DataHolesQuantity
			{
				get { return holesDataFormatter.Quantity; }
				set
				{
					holesDataFormatter.Quantity = value;
					Holes = holesDataFormatter.DbString;
				}
			}

			public string DataHolesComments
			{
				get { return holesDataFormatter.Comments; }
				set
				{
					holesDataFormatter.Comments = value;
					Holes = holesDataFormatter.DbString;
				}
			}

			#endregion

			#region Microvents

			private MicroventsDataFormatter _microventsDataFormatter;

			private MicroventsDataFormatter microventsDataFormatter
			{
				get
				{
					if (_microventsDataFormatter == null)
					{
						_microventsDataFormatter = new MicroventsDataFormatter(Microvents);
					}
					return _microventsDataFormatter;
				}
			}

			public MicroventType DataMicroventsType
			{
				get { return microventsDataFormatter.Type; }
				set
				{
					microventsDataFormatter.Type = value;
					Microvents = microventsDataFormatter.DbString;
				}
			}

			public string DataMicroventsComments
			{
				get { return microventsDataFormatter.Comments; }
				set
				{
					microventsDataFormatter.Comments = value;
					Microvents = microventsDataFormatter.DbString;
				}
			}

			#endregion

			#region Chemical Additives

			private ChemicalAdditivesDataFormatter _chemicalAdditivesDataFormatter;

			private ChemicalAdditivesDataFormatter chemicalAdditivesDataFormatter
			{
				get
				{
					if (_chemicalAdditivesDataFormatter == null)
					{
						_chemicalAdditivesDataFormatter = new ChemicalAdditivesDataFormatter(ChemicalAdditives);
					}
					return _chemicalAdditivesDataFormatter;
				}
			}

			public bool DataHasAntiBlock
			{
				get { return chemicalAdditivesDataFormatter.HasAntiBlock; }
				set
				{
					chemicalAdditivesDataFormatter.HasAntiBlock = value;
					ChemicalAdditives = chemicalAdditivesDataFormatter.DbInt;
				}
			}

			public bool DataHasAntiStatic
			{
				get { return chemicalAdditivesDataFormatter.HasAntiStatic; }
				set
				{
					chemicalAdditivesDataFormatter.HasAntiStatic = value;
					ChemicalAdditives = chemicalAdditivesDataFormatter.DbInt;
				}
			}

			public bool DataHasFoodFlex
			{
				get { return chemicalAdditivesDataFormatter.HasFoodFlex; }
				set
				{
					chemicalAdditivesDataFormatter.HasFoodFlex = value;
					ChemicalAdditives = chemicalAdditivesDataFormatter.DbInt;
				}
			}

			public bool DataHasShrink
			{
				get { return chemicalAdditivesDataFormatter.HasShrink; }
				set
				{
					chemicalAdditivesDataFormatter.HasShrink = value;
					ChemicalAdditives = chemicalAdditivesDataFormatter.DbInt;
				}
			}

			public bool DataHasVirginMaterial
			{
				get { return chemicalAdditivesDataFormatter.HasVirginMaterial; }
				set
				{
					ChemicalAdditives = chemicalAdditivesDataFormatter.DbInt;
					chemicalAdditivesDataFormatter.HasVirginMaterial = value;
				}
			}

			public bool DataHasHighImpact
			{
				get { return chemicalAdditivesDataFormatter.HasHighImpact; }
				set
				{
					chemicalAdditivesDataFormatter.HasHighImpact = value;
					ChemicalAdditives = chemicalAdditivesDataFormatter.DbInt;
				}
			}

			public bool DataHasUtility
			{
				get { return chemicalAdditivesDataFormatter.HasUtility; }
				set
				{
					chemicalAdditivesDataFormatter.HasUtility = value;
					ChemicalAdditives = chemicalAdditivesDataFormatter.DbInt;
				}
			}

			#endregion

			#region Gusset

			private GussetDataFormatter _gussetDataFormatter;

			private GussetDataFormatter gussetDataFormatter
			{
				get
				{
					if (_gussetDataFormatter == null)
					{
						_gussetDataFormatter = new GussetDataFormatter(Gusset);
					}
					return _gussetDataFormatter;
				}
			}

			public GussetOrientation DataGussetOrientation
			{
				get { return gussetDataFormatter.Orientation; }
				set
				{
					gussetDataFormatter.Orientation = value;
					Gusset = gussetDataFormatter.DbString;
				}
			}

			public decimal DataGussetSize
			{
				get { return gussetDataFormatter.Size; }
				set
				{
					gussetDataFormatter.Size = value;
					Gusset = gussetDataFormatter.DbString;
				}
			}

			#endregion

			#region Lip/Hood

			private LipHoodDataFormatter _lipHoodDataFormatter;

			private LipHoodDataFormatter lipHoodDataFormatter
			{
				get
				{
					if (_lipHoodDataFormatter == null)
					{
						_lipHoodDataFormatter = new LipHoodDataFormatter(Lip);
					}
					return _lipHoodDataFormatter;
				}
			}

			public HoodType DataHoodType
			{
				get { return lipHoodDataFormatter.Type; }
				set
				{
					lipHoodDataFormatter.Type = value;
					Lip = lipHoodDataFormatter.DbString;
				}
			}

			public decimal DataHoodSize
			{
				get { return lipHoodDataFormatter.HoodSize; }
				set
				{
					lipHoodDataFormatter.HoodSize = value;
					Lip = lipHoodDataFormatter.DbString;
				}
			}

			public decimal DataLipSize
			{
				get { return lipHoodDataFormatter.LipSize; }
				set
				{
					lipHoodDataFormatter.LipSize = value;
					Lip = lipHoodDataFormatter.DbString;
				}
			}

			#endregion

			#region Gauge

			private GaugeDataFormatter _gaugeDataFormatter;

			private GaugeDataFormatter gaugeDataFormatter
			{
				get
				{
					if (_gaugeDataFormatter == null)
					{
						_gaugeDataFormatter = new GaugeDataFormatter(Gauge);
					}
					return _gaugeDataFormatter;
				}
			}

			public decimal DataGaugeSize
			{
				get { return gaugeDataFormatter.Size; }
				set
				{
					gaugeDataFormatter.Size = value;
					Gauge = gaugeDataFormatter.DbDecimal;
				}
			}

			public bool DataIsFullGauge
			{
				get { return gaugeDataFormatter.FullGauge; }
				set 
				{
					gaugeDataFormatter.FullGauge = value;
					Gauge = gaugeDataFormatter.DbDecimal;
				}
			}

			#endregion

			#region Color Info

			private ColorDataFormatter _colorDataFormatter;

			private ColorDataFormatter colorDataFormatter
			{
				get
				{
					if (_colorDataFormatter == null)
					{
						_colorDataFormatter = new ColorDataFormatter(Color);
					}
					return _colorDataFormatter;
				}
			}

			public ProductColor DataProductColor
			{
				get { return colorDataFormatter.ProductColor; }
				set
				{
					colorDataFormatter.ProductColor = value;
					Color = colorDataFormatter.DbString;
				}
			}

			public TransparencyType DataTransparencyType
			{
				get { return colorDataFormatter.TransparencyType; }
				set
				{
					colorDataFormatter.TransparencyType = value;
					Color = colorDataFormatter.DbString;
				}
			}

			#endregion

			#region Folding

			private FoldingDataFormatter _foldingDataFormatter;

			private FoldingDataFormatter foldingDataFormatter
			{
				get
				{
					if (_foldingDataFormatter == null)
					{
						_foldingDataFormatter = new FoldingDataFormatter(Folding);
					}
					return _foldingDataFormatter;
				}
			}

			public FoldType DataFoldType
			{
				get { return foldingDataFormatter.FoldType; }
				set
				{
					foldingDataFormatter.FoldType = value;
					Folding = foldingDataFormatter.DbString;
				}
			}

			public SlitPosition DataSlitPosition
			{
				get { return foldingDataFormatter.SlitPosition; }
				set
				{
					foldingDataFormatter.SlitPosition = value;
					Folding = foldingDataFormatter.DbString;
				}
			}

			public bool DataTrimmed
			{
				get { return foldingDataFormatter.Trimmed; }
				set
				{
					foldingDataFormatter.Trimmed = value;
					Folding = foldingDataFormatter.DbString;
				}
			}
			#endregion

			#region UserRequest

			private UserRequestDataFormatter _userRequestDataFormatter;
			private UserRequestDataFormatter userRequestDataFormatter
			{
				get
				{
					if(_userRequestDataFormatter == null)
					{
						string userRequestString = IsUserRequestNull() ? "" : UserRequest;
						_userRequestDataFormatter = new UserRequestDataFormatter(userRequestString);
					}
					return _userRequestDataFormatter;
				}
			}

			public PackagingType DataPackagingType
			{
				get { return userRequestDataFormatter.Type; }
				set
				{
					userRequestDataFormatter.Type = value;
					UserRequest = userRequestDataFormatter.DbString;
				}
			}

			public decimal DataPackagingValue
			{
				get { return userRequestDataFormatter.Value; }
				set
				{
					userRequestDataFormatter.Value = value;
					UserRequest = userRequestDataFormatter.DbString;
				}
			}

			#endregion

			public int Id
			{
				get { return ID; }
			}

			public void Save(bool overwrite)
			{
				ProductsTableAdapter adapter = new ProductsTableAdapter();
				adapter.Update(this);
			}

			public void RemovePrinting()
			{
				SetPrintingIdNull();
				// db garbage collector must remove the unused record from Printings table
			}

			public bool HasPrinting
			{
				get
				{
					return !IsPrintingIdNull();
				}
			}

//			public IPrintingDataProvider PrintingData
//			{
//				get 
//				{
//					if (!HasPrinting) return null;
//
//					SchemaPrinting.PrintingsDataTable table;
//
//					if (PrintingId <= 0) // no saved printing yet
//					{
//						table = new SchemaPrinting.PrintingsDataTable();
//						table.AddPrintingsRow(Printing)
//					}
//					else
//					{
//						PrintingsTableAdapter adapter = new PrintingsTableAdapter();
//
//						table = adapter.GetDataById(PrintingId);
//						if (table.Count == 0) return null;
//
//						return table[0];
//					}
//				}
//			}

			public void SetPrintingInfo(IPrintingDataProvider printing)
			{
				throw new NotImplementedException();
			}

			public void SetPrintingId(int printingId)
			{
				PrintingId = printingId;
			}
			#endregion

			#region Data Formatters

			class BundleDataFormatter
			{
				private BundleType _bundleType;
				private short _bagCount;
				private WicketSize _wicketSize;

				public BundleDataFormatter(string dbString)
				{
					string[] nibbles = dbString.Split(';');
					if (nibbles.Length != 3)
					{
						_bundleType = BundleType.NoBundle;
						_bagCount = 0;
						_wicketSize = WicketSize.SelectWicket;
					}
					else
					{
						_bundleType = (BundleType)int.Parse(nibbles[0]);
						_bagCount = short.Parse(nibbles[1]);
						_wicketSize = (WicketSize)int.Parse(nibbles[2]);
					}
				}

				/// <summary>
				/// Returns a string that represents the Bundle in database
				/// </summary>
				/// <returns>Format of the return string is: bundle-type;Number of Bags;Wicket Size</returns>
				public string DbString
				{
					get
					{
						if (BundleType == BundleType.NoBundle)
							return "";

						return string.Format("{0};{1};{2}", (int)BundleType, BagCount, (int)WicketSize);
					}
				}

				public BundleType BundleType
				{
					get { return _bundleType; }
					set { _bundleType = value; }
				}

				public short BagCount
				{
					get { return _bagCount; }
					set { _bagCount = value; }
				}

				public WicketSize WicketSize
				{
					get { return _wicketSize; }
					set { _wicketSize = value; }
				}
			}

			class HolesDataFormatter
			{
				private HoleSize _holeSize;
				private short _quantity; // quantity of holes on a product
				private string _comments; // any other comments regarding the holes. that could be the description of position of holes.

				public HolesDataFormatter(string dbString)
				{
					string[] nibbles = dbString.Split(';');
					if (nibbles.Length != 3)
					{
						_holeSize = HoleSize.NoHoles;
						_quantity = 0;
						_comments = "";
					}
					else
					{
						_holeSize = (HoleSize)int.Parse(nibbles[0]);
						_quantity = short.Parse(nibbles[1]);
						_comments = nibbles[2];
					}
				}

				public string DbString
				{
					get
					{
						if (HoleSize == HoleSize.NoHoles)
							return "";

						return string.Format("{0};{1};{2}", (short)HoleSize, Quantity, Comments);
					}
				}

				/// <summary>
				/// gets/set the size/shape of the holes
				/// </summary>
				public HoleSize HoleSize
				{
					get
					{
						return _holeSize;
					}
					set
					{
						_holeSize = value;
					}
				}

				/// <summary>
				/// gets/set the quantity of the holes on the products
				/// </summary>
				public short Quantity
				{
					get
					{
						return _quantity;
					}
					set
					{
						_quantity = value;
					}
				}

				/// <summary>
				/// gets/sets additional comments in regards to the Holes
				/// </summary>
				public string Comments
				{
					get
					{
						return _comments;
					}
					set
					{
						_comments = value;
					}
				}
			}

			class MicroventsDataFormatter
			{
				private MicroventType _type;
				private string _comments;

				internal MicroventsDataFormatter(string dbString)
				{
					string[] nibbles = dbString.Split(';');
					if (nibbles.Length != 2)
					{
						_type = MicroventType.NoMicrovents;
						_comments = "";
					}
					else
					{
						_type = (MicroventType)int.Parse(nibbles[0]);
						_comments = nibbles[1];
					}
				}

				public string DbString
				{
					get
					{
						if (Type == MicroventType.NoMicrovents)
							return "";

						return string.Format("{0};{1}", (int)Type, Comments);
					}
				}

				/// <summary>
				/// gets/sets the type of the <see cref="Microvents"/>
				/// </summary>
				public MicroventType Type
				{
					get { return _type; }
					set { _type = value; }
				}

				/// <summary>
				/// additional comments in regards to <see cref="Microvents"/>
				/// </summary>
				public string Comments
				{
					get { return _comments; }
					set { _comments = value; }
				}
			}

			class ChemicalAdditivesDataFormatter
			{
				[Flags]
				enum Additives
				{
					AntiBlock = 1,
					AntiStatic = 2,
					FoodFlex = 4,
					VirginMaterial = 8,
					Shrink = 16,
					HighImpact = 32,
					Utility = 64
				}

				private Additives _additives;

				internal ChemicalAdditivesDataFormatter(int dbInt)
				{
					_additives = (Additives)dbInt;
				}

				public int DbInt
				{
					get { return (int)_additives; }
				}

				/// <summary>
				/// indicates if product is anti-block
				/// </summary>
				public bool HasAntiBlock
				{
					get { return (_additives & Additives.AntiBlock) == Additives.AntiBlock; }
					set
					{
						if (value)
							_additives |= Additives.AntiBlock;
						else
							_additives &= ~Additives.AntiBlock;
					}
				}

				/// <summary>
				/// indicates if product is anti-static
				/// </summary>
				public bool HasAntiStatic
				{
					get { return (_additives & Additives.AntiStatic) == Additives.AntiStatic; }
					set
					{
						if (value)
							_additives |= Additives.AntiStatic;
						else
							_additives &= ~Additives.AntiStatic;
					}
				}

				/// <summary>
				/// indicates if product is food-flex
				/// </summary>
				public bool HasFoodFlex
				{
					get { return (_additives & Additives.FoodFlex) == Additives.FoodFlex; }
					set
					{
						if (value)
							_additives |= Additives.FoodFlex;
						else
							_additives &= ~Additives.FoodFlex;
					}
				}

				/// <summary>
				/// indicates if product is shrink
				/// </summary>
				public bool HasShrink
				{
					get { return (_additives & Additives.Shrink) == Additives.Shrink; }
					set
					{
						if (value)
							_additives |= Additives.Shrink;
						else
							_additives &= ~Additives.Shrink;
					}
				}

				/// <summary>
				/// indicates if product uses virgin materials only
				/// </summary>
				public bool HasVirginMaterial
				{
					get { return (_additives & Additives.VirginMaterial) == Additives.VirginMaterial; }
					set
					{
						if (value)
							_additives |= Additives.VirginMaterial;
						else
							_additives &= ~Additives.VirginMaterial;
					}
				}

				/// <summary>
				/// indicates if product is high-impact
				/// </summary>
				public bool HasHighImpact
				{
					get { return (_additives & Additives.HighImpact) == Additives.HighImpact; }
					set
					{
						if (value)
							_additives |= Additives.HighImpact;
						else
							_additives &= ~Additives.HighImpact;
					}
				}

				/// <summary>
				/// indicates if product is utility
				/// </summary>
				public bool HasUtility
				{
					get { return (_additives & Additives.Utility) == Additives.Utility; }
					set
					{
						if (value)
							_additives |= Additives.Utility;
						else
							_additives &= ~Additives.Utility;
					}
				}
			}

			class GussetDataFormatter
			{
				private GussetOrientation _orientation;
				private decimal _size;

				public GussetDataFormatter(string dbString)
				{
					string[] nibbles = dbString.Split(';');
					if (nibbles.Length != 2)
					{
						_orientation = GussetOrientation.NoGusset;
						_size = 0;
					}
					else
					{
						_orientation = (GussetOrientation)int.Parse(nibbles[0]);
						_size = decimal.Parse(nibbles[1]);
					}
				}

				public string DbString
				{
					get
					{
						if (Orientation == GussetOrientation.NoGusset)
							return "";

						return string.Format("{0};{1}", (int)Orientation, Size);
					}
				}

				/// <summary>
				/// gets/set the orientation of the gusset. it could be side-gusset or bottom-gusset or no-gusset.
				/// notes: if you set the value of Orientation to no-gusset, the size will be change to 0.
				/// </summary>
				public GussetOrientation Orientation
				{
					get { return _orientation; }
					set { _orientation = value; }
				}

				/// <summary>
				/// gets/sets the size of the Gusset 
				/// </summary>
				public decimal Size
				{
					get { return _size; }
					set
					{
						_size = value;

						if (value == 0)
							_orientation = GussetOrientation.NoGusset; // no gusset
						else
							if (Orientation == GussetOrientation.NoGusset)
								_orientation = GussetOrientation.SideGusset; // default orientation
					}
				}
			}

			class LipHoodDataFormatter
			{
				private HoodType _type;
				private decimal _hoodSize;
				private decimal _lipSize;

				public LipHoodDataFormatter(string dbString)
				{
					string[] nibbles = dbString.Split(';');
					if (nibbles.Length != 3)
					{
						_type = HoodType.None;
						_lipSize = 0;
						_hoodSize = 0;
					}
					else
					{
						_type = (HoodType)int.Parse(nibbles[0]);
						_lipSize = decimal.Parse(nibbles[1]);
						_hoodSize = decimal.Parse(nibbles[2]);
					}
				}

				public string DbString
				{
					get
					{
						return string.Format("{0};{1};{2}", (int)Type, LipSize, HoodSize);
					}
				}

				/// <summary>
				/// gets/sets the type of the Lip or Hood of the product
				/// </summary>
				public HoodType Type
				{
					get
					{
						return _type;
					}
					set
					{
						_type = value;
						if (value == HoodType.None)
							_hoodSize = 0;
					}
				}

				/// <summary>
				/// gets/set the size of lip in inches
				/// </summary>
				public decimal LipSize
				{
					get { return _lipSize; }
					set { _lipSize = value; }
				}

				/// <summary>
				/// gets/set the size of hood in inches
				/// </summary>
				public decimal HoodSize
				{
					get { return _hoodSize; }
					set
					{
						_hoodSize = value;
						if (value == 0)
							_type = HoodType.None; // no hood
					}
				}
			}

			class GaugeDataFormatter
			{
				private decimal _gauge;

				internal GaugeDataFormatter(decimal dbDecimal)
				{
					_gauge = dbDecimal;
				}

				/// <summary>
				/// Size of the <see cref="Gauge"/>
				/// </summary>
				public decimal Size
				{
					get { return Math.Abs(_gauge); }
					set { _gauge = value * (FullGauge ? -1 : 1); }
				}

				/// <summary>
				/// Indicates whether the gauge is full or not
				/// </summary>
				public bool FullGauge
				{
					get { return _gauge < 0; }
					set { _gauge = Size * (value ? -1 : 1); }
				}

				public decimal DbDecimal
				{
					get { return _gauge; }
				}
			}

			class ColorDataFormatter
			{
				private ProductColor _color = ProductColor.Clear;
				private TransparencyType _transparencyType = TransparencyType.RegularClarity;

				public ColorDataFormatter(string dbString)
				{
					if (dbString != "")
					{
						int semicolon = dbString.IndexOf(";", 0);
						_transparencyType = (TransparencyType)(int.Parse(dbString.Substring(0, semicolon)));
						_color = (ProductColor)(short.Parse(dbString.Substring(semicolon + 1)));
					}
				}

				public string DbString
				{
					get
					{
						string colordesc;
						colordesc = ((int)TransparencyType) + ";";
						if ((short)ProductColor != 0)
							colordesc += ((short)ProductColor).ToString();
						else
							colordesc += "0";

						return colordesc;
					}
				}

				public ProductColor ProductColor
				{
					get { return _color; }
					set { _color = value; }
				}

				public TransparencyType TransparencyType
				{
					get { return _transparencyType; }
					set { _transparencyType = value; }
				}
			}

			class FoldingDataFormatter
			{
				private FoldType _foldType = FoldType.Unknown;
				private SlitPosition _slit = SlitPosition.RegencyDecides;
				private bool _trimmed = false;

				/// <summary>
				/// Creates a FoldingDataFormatter object from a string that has been read from database
				/// </summary>
				/// <param name="dbString">A string that represents the <see cref="FoldingInfo"/> on database</param>
				public FoldingDataFormatter(string dbString)
				{
					if (dbString != "")
					{
						int firstsemicolon = dbString.IndexOf(";", 0);
						int secondsemicolon = dbString.IndexOf(";", firstsemicolon + 1);
						int thirdsemicolon = dbString.IndexOf(";", secondsemicolon + 1);
						FoldType = (FoldType)(short.Parse(dbString.Substring(0, firstsemicolon)));
						SlitPosition = (SlitPosition)(int.Parse(dbString.Substring(firstsemicolon + 1, secondsemicolon - firstsemicolon - 1)));
						Trimmed = (dbString.Substring(thirdsemicolon + 1) == "1");
					}
				}

				/// <summary>
				/// Creates a string that represents the FoldingType on database
				/// </summary>
				/// <returns>Returns the string that represents the FoldingType on database
				/// The format of the string is as following:
				///		foldTypeId;slitPositionId;woundTypeId;(1 id trimmed 0 if not)
				///</returns>
				public string DbString
				{
					get
					{
						string foldingdesc;
						if ((short)FoldType != 0)
							foldingdesc = ((short)FoldType) + ";";
						else
							foldingdesc = "0;";
						foldingdesc += ((int)SlitPosition) + ";";
						foldingdesc += "0;"; // used to be carrying the wounded value which is obsolete
						foldingdesc += Trimmed ? "1" : "0";

						return foldingdesc;
					}
				}

				/// <summary>
				/// Indicates the type of folding
				/// For possible values refer to FoldType
				/// </summary>
				public FoldType FoldType
				{
					get { return _foldType; }
					set { _foldType = value; }
				}

				/// <summary>
				/// Indicates the position on the product that slitting should occur
				/// </summary>
				public SlitPosition SlitPosition
				{
					get { return _slit; }
					set { _slit = value; }
				}

				/// <summary>
				/// Indicates whether the product should be trimmed or not
				/// </summary>
				public bool Trimmed
				{
					get { return _trimmed; }
					set { _trimmed = value; }
				}
			}

			class UserRequestDataFormatter
			{
				private PackagingType _userRequestOption;
				private decimal _userRequestValue;

				/// <summary>
				/// Creates a UserRequest object with a string that represents the UserRequest in database.
				/// The string format is as following: UserRequestType;Value
				/// </summary>
				/// <param name="dbString">The string that represents the UserRequest in database.
				/// The string format is as following: UserRequestType;Value</param>
				public UserRequestDataFormatter(string dbString)
				{
					if (string.IsNullOrEmpty(dbString))
					{
						_userRequestOption = PackagingType.NoPreferences;
						_userRequestValue = 0;
					}
					else
					{
						string[] nibbles = dbString.Split(';');

						_userRequestOption = (PackagingType) int.Parse(nibbles[0]);
						_userRequestValue = decimal.Parse(nibbles[1]);
					}
				}

				/// <summary>
				/// Returns a string that should be saved on the database as UserRequest
				/// </summary>
				/// <returns>A string that represents the UserRequest object on database.</returns>
				public string DbString
				{
					get
					{
						if (Type == PackagingType.NoPreferences)
							return "";

						return string.Format("{0};{1}",(short)Type, Value);
					}
				}

				/// <summary>
				/// Represents the <see cref="PackagingType"/>
				/// Some example can be LbPerRoll, LnFtPerRoll, ...
				/// </summary>
				public PackagingType Type
				{
					get { return _userRequestOption; }
					set { _userRequestOption = value; }
				}

				/// <summary>
				/// The value of the <see cref="UserRequest"/>
				/// For example this indicate how many pound per roll (if the userRequestOption is LbPerRoll)
				/// </summary>
				public decimal Value
				{
					get { return _userRequestValue; }
					set { _userRequestValue = value; }
				}
			}

			#endregion
		}
	}
}
