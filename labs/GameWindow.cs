using System;
using System.IO;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace labs
{
    public class Program : GameWindow
    {
		private Renderer renderer;

		int vertex_buffer_object, color_buffer_object, element_buffer_object;

        public Program(int _width, string _fig) : base(800, 600, new GraphicsMode(16, 16))
        {
			Camera cam = new Camera(new Vector3(50, 50, 50), new Vector3(0, 0, 0));

			Figure fig;

			if (_fig == "-c")
			{
				fig = new Cube(_width);
			}
			else // if (_fig == "-p")
			{
				fig = new Pyramid(_width);
			}

			Figure[] figs = { fig };

			Scene scene = new Scene(cam, figs);
			renderer = new Renderer(scene);
		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

			GL.ClearColor(Color.SkyBlue);
            GL.Enable(EnableCap.DepthTest);

            //GL.Ortho(0, 800, 0, 600, -1.0, 1.0);
			Matrix4 p = Matrix4.CreatePerspectiveFieldOfView((float)(80 * Math.PI / 180), 1, 20, 500);
			GL.MatrixMode(MatrixMode.Projection);
			GL.LoadMatrix(ref p);

			CreateVBO();

			using (StreamReader vs = new StreamReader("Simple_VS.glsl"))
			using (StreamReader fs = new StreamReader("Simple_FS.glsl"))
				renderer.CreateShaders(vs.ReadToEnd(), fs.ReadToEnd());

			/*
			Matrix4 modelview = Matrix4.LookAt(70, 70, 70, 0, 0, 0, 0, 1, 0);
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadMatrix(ref modelview);
			*/
        }

		void CreateVBO()
		{
			int size;

			GL.GenBuffers(1, out vertex_buffer_object);
			GL.GenBuffers(1, out color_buffer_object);
			GL.GenBuffers(1, out element_buffer_object);

			renderer.vertex_buffer_object = vertex_buffer_object;
			renderer.color_buffer_object = color_buffer_object;
			renderer.element_buffer_object = element_buffer_object;

			// Upload the vertex buffer.
			GL.BindBuffer(BufferTarget.ArrayBuffer, vertex_buffer_object);
			GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(renderer.scene.figures[0].Vertices.Length * 3 * sizeof(float)),
			              renderer.scene.figures[0].Vertices, BufferUsageHint.StaticDraw);
			GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out size);
			if (size != renderer.scene.figures[0].Vertices.Length * 3 * sizeof(Single))
				throw new ApplicationException(String.Format(
					"Problem uploading vertex buffer to VBO (vertices). Tried to upload {0} bytes, uploaded {1}.",
					renderer.scene.figures[0].Vertices.Length * 3 * sizeof(Single), size));

			// Upload the color buffer.
			GL.BindBuffer(BufferTarget.ArrayBuffer, color_buffer_object);
			GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(renderer.scene.figures[0].Colors.Length * sizeof(int)), 
			              renderer.scene.figures[0].Colors, BufferUsageHint.StaticDraw);
			GL.GetBufferParameter(BufferTarget.ArrayBuffer, BufferParameterName.BufferSize, out size);
			if (size != renderer.scene.figures[0].Colors.Length * sizeof(int))
				throw new ApplicationException(String.Format(
					"Problem uploading vertex buffer to VBO (colors). Tried to upload {0} bytes, uploaded {1}.",
					renderer.scene.figures[0].Colors.Length * sizeof(int), size));

			// Upload the index buffer (elements inside the vertex buffer, not color indices as per the IndexPointer function!)
			GL.BindBuffer(BufferTarget.ElementArrayBuffer, element_buffer_object);
			GL.BufferData(BufferTarget.ElementArrayBuffer, (IntPtr)(renderer.scene.figures[0].Faces.Length * sizeof(Int32)), 
			              renderer.scene.figures[0].Faces, BufferUsageHint.StaticDraw);
			GL.GetBufferParameter(BufferTarget.ElementArrayBuffer, BufferParameterName.BufferSize, out size);
			if (size != renderer.scene.figures[0].Faces.Length * sizeof(int))
				throw new ApplicationException(String.Format(
					"Problem uploading vertex buffer to VBO (offsets). Tried to upload {0} bytes, uploaded {1}.",
					renderer.scene.figures[0].Faces.Length * sizeof(int), size));
		}

		protected override void OnUnload(EventArgs e)
		{
			if (vertex_buffer_object != 0)
				GL.DeleteBuffers(1, ref vertex_buffer_object);
			if (element_buffer_object != 0)
				GL.DeleteBuffers(1, ref element_buffer_object);
			if (renderer.shader_program != 0)
				GL.DeleteProgram(renderer.shader_program);
			if (renderer.fragment_shader_object != 0)
				GL.DeleteShader(renderer.fragment_shader_object);
			if (renderer.vertex_shader_object != 0)
				GL.DeleteShader(renderer.vertex_shader_object);
		}

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(0, 0, Width, Height);
        }


        protected override void OnUpdateFrame(FrameEventArgs e)
        {
			int shift_speed = 3;

            base.OnUpdateFrame(e);

            if (Keyboard[OpenTK.Input.Key.Escape])
            {
                this.Exit();
                return;
            }
			if (Keyboard[OpenTK.Input.Key.W])
			{
				renderer.scene.camera.Move(ShiftDirection.XAxis, shift_speed);
				return;
			}
			if (Keyboard[OpenTK.Input.Key.A])
			{
				renderer.scene.camera.Move(ShiftDirection.YAxis, shift_speed);
				return;
			}
			if (Keyboard[OpenTK.Input.Key.S])
			{
				renderer.scene.camera.Move(ShiftDirection.XAxis, -shift_speed);
				return;
			}
			if (Keyboard[OpenTK.Input.Key.D])
			{
				renderer.scene.camera.Move(ShiftDirection.YAxis, -shift_speed);
				return;
			}
			if (Keyboard[OpenTK.Input.Key.Q])
			{
				renderer.scene.camera.Move(ShiftDirection.ZAxis, -shift_speed);
				return;
			}
			if (Keyboard[OpenTK.Input.Key.E])
			{
				renderer.scene.camera.Move(ShiftDirection.ZAxis, shift_speed);
				return;
			}
        }

		/*
        public void DrawCircle(float x, float y, float r)
        {
            float alp, k = 360 / 10;
			GL.Begin(PrimitiveType.LineStrip);
            for (int i = 0; i <= 10; i++)
            {
                alp = k * i * (float)Math.PI / 180.0f;
                GL.Vertex3(r * Math.Cos(alp) + x, r * (float)Math.Sin(alp) + y, 0);
            }
            GL.End();
        }
        */

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

			/*DrawCircle(50, 50, 50);*/
			renderer.Render();

            this.SwapBuffers();
        }
    }    
}