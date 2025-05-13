using generics.Interfaces;

namespace generics.Entity
{
    class Person { public int Id; public string Name; }

    class Student : Person, IStudent
    {
        public void SubmitWork()
        {
            Console.WriteLine("Submitting work");
        }

        public void SayName()
        {
            Console.WriteLine($"My name is {Name}");
        }
    }

    class Teacher : Person, ITeacher
    {
        public void GradeStudent(Student student)
        {
            Console.WriteLine($"Grading {student.Name}...");
        }

        public void ExpelStudent(Student student)
        {
            Console.WriteLine($"Expelling {student.Name}!");
        }

        public void ShowPresentStudents()
        {
            Console.WriteLine("Showing present students: ...");
        }
    }

    interface IStudent
    {
        void SubmitWork();
        void SayName();
    }
    interface ITeacher
    {
        void GradeStudent(Student student);
        void ExpelStudent(Student student);
        void ShowPresentStudents();
    }

    class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private IRepository<Student, int> _students = new InMemoryRepository<Student, int>();

        public void AddStudent(Student s)
        {
            _students.Add(s.Id, s);
        }

        public void RemoveStudent(int studentId)
        {
            _students.Remove(studentId);
        }

        public IEnumerable<Student> GetAllStudents()
        {
            foreach (var student in _students.GetAll())
            {
                Console.WriteLine(student.Name);
            }
            return _students.GetAll();
        }

        public Student FindStudent(int studentId)
        {
            return _students.Get(studentId);
        }
    }

    class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        IRepository<Group, int> _groups = new InMemoryRepository<Group, int>();

        public void AddGroup(Group g)
        {
            _groups.Add(g.Id, g);
        }

        public void RemoveGroup(int id)
        {
            _groups.Remove(id);
        }

        IEnumerable<Group> GetAllGroups()
        {
            return _groups.GetAll();
        }
        Group GetGroup(int id)
        {
            return _groups.Get(id);
        }
    }
}
