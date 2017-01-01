using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Plasticonnect;

namespace Plasticore
{
	public enum MyEnum
	{
		Item1, Item2
	}

	[Table("TestProducts")]
	public class TestProduct:Product
	{
		public override Uom DefaultUom
		{
			get { throw new System.NotImplementedException(); }
		}

		public override List<Uom> ValidUoms
		{
			get { throw new System.NotImplementedException(); }
		}

		public override decimal Weight
		{
			get { throw new System.NotImplementedException(); }
		}

		public override PackagingType[] GetValidPackages()
		{
			throw new System.NotImplementedException();
		}

		public MyEnum TheEnum { get; set; }
	}
}