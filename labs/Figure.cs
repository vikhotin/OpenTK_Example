using System;
using System.Windows.Media.Media3D;

namespace labs
{
	public abstract class Figure
	{
		public Point3D[] Vertices
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
		public Cube(double width)
		{
			Vertices = new Point3D[8];
			Vertices[0] = new Point3D(0, 0, 0);
			Vertices[1] = new Point3D(0, width, 0);
			Vertices[2] = new Point3D(width, width, 0);
			Vertices[3] = new Point3D(width, 0, 0);
			Vertices[4] = new Point3D(0, 0, width);
			Vertices[5] = new Point3D(0, width, width);
			Vertices[6] = new Point3D(width, width, width);
			Vertices[7] = new Point3D(width, 0, width);

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
		public Pyramid(double width)
		{
			Vertices = new Point3D[4];
			Vertices[0] = new Point3D(width / 2, -width / 2 / Math.Sqrt(3), -width * Math.Sqrt(6)/9);
			Vertices[1] = new Point3D(-width / 2, -width / 2 / Math.Sqrt(3), -width * Math.Sqrt(6) / 9);
			Vertices[2] = new Point3D(0, width / Math.Sqrt(3), -width * Math.Sqrt(6) / 9);
			Vertices[3] = new Point3D(0, 0, (3 * width * Math.Sqrt(3) - width * Math.Sqrt(6))/9);

			Faces = new int[4][];
			Faces[0] = new int[3] { 0, 1, 2 };
			Faces[1] = new int[3] { 0, 1, 3 };
			Faces[2] = new int[3] { 0, 2, 3 };
			Faces[3] = new int[3] { 1, 2, 3 };
		}
	}
}
