namespace StudentsSystem.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Homeworks")]
    public class Homework
    {
        [Key]
        public int HomeworkID { get; set; }

        public string Content { get; set; }

        public DateTime TimeSent { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }

        [ForeignKey("Student")]
        public int StudentID { get; set; }

        public Course Course { get; set; }

        public Student Student { get; set; }
    }
}
