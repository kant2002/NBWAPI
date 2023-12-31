using System;

namespace NBWAPI
{
    public readonly struct TilePosition : IPoint<TilePosition>
    {
        /// <summary>
        /// The scale of a <see cref="TilePosition"/>. Each tile position corresponds to a 32x32 pixel area.
        /// </summary>
        public const int Scale = PointHelper.TilePositionScale;

        public static readonly TilePosition Invalid = new TilePosition(32000 / PointHelper.TilePositionScale, 32000 / PointHelper.TilePositionScale);
        public static readonly TilePosition None = new TilePosition(32000 / PointHelper.TilePositionScale, 32032 / PointHelper.TilePositionScale);
        public static readonly TilePosition Unknown = new TilePosition(32000 / PointHelper.TilePositionScale, 32064 / PointHelper.TilePositionScale);
        public static readonly TilePosition Origin = new TilePosition(0, 0);

        public static readonly TilePosition TopLeft = new TilePosition(-1, -1);
        public static readonly TilePosition Top = new TilePosition(0, -1);
        public static readonly TilePosition TopRight = new TilePosition(1, -1);
        public static readonly TilePosition Left = new TilePosition(-1, 0);
        public static readonly TilePosition Right = new TilePosition(1, 0);
        public static readonly TilePosition BottomRight = new TilePosition(1, 1);
        public static readonly TilePosition Bottom = new TilePosition(0, 1);
        public static readonly TilePosition BottomLeft = new TilePosition(-1, 1);

        public readonly int x;
        public readonly int y;

        public TilePosition(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public TilePosition(Position p)
            : this(p.x / PointHelper.TilePositionScale, p.y / PointHelper.TilePositionScale)
        {
        }

        public TilePosition(WalkPosition wp)
            : this(wp.x / PointHelper.TileWalkFactor, wp.y / PointHelper.TileWalkFactor)
        {
        }

        public TilePosition(ClientData.Position position)
            : this(position.GetX(), position.GetY())
        {
        }

        public TilePosition Add(TilePosition other)
        {
            return this + other;
        }

        public TilePosition Add(int value)
        {
            return this + new TilePosition(value, value);
        }

        public TilePosition Subtract(TilePosition other)
        {
            return this - other;
        }

        public TilePosition Subtract(int value)
        {
            return this - new TilePosition(value, value);
        }

        public TilePosition Multiply(int multiplier)
        {
            return this * multiplier;
        }

        public TilePosition Divide(int divisor)
        {
            return this / divisor;
        }

        public static bool operator ==(TilePosition p1, TilePosition p2)
        {
            return p1.x == p2.x && p1.y == p2.y;
        }

        public static bool operator !=(TilePosition p1, TilePosition p2)
        {
            return !(p1 == p2);
        }

        public static bool operator <(TilePosition left, TilePosition right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(TilePosition left, TilePosition right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator <=(TilePosition left, TilePosition right)
        {
            return left.CompareTo(right) <= 0;
        }

        public static bool operator >=(TilePosition left, TilePosition right)
        {
            return left.CompareTo(right) >= 0;
        }

        public static TilePosition operator +(TilePosition p1, TilePosition p2)
        {
            return new TilePosition(p1.x + p2.x, p1.y + p2.y);
        }

        public static TilePosition operator +(TilePosition p1, int value)
        {
            return new TilePosition(p1.x + value, p1.y + value);
        }

        public static TilePosition operator +(int value, TilePosition p1)
        {
            return new TilePosition(p1.x + value, p1.y + value);
        }

        public static TilePosition operator -(TilePosition p1, TilePosition p2)
        {
            return new TilePosition(p1.x - p2.x, p1.y - p2.y);
        }

        public static TilePosition operator -(TilePosition p1, int value)
        {
            return new TilePosition(p1.x - value, p1.y - value);
        }

        public static TilePosition operator -(int value, TilePosition p1)
        {
            return new TilePosition(value - p1.x, value - p1.y);
        }

        public static TilePosition operator *(TilePosition p1, int multiplier)
        {
            return new TilePosition(p1.x * multiplier, p1.y * multiplier);
        }

        public static TilePosition operator /(TilePosition p1, int divisor)
        {
            return new TilePosition(p1.x / divisor, p1.y / divisor);
        }

        public int CompareTo(TilePosition other)
        {
            return x == other.x ? y.CompareTo(other.y) : x.CompareTo(other.x);
        }

        public int GetApproxDistance(TilePosition point)
        {
            return PointHelper.GetApproxDistance(x, y, point.x, point.y);
        }

        public double GetDistance(TilePosition point)
        {
            return (this - point).GetLength();
        }

        public double GetLength()
        {
            return PointHelper.GetLength(x, y);
        }

        public bool IsValid(Game game)
        {
            return PointHelper.IsValid(x, y, PointHelper.PositionScale, game);
        }

        public TilePosition MakeValid(Game game)
        {
            PointHelper.MakeValid(x, y, PointHelper.PositionScale, game, out int newx, out int newy);
            return new TilePosition(newx, newy);
        }

        public TilePosition SetMax(TilePosition p)
        {
            return new TilePosition(Math.Max(x, p.x), Math.Max(y, p.y));
        }

        public TilePosition SetMin(TilePosition p)
        {
            return new TilePosition(Math.Min(x, p.x), Math.Min(y, p.y));
        }

        public bool Equals(TilePosition other)
        {
            return x == other.x && y == other.y;
        }

        public override bool Equals(object obj)
        {
            return obj is TilePosition p && Equals(p);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }

        public override string ToString()
        {
            return $"({x}, {y})";
        }

        public Position ToPosition()
        {
            return new Position(this);
        }

        public WalkPosition ToWalkPosition()
        {
            return new WalkPosition(this);
        }

        public int X => x;

        public int Y => y;
    }
}