using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace labs
{
    public class Program : GameWindow
    {
		private Renderer renderer;

        public Program() : base(800, 600, new GraphicsMode(16, 16))
        {
			Camera cam = new Camera(new Vector3(50, 50, 50), new Vector3(0, 0, 0));
			Cube cube = new Cube(20);
			//Pyramid cube = new Pyramid(20);
			Scene scene = new Scene(cam, new Figure[1] { cube });
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

			/*
			Matrix4 modelview = Matrix4.LookAt(70, 70, 70, 0, 0, 0, 0, 1, 0);
			GL.MatrixMode(MatrixMode.Modelview);
			GL.LoadMatrix(ref modelview);
			*/
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