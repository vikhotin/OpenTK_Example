using NUnit.Framework;
using System;
using OpenTK;

namespace labs
{
	[TestFixture ()]
	public class test_scene
	{
		[Test ()]
		public void TestScene ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			Cube _cube = new Cube (10);
			Scene _sc = new Scene (_cam, new Figure[1] { _cube });	
			Assert.AreEqual (_sc.camera, _cam);
			Assert.AreEqual (_sc.figures[0], _cube);
		}

		[Test ()]
		public void TestSceneExc ()
		{
			Camera _cam = null;
			Cube _cube = new Cube (10);
			//Scene _sc = new Scene (_cam, new Figure[1] { _cube });
			Assert.Catch (Type.GetType("System.NullReferenceException"), () => {
				Scene _sc = new Scene (_cam, new Figure[1] { _cube });
			});

			_cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			Assert.Catch (Type.GetType("System.NullReferenceException"), () => {
				Scene _sc = new Scene (_cam, null);
			});

		}

	}
}

