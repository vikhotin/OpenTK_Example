using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace labs
{
	public class Renderer
	{
		public Scene scene { get; private set; }

		public int vertex_shader_object { get; set; }
		public int fragment_shader_object { get; set; }
		public int shader_program { get; set; }
		public int vertex_buffer_object { get; set; }
		public int color_buffer_object { get; set; }
		public int element_buffer_object { get; set; }

		public Renderer(Scene s)
		{
			if (s == null)
				throw new NullReferenceException ("Scene is null");
			scene = s;
		}

		public void CreateShaders(string vs, string fs)
		{
			int status_code;
			string info;

			vertex_shader_object = GL.CreateShader(ShaderType.VertexShader);
			fragment_shader_object = GL.CreateShader(ShaderType.FragmentShader);

			// Compile vertex shader
			GL.ShaderSource(vertex_shader_object, vs);
			GL.CompileShader(vertex_shader_object);
			GL.GetShaderInfoLog(vertex_shader_object, out info);
			GL.GetShader(vertex_shader_object, ShaderParameter.CompileStatus, out status_code);

			if (status_code != 1)
				throw new ApplicationException(info);

			// Compile vertex shader
			GL.ShaderSource(fragment_shader_object, fs);
			GL.CompileShader(fragment_shader_object);
			GL.GetShaderInfoLog(fragment_shader_object, out info);
			GL.GetShader(fragment_shader_object, ShaderParameter.CompileStatus, out status_code);

			if (status_code != 1)
				throw new ApplicationException(info);

			shader_program = GL.CreateProgram();
			GL.AttachShader(shader_program, fragment_shader_object);
			GL.AttachShader(shader_program, vertex_shader_object);

			GL.LinkProgram(shader_program);
			GL.UseProgram(shader_program);
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

			GL.EnableClientState(ArrayCap.VertexArray);
			GL.EnableClientState(ArrayCap.ColorArray);

			GL.BindBuffer(BufferTarget.ArrayBuffer, vertex_buffer_object);
			GL.VertexPointer(3, VertexPointerType.Float, 0, IntPtr.Zero);
			GL.BindBuffer(BufferTarget.ArrayBuffer, color_buffer_object);
			GL.ColorPointer(4, ColorPointerType.UnsignedByte, 0, IntPtr.Zero);
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, element_buffer_object);

			foreach (var fig in scene.figures)
			{
				GL.DrawElements(PrimitiveType.Triangles, fig.Faces.Length,
					DrawElementsType.UnsignedInt, IntPtr.Zero);
			}

			GL.DisableClientState(ArrayCap.VertexArray);
			GL.DisableClientState(ArrayCap.ColorArray);

			/*
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
			*/
		}
	}
}