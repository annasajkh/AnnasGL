namespace SampleApp
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            using (Game game = new Game("Sample App", 960, 540))
            {
                game.Run();
            }
        }
    }
}