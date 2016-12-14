using NUnit.Framework;
using System;
using OpenTK;

namespace labs
{
	[TestFixture ()]
	public class test_figure
	{
		[Test ()]
		public void TestCase ()
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
	}
}

