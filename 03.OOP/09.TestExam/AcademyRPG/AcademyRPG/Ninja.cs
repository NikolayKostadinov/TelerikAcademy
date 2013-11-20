namespace AcademyRPG
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Ninja : Character, IFighter, IGatherer
    {
        private int attackPoints = 0;

        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
        }

        public int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            private set
            {
                this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get { return 0; }
        }

        public bool IsDestroyed
        {
            get
            {
                return false;
            }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            var otherObjects = from at in availableTargets
                               where at.Owner != this.Owner
                               select at;
            if (otherObjects.Count() > 0)
            {
                int maxHitPoints = otherObjects.Max(oo => oo.HitPoints);
                return availableTargets.IndexOf((from oo in otherObjects
                                                 where oo.HitPoints == maxHitPoints
                                                 select oo).Single());
            }
            else
            {
                return -1;
            }
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }
            else if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            return false;
        }
    }
}
