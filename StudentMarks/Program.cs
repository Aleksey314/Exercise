using System;

namespace StudentMarks
{
    class Mark
    {
        public string subject;
        public int mark;
        public Mark (string s)
        {
            subject = s;           
        }
        public void GetMark()
        {
            do
            {
                Console.Write($"{subject} mark is ");
                mark = Convert.ToInt32(Console.ReadLine());
            }
            while ((5 < mark) | (mark < 0));
        }
    }
    class Student
    {
        public string Name;
        public Mark[] marks = new Mark[4];        
        public Student(string n)
        {
            Name = n;           
            marks[0] = new Mark("mathematics");
            marks[1] = new Mark("phisics");
            marks[2] = new Mark("Chemistry");
            marks[3] = new Mark("Biology");
        }
        public float GetAvgMark()
        {
            int mult = 0;
            for(int i=0;i<4;i++)
            {
                mult += marks[i].mark;
            }
            float avg =(float) mult / 4;
            return avg;
        }
        public void ResetAllMarks()
        {
            Console.Write($"Do you want reset {Name} marks? (y/n) ");
            string r = Console.ReadLine();
            if (r == "n"){ return; }
            for (int i = 0; i < 4; i++) { marks[i].mark = 0; }
        }
        public void GetMarksTable()
        {
            Console.WriteLine($"Enter {Name} marks");
            for (int i = 0; i < 4; i++)
            {
                marks[i].GetMark();
            }
        }
        public void DisplayMarksTable()
        {
            Console.WriteLine($"---Marks table:---");
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine($"{Name} mark in {marks[i].subject} is {marks[i].mark}");
            }
            Console.WriteLine($"Average of all marks {GetAvgMark()}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Student st1 = new Student("Fyodor");
            Student st2 = new Student("Syemen");
            st1.GetMarksTable();
            st2.GetMarksTable();
            st1.DisplayMarksTable();
            st2.DisplayMarksTable();
            st1.ResetAllMarks();
            st2.ResetAllMarks();
            st1.DisplayMarksTable();
            st2.DisplayMarksTable();
        }
    }
}
