using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentRegistrationForm
{
    public partial class StudentForm : System.Web.UI.Page
    {
        private IEnumerable<KeyValuePair<int, string>> universities =
            new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(0,"TU Varna"),
                new KeyValuePair<int, string>(1,"IU Varna"),
                new KeyValuePair<int, string>(2,"Sofia Univarsity"),
                new KeyValuePair<int, string>(3,"UNSS"),
                new KeyValuePair<int, string>(4,"TU Sofia"),
                new KeyValuePair<int, string>(5,"BSU"),
            };

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DropDownListUniversity.Items.Add(string.Empty);
            if (!this.Page.IsPostBack)
            {
                foreach (var university in universities)
                {
                    this.DropDownListUniversity.Items.Add(
                        new ListItem(
                            university.Value,
                            university.Key.ToString()));
                }
            }
        }

        protected void DropDownListUniversity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.DropDownListUniversity.SelectedIndex == 0)
            {
                return;
            }
            this.ListBoxCourses.Items.Clear();
            var universityName = this.DropDownListUniversity.SelectedItem.Text;
            var specialties = new List<KeyValuePair<int, String>>();
            for (int i = 0; i < 20; i++)
            {
                this.ListBoxCourses.Items.Add(
                    new ListItem("Course " + i + " of the " + universityName ,i.ToString()));
            }
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                var student = GetDataForStudent();
                this.Result.InnerHtml = student.ToString();
            }
            catch (ArgumentNullException ex) 
            {
                this.Result.InnerHtml = ex.Message.MakeMessage("h1");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                this.Result.InnerHtml = ex.Message.MakeMessage("h1");
            }
        }

        private Student GetDataForStudent()
        {
            Student student = new Student()
            {
                FirstName = this.TextBoxFirstName.Text,
                LastName = this.TextBoxLastName.Text,
                FacultyNumber = this.TextBoxFacultyNumber.Text,
                University = this.DropDownListUniversity.SelectedItem.Text,
            };

            var selectedCourses = this.ListBoxCourses.GetSelectedIndices();
            var items = this.ListBoxCourses.Items;

            if (selectedCourses.Length < 1)
            {
                throw new ArgumentOutOfRangeException(
                    "There must be atleast one selected course!",
                    new ArgumentOutOfRangeException("FacultyNember"));
            }
        
            List<string> courses = new List<string>();
            foreach (var courseId in selectedCourses) 
            {
                courses.Add(items[courseId].Text);
            }
            student.Courses = courses;

            return student;
        }
    }
}