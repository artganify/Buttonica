using Buttonica.Engine.Core.Types;
using Buttonica.Engine.Entities;
using Microsoft.Xna.Framework;

namespace Buttonica.Engine.Graphics
{
	/// <summary>
	///     Represents an entity within a 2D world space
	/// </summary>
	public class Entity2D : EntityBase
	{
		private RectangleF _drawArea;
		private float _rotation;

		/// <summary>
		///     Gets or sets the draw area of this entity
		/// </summary>
		public RectangleF DrawArea
		{
			get { return _drawArea; }
			set
			{
				_drawArea = value;
				OnPositionChanged();
			}
		}

		/// <summary>
		///     Gets or sets the positon of this entity
		/// </summary>
		public Vector2 Position
		{
			get { return new Vector2(_drawArea.X, _drawArea.Y); }
			set { DrawArea = new RectangleF(value.X, value.Y, _drawArea.Width, _drawArea.Height); }
		}

		/// <summary>
		///     Gets or sets the rotation of this entity, in degrees
		/// </summary>
		public float Rotation
		{
			get { return _rotation; }
			set
			{
				_rotation = value;
				OnRotationChanged();
			}
		}

		/// <summary>
		///     Gets or sets the top left coordinate of the entity
		/// </summary>
		public Vector2 TopLeft
		{
			get { return DrawArea.Position; }
			set { DrawArea = new RectangleF(value, DrawArea.Size); }
		}

		/// <summary>
		///     Gets or sets the center coordinates of the entity
		/// </summary>
		public Vector2 Center
		{
			get { return DrawArea.Center; }
			set { DrawArea = RectangleF.FromCenter(value, DrawArea.Width, DrawArea.Height); }
		}

		/// <summary>
		///     Gets or sets the size of the entity
		/// </summary>
		public Vector2 Size
		{
			get { return DrawArea.Size; }
			set { DrawArea = RectangleF.FromCenter(DrawArea.Center, value.X, value.Y); }
		}

		/// <summary>
		///     Creates a new <see cref="Entity2D" />
		/// </summary>
		protected Entity2D()
		{
		}

		/// <summary>
		///     Creates a new <see cref="Entity2D" /> using the specified draw area
		/// </summary>
		public Entity2D(RectangleF drawArea)
		{
			_drawArea = drawArea;
		}

		/// <summary>
		///     Invoked when the position of the entity has changed
		/// </summary>
		protected virtual void OnPositionChanged()
		{
		}

		/// <summary>
		///     Invoked when the rotation of the entity has changed
		/// </summary>
		protected virtual void OnRotationChanged()
		{
		}
	}
}