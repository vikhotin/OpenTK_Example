using NUnit.Framework;
using System;
using OpenTK;

namespace labs
{
	[TestFixture ()]
	public class test_camera
	{
		[Test ()]
		public void TestCamera ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			Assert.AreEqual (new Vector3 (0, 0, 0), _cam.Pos);
			Assert.AreEqual (new Vector3 (1, 1, 1), _cam.Trg);
		}

		[Test ()]
		public void TestMoveX ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			ShiftDirection dir = ShiftDirection.XAxis;
			_cam.Move (dir, 10);
			Assert.AreEqual (new Vector3(10,0,0),_cam.Pos);
			Assert.AreEqual (new Vector3 (11,1,1), _cam.Trg);
		}

		[Test ()]
		public void TestMoveY ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			ShiftDirection dir = ShiftDirection.YAxis;
			_cam.Move (dir, 10);
			Assert.AreEqual (new Vector3(0,10,0),_cam.Pos);
			Assert.AreEqual (new Vector3 (1,11,1), _cam.Trg);
		}

		[Test ()]
		public void TestMoveZ ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			ShiftDirection dir = ShiftDirection.ZAxis;
			_cam.Move (dir, 10);
			Assert.AreEqual (new Vector3(0,0,10),_cam.Pos);
			Assert.AreEqual (new Vector3 (1,1,11), _cam.Trg);
		}
	}
}

