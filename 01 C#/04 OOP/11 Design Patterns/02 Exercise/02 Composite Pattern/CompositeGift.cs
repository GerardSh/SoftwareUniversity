using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        readonly HashSet<GiftBase> giftBases;

        public CompositeGift(string name, decimal price)
            : base(name, price)
        {
            giftBases = new HashSet<GiftBase>();
        }

        public void Add(GiftBase gift) => giftBases.Add(gift);

        public void Remove(GiftBase gift) => giftBases.Remove(gift);

        public override decimal CalculateTotalPrice()
        {
            decimal totalPrice = giftBases.Sum(x => x.CalculateTotalPrice());

            return totalPrice;
        }
    }
}
