namespace StudentCommon
{
    using System;

    public class Student : ICloneable, IComparable<Student>
    {
        public Student(string firstName, string middleName, string lastName, string ssn)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.Ssn = ssn;
        }

        public Student(
            string firstName,
            string middlename,
            string lastName,
            string ssn,
            string permanentAddress,
            string mobilePhone,
            string email,
            short course,
            Specialties specialty,
            Universities university,
            Faculties faculty) 
            : this(
                firstName,
                middlename,
                lastName,
                ssn,
                permanentAddress,
                mobilePhone,
                email,
                course)
        {
            this.Specialty = specialty;
            this.University = university;
            this.Faculty = faculty;
        }

        public Student(
            string firstName,
            string middlename,
            string lastName,
            string ssn,
            string permanentAddress,
            string mobilePhone,
            string email,
            short course) 
        {
            this.FirstName = firstName;
            this.MiddleName = middlename;
            this.LastName = lastName;
            this.Ssn = ssn;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
        }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Ssn { get; set; }

        public string PermanentAddress { get; set; }

        public string MobilePhone { get; set; }

        public string Email { get; set; }

        public short Course { get; set; }

        public Specialties Specialty { get; set; }

        public Universities University { get; set; }

        public Faculties Faculty { get; set; }

        public static bool operator ==(Student st1, Student st2)
        {
            return Student.Equals(st1, st2);
        }

        public static bool operator !=(Student st1, Student st2)
        {
            return !Student.Equals(st1, st2);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = (result * 23) + ((this.FirstName != null) ? this.FirstName.GetHashCode() : 0);
                result = (result * 23) + ((this.MiddleName != null) ? this.MiddleName.GetHashCode() : 0);
                result = (result * 23) + ((this.LastName != null) ? this.LastName.GetHashCode() : 0);
                result = (result * 23) + ((this.Ssn != null) ? this.Ssn.GetHashCode() : 0);
                result = (result * 23) + ((this.PermanentAddress != null) ? this.PermanentAddress.GetHashCode() : 0);
                result = (result * 23) + ((this.MobilePhone != null) ? this.MobilePhone.GetHashCode() : 0);
                result = (result * 23) + ((this.Email != null) ? this.Email.GetHashCode() : 0);
                result = (result * 23) + this.Course.GetHashCode();
                result = (result * 23) + this.Specialty.GetHashCode();
                result = (result * 23) + this.University.GetHashCode();
                result = (result * 23) + this.Faculty.GetHashCode();
                return result;
            }
        }

        public override string ToString() 
        {
            return string.Format(
                "{0,-10} {1,-10} {2,-10} | {3}", 
                this.FirstName, 
                this.MiddleName, 
                this.LastName, 
                this.Ssn);
        }

        public override bool Equals(object obj)
        {
            bool areEqual = false;

            if (obj is Student || (object)(obj as Student) != null) 
            {
                Student st = obj as Student;
                if ((st.FirstName + st.MiddleName + st.LastName).Equals(
                    this.FirstName + 
                    this.MiddleName + 
                    this.LastName))
                {
                    if (st.Ssn.Equals(this.Ssn))
                    {
                        areEqual = true;
                    }
                }
            }

            return areEqual;
        }

        object ICloneable.Clone() 
        {
            return this.Clone();
        }

        public Student Clone()
        {
            Student st = new Student(
                this.FirstName,
                this.MiddleName,
                this.LastName,
                this.Ssn,
                this.PermanentAddress,
                this.MobilePhone,
                this.Email,
                this.Course,
                this.Specialty,
                this.University,
                this.Faculty);

            return st;
        }

        public int CompareTo(Student other)
        {
            if (this.Equals(other)) 
            { 
                return 0; 
            }

            int result = this.FirstName.CompareTo(other.FirstName);

            if (result == 0)
            {
                result = this.MiddleName.CompareTo(other.MiddleName);
                if (result == 0)
                {
                     result = this.LastName.CompareTo(other.LastName);
                     if (result == 0)
                     {
                         return (int)(long.Parse(this.Ssn) - long.Parse(other.Ssn));
                     }
                }
                else 
                {
                    return result;
                }
            }
            else
            {
                return result;
            }

            return 0;
        }
    } 
}
