using VGP133_Final_Karlsson_Vincent;

bool running = true;

while (running)
{
    UI.RenderMenuHeader("Game Start");
    UI.PrintMenu<GameStart>();
    int menuInput = Globals.GetMenuChoice<GameStart>();
    GameManager gameManager = new GameManager();

    switch ((GameStart)menuInput)
    {
        case GameStart.NewGame:
            gameManager.Initialize(true);
            break;
        case GameStart.Continue:
            gameManager.Initialize(false);
            break;
        case GameStart.Exit:
            Console.WriteLine("\n--| EXITING GAME |--");
            running = false;
            break;
        default:
            break;
    }

    Globals.Pause();

    if (gameManager.Player != null)
    {
        gameManager.Game();
    }
}