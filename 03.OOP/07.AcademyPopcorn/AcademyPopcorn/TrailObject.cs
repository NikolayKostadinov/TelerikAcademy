using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class TrailObject : GameObject
    {
        private int lifeTime;

        public TrailObject(MatrixCoords topLeft, char symbol, int lifeTime) 
            : base(topLeft,new char[,]{{symbol}})
        {
            this.lifeTime = lifeTime;
        }

        public override void Update()
        {
            if (this.lifeTime > 0)
            {
                this.lifeTime -= 1;
            }
            else 
            {
                this.IsDestroyed = true; 
            }
        }
    }
}
