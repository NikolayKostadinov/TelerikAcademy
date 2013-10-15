using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Bullet : MovingObject
    {
        public new const string CollisionGroupString = "Bullet";

        public Bullet(MatrixCoords topLeft) : base(topLeft, new char[,] { { '^' } }, new MatrixCoords(-1, 0)) 
        { 
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            bool result = otherCollisionGroupString.ToLower().Contains("block");

            return result;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

    }
}
