namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Giant : Character, IFighter, IGatherer
    {
        private const int Neutral = 0;
        private int attacPoints = 150;

        public Giant(string name, Point position)
            : base(name, position, Neutral)
        {
            this.HitPoints = 200;
        }

        public int AttackPoints
        {
            get { return this.attacPoints; }
            set { this.attacPoints = value; }
        }

        public int DefensePoints
        {
            get { return 80; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {

            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += 100;
                return true;
            }

            return false;
        }
    }
}
