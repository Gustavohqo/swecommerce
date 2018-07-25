namespace model
{
    public class CartItem
    {
        public long ProductID { get; set; }

        public int Amount { get; set; }


        protected bool Equals(CartItem other)
        {
            return ProductID == other.ProductID;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CartItem) obj);
        }

        public override int GetHashCode()
        {
            return ProductID.GetHashCode();
        }

        public static bool operator ==(CartItem left, CartItem right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CartItem left, CartItem right)
        {
            return !Equals(left, right);
        }
    }
}