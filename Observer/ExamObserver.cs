using System;
using System.Collections.Generic;

namespace Observer
{
    public interface IStudentObserver
    {
        void ReceiveResult(string studentName, int points, string grade);
    }

    public class Student : IStudentObserver
    {
        public string Name { get; }

        public Student(string name)
        {
            Name = name;
        }

        public void ReceiveResult(string studentName, int points, string grade)
        {
            Console.WriteLine($"Student: {studentName} | Wynik: {points} pkt | Ocena: {grade}");
        }
    }

    public class Lecturer
    {
        private readonly List<IStudentObserver> _observers = new();
        private readonly Dictionary<string, int> _results = new(); 

        public void Subscribe(IStudentObserver observer)
        {
            _observers.Add(observer);
        }

        public void Unsubscribe(IStudentObserver observer)
        {
            _observers.Remove(observer);
        }

        public void SetResult(string studentName, int points)
        {
            _results[studentName] = points;
        }

        public void AnnounceResults()
        {
            Console.WriteLine("Wykładowca: Ogłaszam wyniki egzaminu.");

            foreach (var observer in _observers)
            {
                if (observer is Student student)
                {
                    if (_results.TryGetValue(student.Name, out int points))
                    {
                        string grade = CalculateGrade(points);
                        observer.ReceiveResult(student.Name, points, grade);
                    }
                    else
                    {
                        observer.ReceiveResult(student.Name, 0, "brak wyniku");
                    }
                }
            }
        }

        private static string CalculateGrade(int points)
        {
            if (points >= 90) return "5.0";
            if (points >= 80) return "4.5";
            if (points >= 70) return "4.0";
            if (points >= 60) return "3.5";
            if (points >= 50) return "3.0";
            return "2.0";
        }
    }
}
