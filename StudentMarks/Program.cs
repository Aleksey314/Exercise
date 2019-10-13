using System;
using System.Collections.Generic;

namespace StudentMarks
{
    class Mark
    {
        public string subject;
        public List<int> mark=new List<int>();
        public Mark (string s) {subject = s;}
        public float GetAvgSubMark()//Средние оценки по предмету
        {
            int mult = 0; int r = 0;float savg = 0;            
            for (int i = 0; i < mark.Count-1; i++){ mult += mark[i];r++; }
            if (r==0) { r = 1; }//если список пустой, на 0 не делим
            savg =(float) mult / r;
            return savg;
        }
    }
    class Student
    {
        public string Name;        
        public Student(string n) { Name = n; }
        public List<Mark> SubM=new List<Mark>();       
        
        public float GetAvgMark()//Средняя оценка студента
        {
            int mult = 0;int r = 0;float avg = 0;
            for(int i=0;i<SubM.Count;i++)
                for(int j=0;j<SubM[i].mark.Count-1;j++)
                { mult += SubM[i].mark[j];r++; }
            if (r == 0) { r = 1; }//если список пустой
            avg =(float) mult / r;
            return avg;
        }        
        public void ResetAllMarks()
        {
            Console.WriteLine();
            Console.Write($"Do you want reset {Name} marks? (y/n) ");
            string r = Console.ReadLine();
            if (r == "n"){ return; }
            for(int i = 0; i < SubM.Count; i++) { SubM[i].mark.Clear(); }
        }
        public void GetMarksTable()
        {               
            Mark c;
            do
            {
                Console.Write($"Enter {Name} subject (enter \"0\" to stop subjects list) ");
                c =new Mark( Console.ReadLine());
                if (c.subject == "0") { break; }
                Console.WriteLine($"Enter {Name} marks on {c.subject} (enter \"0\" to stop marks list)");
                do
                {
                    string entm = Console.ReadLine();
                    if(int.TryParse(entm,out int entz) & (entz < 6) & (entz > -1))//Проверка корректности ввода оценки
                    {
                        c.mark.Add(entz);
                        if (entz == 0) { break; }                        
                    }
                    else { Console.WriteLine($"The mark should be number from 1 to 5. Try again.");continue; }                    
                }
                while (true);
                SubM.Add(c);
            }
            while (true);            
        }
        public void DisplayMarksTable()
        {
            Console.WriteLine();
            Console.WriteLine($"---{Name} Marks table:---");
            for (int i = 0; i < SubM.Count; i++)
            {
                Console.Write($"-{SubM[i].subject}- :");
                for (int j = 0; j < SubM[i].mark.Count-1; j++)
                {
                    Console.Write($" {SubM[i].mark[j]} ");
                }
                Console.WriteLine($"  --Average of {SubM[i].subject} is: {SubM[i].GetAvgSubMark()}");
            }
            Console.WriteLine();
            Console.WriteLine($"Average of all {Name} marks is: {GetAvgMark()}");
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
