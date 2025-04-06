using System;
using System.Collections.Generic;
using _20240620;

namespace _20240620
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 確保主控台能正確顯示中文字元
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("--- 創建寶可夢 ---");

            // 創建每個寶可夢的實例
            Charmander charmander = new Charmander();
            Eevee eevee = new Eevee();
            Flareon flareon = new Flareon("閃亮亮火伊布");
            Charmeleon charmeleon = new Charmeleon();

            // 將它們儲存在 List 中
            List<Pokemon> myPokemon = new List<Pokemon>
            {
                charmander,
                eevee,
                flareon,
                charmeleon
            };

            Console.WriteLine("\n--- 介紹我的寶可夢 ---");
            foreach (Pokemon p in myPokemon)
            {
                Console.WriteLine(p.GuessWhoAmI());
            }

            Console.WriteLine("\n--- 進行攻擊測試 ---");

            // 針對火系寶可夢進行攻擊測試
            Console.WriteLine("\n小火龍攻擊:");
            charmander.Attack();

            Console.WriteLine("\n伊布攻擊 (使用基礎攻擊):");
            eevee.Attack(); // 使用 Pokemon 基礎的 Attack 方法

            Console.WriteLine("\n火伊布攻擊:");
            flareon.Attack();

            Console.WriteLine("\n火恐龍攻擊:");
            charmeleon.Attack();


            Console.WriteLine("\n--- 使用介面進行攻擊 ---");
            // 示範使用 IFireType 介面
            foreach (Pokemon p in myPokemon)
            {
                // 檢查寶可夢是否實作了 IFireType 介面
                if (p is IFireType firePokemon) // 使用模式匹配
                {
                    Console.WriteLine($"\n{p.Name} (火系) 準備攻擊:");
                    firePokemon.Attack(); // 透過介面參考呼叫 Attack 方法
                }
                else
                {
                    Console.WriteLine($"\n{p.Name} 不是火系攻擊手 (或未實作IFireType攻擊)。");
                    // (選擇性) 呼叫基礎攻擊
                    // p.Attack();
                }
            }


            Console.WriteLine("\n\n測試結束，按 Enter 鍵退出。");
            Console.ReadLine();
        }
    }
}