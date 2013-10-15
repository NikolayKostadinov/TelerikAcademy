using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        private const char Symbol = 'X';

        public new const string CollisionGroupString = "ExplodingBlock";
        
        public ExplodingBlock(MatrixCoords topLeft) : base(topLeft) 
        {
            this.body[0, 0] = Symbol;
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "ball";
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> explosions = new List<GameObject>();
            int currentRow = this.topLeft.Row;
            int currentCol = this.topLeft.Col;
            if (this.IsDestroyed)
            {
                explosions.Add(new Explosive(new MatrixCoords(currentRow - 1, currentCol - 1)));
                explosions.Add(new Explosive(new MatrixCoords(currentRow, currentCol - 1)));
                explosions.Add(new Explosive(new MatrixCoords(currentRow - 1, currentCol)));
                explosions.Add(new Explosive(new MatrixCoords(currentRow + 1, currentCol + 1)));
                explosions.Add(new Explosive(new MatrixCoords(currentRow + 1, currentCol)));
                explosions.Add(new Explosive(new MatrixCoords(currentRow, currentCol + 1)));
                explosions.Add(new Explosive(new MatrixCoords(currentRow - 1, currentCol + 1)));
                explosions.Add(new Explosive(new MatrixCoords(currentRow + 1, currentCol - 1)));
            }
            return explosions; 
        }
    }
}
