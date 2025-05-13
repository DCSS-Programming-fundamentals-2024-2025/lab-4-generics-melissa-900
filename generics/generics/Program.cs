using generics.Entity;
using generics.Interfaces;

class Program
{
    static void Main(string[] args)
    {
        // Test your lab here
        Faculty fpm = new Faculty();
        Group KP41 = new Group { Id = 41, Name = "КП-41" };
        Group KP42 = new Group { Id = 42, Name = "КП-42" };
        Group KP43 = new Group { Id = 43, Name = "КП-43" };
        fpm.AddGroup(KP41);
        fpm.AddGroup(KP42);
        fpm.AddGroup(KP43);

        Student Melissa = new Student { Id = 1, Name = "Melisa"};
        Student Student1 = new Student { Id = 2, Name = "1"};
        Student Student2 = new Student { Id = 3, Name = "2"};

        KP41.AddStudent(Melissa);
        KP41.AddStudent(Student1);
        KP41.AddStudent(Student2);
        
        IEnumerable<Student> studentsKP41 = KP41.GetAllStudents();
        Console.WriteLine(studentsKP41);
    }
}