using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Student
{
    public class StudentGrades
    {
        private string oStudentFirstName;
        private string oStudentLastName;
        private string oStudentMiddleName;
        private string oStudentID;
        private string oEmail;
        private string oPhone;
        private string oAddress;
        private string oZip;
        private string oMajor;
        private DateTime oEnrolledDate;
        private List<string> oCourseCompleted = new List<string>();
        private List<string> oCourseQtrYr = new List<string>();
        private List<double> oCourseGrade = new List<double>();
        private double oGPA;


        public StudentGrades()
        {
        }

        public StudentGrades(string StudentFirstName, string StudentMiddleName, string StudentLastName)
        {
            oStudentFirstName = StudentFirstName;
            oStudentMiddleName = StudentMiddleName;
            oStudentLastName = StudentLastName;
        }

        public string StudentFirstName
        {
            get
            {
                return oStudentFirstName;
            }

            set
            {
                oStudentFirstName = value;
            }
        }

        public string StudentLastName
        {
            get
            {
                return oStudentLastName;
            }

            set
            {
                oStudentLastName = value;
            }
        }

        public string StudentMiddleName
        {
            get
            {
                return oStudentMiddleName;
            }

            set
            {
                oStudentMiddleName = value;
            }
        }

        public string StudentID
        {
            get
            {
                return oStudentID;
            }

            set
            {
                oStudentID = value;
            }
        }

        public string Email
        {
            get
            {
                return oEmail;
            }

            set
            {
                oEmail = value;
            }
        }

        public string Phone
        {
            get
            {
                return oPhone;
            }

            set
            {
                oPhone = value;
            }
        }

        public string Address
        {
            get
            {
                return oAddress;
            }

            set
            {
                oAddress = value;
            }
        }

        public string Zip
        {
            get
            {
                return oZip;
            }

            set
            {
                oZip = value;
            }
        }

        public string Major
        {
            get
            {
                return oMajor;
            }

            set
            {
                oMajor = value;
            }
        }

        public DateTime EnrolledDate
        {
            get
            {
                return oEnrolledDate;
            }

            set
            {
                oEnrolledDate = value;
            }
        }

        public List<string> CourseCompleted
        {
            get
            {
                return oCourseCompleted;
            }

            set
            {
                oCourseCompleted = value;
            }
        }

        public List<string> CourseQtrYr
        {
            get
            {
                return oCourseQtrYr;
            }

            set
            {
                oCourseQtrYr = value;
            }
        }

        public List<double> CourseGrade
        {
            get
            {
                return oCourseGrade;
            }

            set
            {
                oCourseGrade = value;
            }
        }

        public double GPA
        {
            get
            {
                return oGPA;
            }
            set
            {
                oGPA = value;
            }
        }

        public void AddGrade(double Grade)
        {
            oCourseGrade.Add(Grade);
        }

        public void AddClassDate(string course)
        {
            oCourseQtrYr.Add(course);
        }

        public void AddCourse(string course)
        {
            oCourseCompleted.Add(course);
        }


        public bool isHonorRoll()
        {
            if (oGPA >= 3.5)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool isHonorRoll(double GPA)
        {
            if (GPA >= 3.5)
            {
                return true;
            }
            else
            {
                return false;
            }

        }


        public string GetName()
        {
            if (oStudentMiddleName.Length == 0)
            {
                return oStudentFirstName + " " + oStudentLastName;
            }
            else
            {
                return oStudentFirstName + " " + oStudentMiddleName + " " + oStudentLastName;
            }
        }

        public string GetName(string oStudentFirstName, string oStudentLastName)
        {

            return oStudentFirstName + " " + oStudentLastName;

        }

        public string GetName(string StudentFirstName, string StudentMiddleName, string StudentLastName)
        {
            if (StudentMiddleName.Length == 0)
            {
                return StudentFirstName + " " + StudentLastName;
            }
            else
            {
                return StudentFirstName + StudentMiddleName + StudentLastName;
            }
        }

        public string GetAddress(string Zip, string Address)
        {
            SqlConnection myConnection = new SqlConnection("Data Source=134.39.173.35;Initial Catalog=skanaley_w17;User ID=skanaley_w17;Password=ZZqf60mp88pk91sk");

            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("Select city, state, zip from tblZipcodes where zip='" + Zip + "'", myConnection);

            SqlDataReader rdrZip = myCommand.ExecuteReader();

            rdrZip.Read();

            string MailLabel = "";

            if (rdrZip.HasRows)
            {
                string city = rdrZip["city"].ToString();
                string state = rdrZip["state"].ToString();

                MailLabel = Address + "\r\n" + city + "," + state + "\r\n" + Zip;
            }
            else
            {
                MailLabel = "Error, zip not found";
            }

            myConnection.Close();
            return MailLabel;

        }

        public string GetAddress()
        {
            SqlConnection myConnection = new SqlConnection("Data Source=134.39.173.35;Initial Catalog=skanaley_w17;User ID=skanaley_w17;Password=ZZqf60mp88pk91sk");

            myConnection.Open();

            SqlCommand myCommand = new SqlCommand("Select city, state, zip from tblZipcodes where zip='" + oZip + "'", myConnection);

            SqlDataReader rdrZip = myCommand.ExecuteReader();

            rdrZip.Read();

            string MailLabel = "";

            if (rdrZip.HasRows)
            {

                string city = rdrZip["city"].ToString();
                string state = rdrZip["state"].ToString();
                MailLabel = oAddress + "\r\n" + city + "," + state + "\r\n" + Zip;
            }

            else
            {
                MailLabel = "Error, zip not found";
            }

            myConnection.Close();
            return MailLabel;

        }
        public double GetGPA()
        {
            int intCount = oCourseGrade.Count;
            double TotalGrade = 0;
            foreach (double item in oCourseGrade)
            {
                TotalGrade += item;
            }
            oGPA = TotalGrade / intCount;
            return oGPA;
        }
        public double GetGPA(List<double> CourseGrade)
        {
            int intCount = CourseGrade.Count;
            double TotalGrade = 0;
            foreach (double item in CourseGrade)
            {
                TotalGrade += item;
            }
            oGPA = TotalGrade / intCount;
            return oGPA;
        }

        public string GetTimeAsStudent()
        {

            TimeSpan timeDiff = oEnrolledDate.Subtract(DateTime.Now);
            string diff = (timeDiff.TotalDays).ToString();
            return diff;

        }
        public string GetTimeAsStudent(DateTime EnrolledDate)
        {

            TimeSpan timeDiff = DateTime.Now.Subtract(EnrolledDate);
            string diff = (timeDiff.TotalDays).ToString("0 days");
            return diff;

        }

        public string GetClassList()
        {
            string ClassList = "";
            for (int index = 0; index <= oCourseGrade.Count - 1; index++)
            {
                if (oCourseGrade[index] >= 2.0)
                    ClassList += "Class: " + oCourseCompleted[index] + ", Grade: " + oCourseGrade[index] + ", Qtr/Year: " + oCourseQtrYr[index] + "\r\n";
            }
            return ClassList;
        }

        public string GetClassList(List<string> CourseCompleted, List<double> CourseGrade, List<string> CourseQtrYr)
        {
            string ClassList = "";
            for (int index = 0; index <= CourseGrade.Count - 1; index++)
            {
                if (CourseGrade[index] >= 2.0)
                    ClassList += "Class: " + CourseCompleted[index] + ", Grade: " + CourseGrade[index] + ", Qtr/Year: " + CourseQtrYr[index] + "\r\n";
            }
            return ClassList;
        }

        public string GetClassFailList()
        {
            string ClassList = "";
            for (int index = 0; index <= oCourseGrade.Count - 1; index++)
            {
                if (oCourseGrade[index] < 2.0)
                    ClassList += "Class: " + oCourseCompleted[index] + ", Grade: " + oCourseGrade[index] + ", Qtr/Year: " + oCourseQtrYr[index] + "\r\n";
            }
            return ClassList;
        }

        public string GetClassFailList(List<string> CourseCompleted, List<double> CourseGrade, List<string> CourseQtrYr)
        {
            string ClassList = "";
            for (int index = 0; index <= CourseGrade.Count - 1; index++)
            {
                if (CourseGrade[index] < 2.0)
                    ClassList += "Class: " + CourseCompleted[index] + ", Grade: " + oCourseGrade[index] + ", Qtr/Year: " + CourseQtrYr[index] + "\r\n";
            }
            return ClassList;
        }
    }
}
