using System;
using OpenTK;

namespace labs
{
	
	[Serializable]
	public class FigureZeroSizeException : Exception
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="T:FigureZeroSizeException"/> class
		/// </summary>
		public FigureZeroSizeException ()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FigureZeroSizeException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		public FigureZeroSizeException (string message) : base (message)
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FigureZeroSizeException"/> class
		/// </summary>
		/// <param name="message">A <see cref="T:System.String"/> that describes the exception. </param>
		/// <param name="inner">The exception that is the cause of the current exception. </param>
		public FigureZeroSizeException (string message, Exception inner) : base (message, inner)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="T:FigureZeroSizeException"/> class
		/// </summary>
		/// <param name="context">The contextual information about the source or destination.</param>
		/// <param name="info">The object that holds the serialized object data.</param>
		protected FigureZeroSizeException (System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base (info, context)
		{
		}
	}

	public abstract class Figure
	{
		public Vector3[] Vertices
		{
			get;
			protected set;
		}

		public int[][] Faces
		{
			get;
			protected set;
		}
	}

	class Cube : Figure
	{
		public Cube(float width)
		{

			if (width == 0)
				throw new FigureZeroSizeException("Cube size = 0");


			Vertices = new Vector3[8];
			Vertices[0] = new Vector3(0, 0, 0);
			Vertices[1] = new Vector3(0, width, 0);
			Vertices[2] = new Vector3(width, width, 0);
			Vertices[3] = new Vector3(width, 0, 0);
			Vertices[4] = new Vector3(0, 0, width);
			Vertices[5] = new Vector3(0, width, width);
			Vertices[6] = new Vector3(width, width, width);
			Vertices[7] = new Vector3(width, 0, width);

			Faces = new int[6][];
			Faces[0] = new int[4] { 0, 1, 2, 3 };
			Faces[1] = new int[4] { 0, 3, 7, 4 };
			Faces[2] = new int[4] { 4, 5, 6, 7 };
			Faces[3] = new int[4] { 1, 2, 6, 5 };
			Faces[4] = new int[4] { 0, 1, 5, 4 };
			Faces[5] = new int[4] { 2, 3, 7, 6 };
		}
	}

	class Pyramid : Figure
	{
		public Pyramid(float width)
		{
			if (width == 0)
				throw new FigureZeroSizeException("Pyramide size = 0");
			
			float r3 = Convert.ToSingle(Math.Sqrt(3));
			float r6 = Convert.ToSingle(Math.Sqrt(6));

			Vertices = new Vector3[4];
			Vertices[0] = new Vector3(width / 2, -width / 2 / r3, -width * r6/9);
			Vertices[1] = new Vector3(-width / 2, -width / 2 / r3, -width * r6 / 9);
			Vertices[2] = new Vector3(0, width / r3, -width * r6 / 9);
			Vertices[3] = new Vector3(0, 0, (3 * width * r3 - width * r6)/9);

			Faces = new int[4][];
			Faces[0] = new int[3] { 0, 1, 2 };
			Faces[1] = new int[3] { 0, 1, 3 };
			Faces[2] = new int[3] { 0, 2, 3 };
			Faces[3] = new int[3] { 1, 2, 3 };
		}
	}
}
