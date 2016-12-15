namespace labs
{
	public class Scene
	{
		public Camera camera { get; set; }
		public Figure[] figures { get; set; }

		public Scene(Camera cam, Figure[] figs)
		{
			camera = cam;
			figures = figs;
		}
	}
}
