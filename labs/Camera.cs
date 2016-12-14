using System;
using System.Windows.Media.Media3D;

namespace labs
{
	public enum ShiftDirection
	{
		XAxis,
		YAxis,
		ZAxis,
	}

	public sealed class Camera
	{
		public Point3D Pos
		{
			get;
			set;
		}
		
		public Point3D Trg //Target
		{
			get;
			set;
		}

		public Camera(Point3D pos, Point3D trg)
		{
			Pos = pos;
			Trg = trg;
		}

		public void Move(ShiftDirection dir, double shift)
		{
			switch (dir)
			{
				case ShiftDirection.XAxis:
					Pos = new Point3D(Pos.X + shift, Pos.Y, Pos.Z);
					Trg = new Point3D(Trg.X + shift, Trg.Y, Trg.Z);
					break;
				case ShiftDirection.YAxis:
					Pos = new Point3D(Pos.X, Pos.Y + shift, Pos.Z);
					Trg = new Point3D(Trg.X, Trg.Y + shift, Trg.Z);
					break;
				case ShiftDirection.ZAxis:
					Pos = new Point3D(Pos.X, Pos.Y, Pos.Z + shift);
					Trg = new Point3D(Trg.X, Trg.Y, Trg.Z + shift);
					break;					
				default:
					break;
			}
		}
		/*
		public void Rotate(ShiftDirection dir, double shift)
		{
			switch (dir)
			{
				case ShiftDirection.XAxis:
					Pos = new Point3D(Pos.X + shift, Pos.Y, Pos.Z);
					//Trg = new Point3D(Trg.X + shift, Trg.Y, Trg.Z);
					break;
				case ShiftDirection.YAxis:
					Pos = new Point3D(Pos.X, Pos.Y + shift, Pos.Z);
					//Trg = new Point3D(Trg.X, Trg.Y + shift, Trg.Z);
					break;
				case ShiftDirection.ZAxis:
					Pos = new Point3D(Pos.X, Pos.Y, Pos.Z + shift);
					//Trg = new Point3D(Trg.X, Trg.Y, Trg.Z + shift);
					break;
				default:
					break;
			}
		}
		*/
	}
}
