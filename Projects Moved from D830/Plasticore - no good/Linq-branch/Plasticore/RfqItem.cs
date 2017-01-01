namespace Plasticore
{
	public partial class RfqItem : RequisitionItem
	{
        private DataAccessLayer.RfqItem _rfqItemData;
        private Product _product;
        public new Product Product
        {
            get
            {
                if (_product == null)
                    switch ((Product.ProductType)_rfqItemData.Product.Type)
                    {
                        case Product.ProductType.LooseBag: _product = new LooseBag(_rfqItemData.Product);
                            break;
                        case Product.ProductType.LooseSheet: _product = new LooseSheet(_rfqItemData.Product);
                            break;
                        case Product.ProductType.PtoSheet: _product = new PtoSheet(_rfqItemData.Product);
                            break;
                        case Product.ProductType.PtoBag: _product = new PtoBag(_rfqItemData.Product);
                            break;
                        case Product.ProductType.PtoSleeve: _product = new PtoSleeve(_rfqItemData.Product);
                            break;
                        case Product.ProductType.Sheeting: _product = new Sheeting(_rfqItemData.Product);
                            break;
                        case Product.ProductType.Tubing: _product = new Tubing(_rfqItemData.Product);
                            break;
                        case Product.ProductType.Cgp: _product = new Cgp(_rfqItemData.Product);
                            break;
                    }
                return _product;
            }
            set { _product = value; }
        }


		public enum QuantityRequested
		{
			/// <summary>
			/// Indicates that the quantity requested is exact number
			/// </summary>
			Exact,

			/// <summary>
			/// Asked for the minimum possible quantity. sellers decides the quantity and put it in the quote
			/// </summary>
			MinimumQuantity
		}

		public Condition AddCondition(string condition)
		{
			return AddCondition(Condition.AuthorType.Buyer, condition);
		}
	}
}
