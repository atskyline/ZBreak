using System.Drawing;

namespace ZBreak
{
    struct Pixel
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Color Color { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Pixel))
            {
                return false;
            }

            Pixel other = (Pixel)obj;

            if (this.X == other.X &&
                this.Y == other.Y &&
                this.Color == other.Color)
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return X.GetHashCode() ^
                   Y.GetHashCode() ^
                   Color.GetHashCode();
        }

        public static bool operator ==(Pixel left, Pixel right)
        {
            return left.Equals(right);
        }
        public static bool operator !=(Pixel left, Pixel right)
        {
            return !(left == right);
        }
    }
}
