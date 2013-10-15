using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        public const int WorldRows = 23;
        public const int WorldCols = 40;
        public const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));

                engine.AddObject(currBlock);
            }

            // Add walls
            for (int i = 0; i < WorldRows; i++)
            {
                IndestructibleBlock currLeftWall = 
                    new IndestructibleBlock(new MatrixCoords(i, 0));

                engine.AddObject(currLeftWall);

                IndestructibleBlock currRightWall =
                    new IndestructibleBlock(new MatrixCoords(i, WorldCols - 1));

                engine.AddObject(currRightWall);
            }
            
            //add roof
            for (int i = 0; i < WorldCols; i++)
            {
                IndestructibleBlock currLeftWall =
                    new IndestructibleBlock(new MatrixCoords(0, i), '-');

                engine.AddObject(currLeftWall);
            }

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0),
                new MatrixCoords(-1, 1));
            engine.AddObject(theBall);

            //MeteoriteBall theBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, 0),
            //    new MatrixCoords(-1, 1));

            //Ball theUnstopableBall = new UnstoppableBall(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));
            //engine.AddObject(theUnstopableBall);

            
            //engine.AddObject(new UnpassableBlocks(new MatrixCoords(3, 6)));
            

            engine.AddObject(new GiftBlock(new MatrixCoords(4, 6)));

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            ShootPlayerEngine gameEngine = new ShootPlayerEngine(renderer, keyboard, 150);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };

            keyboard.OnActionPressed += (sender, eventInfo) =>
            {
                gameEngine.ShootWithPlayerRacket();
            };

            Initialize(gameEngine);

            gameEngine.Run();
        }
    }
}
