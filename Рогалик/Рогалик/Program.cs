using System;

namespace Рогалик
{
    internal class Program
    {
        static void Main(string[] args)
        {
            static int CalculateRandom(int[] array)
            {
                Random random = new Random();
                int randomValue = random.Next(array[0], array[1] + 1);
                return randomValue;
            }

            static int Randomizer(int maxNumber)
            {
                if (maxNumber > 0)
                {
                    Random random = new Random();
                    int randomNumber = random.Next(1, maxNumber + 1);
                    return randomNumber;
                }
                else
                {
                    Console.WriteLine("Ошибка: Введите положительное число.");
                    return -1;
                }
            }

            static string StringRandomizer(string[] array)
            {
                if (array != null && array.Length > 0)
                {
                    Random random = new Random();
                    int randomIndex = random.Next(array.Length);
                    return array[randomIndex];
                }
                else
                {
                    Console.WriteLine("Ошибка: Передан пустой массив строк или null.");
                    return null;
                }
            }

            Console.WriteLine("Добро пожаловать, воин!\r\n" +
                              "Назови себя:");

            string name = Console.ReadLine();
            int hp = 200;
            string wp = "Начальное оружие";
            string[] ap = { };
            int dwp = 10;
            int kolz = 0; // Количество золота
            int killedEnemies = 0; // Количество поверженных врагов

            Console.WriteLine("Привет, " + name + "!");

            string[] weapons = { "Кинжал", "Простой стальной меч", "Фламберг" };
            int[] w0 = { 15, 30 };
            int[] w1 = { 20, 35 };
            int[] w2 = { 25, 40 };

            string asm = "малая";
            string am = "средняя";
            string ab = "большая";

            int[] rasm = { 20, 40 };
            int[] ram = { 40, 60 };
            int[] rab = { 60, 80 };

            string[] enemies = { "Слизень", "Скелет", "Зомби", "Огр", "Мумия" };
            int[] he0 = { 20, 50 };
            int[] he1 = { 30, 60 };
            int[] he2 = { 40, 70 };
            int[] he3 = { 50, 80 };
            int[] he4 = { 60, 90 };

            int kono = 0;
            int vyb = 0;
            int kolk = 0;

            while (kono != 1)
            {
                int tvk = Randomizer(3);

                Console.WriteLine(name + " вошёл в комнату.");

                if (tvk == 1) // Комната с противником
                {
                    kolk++; // Увеличиваем количество пройденных комнат
                    string tve = StringRandomizer(enemies);
                    string we = StringRandomizer(weapons);
                    int he = 0;
                    int dwe = 0;

                    if (tve == "Слизень")
                        he = CalculateRandom(he0);
                    else if (tve == "Скелет")
                        he = CalculateRandom(he1);
                    else if (tve == "Зомби")
                        he = CalculateRandom(he2);
                    else if (tve == "Огр")
                        he = CalculateRandom(he3);
                    else if (tve == "Мумия")
                        he = CalculateRandom(he4);

                    Console.WriteLine("В комнате оказался противник. Вашим врагом оказался " + tve);

                    int konv = 0;

                    while (konv != 1)
                    {
                        Console.WriteLine("Ваши действия:\r\n" +
                                          "1 - атаковать\r\n" +
                                          "2 - применить аптечку");

                        vyb = Convert.ToInt32(Console.ReadLine());

                        if (vyb == 1)
                        {
                            if (wp == "Начальное оружие")
                                dwp = 10;
                            else if (wp == "Кинжал")
                                dwp = CalculateRandom(w0);
                            else if (wp == "Простой стальной меч")
                                dwp = CalculateRandom(w1);
                            else if (wp == "Фламберг")
                                dwp = CalculateRandom(w2);

                            if (we == "Кинжал")
                                dwe = CalculateRandom(w0);
                            else if (we == "Простой стальной меч")
                                dwe = CalculateRandom(w1);
                            else if (we == "Фламберг")
                                dwe = CalculateRandom(w2);

                            he -= dwp;
                            hp -= dwe;

                            Console.WriteLine(name + " нанёс " + dwp + " единиц урона " + tve + ".\r\n" +
                                              "У " + tve + " осталось " + he + " единиц здоровья.\r\n" +
                                              tve + " нанёс " + dwe + " единиц урона " + name + ".\r\n" +
                                              "У " + name + " осталось " + hp + " единиц здоровья.");

                            if (he <= 0)
                            {
                                Console.WriteLine(tve + " повержен.");
                                konv = 1;
                                killedEnemies++; // Увеличиваем количество поверженных врагов
                            }

                            if (hp <= 0)
                            {
                                Console.WriteLine(name + " повержен.\r\n" +
                                                  "Игра окончена.\r\n" +
                                                  "Результаты забега:\r\n" +
                                                  "Количество пройденных комнат: " + kolk + "\r\n" +
                                                  "Количество золота: " + kolz + "\r\n" +
                                                  "Количество поверженных врагов: " + killedEnemies);
                                konv = 1;
                                kono = 1;
                            }
                        }
                        else if (vyb == 2)
                        {
                            int healing = 0;
                            if (ap.Length > 0)
                            {
                                string apt = StringRandomizer(ap);
                                if (apt == asm)
                                    healing = CalculateRandom(rasm);
                                else if (apt == am)
                                    healing = CalculateRandom(ram);
                                else if (apt == ab)
                                    healing = CalculateRandom(rab);

                                if (healing != 0)
                                {
                                    hp += healing;
                                    Console.WriteLine(name + " восстановил " + healing + " единиц здоровья.");

                                    // Удаляем использованную аптечку из массива
                                    for (int i = 0; i < ap.Length; i++)
                                    {
                                        if (ap[i] == apt)
                                        {
                                            ap[i] = ap[ap.Length - 1];
                                            Array.Resize(ref ap, ap.Length - 1);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                Console.WriteLine("У " + name + " нет аптечек.");
                            }
                        }
                    }
                }
                else if (tvk == 2) // Комната с золотом
                {
                    kolk++; // Увеличиваем количество пройденных комнат
                    Console.WriteLine("Вы нашли золото!");
                    int gold = CalculateRandom(new int[] { 50, 100 });
                    kolz += gold; // Увеличиваем количество золота
                    Console.WriteLine(name + " получил " + gold + " золота.");
                }
                else if (tvk == 3) // Комната с сундуком
                {
                    kolk++; // Увеличиваем количество пройденных комнат
                    Console.WriteLine("Вы нашли сундук!");
                    int rewardType = Randomizer(100); // Шанс 75%
                    if (rewardType <= 75)
                    {
                        string apt = StringRandomizer(new string[] { asm, am, ab });
                        Array.Resize(ref ap, ap.Length + 1);
                        ap[ap.Length - 1] = apt;
                        Console.WriteLine(name + " нашёл аптечку: " + apt);
                    }
                    else
                    {
                        string we = StringRandomizer(weapons);
                        Console.WriteLine(name + " получил новое оружие: " + we);
                        wp = we;
                    }
                }
            }
        }
    }
}

