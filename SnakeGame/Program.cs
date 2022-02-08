using SnakeGame;

/// <summary>
/// The twist that we added to this program is, we added two walls that represents an obsticale 
/// that if the snake hits a wall the game will end (gameover).
/// </summary>


static ConsoleKey ReadKeyIfExists() => Console.KeyAvailable ? Console.ReadKey(intercept: true).Key : ConsoleKey.NoName;

static void Loop()
{
    bool running = true;
    GameWorld world = new GameWorld();
    try
    {

        // Initialisera spelet
        const int frameRate = 5;

        ConsoleRenderer renderer = new ConsoleRenderer(world);

        // Skapa spelare och andra objekt, genom korrekta anrop till vår GameWorld-instans

        Player Snake = new Player(new Position(25, 10));
        world.GameObjects.Add(Snake);

        Food orgfood = world.CreatFood();
        world.GameObjects.Add(orgfood);
        //System.Diagnostics.Debug.WriteLine("LINE 25 position x " + Snake.position.X + " position y " + Snake.position.Y);

        Wall wallOne = new Wall(new Position(5, 12));
        Wall wallTwo = new Wall(new Position(43, 7));
        wallOne.WallNumber = 1;
        wallTwo.WallNumber = 2;
        world.GameObjects.Add(wallOne);
        world.GameObjects.Add(wallTwo);

        // Huvudloopen

        while (running)
        {
            // Kom ihåg vad klockan var i början
            DateTime before = DateTime.Now;

            // Hantera knapptryckningar från användaren
            ConsoleKey key = ReadKeyIfExists();

            switch (key)
            {// logik för andra knapptryckningar (W, A, S, D)
                case ConsoleKey.Q:
                    running = false;
                    break;

                case ConsoleKey.W:
                    Snake.SetDirection(Player.Direction.upp);
                    break;

                case ConsoleKey.S:
                    Snake.SetDirection(Player.Direction.ner);
                    break;

                case ConsoleKey.A:
                    Snake.SetDirection(Player.Direction.vänster);
                    break;

                case ConsoleKey.D:
                    Snake.SetDirection(Player.Direction.höger);
                    break;

            }
            // Uppdatera världen och rendera om

            renderer.RenderBlank();
            world.Update();
            renderer.Render();

            // Mät hur lång tid det tog
            double frameTime = Math.Ceiling((1000.0 / frameRate) - (DateTime.Now - before).TotalMilliseconds);
            if (frameTime > 0)
            {
                // Vänta rätt antal millisekunder innan loopens nästa varv
                Thread.Sleep((int)frameTime);
            }
        }

    }
    catch (Exception ex) //to crash to program when the snake hits the wall, (managed error)
    {

        Console.SetCursorPosition(1, 10);
        Console.WriteLine("Opps you hit a wall!,  Game over!! :(");
        Console.ForegroundColor = ConsoleColor.Red;
    }

}

Loop();
