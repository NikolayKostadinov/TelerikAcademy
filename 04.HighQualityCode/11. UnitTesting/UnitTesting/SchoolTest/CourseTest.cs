namespace SchoolTest
{
    using System;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class CourseTest
    {
        [TestMethod]
        public void TestCourseConstructor()
        {
            Course course = new Course("Software Engineering");
            Assert.AreEqual(course.Name, "Software Engineering", "Invalid Name");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseConstructorEmptyName() 
        {
            Course course = new Course(string.Empty);
        }

        [TestMethod]
        public void TestCourseJoinCourse() 
        {
            Course course = new Course("Software Engineering");
            Student student = new Student("Nikolay Kostadinov", 10000);
            course.JoinCourse(student);
            bool isStudentInCourse = CheckForStudent(student, course);
            Assert.AreEqual(isStudentInCourse, true, "Invalid join");
        }

        private bool CheckForStudent(Student student, Course course)
        {
            bool isStudentInCourse = false;
            Dictionary<uint, Student> students = course.ViewStudents();
            if (students.ContainsKey(student.Id)) 
            {
                isStudentInCourse = students[student.Id].Name == student.Name;
            }
            return isStudentInCourse;
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestCourseJoinCourseMax()
        {
            const int StartStudentsID = 10000;
            const int MaxCourseCapacity = 30;
            const int LastStudentID = StartStudentsID + MaxCourseCapacity + 1;

            Course course = new Course("Software Engineering");

            for (uint id = StartStudentsID; id < LastStudentID; id++)
            {
                course.JoinCourse(new Student("Nikolay Kostadinov", id));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseJoinCourseEmpty()
        {
            Course course = new Course("Software Engineering");
            Student student = null;
            course.JoinCourse(student);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseJoinCourseDublicatedStudent()
        {
            Course course = new Course("Software Engineering");
            course.JoinCourse(new Student("Nikolay Kostadinov", 10000));
            course.JoinCourse(new Student("Nikolay Kostadinov", 10000));
        }

        [TestMethod]
        public void TestCourseLeaveCourse()
        {
            const int StartStudentsID = 10000;
            const int MaxCourseCapacity = 30;
            const int LastStudentID = StartStudentsID + MaxCourseCapacity;

            Course course = new Course("Software Engineering");

            for (uint id = StartStudentsID; id < LastStudentID; id++)
            {
                course.JoinCourse(new Student("Nikolay Kostadinov", id));
            }

            course.LeaveCourse(new Student("Nikolay Kostadinov", 10029));
            bool isStudentInCourse = CheckForStudent(new Student("Nikolay Kostadinov", 10029),course);

            Assert.AreEqual(isStudentInCourse, false, "Leave doesn't work correct");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseLeaveCourseNonExistStudent()
        {
            Course course = new Course("Software Engineering");
            course.JoinCourse(new Student("Nikolay Kostadinov", 10000));
            course.LeaveCourse(new Student("Nikolay Kostadinov", 10029));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestCourseLeaveCourseZero()
        {
            Course course = new Course("Software Engineering");
            course.LeaveCourse(null);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void TestCourseLeaveCourseNonPopulated()
        {
            Course course = new Course("Software Engineering");
            course.LeaveCourse(new Student("Nikolay Kostadinov", 10029));
        }

        [TestMethod]
        public void TestCourseZeroClone()
        {
            Course course = new Course("Software Engineering");
            Course cloneCourse = (Course)course.Clone();
            Assert.AreNotSame(course, cloneCourse, "Clone doesn't work correct");
        }

        [TestMethod]
        public void TestCourseFullClone()
        {
            const int StartStudentsID = 10000;
            const int MaxCourseCapacity = 30;
            const int LastStudentID = StartStudentsID + MaxCourseCapacity;

            Course course = new Course("Software Engineering");

            for (uint id = StartStudentsID; id < LastStudentID; id++)
            {
                course.JoinCourse(new Student("Nikolay Kostadinov", id));
            }

            course.LeaveCourse(new Student("Nikolay Kostadinov", 10029));

            Course cloneCourse = (Course)course.Clone();

            bool isEqual = CompareStudents(course, cloneCourse) && (course.Name == cloneCourse.Name);


            Assert.AreEqual(isEqual, true);
        }

        private static bool CompareStudents(Course course, Course cloneCourse)
        {
            bool isEqual = true;

            foreach (var student in course.ViewStudents())
            {
                if (!cloneCourse.ViewStudents().ContainsKey(student.Key))
                {
                    isEqual = false;
                    break;
                }
            }
            return isEqual;
        }

        [TestMethod]
        public void TestCourseToString()
        {
            Course course = new Course("Software Engineering");
            Assert.AreEqual(course.ToString(), "Software Engineering", "Clone doesn't work correct");
        }
    }
}
