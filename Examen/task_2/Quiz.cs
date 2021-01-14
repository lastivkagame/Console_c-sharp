using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace task_2
{
    public enum TypeQUIZ
    {
        Math,
        Geography,
        English,
        History,
        Mixed,
    }

    class Quiz
    {
        public static double Balls { get; set; }

        public Quiz()
        {
            Balls = 0;
        }

        static public void StartQuiz(string name, TypeQUIZ type)
        {
            #region Preparation
            List<string> list_Questions = null;
            List<string> list_Answers = null;
            string json;

            switch (type)
            {
                case TypeQUIZ.Math:
                    json = File.ReadAllText("Math_Question.json");
                    list_Questions = JsonConvert.DeserializeObject<List<string>>(json);

                    json = File.ReadAllText("Math_Answers.json");
                    list_Answers = JsonConvert.DeserializeObject<List<string>>(json);
                    break;
                case TypeQUIZ.Geography:
                    json = File.ReadAllText("Geography_Question.json");
                    list_Questions = JsonConvert.DeserializeObject<List<string>>(json);

                    json = File.ReadAllText("Geography_Answers.json");
                    list_Answers = JsonConvert.DeserializeObject<List<string>>(json);
                    break;
                case TypeQUIZ.English:
                    json = File.ReadAllText("English_Question.json");
                    list_Questions = JsonConvert.DeserializeObject<List<string>>(json);

                    json = File.ReadAllText("English_Answers.json");
                    list_Answers = JsonConvert.DeserializeObject<List<string>>(json);
                    break;
                case TypeQUIZ.History:
                    json = File.ReadAllText("History_Question.json");
                    list_Questions = JsonConvert.DeserializeObject<List<string>>(json);

                    json = File.ReadAllText("History_Answers.json");
                    list_Answers = JsonConvert.DeserializeObject<List<string>>(json);
                    break;
                case TypeQUIZ.Mixed:
                    List<string> list_Questions1 = null;
                    List<string> list_Answers1 = null;

                    List<string> list_Questions2 = null;
                    List<string> list_Answers2 = null;

                    List<string> list_Questions3 = null;
                    List<string> list_Answers3 = null;

                    List<string> list_Questions4 = null;
                    List<string> list_Answers4 = null;

                    json = File.ReadAllText("Math_Question.json");
                    list_Questions1 = JsonConvert.DeserializeObject<List<string>>(json);

                    json = File.ReadAllText("Math_Answers.json");
                    list_Answers1 = JsonConvert.DeserializeObject<List<string>>(json);

                    json = File.ReadAllText("Geography_Question.json");
                    list_Questions2 = JsonConvert.DeserializeObject<List<string>>(json);

                    json = File.ReadAllText("Geography_Answers.json");
                    list_Answers2 = JsonConvert.DeserializeObject<List<string>>(json);

                    json = File.ReadAllText("English_Question.json");
                    list_Questions3 = JsonConvert.DeserializeObject<List<string>>(json);

                    json = File.ReadAllText("English_Answers.json");
                    list_Answers3 = JsonConvert.DeserializeObject<List<string>>(json);

                    json = File.ReadAllText("History_Question.json");
                    list_Questions4 = JsonConvert.DeserializeObject<List<string>>(json);

                    json = File.ReadAllText("History_Answers.json");
                    list_Answers4 = JsonConvert.DeserializeObject<List<string>>(json);

                    int number = ((list_Answers1.Count + list_Answers2.Count + list_Answers3.Count + list_Answers4.Count) / 4);
                    Random random = new Random(number);

                    if (number > 4)
                    {
                        number = number / 4;
                    }
                    else
                    {
                        number = 1;
                    }

                    list_Questions = new List<string>();
                    list_Answers = new List<string>();

                    for (int i = 0; i < number; i++)
                    {
                        int k1 = random.Next(list_Questions1.Count);
                        int k2 = random.Next(list_Questions2.Count);
                        int k3 = random.Next(list_Questions3.Count);
                        int k4 = random.Next(list_Questions4.Count);

                        list_Questions.Add(list_Questions1[k1]);
                        list_Questions.Add(list_Questions2[k2]);
                        list_Questions.Add(list_Questions3[k3]);
                        list_Questions.Add(list_Questions4[k4]);

                        list_Answers.Add(list_Answers1[k1]);
                        list_Answers.Add(list_Answers2[k2]);
                        list_Answers.Add(list_Answers3[k3]);
                        list_Answers.Add(list_Answers4[k4]);
                    }
                    break;
                default:
                    break;
            }
            #endregion

            Console.Clear();
            Console.WriteLine("\t --- Let's start ---");
            Console.WriteLine("You can earn max balls this = 100");
            double one_question_balls = 100 / list_Questions.Count;
            Console.WriteLine("One correct question = " + one_question_balls);
            Console.WriteLine("");
            string answer;
            int correcttask = 0, inccorecttask = 0;

            for (int i = 0; i < list_Questions.Count; i++)
            {
                Console.WriteLine("Question #" + i + ":  " + list_Questions[i]);
                Console.Write("Enter answer: ");
                answer = Console.ReadLine();

                if (list_Answers[i].Contains(answer))
                {
                    Balls += one_question_balls;
                    correcttask++;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.WriteLine("Its correct!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                }
                else
                {
                    inccorecttask++;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Its NOT correct!");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.BackgroundColor = ConsoleColor.Black;
                }

                Console.WriteLine("\n Press something ...");
                Console.ReadKey();
                Console.Clear();
            }
            Console.Clear();
            Console.WriteLine("QUIZ is end! Your score: " + Balls);
            Console.WriteLine("Correct answers: " + correcttask);
            Console.WriteLine("Incorect answers: "+ inccorecttask);
            Console.WriteLine();

            if (Balls > 50)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("Its good resalt!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Green;
                Console.WriteLine("I believe you can more!!!");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.BackgroundColor = ConsoleColor.Black;
            }

            List<string> players = new List<string>();
            //players.Add("100 -> user");

            switch (type)
            {
                case TypeQUIZ.Math:
                    using (FileStream fs = new FileStream("score_math.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }

                    players.Add(Balls + " -> " + name);

                    players.Sort();

                    using (FileStream fs = new FileStream("score_math.bin", FileMode.OpenOrCreate))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, players);
                    }
                    break;
                case TypeQUIZ.Geography:
                    using (FileStream fs = new FileStream("score_geography.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }

                    players.Add(Balls + " -> " + name);

                    players.Sort();

                    using (FileStream fs = new FileStream("score_geography.bin", FileMode.OpenOrCreate))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, players);
                    }
                    break;
                case TypeQUIZ.English:
                    using (FileStream fs = new FileStream("score_english.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }

                    players.Add(Balls + " -> " + name);

                    players.Sort();

                    using (FileStream fs = new FileStream("score_english.bin", FileMode.OpenOrCreate))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, players);
                    }
                    break;
                case TypeQUIZ.History:
                    using (FileStream fs = new FileStream("score_history.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }

                    players.Add(Balls + " -> " + name);

                    players.Sort();

                    using (FileStream fs = new FileStream("score_history.bin", FileMode.OpenOrCreate))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, players);
                    }
                    break;
                case TypeQUIZ.Mixed:
                    using (FileStream fs = new FileStream("score_mixed.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }

                    players.Add(Balls + " -> " + name);

                    players.Sort();

                    using (FileStream fs = new FileStream("score_mixed.bin", FileMode.OpenOrCreate))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        bf.Serialize(fs, players);
                    }
                    break;
                default:
                    break;
            }


            
            Console.WriteLine("\n\n");

            Console.WriteLine(" --- All Participains ---");
            for (int i = 0; i < players.Count; i++)
            {
                if ((Balls + " -> " + name) == players[i])
                {
                    Console.WriteLine("You: -> " + players[i]);
                }
                else
                {
                    Console.WriteLine(players[i]);
                }
            }
            Balls = 0;
        }

        static public void AddQuestionToQuiz(TypeQUIZ type)
        {
            string temp = "", json = "", temp2 = "";
            List<string> group_quest = new List<string>();
            List<string> group_answer = new List<string>();

            do
            {
                Console.Clear();

                Console.WriteLine("If tou want exit enter it->  Enter question: exit");
                Console.Write("Enter question: ");
                temp = Console.ReadLine();

                if (temp != "exit" && temp != " " && temp != "")
                {
                    group_quest.Add(temp);
                    Console.Write("Enter answer: ");
                    temp2 = Console.ReadLine();
                    group_answer.Add(temp2);
                }
            } while (temp != "exit");

            switch (type)
            {
                case TypeQUIZ.Math:
                    json = JsonConvert.SerializeObject(group_quest, Formatting.Indented);
                    File.WriteAllText("Math_Question.json", json);

                    json = JsonConvert.SerializeObject(group_answer, Formatting.Indented);
                    File.WriteAllText("Math_Answers.json", json);
                    break;
                case TypeQUIZ.Geography:
                    json = JsonConvert.SerializeObject(group_quest, Formatting.Indented);
                    File.WriteAllText("Geography_Question.json", json);

                    json = JsonConvert.SerializeObject(group_answer, Formatting.Indented);
                    File.WriteAllText("Geography_Answers.json", json);
                    break;
                case TypeQUIZ.English:
                    json = JsonConvert.SerializeObject(group_quest, Formatting.Indented);
                    File.WriteAllText("English_Question.json", json);

                    json = JsonConvert.SerializeObject(group_answer, Formatting.Indented);
                    File.WriteAllText("English_Answers.json", json);
                    break;
                case TypeQUIZ.History:
                    json = JsonConvert.SerializeObject(group_quest, Formatting.Indented);
                    File.WriteAllText("History_Question.json", json);

                    json = JsonConvert.SerializeObject(group_answer, Formatting.Indented);
                    File.WriteAllText("History_Answers.json", json);
                    break;
                default:
                    break;
            }
            group_quest.Clear();
        }

        static public List<string> YourRezalts(string name, TypeQUIZ type)
        {
            List<string> players = new List<string>();

            switch (type)
            {
                case TypeQUIZ.Math:
                    using (FileStream fs = new FileStream("score_math.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }
                    break;
                case TypeQUIZ.Geography:
                    using (FileStream fs = new FileStream("score_geography.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }

                    break;
                case TypeQUIZ.English:
                    using (FileStream fs = new FileStream("score_english.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }
                    break;
                case TypeQUIZ.History:
                    using (FileStream fs = new FileStream("score_history.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }
                    break;
                case TypeQUIZ.Mixed:
                    using (FileStream fs = new FileStream("score_mixed.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }
                    break;
                default:
                    break;
            }

            List<string> your_rezalt = new List<string>();

            for (int i = 0; i < players.Count; i++)
            {
                if (players[i].Contains(name))
                {
                    your_rezalt.Add(players[i]);
                }
            }
            
            your_rezalt.Sort();

            return your_rezalt;
        }

        static public List<string> Top20Leaders(TypeQUIZ type)
        {
            List<string>players = new List<string>();

            switch (type)
            {
                case TypeQUIZ.Math:
                    using (FileStream fs = new FileStream("score_math.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }
                    break;
                case TypeQUIZ.Geography:
                    using (FileStream fs = new FileStream("score_geography.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }

                    break;
                case TypeQUIZ.English:
                    using (FileStream fs = new FileStream("score_english.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }
                    break;
                case TypeQUIZ.History:
                    using (FileStream fs = new FileStream("score_history.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }
                    break;
                case TypeQUIZ.Mixed:
                    using (FileStream fs = new FileStream("score_mixed.bin", FileMode.Open))
                    {
                        BinaryFormatter bf = new BinaryFormatter();
                        players = (List<string>)bf.Deserialize(fs);
                    }
                    break;
                default:
                    break;
            }

            for (int i = 21; i < players.Count; i++)
            {
                players.RemoveAt(i);
            }

            return players;
        }
    }
}
