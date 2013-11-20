namespace AcademyRPG
{
    using System;
    using System.Linq;

    public class ExtendedEngine : Engine
    {
        public override void ExecuteCreateObjectCommand(string[] commandWords)
        {
            switch (commandWords[1])
            {
                case "knight":
                    {
                        // <name> <position> <owner>
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Knight(name, position, owner));
                        return;
                    }
                case "house":
                    {
                        // <position> <owner>

                        Point position = Point.Parse(commandWords[2]);
                        int owner = int.Parse(commandWords[3]);
                        this.AddObject(new House(position, owner));
                        return;
                    }
                case "giant":
                    {
                        // <name> <position>
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Giant(name, position));
                        return;
                    }
                case "rock":
                    {
                        //<hitpoints> <position> 
                        int hitPoints = int.Parse(commandWords[2]);
                        Point position = Point.Parse(commandWords[3]);
                        this.AddObject(new Rock(hitPoints, position));
                        return;
                    }
                case "ninja":
                    {
                        // <name> <position> <owner>
                        string name = commandWords[2];
                        Point position = Point.Parse(commandWords[3]);
                        int owner = int.Parse(commandWords[4]);
                        this.AddObject(new Ninja(name, position, owner));
                        return;
                    }
            }

            base.ExecuteCreateObjectCommand(commandWords);
        }
    }
}
