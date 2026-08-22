List<Student> students = new List<Student>();

while (true)
{
    Console.WriteLine("\n===== Student Management System =====");

    Console.WriteLine("1: Create Student");
    Console.WriteLine("2: Read All Students");
    Console.WriteLine("3: Search Student");
    Console.WriteLine("4: Update Student");
    Console.WriteLine("5: Delete Student");
    Console.WriteLine("6: Exit");
    Console.WriteLine("7: Search By Name");
    Console.WriteLine("8: Sort By Marks");

    Console.Write("Enter Choice: ");
    int choice = Convert.ToInt32(Console.ReadLine());

    switch (choice)
    {
        // CREATE
        case 1:

            Console.WriteLine("\n===== Create Student =====");

            Console.Write("Enter Roll: ");
            int roll = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Marks: ");
            int marks = Convert.ToInt32(Console.ReadLine());

            if (marks < 0 || marks > 100)
            {
                Console.WriteLine("Invalid Marks! Marks must be between 0 and 100.");
                break;
            }

            Student student = new Student()
            {
                Roll = roll,
                Name = name,
                Marks = marks
            };

            students.Add(student);

            Console.WriteLine("Student Created Successfully!");

            break;


        // READ ALL
        case 2:

            Console.WriteLine("\n===== All Students =====");

            if (students.Count == 0)
            {
                Console.WriteLine("No students found.");
                break;
            }

            foreach (var s in students)
            {
                Console.WriteLine($"Roll  : {s.Roll}");
                Console.WriteLine($"Name  : {s.Name}");
                Console.WriteLine($"Marks : {s.Marks}");
                Console.WriteLine("----------------------");
            }

            break;


        // SEARCH BY ROLL
        case 3:

            Console.Write("Enter Roll Number: ");
            int findNumber = Convert.ToInt32(Console.ReadLine());

            var resultFind = students
                .FirstOrDefault(s => s.Roll == findNumber);

            if (resultFind != null)
            {
                Console.WriteLine($"Name  : {resultFind.Name}");
                Console.WriteLine($"Marks : {resultFind.Marks}");
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }

            break;


        // UPDATE
        case 4:

            Console.Write("Enter Roll Number: ");
            int find2Number = Convert.ToInt32(Console.ReadLine());

            var resultFind2 = students
                .FirstOrDefault(s => s.Roll == find2Number);

            if (resultFind2 != null)
            {
                Console.Write("Enter New Name: ");
                string newName = Console.ReadLine();

                Console.Write("Enter New Marks: ");
                int newMarks = Convert.ToInt32(Console.ReadLine());

                if (newMarks < 0 || newMarks > 100)
                {
                    Console.WriteLine("Invalid Marks! Marks must be between 0 and 100.");
                    break;
                }

                resultFind2.Name = newName;
                resultFind2.Marks = newMarks;

                Console.WriteLine("Student Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }

            break;


        // DELETE
        case 5:

            Console.Write("Enter Roll Number: ");
            int find3Number = Convert.ToInt32(Console.ReadLine());

            var resultFind3 = students
                .FirstOrDefault(s => s.Roll == find3Number);

            if (resultFind3 != null)
            {
                students.Remove(resultFind3);

                Console.WriteLine("Student Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }

            break;


        // EXIT
        case 6:

            Console.WriteLine("Goodbye!");

            return;


        // SEARCH BY NAME
        case 7:

            Console.Write("Enter Name: ");
            string searchName = Console.ReadLine();

            var results = students
                .Where(s => s.Name.Contains(
                    searchName,
                    StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (results.Count > 0)
            {
                foreach (var s in results)
                {
                    Console.WriteLine($"Roll  : {s.Roll}");
                    Console.WriteLine($"Name  : {s.Name}");
                    Console.WriteLine($"Marks : {s.Marks}");
                    Console.WriteLine("----------------------");
                }
            }
            else
            {
                Console.WriteLine("Student Not Found.");
            }

            break;


        // SORT BY MARKS
        case 8:

            var sortedStudents = students
                .OrderBy(s => s.Marks)
                .ToList();

            if (sortedStudents.Count == 0)
            {
                Console.WriteLine("No students found.");
                break;
            }

            foreach (var s in sortedStudents)
            {
                Console.WriteLine($"Roll  : {s.Roll}");
                Console.WriteLine($"Name  : {s.Name}");
                Console.WriteLine($"Marks : {s.Marks}");
                Console.WriteLine("----------------------");
            }

            break;


        default:

            Console.WriteLine("Choice Not Found.");

            break;
    }
}


class Student
{
    public int Roll { get; set; }
    public string Name { get; set; }
    public int Marks { get; set; }
}