using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Explosive : MovingObject
    {
        public const char Symbol = ' ';

        public Explosive(MatrixCoords topLeft) : base(topLeft, new char[,]{{' '}}, new MatrixCoords(0,0)) 
        {
            this.body[0, 0] = Symbol;
        }

        public override void Update()
        {
            this.IsDestroyed = true;
        }
        
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }
    }
}
