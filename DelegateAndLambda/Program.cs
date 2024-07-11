
List<Book> books = new List<Book>
{
    new Book { Title = "The Hobbit", Author = "J.R.R. Tolkien", YearPublished = 1937 },
    new Book { Title = "harry potter and the Sorcerer's Stone", Author = "J.K. Rowling", YearPublished = 1997 },
    new Book { Title = "1984", Author = "George Orwell", YearPublished = 1949 },
    new Book { Title = "Pride and Prejudice", Author = "Jane Austen", YearPublished = 1813 }
};

Action<string> print = (sentence) => Console.WriteLine(sentence);

IEnumerable<Book> sortedBooks = books.OrderBy(
    p => p.Title,
    new CaseInsensitiveComparer()
    );

foreach (var book in sortedBooks)
{
    print($"{book.Title} - {book.Author} - {book.YearPublished}");
}



// List<Student> students = new List<Student>
// {
//     new Student { Name = "Alice", Grade = 10 },
//     new Student { Name = "Bob", Grade = 20 },
//     new Student { Name = "Charlie", Grade = 30 }
// };
//
// IEnumerable<Student> sortedStudents = students.OrderBy(
//     p => p.Grade,
//     new DescendingByGrade()
//     );
//
// foreach (var student in sortedStudents)
// {
//     Console.WriteLine("{0} - Grade : {1}", student.Name, student.Grade);
//     
// }

public class Student
{
    public required string Name { get; set; } 
    public int Grade { get; set; }
}

public class Book
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }
    public Student Students { get; set; }
}


public class DescendingByGrade : IComparer<int>
{
    public int Compare(int x, int y)
    {
        var test = y.CompareTo(x);
        return test;
    }
}

public class CaseInsensitiveComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        // Compare strings ignoring case
       var test = string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
       return test;
    }
}
