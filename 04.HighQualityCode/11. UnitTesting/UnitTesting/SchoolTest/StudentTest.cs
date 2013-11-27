namespace SchoolTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using School;

    [TestClass]
    public class StudentTest
    {
        [TestMethod]
        public void TestStudentConstructor()
        {
            Student student = new Student("Nikolay Kostadinov",10000);
            Assert.AreEqual(student.Name, "Nikolay Kostadinov", "Invalid Name");
            Assert.AreEqual(student.Id, 10000u, "Invalid Id");
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestStudentConstructorInvalidId()
        {
            Student student = new Student("Nikolay Kostadinov",10);
        }

        [TestMethod]
        [ExpectedException(typeof(System.ArgumentException))]
        public void TestStudentConstructorWithEmptyName()
        {
            Student student = new Student(string.Empty, 10000);
        }

        [TestMethod]
        public void TestStudentTostring() 
        {
            Student student = new Student("Nikolay Kostadinov",10000);
            Assert.AreEqual(student.ToString(), "10000; Nikolay Kostadinov", "Invalid String");
        }

        [TestMethod]
        public void TestStudentClone()
        {
            Student student = new Student("Nikolay Kostadinov", 10000);
            Student cloneStudent = (Student)student.Clone();
            Assert.AreEqual(student.GetHashCode() == cloneStudent.GetHashCode(), false, "Invalid DeepCopy");
            Assert.AreEqual(student.Equals(cloneStudent), false, "Invalid DeepCopy");
            Assert.AreEqual(student.Name, cloneStudent.Name, "Invalid DeepCopy");
            Assert.AreEqual(student.Id, cloneStudent.Id, "Invalid DeepCopy");
        }
    }
}
