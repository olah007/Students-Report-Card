using System;
using System.Collections.Generic;

namespace Student_Report_Card
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<========= STUDENT REPORT CARD =========>");
            Console.WriteLine(" ");
            
            Console.Write("Enter the number of students: ");
            var canConvertInput = Int32.TryParse(Console.ReadLine(), out int studentNumber);
            if(!canConvertInput)
            {
                Console.WriteLine("Invalid input. Try again!");
                Console.WriteLine(" ");
                return;
            }
            else if(studentNumber <=0)
            {
                Console.WriteLine("Wrong input, value must be a positive integer. Try again!");
                return;
            }

            string[] subjects = {"English", "Mathematics", "Computer"};
            string[] studentNames = new string[studentNumber];
            var subjectMarks = new double[studentNumber, subjects.Length];   // multi-dimensional array
            IDictionary<int, double> totalScores = new Dictionary<int, double>();
            List<double> totalScoresList = new List<double>();
        
            for(int i=0; i < studentNumber; i++)
            {
                double totalMarks = 0;

                Console.Write("Enter Student Name : ");
                studentNames[i] = Console.ReadLine();

                // Entering the subjects marks
                for(int j=0; j <= subjects.Length; j++)
                {
                    if(j < subjects.Length)
                    {
                        Console.Write($"Enter {subjects[j]} Marks (Out Of 100) : ");
                        var canConvert = Double.TryParse(Console.ReadLine(), out double convertedValue);
                        if(!canConvert || convertedValue > 100)
                        {
                            Console.WriteLine("Invalid input. Start all over!");
                            return;
                        }
                        else
                        {
                            subjectMarks[i, j] = convertedValue; 
                            totalMarks += convertedValue;
                        }
                    }
                    else{
                        totalScores[i] = totalMarks;
                        totalScoresList.Add(totalMarks);
                    }
                }
                Console.WriteLine(" ");
            }

            // sort students' total score in descending order 
            double[] sortedScores = new double[studentNumber];
            for(int k=0; k < studentNumber; k++)
            {
                double maxScore = 0;
                foreach(var elementalscore in totalScoresList)
                {
                    if(elementalscore > maxScore)
                    {
                        maxScore = elementalscore;
                    }
                }
                sortedScores[k] = maxScore;
                totalScoresList.Remove(maxScore);
            }
            
            // Display students' report
            Console.WriteLine("****************Report Card***********************");
            Console.WriteLine("**************************************************");

            for (int m=0; m < studentNumber; m++)     
            {
                int index = 0;
                foreach(KeyValuePair<int, double> scores in totalScores)
                {
                    if(scores.Value == sortedScores[m])
                    {
                        index++;
                        Console.WriteLine("");
                        Console.WriteLine($"Student Name: {studentNames[scores.Key]},  Position: {m+1},  Total: {sortedScores[m]}/300");
                        Console.WriteLine("**************************************************");
                    }
                    
                    if(index >=2)
                    {
                        m += index;
                        return;
                    }
                }
            }           
        }
    }
}