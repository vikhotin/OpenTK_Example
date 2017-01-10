using NUnit.Framework;
using System;
using OpenTK;

namespace labs
{
	[TestFixture ()]
	public class test_figure
	{
		[Test ()]
		public void TestCube ()
		{
			float width = 10;
			Cube _cube = new Cube (width);
			Assert.AreEqual (new Vector3[8] {new Vector3 (0, 0, 0),
				new Vector3 (0, width, 0),
				new Vector3 (width, width, 0),
				new Vector3 (width, 0, 0),
				new Vector3 (0, 0, width),
				new Vector3 (0, width, width),
				new Vector3 (width, width, width),
				new Vector3 (width, 0, width)
			}, _cube.Vertices);
		}

		[Test ()]
		public void TestCubeMax ()
		{
			string temp = "3,402823E+39";
			Assert.Catch(Type.GetType("System.OverflowException"),()=>{Cube _cube = new Cube (float.Parse(temp));});
		}
		[Test ()]
		public void TestCubeMin ()
		{
			string temp = "-3,402823E+39";
			Assert.Catch(Type.GetType("System.OverflowException"),()=>{Cube _cube = new Cube (float.Parse(temp));});
		}

		[Test ()]
		public void TestCubeZero ()
		{
			Assert.Catch(Type.GetType("labs.FigureZeroSizeException"),()=>{Cube _cube = new Cube (0);});
		}

		[Test ()]
		public void TestPyramidMax ()
		{
			string temp = "3,402823E+39";
			Assert.Catch(Type.GetType("System.OverflowException"),()=>{Pyramid _pyr = new Pyramid  (float.Parse(temp));});
		}

		[Test ()]
		public void TestPyramidMin ()
		{
			string temp = "-3,402823E+39";
			Assert.Catch(Type.GetType("System.OverflowException"),()=>{Pyramid _pyr = new Pyramid  (float.Parse(temp));});
		}

		[Test ()]
		public void TestPyramidZero ()
		{
			Assert.Catch(Type.GetType("labs.FigureZeroSizeException"),()=>{Pyramid _pyr = new Pyramid (0);});
		}

		[Test ()]
		public void TestPyramid ()
		{
			float width = 10;
			Pyramid _pyr = new Pyramid (width);


			float r3 = Convert.ToSingle(Math.Sqrt(3));
			float r6 = Convert.ToSingle(Math.Sqrt(6));

			Assert.AreEqual (new Vector3[4] {new Vector3(width / 2, -width / 2 / r3, -width * r6/9),
				new Vector3(-width / 2, -width / 2 / r3, -width * r6 / 9),
				new Vector3 (0, width / r3, -width * r6 / 9),
				new Vector3 (0, 0, (3 * width * r3 - width * r6)/9)
			}, _pyr.Vertices);
		}
	}
}

