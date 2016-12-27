<<<<<<< HEAD
﻿using OpenTK;
using OpenTK.Graphics.OpenGL;
=======
﻿using System;
using OpenTK;
>>>>>>> refs/remotes/origin/alex

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

		/*
		public void Rotate(ShiftDirection dir, float angle)
		{
			switch (dir)
			{
				case ShiftDirection.XAxis:
					//Pos = new Vector3(Pos.X + shift, Pos.Y, Pos.Z);
					//Trg = new Vector3(Trg.X + shift, Trg.Y, Trg.Z);
					//GL.MatrixMode(MatrixMode.Modelview);
					//GL.Rotate(angle, 1, 0, 0);
					break;
				case ShiftDirection.YAxis:
					//Pos = new Vector3(Pos.X, Pos.Y + shift, Pos.Z);
					//Trg = new Vector3(Trg.X, Trg.Y + shift, Trg.Z);
					//GL.MatrixMode(MatrixMode.Modelview);
					//GL.Rotate(angle, 0, 1, 0);
					break;
				case ShiftDirection.ZAxis:
					//Pos = new Vector3(Pos.X, Pos.Y, Pos.Z + shift);
					//Trg = new Vector3(Trg.X, Trg.Y, Trg.Z + shift);
					//GL.MatrixMode(MatrixMode.Modelview);
					//GL.Rotate(angle, 0, 0, 1);
					break;
				default:
					break;
			}
		}
		*/

	}
}
