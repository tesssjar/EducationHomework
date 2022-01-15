using System;
using System.Collections.Generic;
using ClassStudent;


namespace ClassEmployer
{
    public class Employer
    {
        public string empName;

        public Employer(string Name)
        {
            empName = Name;
        }

        public string Name
        {
            get { return empName; }
            set => empName = value;
        }

        public List<Student> Employee { get; set; }

        public static void AddStudent(Student student, List<Student> employee) => employee.Add(student);

        public static double SalaryCount(Student student)
        {
            double res = (Student.IndexOfHappiness(student.KdmMark, student.VmMark) / 100.0) * 20000.0;

            return res;
        }
    }
}