using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Gift : MovingObject
    {
        public new const string CollisionGroupString = "Gift";

        public Gift(MatrixCoords topLeft) : base(topLeft, new char[,] { { '$' } }, new MatrixCoords(1, 0)) 
        { 
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            foreach (string collosionObject in collisionData.hitObjectsCollisionGroupStrings) 
            {
                if (collosionObject == "racket") 
                {
                    this.IsDestroyed = true;
                } 
            }
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (this.IsDestroyed == true)
            {
                return new List<GameObject>() { new ShootingRacket(new MatrixCoords(this.TopLeft.Row + 1, this.TopLeft.Col)) };
            }
            else 
            {
                return base.ProduceObjects();
            }
        }
    }
}
