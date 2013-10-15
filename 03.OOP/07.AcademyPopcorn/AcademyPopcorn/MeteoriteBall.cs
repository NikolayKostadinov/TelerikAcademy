using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class MeteoriteBall : Ball
    {
        private const int TimeToLive = 3;

        private const char Symbol = '@';

        private List<GameObject> trialObjects = new List<GameObject>();

        public MeteoriteBall(MatrixCoords coords, MatrixCoords speed) 
            : base(coords, speed)
        {
            this.body[0, 0] = Symbol;
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            this.trialObjects.RemoveAll(obj => obj.IsDestroyed); 
            this.trialObjects.Add(new TrailObject(this.TopLeft, '*', 3));
            return trialObjects;
        }
    }
}
