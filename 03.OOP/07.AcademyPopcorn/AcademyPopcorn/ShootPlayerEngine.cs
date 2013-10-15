namespace AcademyPopcorn
{
    using System;

    public class ShootPlayerEngine : Engine
    {

        public ShootPlayerEngine(IRenderer renderer, IUserInterface userInterface, int sleepTimer)
            : base(renderer, userInterface, sleepTimer) 
        {
        }

        public void ShootWithPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }
    }
}
