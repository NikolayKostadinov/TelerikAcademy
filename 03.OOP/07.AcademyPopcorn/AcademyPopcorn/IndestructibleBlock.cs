using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class IndestructibleBlock : Block
    {
        public const char Symbol = '|';


        public IndestructibleBlock(MatrixCoords upperLeft, char symbol)
            : base(upperLeft)
        {
            this.body[0, 0] = symbol;
        }

        public IndestructibleBlock(MatrixCoords upperLeft)
            : this(upperLeft, Symbol)
        {
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            //base.RespondToCollision(collisionData);
        }
    }
}
