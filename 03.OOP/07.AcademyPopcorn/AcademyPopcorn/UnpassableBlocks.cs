using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    /*Task8: Implement an UnstoppableBall and an UnpassableBlock. The UnstopableBall only bounces off UnpassableBlocks and will destroy any 
     other block it passes through. The UnpassableBlock should be indestructible. */
    public class UnpassableBlocks : Block
    {
        public const char Symbol = 'U';
        public new const string CollisionGroupString = "unpassableBlock";

        public UnpassableBlocks(MatrixCoords upperLeft)
            : base(upperLeft)
        {
            this.body[0, 0] = UnpassableBlocks.Symbol;

        }
        public override string GetCollisionGroupString()
        {
            return UnpassableBlocks.CollisionGroupString;
        }
        public override void RespondToCollision(CollisionData collisionData)
        {
            //base.RespondToCollision(collisionData);
        }
    }
}
