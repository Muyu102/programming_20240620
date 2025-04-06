using System;

namespace _20240620
{
    // 列舉: 寶可夢屬性
    public enum Property
    {
        Normal,
        Fire
    }

    // 列舉: 招式 - 根據期末考UML圖
    public enum Skill
    {
        噴射火焰,
        捨身衝撞,
        火焰牙,
        閃焰衝鋒
    }

    // 抽象類別: 寶可夢
    public abstract class Pokemon
    {
        private static Random rnd = new Random();

        // 根據UML定義的屬性 (# 代表 protected)
        public string Name { get; protected set; }
        public Property Property { get; protected set; }
        public int Health { get; protected set; }
        public Skill Skill { get; protected set; }
        public double Power { get; protected set; }

        // 預設建構子
        public Pokemon()
        {
            Health = rnd.Next(0, 101); // 隨機血量 (0-100)
            Name = "未知寶可夢";
            Property = Property.Normal;
            Skill = Skill.捨身衝撞;
            Power = rnd.Next(10, 51);  // 隨機威力 (10-50)
        }

        // 帶有名稱的建構子
        public Pokemon(string name)
        {
            this.Name = name;
            Health = rnd.Next(0, 101); // 隨機血量 (0-100)
        }

        // 抽象方法：猜猜我是誰？
        public abstract string GuessWhoAmI();

        // 虛擬方法：攻擊
        public virtual string Attack()
        {
            // 基礎攻擊使用指定的 Skill 屬性
            string attackMessage = $"{Name} 使用了 {Skill}!";
            Console.WriteLine(attackMessage);
            Console.WriteLine($"我的血量剩餘: {Health}");
            return attackMessage;
        }
    }

    // 介面: 一般屬性介面
    public interface INormalType
    {
        string GuessWhoAmI();
    }

    // 介面: 火屬性介面
    public interface IFireType : INormalType
    {
        string Attack();
    }

    // 類別: 小火龍
    public class Charmander : Pokemon, IFireType
    {
        public Charmander() : base("小火龍")
        {
            Property = Property.Fire;
            Skill = Skill.火焰牙;
            Power = 52;
        }

        public Charmander(string name) : base(name)
        {
            Property = Property.Fire;
            Skill = Skill.火焰牙;
            Power = 52;
        }

        // 覆寫抽象方法
        public override string GuessWhoAmI()
        {
            return $"我是火屬性的 {Name}! HP: {Health}, Power: {Power}, Main Skill: {Skill}";
        }

        // 覆寫基礎 Attack 方法，滿足 IFireType 介面要求
        public override string Attack()
        {
            string attackMessage = $"{Name} 用 {Skill} 攻擊!";
            Console.WriteLine(attackMessage);
            Console.WriteLine($"HP 剩餘: {Health}");
            return attackMessage;
        }
    }

    // 類別: 伊布
    public class Eevee : Pokemon, INormalType
    {
        public Eevee() : base("伊布")
        {
            Property = Property.Normal;
            Skill = Skill.捨身衝撞;
            Power = 55;
        }

        public Eevee(string name) : base(name)
        {
            Property = Property.Normal;
            Skill = Skill.捨身衝撞;
            Power = 55;
        }

        // 實作 INormalType 介面要求
        public override string GuessWhoAmI()
        {
            return $"我是普通屬性的 {Name}! HP: {Health}, Power: {Power}, Main Skill: {Skill}";
        }

        // 除非被覆寫，否則使用 Pokemon 基礎的 Attack() 方法
    }

    // 類別: 火伊布
    public class Flareon : Eevee, IFireType // 繼承自 Eevee，同時需要滿足 IFireType 介面
    {
        public Flareon() : base("火伊布") // 呼叫 Eevee 的建構子
        {
            Property = Property.Fire;
            Skill = Skill.閃焰衝鋒;
            Power = 130;
        }

        public Flareon(string name) : base(name) // 呼叫 Eevee 的建構子
        {
            Property = Property.Fire;
            Skill = Skill.閃焰衝鋒;
            Power = 130;
        }

        // 覆寫 Eevee 的 GuessWhoAmI
        public override string GuessWhoAmI()
        {
            return $"我是從伊布進化來的火屬性 {Name}! HP: {Health}, Power: {Power}, Main Skill: {Skill}";
        }

        // 覆寫基礎 Attack 方法
        public override string Attack()
        {
            string attackMessage = $"{Name} 使出破壞力驚人的 {Skill}!";
            // 閃焰衝鋒的反作用力傷害
            int recoil = (int)(Power * 0.1); // 根據 Power 計算反作用力傷害
            Health = Math.Max(0, Health - recoil); // 套用反作用力傷害，確保血量不低於 0

            Console.WriteLine(attackMessage);
            Console.WriteLine($"承受反作用力傷害! HP 剩餘: {Health}");
            return attackMessage;
        }
    }

    // 類別: 火恐龍
    public class Charmeleon : Charmander // 繼承自 Charmander
    {
        public Charmeleon() : base("火恐龍") // 呼叫 Charmander 的建構子
        {
            Skill = Skill.噴射火焰;
            Power = 80;
        }

        public Charmeleon(string name) : base(name) // 呼叫 Charmander 的建構子
        {
            Skill = Skill.噴射火焰;
            Power = 80;
        }

        // 覆寫 Charmander 的 GuessWhoAmI
        public override string GuessWhoAmI()
        {
            return $"我是進化後的火屬性 {Name}! HP: {Health}, Power: {Power}, Main Skill: {Skill}";
        }

        // 覆寫 Charmander 的 Attack
        public override string Attack()
        {
            string attackMessage = $"{Name} 猛烈地噴出 {Skill}!";
            Console.WriteLine(attackMessage);
            Console.WriteLine($"HP 剩餘: {Health}");
            return attackMessage;
        }
    }
}