using System;
using System.Collections.Generic;
using System.Linq;

namespace TowerOfHanoi
{
    class Program
    {
        // genRandom value start
        static string[][] GetRandomInputs()
        {
            string[] chars = new string[] { "G", "R", "Y" };
            Random rnd = new Random();

            string[][] inputUser = new string[3][];
            inputUser[0] = new string[3];
            inputUser[1] = new string[3];
            inputUser[2] = new string[3];

            // intial inputUser arrays value
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    inputUser[i][j] = "0";
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    while (true)
                    {
                        var value = chars[rnd.Next(0, chars.Length)].ToCharArray()[0];

                        if (!IsContainThreeTimes(inputUser, value))
                        {
                            inputUser[i][j] = value.ToString();
                            break;
                        }
                    }
                }
            }

            return inputUser;
        }

        private static bool IsContainThreeTimes(string[][] arrays, char value)
        {
            int count = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (arrays[i][j].Equals(value.ToString()))
                        count++;
                }
            }

            return count >= 3;
        }

        // getRandom value end

        static void PrintArray(List<string> list1, List<string> list2, List<string> list3)
        {
            var max = list1.Count > list2.Count && list1.Count > list3.Count ? list1.Count
                : list2.Count > list1.Count && list2.Count > list3.Count ? list2.Count
                : list3.Count;

            var list1Length = 0;
            var list2Length = 0;
            var list3Length = 0;

            var list1Enter = max - list1.Count;
            var list2Enter = max - list2.Count;
            var list3Enter = max - list3.Count;

            for (int i = 0; i < max; i++)
            {
                if (list1Enter == 0)
                {
                    Console.Write(list1[list1Length] + "\t");
                    list1Length++;

                }

                else
                {
                    Console.Write(" " + "\t");
                    list1Enter--;
                }

                if (list2Enter == 0)
                {
                    Console.Write(list2[list2Length] + "\t");
                    list2Length++;

                }

                else
                {
                    Console.Write(" " + "\t");
                    list2Enter--;
                }


                if (list3Enter == 0)
                {
                    Console.Write(list3[list3Length] + "\t");
                    list3Length++;

                }

                else
                {
                    Console.Write(" " + "\t");
                    list3Enter--;
                }
                Console.WriteLine();
            }
        }

        static bool IsSame(List<string> array)
        {
            var result = false;
            for (int i = 0; i < array.Count - 1; i++)
            {
                if (!array[i].Equals(array[i + 1]))
                {
                    result = false;
                    break;
                }
                else
                {
                    result = true;
                }
            }

            return result;
        }

        static void Main(string[] args)
        {
            var inputs = GetRandomInputs();

            var array1 = inputs[0].ToList();
            var array2 = inputs[1].ToList();
            var array3 = inputs[2].ToList();

            PrintArray(array1, array2, array3);

            int tryValue = 1;

            do
            {
                Console.WriteLine($"\nTry {tryValue}\n");
                var input = Console.ReadLine().Split(' ');
                var input1 = Convert.ToInt32(input[0]);
                var input2 = Convert.ToInt32(input[1]);

                switch (input1)
                {
                    case 1:
                        switch (input2)
                        {
                            case 2:
                                array2.Insert(0, array1[0]);
                                array1.RemoveAt(0);
                                break;
                            case 3:
                                array3.Insert(0, array1[0]);
                                array1.RemoveAt(0);
                                break;
                        }
                        break;
                    case 2:
                        switch (input2)
                        {
                            case 1:
                                array1.Insert(0, array2[0]);
                                array2.RemoveAt(0);
                                break;
                            case 3:
                                array3.Insert(0, array2[0]);
                                array2.RemoveAt(0);
                                break;
                        }
                        break;
                    case 3:
                        switch (input2)
                        {
                            case 1:
                                array1.Insert(0, array3[0]);
                                array3.RemoveAt(0);
                                break;
                            case 2:
                                array2.Insert(0, array3[0]);
                                array3.RemoveAt(0);
                                break;
                        }
                        break;
                    default:
                        break;
                }

                PrintArray(array1, array2, array3);

                if (IsSame(array1) && IsSame(array2) && IsSame(array3))
                {
                    Console.WriteLine($"Congratualition! You are successfully done in {tryValue} try");
                    break;
                }

                tryValue++;

            } while (true);
        }

    }
}
