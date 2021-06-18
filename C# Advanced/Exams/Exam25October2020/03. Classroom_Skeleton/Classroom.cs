using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        public List<Student> students;

        public int Capacity { get; set; }
        public int Count
        {
            get
            {
                return students.Count;
            }
        }

        public Classroom(int capacity)
        {
            this.Capacity = capacity;
            this.students = new List<Student>();
        }

        public string RegisterStudent(Student student)
        {
            if (this.Capacity > students.Count)
            {
                students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }

            return "No seats in the classroom";
        }

        public string DismissStudent(string firstName, string lastName)
        {
            if (students.Any(s => s.FirstName == firstName && s.LastName == lastName))
            {
                Student findDissmissedStudent = students.Find(s => s.FirstName == firstName && s.LastName == lastName);
                students.Remove(findDissmissedStudent);
                return $"Dismissed student {firstName} {lastName}";
            }

            return "Student not found";
        }

        public string GetSubjectInfo(string subject)
        {
            List<Student> filteredStudentsList = students.Where(s => s.Subject == subject).ToList();

            if (filteredStudentsList.Count > 0)
            {
                StringBuilder result = new StringBuilder();
                result.AppendLine($"Subject: {subject}");
                result.AppendLine("Students:");

                foreach (var student in filteredStudentsList)
                {
                    result.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return result.ToString().TrimEnd();
            }

            return "No students enrolled for the subject";
        }

        public int GetStudentsCount()
        {
            return students.Count;
        }

        public Student GetStudent(string firstName, string lastName)
        {
            return students.Find(s => s.FirstName == firstName && s.LastName == lastName);
        }
    }
}
