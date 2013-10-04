namespace School
{
    using System;

    public class Discipline : Comments
    {
        private string name;
        private short numberOfLectures;
        private short numberOfExercises;

        public Discipline(string name, short numberOfLectures, short numberOfExcercises) : base(string.Empty) 
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExcercises;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                if (value == string.Empty || value == null)
                {
                    throw new ArgumentOutOfRangeException(
                        "Name od discipline can't be empty", 
                        new ArgumentOutOfRangeException());
                }

                this.name = value;
            }
        }

        public short NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Number of lecture nust be greater than or equal to 0.",
                        new ArgumentOutOfRangeException());
                }

                this.numberOfLectures = value;
            }
        }

        public short NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(
                        "Number of lecture nust be greater than or equal to 0.",
                        new ArgumentOutOfRangeException());
                }

                this.numberOfExercises = value;
            }
        }
    }
}
