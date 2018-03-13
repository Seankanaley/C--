using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalsTesting
{
    public partial class formFinalTest : Form
    {

        Student.StudentGrades student = new Student.StudentGrades();
        public formFinalTest()
        {
            InitializeComponent();
        }

        private void btnGetName_Click(object sender, EventArgs e)
        {
            lblGetName.Text = student.GetName(txtFirstName.Text, txtMiddleName.Text, txtLastName.Text);
        }

        private void btnGetAddress_Click(object sender, EventArgs e)
        {
            lblGetAddress.Text = student.GetAddress(txtZip.Text, txtAddress.Text);
        }

        private void btnGetTime_Click(object sender, EventArgs e)
        {
            
            lblGetTime.Text = student.GetTimeAsStudent(Convert.ToDateTime(dtpEnrolledDate.Text).Date);
        }

        private void btnIsHonorRoll_Click(object sender, EventArgs e)
        {

            lblIsHonorRoll.Text = student.isHonorRoll().ToString();
        }



        private void btnAddGrade_Click(object sender, EventArgs e)
        {
            student.AddGrade(double.Parse(txtCourseGrade.Text));
            txtCourseGrade.Clear();
            txtCourseGrade.Focus();
        }

        private void btnGetGPA_Click(object sender, EventArgs e)
        {
           lblGetGPA.Text = student.GetGPA().ToString();
        }

        private void btnAddCourse_Click(object sender, EventArgs e)
        {
            student.AddCourse(txtCourse.Text);
            txtCourse.Clear();
            txtCourse.Focus();
        }

        private void btnGetPassed_Click(object sender, EventArgs e)
        {
            lblGetPassed.Text = student.GetClassList(student.CourseCompleted, student.CourseGrade, student.CourseQtrYr).ToString();
        }

        private void btnGetFailed_Click(object sender, EventArgs e)
        {
            lblGetFailed.Text = student.GetClassFailList(student.CourseCompleted, student.CourseGrade, student.CourseQtrYr).ToString();
        }

        private void btnAddQtr_Click(object sender, EventArgs e)
        {
            student.AddClassDate(txtCourseQtr.Text);
            txtCourseQtr.Clear();
            txtCourseQtr.Focus();
        }

        private void btnAddAll_Click(object sender, EventArgs e)
        {
            student.AddGrade(double.Parse(txtCourseGrade.Text));
            student.AddCourse(txtCourse.Text);
            student.AddClassDate(txtCourseQtr.Text);
            txtCourseQtr.Clear();
            txtCourse.Clear();
            txtCourseGrade.Clear();

        }
    }
}
