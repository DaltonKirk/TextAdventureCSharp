namespace TextAdventure
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Game _Game = new Game();

            //start our game loop - we keep running this function until the player quits.
            while (_Game.isRunning)
            {
                _Game.Update();
            }
        }
    }
}