using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace labs
{
	public class Renderer
	{
		public Scene scene { get; private set; }

		public Renderer(Scene s)
		{
			if (s == null)
				throw new NullReferenceException ("Scene is null");
			scene = s;
		}

		public void Render()
		{
			Matrix4 mat = Matrix4.LookAt(Convert.ToSingle(scene.camera.Pos.X),
										 Convert.ToSingle(scene.camera.Pos.Y),
										 Convert.ToSingle(scene.camera.Pos.Z),
										 Convert.ToSingle(scene.camera.Trg.X),
										 Convert.ToSingle(scene.camera.Trg.Y),
										 Convert.ToSingle(scene.camera.Trg.Z),
										 0, 0, 1);
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadMatrix(ref mat);

			foreach (var fig in scene.figures)
			{
				foreach (var face in fig.Faces)
				{
					GL.Color3(Color.Red);
					GL.Begin(PrimitiveType.Polygon);
					foreach (var point in face)
					{
						GL.Vertex3(fig.Vertices[point].X,
								   fig.Vertices[point].Y,
								   fig.Vertices[point].Z);
					}
					GL.End();

					GL.Color3(Color.Black);
					GL.Begin(PrimitiveType.LineLoop);
					foreach (var point in face)
					{
						GL.Vertex3(fig.Vertices[point].X,
								   fig.Vertices[point].Y,
								   fig.Vertices[point].Z);
					}
					GL.End();
				}
			}
		}
	}
}
