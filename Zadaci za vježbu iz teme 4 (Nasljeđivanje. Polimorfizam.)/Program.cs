using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadaci_za_vježbu_iz_teme_4__Nasljeđivanje.Polimorfizam._
{
    internal class Program
    {
        class Dessert
        {
            string name;
            double weight;
            int calories;

            public Dessert(string N, double W, int C)
            {
                Name = N;
                Weight = W;
                Calories = C;
            }

            public Dessert()
            {

            }

            public string Name { get => name; set => name = value; }
            public double Weight { get => weight; set => weight = value; }
            public int Calories { get => calories; set => calories = value; }

            public override string ToString()
            {
                string text = "Desert " + Name + " ima " + Weight + "g s " + Calories + " kalorija.";

                return text;
            }

            public virtual string getDessertType()
            {
                return "dessert";
            }
        }

        class Cake : Dessert
        {
            bool containsGluten;
            string cakeType;
            public bool ContainsGluten { get => containsGluten; set => containsGluten = value; }
            public string CakeType { get => cakeType; set => cakeType = value; }

            public override string getDessertType()
            {
                return "cake";
            }
            public override string ToString()
            {
                string text = "Torta " + Name + " je " + CakeType + " vrsta i ";
                if (ContainsGluten)
                {
                    text += "im";
                }
                else
                {
                    text += "nem";
                }

                text += "a gluten, ima " + Weight + "g s " + Calories + " kalorija.";
                return text;
            }
            public Cake(string N, double W, int C, bool CG, string CT)
            {
                Name = N;
                Weight = W;
                Calories = C;
                ContainsGluten = CG;
                CakeType = CT;
            }
        }

        class IceCream : Dessert
        {
            string flavor;
            string color;
            public string Flavor { get => flavor; set => flavor = value; }
            public string Color { get => color; set => color = value; }

            public override string getDessertType()
            {
                return "ice cream";
            }
            public override string ToString()
            {
                string text = "Sladoled " + Name + " je " + Color + " boje i ima okus " + Flavor + ", ima " + Weight + "g s " + Calories + " kalorija.";
                return text;
            }
            public IceCream(string N, double W, int C, string F, string CR)
            {
                Name = N;
                Weight = W;
                Calories = C;
                Flavor = F;
                Color = CR;
            }
        }

        class Person
        {
            string name, surname;
            int age;

            public Person(string N, string S, int A)
            {
                Name = N;
                Surname = S;
                Age = A;
            }
            public Person()
            {
            }

            public string Name { get => name; set => name = value; }
            public string Surname { get => surname; set => surname = value; }
            public int Age { get => age; set => age = value; }

            public override bool Equals(object obj)
            {
                return obj is Person person &&
                       Name == person.Name &&
                       Surname == person.Surname &&
                       Age == person.Age;
            }

            public override int GetHashCode()
            {
                int hashCode = 675080504;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Name);
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Surname);
                hashCode = hashCode * -1521134295 + Age.GetHashCode();
                return hashCode;
            }

            public override string ToString()
            {
                string text = "Ime " + Name + ", prezime " + Surname + ", ima " + Age + " godina.";

                return text;
            }

        }

        class Student : Person
        {
            string studentId;
            int academicYear;

            public string StudentId { get => studentId; set => studentId = value; }
            public int AcademicYear { get => academicYear; set => academicYear = value; }
            public override string ToString()
            {
                string text = "Ime " + Name + ", prezime " + Surname + ", ima " + Age + " godina.";

                return "Ime " + Name + ", prezime " + Surname + ", ima " + Age + " godina." + " ID mu je " + StudentId + " i ide u " + AcademicYear + " razred.";
            }

            public override bool Equals(object obj)
            {
                return obj is Student student &&
                       base.Equals(obj) &&
                       StudentId == student.StudentId;
            }

            public override int GetHashCode()
            {
                int hashCode = 2134068595;
                hashCode = hashCode * -1521134295 + base.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StudentId);
                return hashCode;
            }

            public Student(string N, string S, int A, string SI, int AY)
            {
                Name = N;
                Surname = S;
                Age = A;
                StudentId = SI;
                AcademicYear = AY;
            }
            public Student()
            {
            }
        }

        class Teacher : Person
        {
            string email, subject;
            double salary;

            public string Email { get => email; set => email = value; }
            public string Subject { get => subject; set => subject = value; }
            public double Salary { get => salary; set => salary = value; }
            public override string ToString()
            {
                return "Ime " + Name + ", prezime " + Surname + " ima " + Age + " godina. E-mail: " + Email + ", uči " + Subject + " i ima plaču od " + Salary + " eura.";
            }
            public Teacher(string N, string S, int A, string E, string SU, double SA)
            {
                Name = N;
                Surname = S;
                Age = A;
                Email = E;
                Subject = SU;
                Salary = SA;
            }
            public Teacher()
            {
            }
            void increaseSalary(int percent)
            {
                this.salary += (this.salary * (percent / 100));
            }
            static void increaseSalaryStatic(int percent, Teacher teach)
            {
                teach.salary += (teach.salary * (percent / 100));
            }

            public override bool Equals(object obj)
            {
                return obj is Teacher teacher &&
                       base.Equals(obj) &&
                       Email == teacher.Email;
            }

            public override int GetHashCode()
            {
                int hashCode = 1751577597;
                hashCode = hashCode * -1521134295 + base.GetHashCode();
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Email);
                return hashCode;
            }
        }

        static void Main(string[] args)
        {
            Dessert dessert = new Dessert("Chocolate Mousse", 120, 300);
            Cake cake = new Cake("Chocolate cake", 400, 800, false, "birthday");
            IceCream iceCream = new IceCream("Chocolate", 200, 400, "Chocolate", "Brown");

            Console.WriteLine(dessert.ToString());
            Console.WriteLine(cake.ToString());
            Console.WriteLine(iceCream.ToString());

            Console.WriteLine("");

            Student student1 = new Student("Branko", "Branimir", 17, "00001467", 3);
            Student student2 = new Student("Krešo", "Krešimir", 18, "00001467", 4);
            Teacher teacher1 = new Teacher("Ivan", "Ivanović", 45, "ivan.ivanovic@skole.hr", "Math", 975.7);
            Teacher teacher2 = new Teacher("Ivo", "Ivanović", 35, "ivan.ivanovic@skole.hr", "English", 775.3);
            Teacher teacher3 = new Teacher("Ana", "Anić", 28, "ana.anic@skole.hr", "Math", 775.5);
            List<Person> persons = new List<Person>();
            persons.Add(student1);
            persons.Add(student2);
            persons.Add(teacher1);
            persons.Add(teacher2);
            persons.Add(teacher3);

            double salary = 0;
            int amount = 0;

            foreach (Person person in persons)
            {
                Console.WriteLine(person.ToString());

                if (person is Teacher)
                {
                    Teacher teacher = person as Teacher;
                    salary += teacher.Salary;

                    amount++;
                }
            }

            Console.WriteLine("Prosječna plača profesora liste je " + salary / amount + ".");

            Console.ReadKey();
        }
    }
}