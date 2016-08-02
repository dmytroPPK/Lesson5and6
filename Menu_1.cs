using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson56
{
    //Menu class
    static partial class Menu
    {

        private static void GirlsList()
        {

            if (Scout.ListOfScout == null || Scout.ListOfScout.Count == 0)
            {
                Console.WriteLine("Add Scout to list. At present no-one is not at list");
                Menu.MenuOrExit();
                return;
            }

            Console.WriteLine("List of Girls:");
            foreach (var item in Scout.ListOfScout)
            {
                if (item is Girl)
                {
                    Girl girl = (Girl)item;
                    Console.WriteLine(" - name-> " + girl.Name + ": age-> " + girl.Age);
                }
            }

            Menu.MenuOrExit();

        }

        private static void BoysList()
        {

            if (Scout.ListOfScout == null || Scout.ListOfScout.Count == 0)
            {
                Console.WriteLine("Add Scout to list. At present no-one is not at list");
                Menu.MenuOrExit();
                return;
            }

            Console.WriteLine("List of Boys:");
            foreach (var item in Scout.ListOfScout)
            {
                if (item is Boy)
                {
                    Boy boy = (Boy)item;
                    Console.WriteLine(" - name-> " + boy.Name + ": age-> " + boy.Age);
                }
            }


            Menu.MenuOrExit();

        }

        private static void ListGender()
        {

            if (Scout.ListOfScout == null || Scout.ListOfScout.Count == 0)
            {
                Console.WriteLine("Add Scout to list. At present no-one is not at list");
                Menu.MenuOrExit();
                return;
            }

            foreach (var item in Scout.ListOfScout)
            {
                Console.WriteLine(" - name-> " + item.Name + ": age-> " + item.Age + ": gender-> " + ((item is Boy) ? "Boy" : "Girl"));
            }


            Menu.MenuOrExit();

        }

        private static void AllList(bool showInteractive = true)
        {


            if (Scout.ListOfScout == null || Scout.ListOfScout.Count == 0)
            {
                Console.WriteLine("Add Scout to list. At present no-one is not at list");
                Menu.MenuOrExit();
                return;
            }

            string name;
            int age;
            string msgFormat = "id {2}, Name -> {0}, Age -> {1}";
            string msgSportFormat = "\tid {3,2}. type of sport -> {0,7}, score -> {1,4}, comment -> {2,-50}";
            for (int count = 0; count < Scout.ListOfScout.Count; count++)
            {
                name = Scout.ListOfScout[count].Name;
                age = Scout.ListOfScout[count].Age;
                Console.WriteLine(String.Format(msgFormat, name, age, count));
                Console.WriteLine("\tList of Sports:");
                if (Scout.ListOfScout[count].ListOfSport != null && Scout.ListOfScout[count].ListOfSport.Count != 0)
                {

                    for (int i = 0; i < Scout.ListOfScout[count].ListOfSport.Count; i++)
                    {
                        Console.WriteLine(String.Format(msgSportFormat, Scout.ListOfScout[count].ListOfSport[i].Name, Scout.ListOfScout[count].ListOfSport[i].Score, Scout.ListOfScout[count].ListOfSport[i].MsgAward, i));
                    }

                }
                else
                {
                    Console.WriteLine("empty list");
                }

            }

            if (showInteractive)
            {
                Menu.MenuOrExit();
            }
        }

        private static void DeleteSport() //Helper here !!!
        {
            if (Scout.ListOfScout == null || Scout.ListOfScout.Count == 0)
            {
                Console.WriteLine("Add Scout to list. At present no-one is not at list");
                Menu.MenuOrExit();
                return;
            }
            Helper.PrintMsg("Enter the id of scout who will be changed by you:");
            AllList(false);
            Console.ForegroundColor = ConsoleColor.Cyan;
            int idScout;
            while (true)
            {
                Console.Write("Enter the id of scout: ");

                if (!Int32.TryParse(Console.ReadLine(), out idScout))
                {
                    Helper.PrintErrorMsg("not valid type of data");
                    continue;
                }
                else if ((idScout >= Scout.ListOfScout.Count - 1) || (idScout < 0))
                {
                    Helper.PrintErrorMsg("Boundary of index");
                    continue;
                }
                else
                {
                    break;
                }

            }
            Console.Clear();
            Console.Write("You choose - > ");
            Console.WriteLine("name: " + Scout.ListOfScout[idScout].Name + " age: " + Scout.ListOfScout[idScout].Age);
            Console.ForegroundColor = ConsoleColor.Gray;

            #region delete sport
            while (true)
            {
                if (Scout.ListOfScout[idScout].ListOfSport == null || Scout.ListOfScout[idScout].ListOfSport.Count == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Scount does not have any sport !!!\n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }

                Console.Write("Do you wanna delete the sport of scout ? <yes,no>: ");
                string prompt = Console.ReadLine().ToLower();
                if (prompt == "yes")
                {
                    int idSport = 0;
                    while (true)
                    {
                        Console.Write("enter id of sport: ");
                        if (!Int32.TryParse(Console.ReadLine(), out idSport) || (idSport < 0 || idSport > Scout.ListOfScout[idScout].ListOfSport.Count - 1))
                        {
                            Helper.PrintErrorMsg("it's not a number OR boundary of index");
                            continue;
                        }
                        else
                        {
                            
                            Scout.ListOfScout[idScout].DeleteSport(idSport);
                            Scout.ListOfScout[idScout].Experience();
                            break;
                        }
                    }
                    Helper.PrintMsg("\nSport[" + idSport + "] was removed\n");
                    break;
                }
                else if (prompt == "no")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            #endregion


            Menu.MenuOrExit();

        }

        private static void AddSport(bool showInteractive = true) //Helper here !!!
        {

            if (Scout.ListOfScout == null || Scout.ListOfScout.Count == 0)
            {
                Console.WriteLine("Add Scout to list. At present no-one is not at list");
                Menu.MenuOrExit();
                return;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Enter the id of scout who will be changed by you:");
            Console.ForegroundColor = ConsoleColor.Gray;
            AllList(false);
            Console.ForegroundColor = ConsoleColor.Cyan;
            int idScout;
            while (true)
            {
                Console.Write("Enter the id of scout: ");

                if (!Int32.TryParse(Console.ReadLine(), out idScout))
                {
                    Helper.PrintErrorMsg("not valid type of data");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    continue;
                }
                else if ((idScout > Scout.ListOfScout.Count - 1) || (idScout < 0))
                {
                    Helper.PrintErrorMsg("Boundary of index !!!");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    continue;
                }
                else
                {
                    break;
                }

            }
            Console.Clear();
            Console.Write("You choose - > ");
            Console.WriteLine("name: " + Scout.ListOfScout[idScout].Name + " age: " + Scout.ListOfScout[idScout].Age);
            Console.ForegroundColor = ConsoleColor.Gray;

            #region Add sport

            //array of sport for gender
            string[] sportsGender = null;
            if (Scout.ListOfScout[idScout] is Boy)
            {
                sportsGender = Sport.MaleSport;
            }
            else if (Scout.ListOfScout[idScout] is Girl)
            {
                sportsGender = Sport.FemaleSport;
            }


            while (true)
            {

                Console.Write("Do you wanna add the sport of scout ? <yes,no>: ");
                string prompt = Console.ReadLine().ToLower();
                if (prompt == "yes")
                {

                    #region List of  sports

                    for (int i = 0; i < sportsGender.Length; i++)
                    {
                        Console.WriteLine("Id " + i + " . sport: " + sportsGender[i]);
                    }

                    #endregion

                    int idSport = 0;
                    while (true)
                    {
                        Console.Write("enter id of sport: ");
                        if (!Int32.TryParse(Console.ReadLine(), out idSport) || (idSport < 0 || idSport > sportsGender.Length - 1))
                        {
                            Helper.PrintErrorMsg("it's not a number OR boundary of index");
                            continue;
                        }
                        else
                        {

                            int scoreOfSport;
                            string msgAwardSport;

                            while (true)
                            {
                                Console.Write("Enter a score: ");
                                if (!Int32.TryParse(Console.ReadLine(), out scoreOfSport))
                                {
                                    Helper.PrintErrorMsg("It's not a number");
                                    continue;
                                }
                                break;
                            }
                            Console.Write("Enter a massage of award for scout progress: ");
                            msgAwardSport = Console.ReadLine();
                            Scout.ListOfScout[idScout].AddSport(sportsGender[idSport], scoreOfSport, msgAwardSport);
                            Scout.ListOfScout[idScout].Experience();
                            break;
                        }
                    }
                    Helper.PrintMsg("\nSport was added.\n");
                    break;
                }
                else if (prompt == "no")
                {
                    break;
                }
                else
                {
                    continue;
                }
            }
            #endregion


            Menu.MenuOrExit();

        }

        private static void AddScout() //Helper here !!!
        {
            string name;
            string gender;
            int age = 0;
            Console.Clear();
            Console.WriteLine("\t<< Add new scout >>");

            Console.WriteLine("Choose gender < boy-> 'b' >,< girl-> 'g'");
            while (true) //while 1
            {
                Console.Write(" - gender <- ");
                gender = Console.ReadLine();
                if (gender == "b" || gender == "g")
                {
                    break;
                }

                else
                {
                    Helper.PrintErrorMsg("Wrong entered type of scout. try again...");
                    continue;
                }
            } // end while 1

            Console.Write(" Enter name: ");
            name = Console.ReadLine();

            Helper.IntegerValid(" Enter age:", "Invalid data type. Try again", age);

            Scout scout = null;
            if (gender == "b")
            {
                scout = new Boy { Name = name, Age = age };
            }
            else
            {
                scout = new Girl { Name = name, Age = age };
            }
            Scout.ListOfScout.Add(scout);


            // add sport
            Console.WriteLine("List of availibale sport for current gender :");
            if (scout is Boy)
            {
                for (int i = 0; i < Sport.MaleSport.Length; i++)
                {
                    Console.WriteLine(i + ". type of sport: " + Sport.MaleSport[i]);
                }

                int idOfsport;
                while (true)
                {
                    Console.Write("\nEnter id of sport: ");
                    if (Int32.TryParse(Console.ReadLine(), out idOfsport))
                    {
                        if (idOfsport >= 0 && idOfsport < Sport.MaleSport.Length)
                        {
                            int scoreEntered;
                            while (true)
                            {
                                Console.Write("enter a score: ");
                                if (!Int32.TryParse(Console.ReadLine(), out scoreEntered))
                                {
                                    Helper.PrintErrorMsg("It's not a number. Try again");
                                    continue;
                                }
                                break;
                            }
                            Console.Write("Please enter a msg award for scout in his sport: ");
                            string msgAwardEntered = Console.ReadLine();
                            scout.ListOfSport.Add(new Sport { Name = Sport.MaleSport[idOfsport], Score = scoreEntered, MsgAward = msgAwardEntered });
                            Helper.PrintMsg("\t < Scout Added >");

                            break;
                        }
                        else
                        {
                            Helper.PrintErrorMsg("Boundary of index.Try again.");
                            continue;
                        }
                    }
                    else
                    {
                        Helper.PrintErrorMsg("It's not a number. Try again");
                        continue;
                    }
                } // end while for id of sport
            } // end if is Boy
            if (scout is Girl)
            {
                for (int i = 0; i < Sport.FemaleSport.Length; i++)
                {
                    Console.WriteLine(i + ". type of sport: " + Sport.FemaleSport[i]);
                }

                int idOfsport;
                while (true)
                {
                    Console.Write("\nEnter id of sport: ");
                    if (Int32.TryParse(Console.ReadLine(), out idOfsport))
                    {
                        if (idOfsport >= 0 && idOfsport < Sport.FemaleSport.Length)
                        {
                            int scoreEntered;
                            while (true)
                            {
                                Console.Write("enter a score: ");
                                if (!Int32.TryParse(Console.ReadLine(), out scoreEntered))
                                {
                                    Helper.PrintErrorMsg("It's not a number. Try again");
                                    continue;
                                }
                                break;
                            }
                            Console.Write("Please enter a msg award for scout in his sport: ");
                            string msgAwardEntered = Console.ReadLine();
                            scout.ListOfSport.Add(new Sport { Name = Sport.FemaleSport[idOfsport], Score = scoreEntered, MsgAward = msgAwardEntered });

                            Helper.PrintMsg("\t < Scout Added >");

                            break;
                        }
                        else
                        {
                            Helper.PrintErrorMsg("Boundary of index. Try again.");
                            continue;
                        }
                    }
                    else
                    {
                        Helper.PrintErrorMsg("It's not a number. Try again");
                        continue;
                    }
                } // end while for id of sport
            } // end if is Girl

            scout.Experience();

            Menu.MenuOrExit();


        }


        private static void Calculate() //Fixed !!! Fen Shui is done )
        {

            if (Scout.ListOfScout == null || Scout.ListOfScout.Count == 0)
            {
                Console.WriteLine("Add Scout to list. At present no-one is not at list");
                Menu.MenuOrExit();
                return;
            }

            #region Средний бал лагеря
            {
                double avarageCampusScore = 0;
                Console.Clear();
                foreach (var item in Scout.ListOfScout)
                {
                    avarageCampusScore += item.AvarScore;

                }
                avarageCampusScore /= Scout.ListOfScout.Count;
                Console.WriteLine("Средний бал лагеря - " + avarageCampusScore);
            }
            Console.WriteLine("---------");
            #endregion

            # region Самый высокий средний бал дев и мальчик
            {
                
                var scoutBoys = (from item in Scout.ListOfScout
                                 where item is Boy 
                                 where item.AvarScore == (Scout.ListOfScout.Where(ob=>ob is Boy)).Max(p=>p.AvarScore)
                                 select item).ToList();

                var scoutGirls = (from item in Scout.ListOfScout
                                  where item is Girl
                                  where item.AvarScore == (Scout.ListOfScout.Where(ob => ob is Girl)).Max(p => p.AvarScore)
                                  select item).ToList();



                foreach(var scout in scoutBoys)
                {
                    Console.WriteLine("Мах средний бал среди парней: " + scout.AvarScore + ". У " + scout.Name);
                }
                foreach (var scout in scoutGirls)
                {
                    Console.WriteLine("Мах средний бал среди девушек: " + scout.AvarScore + ". У " + scout.Name);
                }
                
            }

            Console.WriteLine(new String('-', 20));
            #endregion

            #region Самого успешного скаута – больше всего балов за все предметы (мальчик и девочка)
            {
                var scoutBoys = (from item in Scout.ListOfScout
                                 where item is Boy
                                 where item.AllScore == (Scout.ListOfScout.Where(ob => ob is Boy)).Max(p => p.AllScore)
                                 select item).ToList();

                var scoutGirls = (from item in Scout.ListOfScout
                                  where item is Girl
                                  where item.AllScore == (Scout.ListOfScout.Where(ob => ob is Girl)).Max(p => p.AllScore)
                                  select item).ToList();

                foreach (var scout in scoutBoys)
                {
                    Console.WriteLine("Мах бал за все предметы среди парней: " + scout.AllScore + ". У " + scout.Name);
                }
                foreach (var scout in scoutGirls)
                {
                    Console.WriteLine("Мах бал за все предметы среди девушек: " + scout.AllScore + ". У " + scout.Name);
                }
                
            }
            Console.WriteLine(new String('-', 20));
            #endregion

            #region Самого активного скаута – больше всего предметов (мальчик и девочка)
            {
                var scoutBoys = (from item in Scout.ListOfScout
                                 where item is Boy
                                 where item.NumSports == (Scout.ListOfScout.Where(ob => ob is Boy)).Max(p => p.NumSports)
                                 select item).ToList();

                var scoutGirls = (from item in Scout.ListOfScout
                                  where item is Girl
                                  where item.NumSports == (Scout.ListOfScout.Where(ob => ob is Girl)).Max(p => p.NumSports)
                                  select item).ToList();

                foreach (var scout in scoutBoys)
                {
                    Console.WriteLine("Мах к-ство предметов среди парней: " + scout.NumSports + ". У " + scout.Name);
                }
                foreach (var scout in scoutGirls)
                {
                    Console.WriteLine("Мах к-ство предметов среди девушек: " + scout.NumSports + ". У " + scout.Name);
                }
                
            }
            Console.WriteLine(new String('-', 20));
            #endregion

            #region Самого большого лентяя мальчика, девочку. (меньше всего предметов)
            {
                var scoutBoys = (from item in Scout.ListOfScout
                                 where item is Boy
                                 where item.NumSports == (Scout.ListOfScout.Where(ob => ob is Boy)).Min(p => p.NumSports)
                                 select item).ToList();

                var scoutGirls = (from item in Scout.ListOfScout
                                  where item is Girl
                                  where item.NumSports == (Scout.ListOfScout.Where(ob => ob is Girl)).Min(p => p.NumSports)
                                  select item).ToList();

                foreach (var scout in scoutBoys)
                {
                    Console.WriteLine("Min к-ство предметов среди парней: " + scout.NumSports + ". У " + scout.Name);
                }
                foreach (var scout in scoutGirls)
                {
                    Console.WriteLine("Min к-ство предметов среди девушек: " + scout.NumSports + ". У " + scout.Name);
                }
                

            }
            Console.WriteLine(new String('-', 20));
            #endregion

            #region Средний бал за все награды у скаутов список
            {
                for (int i = 0; i < Scout.ListOfScout.Count; i++)
                {
                    Console.WriteLine("  - Name: {0,10}; avarage score: {1}", Scout.ListOfScout[i].Name, Scout.ListOfScout[i].AvarScore);
                }
            }
            Console.WriteLine(new String('-', 20));
            #endregion
            Menu.MenuOrExit();

        }



        private static void MenuOrExit()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\nPress any key to exit");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" OR ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("enter \"M\" to menu: ");
            Console.ForegroundColor = ConsoleColor.Magenta;
            string strFlag = Console.ReadLine();
            if (strFlag.ToLower() == "m")
            {
                Menu._showAgain = true;
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Clear();
                Menu.Show();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t<<---Bye !!!--->>");
                Console.ReadKey();
            }

        }
    }
}
