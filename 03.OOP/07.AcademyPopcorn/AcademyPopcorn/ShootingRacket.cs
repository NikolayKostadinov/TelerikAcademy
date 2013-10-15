using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class ShootingRacket : Racket
    {
        private bool hasFire = false; 

        public ShootingRacket(MatrixCoords topLeft) : base(topLeft, 6) 
        {
            this.body = new char[,]{{'=','=','=','^','=','=','='}};
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            if (hasFire = true)
            {
                List<GameObject> bullets = new List<GameObject>();
                bullets.Add(new Bullet(new MatrixCoords(this.topLeft.Col + 3, this.topLeft.Row)));
                return bullets;
            }
            else 
            {
                return base.ProduceObjects();
            }
        }

        public void Shoot()
        {
            this.hasFire = true;
        }
    }
}
