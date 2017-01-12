using System;
using OpenTK;

namespace labs
{
 
	[Serializable]
	public class EqualPosTrgException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:Exception"/> class
		/// </summary>
		public EqualPosTrgException ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:EqualPosTrgException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		public EqualPosTrgException (string message) : base (message)
		{

		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:EqualPosTrgException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		/// <param name="inner">The exception that is the cause of the current exception. </param>
		public EqualPosTrgException (string message, Exception inner) : base (message, inner)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:EqualPosTrgException"/> class
		/// </summary>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <param name="info">The object that holds the serialized object data.</param>
		protected EqualPosTrgException (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (info, context)
		{
		}
	}

	public enum ShiftDirection
	{
		XAxis,
		YAxis,
		ZAxis,
	}

	public sealed class Camera
	{
		public Vector3 Pos
		{
			get;
			set;
		}
		
		public Vector3 Trg //Target
		{
			get;
			set;
		}

		public Camera(Vector3 pos, Vector3 trg)
		{
			if (pos == trg)
				throw new EqualPosTrgException("Position and target are equal!");
			Pos = pos;
			Trg = trg;
		}

		public void Move(ShiftDirection dir, float shift)
		{
			switch (dir)
			{
				case ShiftDirection.XAxis:
					Pos = new Vector3(Pos.X + shift, Pos.Y, Pos.Z);
					Trg = new Vector3(Trg.X + shift, Trg.Y, Trg.Z);
					break;
				case ShiftDirection.YAxis:
					Pos = new Vector3(Pos.X, Pos.Y + shift, Pos.Z);
					Trg = new Vector3(Trg.X, Trg.Y + shift, Trg.Z);
					break;
				case ShiftDirection.ZAxis:
					Pos = new Vector3(Pos.X, Pos.Y, Pos.Z + shift);
					Trg = new Vector3(Trg.X, Trg.Y, Trg.Z + shift);
					break;					
				default:
					break;
			}
		}
			

	}
}
