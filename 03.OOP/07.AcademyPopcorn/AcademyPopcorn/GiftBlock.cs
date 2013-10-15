using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        public GiftBlock(MatrixCoords topLeft) : base(topLeft) 
        {
            this.body[0, 0] = 'G'; 
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> gifts = new List<GameObject>();

            if (this.IsDestroyed == true) 
            {
                gifts.Add(new Gift(this.TopLeft));
            }

            return gifts;
        }
    }
}
