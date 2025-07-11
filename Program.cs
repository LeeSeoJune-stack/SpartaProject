
namespace BeginnerRPG
    {
        class Program
        {
            static int gold = 800;
            static List<string> inventory = new List<string> { "무쇠갑옷", "스파르타의 창" };
            static List<string> equipped = new List<string> { "무쇠갑옷", "스파르타의 창" };

            static List<string> shopItems = new List<string>
        {
            "수련자 갑옷",
            "무쇠갑옷",
            "스파르타의 갑옷",
            "낡은 검",
            "청동 도끼",
            "스파르타의 창"
        };

            static List<string> shopDescriptions = new List<string>
        {
            "수련에 도움을 주는 갑옷입니다.",
            "무쇠로 만들어져 튼튼한 갑옷입니다.",
            "스파르타의 전사들이 사용했다는 전설의 갑옷입니다.",
            "쉽게 볼 수 있는 낡은 검 입니다.",
            "어디선가 사용됐던거 같은 도끼입니다.",
            "스파르타의 전사들이 사용했다는 전설의 창입니다."
        };

            static List<string> shopEffects = new List<string>
        {
            "방어력 +5",
            "방어력 +9",
            "방어력 +15",
            "공격력 +2",
            "공격력 +5",
            "공격력 +7"
        };

            static List<int> prices = new List<int> { 1000, 1200, 3500, 600, 1500, 2000 };
            static List<bool> purchased = new List<bool> { false, true, false, false, false, true };

            static void Main(string[] args)
            {
                string input = "";

                while (input != "exit")
                {
                    Console.Clear();
                    Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
                    Console.WriteLine("이곳에서 던전으로 들어가기 전 활동을 할 수 있습니다.");
                    Console.WriteLine();
                    Console.WriteLine("1. 상태 보기");
                    Console.WriteLine("2. 인벤토리");
                    Console.WriteLine("3. 상점");
                    Console.Write("원하시는 행동을 입력해주세요.\n>> ");
                    input = Console.ReadLine();

                    if (input == "1")
                    {
                        Status();
                    }
                    else if (input == "2")
                    {
                        InventoryMenu();
                    }
                    else if (input == "3")
                    {
                        Shop();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadLine();
                    }
                }
            }

            static void Status()
            {
                Console.Clear();
                Console.WriteLine("상태 보기");
                Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
                Console.WriteLine("Lv. 01");
                Console.WriteLine("Chad ( 전사 )");
                Console.WriteLine("공격력 : 10");
                Console.WriteLine("방어력 : 5");
                Console.WriteLine("체 력 : 100");
                Console.WriteLine("Gold : " + gold + " G");
                Console.WriteLine("\n0. 나가기");
                Console.Write(">> ");
                Console.ReadLine();
            }

            static void InventoryMenu()
            {
                Console.Clear();
                Console.WriteLine("인벤토리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("\n[아이템 목록]");

                if (inventory.Count == 0)
                {
                    Console.WriteLine("(아이템이 없습니다)");
                    Console.WriteLine("\n0. 나가기");
                    Console.Write(">> ");
                    Console.ReadLine();
                    return;
                }

                for (int i = 0; i < inventory.Count; i++)
                {
                    string mark = equipped.Contains(inventory[i]) ? "[E]" : "";
                    Console.WriteLine($"- {mark}{inventory[i]}");
                }

                Console.WriteLine("\n1. 장착 관리");
                Console.WriteLine("2. 나가기");
                Console.Write(">> ");
                string input = Console.ReadLine();

                if (input == "1") EquipManage();
            }

            static void EquipManage()
            {
                Console.Clear();
                Console.WriteLine("인벤토리 - 장착 관리");
                Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.");
                Console.WriteLine("\n[아이템 목록]");
                for (int i = 0; i < inventory.Count; i++)
                {
                    string mark = equipped.Contains(inventory[i]) ? "[E]" : "";
                    Console.WriteLine($"- {i + 1} {mark}{inventory[i]}");
                }

                Console.WriteLine("\n0. 나가기");
                Console.Write(">> ");
                string input = Console.ReadLine();
                int idx;

                if (int.TryParse(input, out idx))
                {
                    if (idx == 0) return;
                    if (idx >= 1 && idx <= inventory.Count)
                    {
                        string item = inventory[idx - 1];
                        if (equipped.Contains(item))
                        {
                            equipped.Remove(item);
                            Console.WriteLine($"'{item}' 장착 해제됨");
                        }
                        else
                        {
                            equipped.Add(item);
                            Console.WriteLine($"'{item}' 장착함");
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                }

                Console.WriteLine("\n엔터를 누르세요...");
                Console.ReadLine();
            }

            static void Shop()
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine("상점");
                    Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                    Console.WriteLine("\n[보유 골드]");
                    Console.WriteLine(gold + " G");

                    Console.WriteLine("\n[아이템 목록]");
                    for (int i = 0; i < shopItems.Count; i++)
                    {
                        string price = purchased[i] ? "구매완료" : prices[i] + " G";
                        Console.WriteLine($"- {shopItems[i],-12} | {shopEffects[i],-10} | {shopDescriptions[i],-35} | {price}");
                    }

                    Console.WriteLine("\n1. 아이템 구매");
                    Console.WriteLine("0. 나가기");
                    Console.Write(">> ");
                    string input = Console.ReadLine();

                    if (input == "0") break;
                    else if (input == "1")
                    {
                        Console.Clear();
                        Console.WriteLine("[아이템 구매]");
                        for (int i = 0; i < shopItems.Count; i++)
                        {
                            string state = purchased[i] ? "구매완료" : prices[i] + " G";
                            Console.WriteLine($"{i + 1}. {shopItems[i]} | {shopEffects[i]} | {state}");
                        }

                        Console.WriteLine("0. 취소");
                        Console.Write(">> ");
                        string buyInput = Console.ReadLine();
                        int buyIndex;

                        if (int.TryParse(buyInput, out buyIndex))
                        {
                            if (buyIndex == 0) continue;
                            if (buyIndex >= 1 && buyIndex <= shopItems.Count)
                            {
                                int idx = buyIndex - 1;
                                if (purchased[idx])
                                {
                                    Console.WriteLine("이미 구매한 아이템입니다.");
                                }
                                else if (gold < prices[idx])
                                {
                                    Console.WriteLine("골드가 부족합니다.");
                                }
                                else
                                {
                                    gold -= prices[idx];
                                    purchased[idx] = true;
                                    inventory.Add(shopItems[idx]);
                                    Console.WriteLine($"'{shopItems[idx]}' 구매 완료!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("잘못된 입력입니다.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                        }

                        Console.WriteLine("엔터를 누르세요...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                        Console.ReadLine();
                    }
                }
            }
        }
    }

