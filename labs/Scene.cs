namespace labs
{
	public class Scene
	{
		public Camera camera { get; set; }
		public Figure[] figures { get; set; }

		public Scene(Camera cam, Figure[] figs)
		{
			if (cam == null || figs == null) {
				throw new System.NullReferenceException("Camera or figures is null");
			}
			camera = cam;
			figures = figs;
		}
	}
}
