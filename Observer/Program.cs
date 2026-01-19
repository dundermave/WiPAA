using Observer;

namespace Observer
{
    internal class Program
    {
        static void Main()
        {
            Lecturer lecturer = new Lecturer();

            Student s1 = new Student("Alicja");
            Student s2 = new Student("Bartek");
            Student s3 = new Student("Celina");

            lecturer.Subscribe(s1);
            lecturer.Subscribe(s2);
            lecturer.Subscribe(s3);

            lecturer.SetResult("Alicja", 92);
            lecturer.SetResult("Bartek", 77);
            lecturer.SetResult("Celina", 58);

            lecturer.AnnounceResults();
        }
    }
}
