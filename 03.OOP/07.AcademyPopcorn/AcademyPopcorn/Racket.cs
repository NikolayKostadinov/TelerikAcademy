using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Racket : GameObject
    {
        public new const string CollisionGroupString = "racket";

        public int Width {get; protected set;}

        public Racket(MatrixCoords topLeft, int width) : base(topLeft, new char[,]{{'='}})
        {
            this.Width = width;
            this.body = GetRacketBody(this.Width);
        }

        char[,] GetRacketBody(int width)
        {
            char[,] body = new char[1, width];

            for (int i = 0; i < width; i++)
            {
                body[0, i] = '=';
            }

            return body;
        }

        public void MoveLeft()
        {
            if (this.topLeft.Col >= 2) 
            { 
                this.topLeft.Col--;
            }
        }

        public void MoveRight()
        {
            if (this.topLeft.Col + this.Width <= AcademyPopcornMain.WorldCols - 3)
            this.topLeft.Col++;
        }

        public override string GetCollisionGroupString()
        {
            return Racket.CollisionGroupString;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == Racket.CollisionGroupString || otherCollisionGroupString == "ball";
        }

        public override void Update()
        {
        }
    }
}
