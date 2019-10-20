using System;
using System.Collections.Generic;

namespace StudentMarks
{
    class Mark
    {
        public string subject;
        public List<int> mark=new List<int>();
        public Mark (string s) {subject = s;}
        public float GetAvgSubMark()
        {
            int mult = 0; int r = 0;float savg = 0;            
            for (int i = 0; i < mark.Count-1; i++){ mult += mark[i];r++; }
            if (r==0) { r = 1; }
            savg =(float) mult / r;
            return savg;
        }
    }
    class Student
    {
        public string Name;
        public float AvgMark;
        public Student(string n) { Name = n; }        
        public List<Mark> SubM=new List<Mark>();        
        
        public static void Conclusion(float avgmark,string name)
        {
            Console.WriteLine();
            if (avgmark > 4.8)//                                            using "if-else" construction
                Console.WriteLine($"{name} is the excellent student");
            else if (avgmark >= 4)
                Console.WriteLine($"{name} is the good student");
            else if (avgmark >= 3)
                Console.WriteLine($"{name}\'s progress can be better");
            else Console.WriteLine($"{name} studies badly");
        }
        public void GetAvgMark(out float avg)//                              using parameter passing by reference
        {
            int mult = 0;int r = 0;
            for(int i=0;i<SubM.Count;i++)
                for(int j=0;j<SubM[i].mark.Count-1;j++)
                { mult += SubM[i].mark[j];r++; }
            if (r == 0) { r = 1; }
            avg =(float) mult / r;            
        }        
        public static void ResetAllMarks(string name, List< Mark> subm)//    using parameters passing by value
        {
            Console.WriteLine();
            Console.Write($"Do you want reset {name} marks? (y/n) ");
            string r = Console.ReadLine();
            switch(r)//                                                      using switch statement
            {
                case "n":return;
            }
            foreach(Mark c in subm) { c.mark.Clear(); }//                    using foreach loops
            //if (r == "n"){ return; }
            //for(int i = 0; i < subm.Count; i++) { subm[i].mark.Clear(); }
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
                    if(int.TryParse(entm,out int entz) & (entz < 6) & (entz > -1))
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
            GetAvgMark(out AvgMark);
            Console.WriteLine($"Average of all {Name} marks is: {AvgMark}");
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
            Student.Conclusion(st1.AvgMark, st1.Name);
            Student.ResetAllMarks(st1.Name,st1.SubM);
            Student.ResetAllMarks(st2.Name,st2.SubM);
            st1.DisplayMarksTable();
            st2.DisplayMarksTable();
        }
    }
}
