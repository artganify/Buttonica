using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.Xna.Framework;

namespace Pressiah.Primitives
{
    /// <summary>
    ///     Represents a rectangle using floating point values, because XNA failed to provide one :)
    /// </summary>
    public struct RectangleF
    {
        /// <summary>
        ///     Specifies a <see cref="RectangleF" /> with no position or size
        /// </summary>
        public static readonly RectangleF Zero = new RectangleF();

        /// <summary>
        ///     Gets or sets the X coordinate of the rectangle
        /// </summary>
        public float X;

        /// <summary>
        ///     Gets or sets the Y coordinate of the rectangle
        /// </summary>
        public float Y;

        /// <summary>
        ///     Gets or sets the width of the rectangle
        /// </summary>
        public float Width;

        /// <summary>
        ///     Gets or sets the height of the rectangle
        /// </summary>
        public float Height;

        /// <summary>
        ///     Returns the Y coordinate of the top edge of this rectangle
        /// </summary>
        public float Top => Y;

        /// <summary>
        ///     Returns the Y coordinate of the bottom edge of this rectangle
        /// </summary>
        public float Bottom => Y + Height;

        /// <summary>
        ///     Returns the X coordinate of the left edge of this rectangle
        /// </summary>
        public float Left => X;

        /// <summary>
        ///     Returns the X coordinate of the right edge of this rectangle
        /// </summary>
        public float Right => X + Width;

        /// <summary>
        ///     Gets or sets the top left coordinates of this rectangle
        /// </summary>
        public Vector2 Position
        {
            get { return new Vector2(X, Y); }
            set
            {
                X = value.X;
                Y = value.Y;
            }
        }

        /// <summary>
        ///     Gets or sets the size of this rectangle
        /// </summary>
        public Vector2 Size
        {
            get { return new Vector2(Width, Height); }
            set
            {
                Width = value.X;
                Height = value.Y;
            }
        }

        /// <summary>
        ///     Returns the coordinate of the center of this rectangle
        /// </summary>
        public Vector2 Center => new Vector2(X + Width/2f, Y + Height/2f);

        /// <summary>
        ///     Returns whether the rectangle is currently empty
        /// </summary>
        public bool IsEmpty => Width.Equals(0) && Height.Equals(0) && X.Equals(0) && Y.Equals(0);

        /// <summary>
        ///     Creates a new <see cref="RectangleF" /> with the specified position, width and height
        /// </summary>
        public RectangleF(float x, float y, float width, float height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        ///     Creates a new <see cref="RectangleF" /> with the specified location and size.
        /// </summary>
        public RectangleF(Vector2 location, Vector2 size)
        {
            X = location.X;
            Y = location.Y;
            Width = size.X;
            Height = size.Y;
        }

        /// <summary>
        ///     Returns whether two <see cref="RectangleF" /> are equal.
        /// </summary>
        public static bool operator ==(RectangleF a, RectangleF b)
        {
            const float epsilon = 0.00001f;
            return Math.Abs(a.X - b.X) < epsilon
                   && Math.Abs(a.Y - b.Y) < epsilon
                   && Math.Abs(a.Width - b.Width) < epsilon
                   && Math.Abs(a.Height - b.Height) < epsilon;
        }

        /// <summary>
        ///     Returns whether two <see cref="RectangleF" /> instances are not equal.
        /// </summary>
        public static bool operator !=(RectangleF a, RectangleF b)
        {
            return !(a == b);
        }

        /// <summary>
        ///     Returns whether the specified coordinates lie within the bounds of this <see cref="RectangleF" />.
        /// </summary>
        public bool Contains(int x, int y) => X <= x && x < X + Width && Y <= y && y < Y + Height;

        /// <summary>
        ///     Returns whether the specified coordinates lie within the bounds of this <see cref="RectangleF" />.
        /// </summary>
        public bool Contains(float x, float y) => X <= x && x < X + Width && Y <= y && y < Y + Height;

        /// <summary>
        ///     Returns whether the specified <see cref="Point" /> lies within the bounds of this <see cref="RectangleF" />.
        /// </summary>
        public bool Contains(Point value) => X <= value.X && value.X < X + Width && Y <= value.Y && value.Y < Y + Height;

        /// <summary>
        ///     Returns whether the specified <see cref="Point" /> lies within the bounds of this <see cref="RectangleF" />.
        /// </summary>
        /// <param name="value">The coordinates to check for inclusion in this <see cref="RectangleF" />.</param>
        /// <param name="result">
        ///     <c>true</c> if the provided <see cref="Point" /> lies inside this <see cref="RectangleF" />;
        ///     <c>false</c> otherwise. As an output parameter.
        /// </param>
        public void Contains(ref Point value, out bool result)
            => result = X <= value.X && value.X < X + Width && Y <= value.Y && value.Y < Y + Height;

        /// <summary>
        ///     Returns whether the specified <see cref="Vector2" /> lies within the bounds of this <see cref="RectangleF" />.
        /// </summary>
        public bool Contains(Vector2 value) => X <= value.X && value.X < X + Width && Y <= value.Y && value.Y < Y + Height;

        /// <summary>
        ///     Returns whether the specified <see cref="Vector2" /> lies within the bounds of this <see cref="RectangleF" />.
        /// </summary>
        public void Contains(ref Vector2 value, out bool result)
            => result = (X <= value.X) && (value.X < X + Width) && (Y <= value.Y) && (value.Y < Y + Height);

        /// <summary>
        ///     Returns whether the specified <see cref="RectangleF" /> lies within the bounds of this <see cref="RectangleF" />.
        /// </summary>
        public bool Contains(RectangleF value)
            => (X <= value.X) && (value.X + value.Width <= X + Width) && (Y <= value.Y) && (value.Y + value.Height <= Y + Height);

        /// <summary>
        ///     Returns whether the specified <see cref="RectangleF" /> lies within the bounds of this <see cref="RectangleF" />.
        /// </summary>
        public void Contains(ref RectangleF value, out bool result) => result = (X <= value.X) &&
                                                                                (value.X + value.Width <= X + Width) &&
                                                                                (Y <= value.Y) &&
                                                                                (value.Y + value.Height <= Y + Height);

        /// <summary>
        ///     Returns whether the current instance is equal to specified <see cref="object" />.
        /// </summary>
        public override bool Equals(object obj) => obj is RectangleF && this == (RectangleF) obj;

        /// <summary>
        ///     Returns whether the current instance is equal to specified <see cref="RectangleF" />.
        /// </summary>
        public bool Equals(RectangleF other) => this == other;

        /// <summary>
        ///     Returns the hash code of this <see cref="RectangleF" />.
        /// </summary>
        [SuppressMessage("ReSharper", "NonReadonlyMemberInGetHashCode")]
        public override int GetHashCode() => X.GetHashCode() ^ Y.GetHashCode() ^ Width.GetHashCode() ^ Height.GetHashCode();

        /// <summary>
        ///     Adjusts the edges of this <see cref="RectangleF" /> by specified horizontal and vertical amounts.
        /// </summary>
        public void Inflate(int horizontalAmount, int verticalAmount)
        {
            X -= horizontalAmount;
            Y -= verticalAmount;
            Width += horizontalAmount*2;
            Height += verticalAmount*2;
        }

        /// <summary>
        ///     Adjusts the edges of this <see cref="RectangleF" /> by specified horizontal and vertical amounts.
        /// </summary>
        public void Inflate(float horizontalAmount, float verticalAmount)
        {
            X -= horizontalAmount;
            Y -= verticalAmount;
            Width += horizontalAmount*2;
            Height += verticalAmount*2;
        }

        /// <summary>
        ///     Returns whether the other <see cref="RectangleF" /> intersects with this RectangleF.
        /// </summary>
        public bool Intersects(RectangleF value) => value.Left <= Right && Left <= value.Right &&
                                                    value.Top <= Bottom && Top <= value.Bottom;


        /// <summary>
        ///     Returns whether thee other <see cref="RectangleF" /> intersects with this rectangle.
        /// </summary>
        public void Intersects(ref RectangleF value, out bool result) => result = value.Left < Right && Left < value.Right &&
                                                                                  value.Top < Bottom && Top < value.Bottom;

        /// <summary>
        ///     Returns a new <see cref="RectangleF" /> that contains overlapping region of two other rectangles.
        /// </summary>
        public static RectangleF Intersect(RectangleF value1, RectangleF value2)
        {
            RectangleF rectangle;
            Intersect(ref value1, ref value2, out rectangle);
            return rectangle;
        }

        /// <summary>
        ///     Returns a new <see cref="RectangleF" /> that contains overlapping region of two other rectangles.
        /// </summary>
        public static void Intersect(ref RectangleF value1, ref RectangleF value2, out RectangleF result)
        {
            if (value1.Intersects(value2))
            {
                var rightSide = Math.Min(value1.X + value1.Width, value2.X + value2.Width);
                var leftSide = Math.Max(value1.X, value2.X);
                var topSide = Math.Max(value1.Y, value2.Y);
                var bottomSide = Math.Min(value1.Y + value1.Height, value2.Y + value2.Height);
                result = new RectangleF(leftSide, topSide, rightSide - leftSide, bottomSide - topSide);
            }
            else
            {
                result = new RectangleF(0, 0, 0, 0);
            }
        }

        /// <summary>
        ///     Moves the current <see cref="RectangleF" /> by the specified offset
        /// </summary>
        public void Move(int offsetX, int offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        /// <summary>
        ///     Moves the current <see cref="RectangleF" /> by the specified offset
        /// </summary>
        public void Offset(float offsetX, float offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        /// <summary>
        ///     Moves the current <see cref="RectangleF" /> by the specified offset
        /// </summary>
        public void Move(Point amount)
        {
            X += amount.X;
            Y += amount.Y;
        }

        /// <summary>
        ///     Moves the current <see cref="RectangleF" /> by the specified offset
        /// </summary>
        public void Offset(Vector2 amount)
        {
            X += amount.X;
            Y += amount.Y;
        }

        /// <summary>
        ///     Returns a string representation of this <see cref="RectangleF" />
        /// </summary>
        public override string ToString() => "{X:" + X + " Y:" + Y + " Width:" + Width + " Height:" + Height + "}";

        /// <summary>
        ///     Unions two specified <see cref="RectangleF">rectangles</see>
        /// </summary>
        public static RectangleF Union(RectangleF value1, RectangleF value2)
        {
            var x = Math.Min(value1.X, value2.X);
            var y = Math.Min(value1.Y, value2.Y);
            return new RectangleF(x, y,
                Math.Max(value1.Right, value2.Right) - x,
                Math.Max(value1.Bottom, value2.Bottom) - y);
        }

        /// <summary>
        ///     Unions two specified <see cref="RectangleF">rectangles</see>
        /// </summary>
        public static void Union(ref RectangleF value1, ref RectangleF value2, out RectangleF result)
        {
            result.X = Math.Min(value1.X, value2.X);
            result.Y = Math.Min(value1.Y, value2.Y);
            result.Width = Math.Max(value1.Right, value2.Right) - result.X;
            result.Height = Math.Max(value1.Bottom, value2.Bottom) - result.Y;
        }

        /// <summary>
        ///     Creates a new <see cref="RectangleF" /> from the specified center and the specified with and height
        /// </summary>
        public static RectangleF FromCenter(float x, float y, float width, float height)
            => FromCenter(new Vector2(x, y), width, height);

        /// <summary>
        ///     Creates a new <see cref="RectangleF" /> from the specified center and the specified with and height
        /// </summary>
        public static RectangleF FromCenter(Vector2 center, float width, float height)
            => new RectangleF(new Vector2(center.X - width/2, center.Y - height/2), new Vector2(width, height));

    }
}