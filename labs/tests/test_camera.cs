﻿using NUnit.Framework;
using System;
using OpenTK;

namespace labs
{
	[TestFixture ()]
	public class test_camera
	{
		[Test ()]
		public void test_camera_n ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			Assert.AreEqual (new Vector3 (0, 0, 0), _cam.Pos);
			Assert.AreEqual (new Vector3 (1, 1, 1), _cam.Trg);
		}

		[Test ()]
		public void test_camera_equal ()
		{
			Assert.Catch (Type.GetType ("labs.EqualPosTrgException"),() => {Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (0, 0, 0));});
		}


		[Test ()]
		public void test_move_xn ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			ShiftDirection dir = ShiftDirection.XAxis;
			_cam.Move (dir, 10);
			Assert.AreEqual (new Vector3(10,0,0),_cam.Pos);
			Assert.AreEqual (new Vector3 (11,1,1), _cam.Trg);
		}

		[Test ()]
		public void test_move_yn ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			ShiftDirection dir = ShiftDirection.YAxis;
			_cam.Move (dir, 10);
			Assert.AreEqual (new Vector3(0,10,0),_cam.Pos);
			Assert.AreEqual (new Vector3 (1,11,1), _cam.Trg);
		}

		[Test ()]
		public void test_move_zn ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			ShiftDirection dir = ShiftDirection.ZAxis;
			_cam.Move (dir, 10);
			Assert.AreEqual (new Vector3(0,0,10),_cam.Pos);
			Assert.AreEqual (new Vector3 (1,1,11), _cam.Trg);
		}

		[Test ()]
		public void test_move_x ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			ShiftDirection dir = ShiftDirection.XAxis;
			_cam.Move (dir, -10);
			Assert.AreEqual (new Vector3(-10,0,0),_cam.Pos);
			Assert.AreEqual (new Vector3 (-9,1,1), _cam.Trg);
		}

		[Test ()]
		public void test_move_y ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			ShiftDirection dir = ShiftDirection.YAxis;
			_cam.Move (dir, -10);
			Assert.AreEqual (new Vector3(0,-10,0),_cam.Pos);
			Assert.AreEqual (new Vector3 (1,-9,1), _cam.Trg);
		}

		[Test ()]
		public void test_move_z ()
		{
			Camera _cam = new Camera (new Vector3 (0, 0, 0), new Vector3 (1, 1, 1));
			ShiftDirection dir = ShiftDirection.ZAxis;
			_cam.Move (dir, -10);
			Assert.AreEqual (new Vector3(0,0,-10),_cam.Pos);
			Assert.AreEqual (new Vector3 (1,1,-9), _cam.Trg);
		}
	}
}

