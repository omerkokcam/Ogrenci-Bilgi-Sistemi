using System;
using System.IO; //this is for file operations.
using System.Linq;

namespace OgrenciOtomasyonProjesi
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to System...");
            int choice;
            do
            {
                selectsOnTheMenu();
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        newRegistration();
                        break;
                    case 2:
                        updateRegistration();
                        break;
                    case 3:
                        showTheRegistrations();
                        break;
                    case 4:
                        deleteTheRegistration();
                        break;
                    case 5:
                        showProgrammingLessonGradeAverage();
                        break;
                    case 6:
                        Console.WriteLine("Bye!");
                        break;
                    default:
                        Console.WriteLine("Please press 1 - 6");
                        break;
                }
            }
            while (choice != 6); 

        }
        static void selectsOnTheMenu()
        {
            Console.WriteLine("What do you want to do?");
            Console.WriteLine("1 -> New Registration");
            Console.WriteLine("2 -> Update Registration");
            Console.WriteLine("3 -> Show the Registrations");
            Console.WriteLine("4 -> Delete the Registration");
            Console.WriteLine("5 -> Show The Programming Lesson Grade Average");
            Console.WriteLine("6 -> Exit");
        }
        static void newRegistration() //new student registration 
        {
            again:
            string name, surname;
            string schoolNumber;
            string tcNo;//identity(id)
            double programmingLessonGrade;
            Console.WriteLine("Name:");
            name = Console.ReadLine();
            Console.WriteLine("Surname:");
            surname = Console.ReadLine();
            Console.WriteLine("School Number:");
            schoolNumber = Console.ReadLine();
            Console.WriteLine("TÜRKİYE CUMHURİYETİ KİMLİK NUMARASI(ID):");
            tcNo = Console.ReadLine();
            Console.WriteLine("Programming Lesson Grade :"); 
            programmingLessonGrade = double.Parse(Console.ReadLine());
            string filePath = "C:\\Users\\omerm\\OneDrive\\Desktop\\C#Dersleri\\OgrenciOtomasyonProjesiDosyaları\\OgrenciBilgileri.txt";
            string writeToBeFile = tcNo + "," + name + "," + surname + "," + schoolNumber + "," + programmingLessonGrade + Environment.NewLine;
            //file create time
            //if file isn't exist we gonna use Fire.WriteAllText()
            if (!File.Exists(filePath))
            {
                File.WriteAllText(filePath, writeToBeFile);
            }
            else
            {   // if file is exists.
                string[] students = File.ReadAllLines(filePath);//reading the path
                int studentsLength = students.Length;
                for (int i = 0; i < students.Length; i++)
                {
                    string[] lineByLineData = students[i].Split(','); // satır satır ',' ile ayrılmış kelimeleri diziye atıyoruz.
                    if (lineByLineData[0] == tcNo)
                    {
                        Console.WriteLine("Your TÜRKİYE CUMHURİYETİ KİMLİK NUMARASI(ID Number) is already in the system");
                        goto again;
                    }
                }
                File.AppendAllText(filePath, writeToBeFile);
            }
            Console.WriteLine("New registration created. Welcome to the School.");
        }
        static void updateRegistration() // update the student record
        {
            string filePath = "C:\\Users\\omerm\\OneDrive\\Desktop\\C#Dersleri\\OgrenciOtomasyonProjesiDosyaları\\OgrenciBilgileri.txt";
            string[] students = File.ReadAllLines(filePath);//reading the path
            int studentsLength = students.Length;
            if (studentsLength > 0)
            {
                Console.WriteLine("Update Registration Service");
                Console.WriteLine("Please enter your TÜRKİYE CUMHURİYETİ KİMLİK NUMARASI (ID)");//identity and School Number
                Console.WriteLine("TÜRKİYE CUMHURİYETİ KİMLİK NUMARASI (ID) : ");//identity
                string entryIdValue = Console.ReadLine();
                for (int i = 0; i < students.Length; i++)
                {
                    string[] wordByWordOnLines = students[i].Split(','); // satır satır ',' ile ayrılmış kelimeleri diziye atıyoruz.
                    if (wordByWordOnLines[0] == entryIdValue)
                    {
                        Console.WriteLine("Results based on the TÜRKİYE CUMHURİYETİ KİMLİK NUMARASI (ID) searched");
                        Console.WriteLine(students[i]);
                        Console.WriteLine("Which part/s did you wanna update it?");
                        Console.WriteLine(" 1 -> name, 2 ->surname, 3 -> Programming Lesson Grade, 4 -> Cancel the Update");
                        int updatingChoice = int.Parse(Console.ReadLine());
                        string TcNo = wordByWordOnLines[0];
                        string Name = wordByWordOnLines[1];
                        string LastName = wordByWordOnLines[2];
                        string SchoolNumber = wordByWordOnLines[3];
                        double ProgrammingLessonGrade = Convert.ToDouble(wordByWordOnLines[4]);
                        switch (updatingChoice)
                        {
                            case 1:
                                Console.WriteLine("Please enter the new name : ");
                                string updatingName = Console.ReadLine();
                                Name = updatingName;
                                Console.WriteLine("Process is success.");
                                Console.WriteLine("Your new name is " + Name);
                                break;
                            case 2:
                                Console.WriteLine("Please enter the new surname : ");
                                string updatingLastName = Console.ReadLine();
                                LastName = updatingLastName;
                                Console.WriteLine("Process is success.");
                                Console.WriteLine("Your new surname is " + LastName);
                                break;
                            case 3:
                                Console.WriteLine("Please enter the new Programming Lesson Grade : ");
                                double updatingProgrammingLessonGrade = double.Parse(Console.ReadLine());
                                ProgrammingLessonGrade = updatingProgrammingLessonGrade;
                                Console.WriteLine("Process is success.");
                                Console.WriteLine("Your new Programming Lesson Grade is " + ProgrammingLessonGrade);
                                break;
                            case 4:
                                Console.WriteLine("Bye!");
                                break;
                            default:
                                Console.WriteLine("Please press 1 - 3");
                                break;
                        }
                        string newAllData = TcNo + "," + Name + "," + LastName + "," + SchoolNumber + "," + ProgrammingLessonGrade.ToString();
                        students[i] = newAllData;
                        File.WriteAllLines(filePath, students);
                    }
                    if (i == students.Length - 2 && wordByWordOnLines[i] != entryIdValue)
                    {
                        Console.WriteLine("You have entered a wrong or incorrect TÜRKİYE CUMHURİYETİ KİMLİK NUMARASI (ID Number).");
                        Console.WriteLine("Please try again");
                    }
                }
            }
            else
            {
                Console.WriteLine("Currently there are no registered students.");
            }
        }
        static void showTheRegistrations()
        {
        
            string filePath = "C:\\Users\\omerm\\OneDrive\\Desktop\\C#Dersleri\\OgrenciOtomasyonProjesiDosyaları\\OgrenciBilgileri.txt";
            string[] students = File.ReadAllLines(filePath);
            string[] lineByLineData;//satır satır ',' ile ayrılmış verileri alıyoruz.
            int studentsLength = students.Length;
            if(studentsLength > 0)
            {
                string[] TcNos = new string[studentsLength];
                string[] Names = new string[studentsLength];
                string[] LastNames = new string[studentsLength];
                string[] SchoolNumbers = new string[studentsLength];
                double[] ProgrammingLessonGrades = new double[studentsLength];
                for (int i = 0; i < studentsLength; i++)
                {
                    lineByLineData = students[i].Split(",");
                    TcNos[i] = lineByLineData[0];
                    Names[i] = lineByLineData[1];
                    LastNames[i] = lineByLineData[2];
                    SchoolNumbers[i] = lineByLineData[3];
                    ProgrammingLessonGrades[i] = Convert.ToDouble(lineByLineData[4]);
                    Console.WriteLine("Name : " + Names[i] + " Surname : " + LastNames[i] + " School Number : " + SchoolNumbers[i] + " Programming Lesson Grade : " + ProgrammingLessonGrades[i]);
                }
                Console.WriteLine("Number Of The Students : " + studentsLength);
            }
            else
            {
                Console.WriteLine("Currently there are no registered students.");
            }
        }
        static void deleteTheRegistration()
        {
            string filePath = "C:\\Users\\omerm\\OneDrive\\Desktop\\C#Dersleri\\OgrenciOtomasyonProjesiDosyaları\\OgrenciBilgileri.txt";
            string[] students = File.ReadAllLines(filePath);
            int studentsLength = students.Length;
            if(studentsLength > 0)
            {
                Console.WriteLine("Delete Registration Service");
                Console.WriteLine("Please enter the TÜRKİYE CUMHURİYETİ KİMLİK NUMARASI(ID number) of the student registration you want to delete.");
                string entryForDeletingId = Console.ReadLine();
                string[] transferredToTheNewFile = new string[studentsLength - 1];//Records to be transferred to the new file
                int j = 0;
                for (int i = 0; i < studentsLength; i++)
                {
                    string[] lineByLineData = students[i].Split(",");
                    if (lineByLineData[0] == entryForDeletingId)
                    {
                        Console.WriteLine("Information to be deleted");
                        Console.WriteLine("TÜRKİYE CUMHURİYETİ KİMLİK NUMARASI(ID number) : " + lineByLineData[0] + "Name : " + lineByLineData[1] + " Surname : " + lineByLineData[2] + " School Number : " + lineByLineData[3] + " Programming Lesson Grade : " + lineByLineData[4]);
                    }
                    else
                    {
                        
                        transferredToTheNewFile[j] = students[i];
                        j++;
                    }
                }
               
                File.WriteAllLines(filePath, transferredToTheNewFile);
            }
            else
            {
                Console.WriteLine("Currently there are no registered students.");
            }
            
        }
        static void showProgrammingLessonGradeAverage()
        {
            string filePath = "C:\\Users\\omerm\\OneDrive\\Desktop\\C#Dersleri\\OgrenciOtomasyonProjesiDosyaları\\OgrenciBilgileri.txt";
            string[] students = File.ReadAllLines(filePath);
            int studentsLength = students.Length;
            double programmingLessonGrades = 0;
            for(int i = 0; i <studentsLength; i++)
            {
                string[] lineByLineData = students[i].Split(",");
                programmingLessonGrades += Convert.ToDouble(lineByLineData[4]); 
            }
            Console.WriteLine("The average of students programming course is " + programmingLessonGrades / studentsLength );
        }
    }
}
