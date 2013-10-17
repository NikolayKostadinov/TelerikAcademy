using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public class Knight : Character, IFighter
    {
        
        
        public int AttackPoints { get; set;}

        public int DefensePoints { get; set; }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    return i;
                }
            }

            return -1;
        }

        public Knight(string name, Point position, int owner) : base(name,position,owner)
        {
            // TODO: Complete member initialization
            this.AttackPoints = 100;
            this.DefensePoints = 100;
        }
    }
}
