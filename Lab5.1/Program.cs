using System;
using System.Collections.Generic;

namespace Lab5._1
{
    class GameCharacter
    {
        public GameCharacter (string name, int strength, int intelligence)
        {
            pCharName = name;
            pStrength = strength;
            pIntelligence = intelligence;
        }

        private string pCharName;
        private int pStrength;
        private int pIntelligence;

        public string CharName
        {
            get {return pCharName;}
            set {pCharName = value;}
        }
        public int  Strength
        {
            get {return pStrength;}
            set {pStrength = value;}
        }
        public int Intelligence
        {
            get {return pIntelligence;}
            set
            {pIntelligence = value;}
        }
        public virtual string Play()
        {
            return $"{CharName} (intelligence: {Intelligence}, strength: {Strength})";
        }
    }
    class Warrior : GameCharacter 
    {
        public Warrior (string name, int strength, int intelligence, string weaponType) : base (name, strength, intelligence)
        {
            WeaponType = weaponType;
        }
       private string WeaponType;

        public override string Play()
        {
            return $"{CharName} (intelligence: {Intelligence}, strength: {Strength}) {WeaponType}";
        }

    }

    class MagicUsingCharacter : GameCharacter
    {
        public MagicUsingCharacter (string name, int strength, int intelligence, int magicalEnergy) : base (name, strength, intelligence)
        {
            MagicalEnergy = magicalEnergy;
        }
        private int MagicalEnergy;

        public int magicalEnergy
        {
            get {return MagicalEnergy;}
            set {MagicalEnergy = value;}
        }

        public override string Play()
        {
            return $"{CharName} (intelligence: {Intelligence}, strength: {Strength} magic: {MagicalEnergy})";
        }

    }

    class Wizard : MagicUsingCharacter
    {
        public Wizard (string name, int strength, int intelligence, int magicalEnergy, int spellNumber) : base (name, strength, intelligence, magicalEnergy)
        {
            SpellNumber = spellNumber;
        }
       private int SpellNumber;

        public override string Play()
        {
            return $"{CharName} (intelligence: {Intelligence}, strength: {Strength} magic: {magicalEnergy}) {SpellNumber} spells";
        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            List<GameCharacter> gameCharacters = new List<GameCharacter>();
            Warrior Tnarg = new Warrior("Tnarg the Barbarian", 9, 16, "Axe");
            Warrior Kincaid = new Warrior("Kincaid the Fighter", 16, 15, "Longsword");
            Warrior Grant = new Warrior("Grant the Viking", 16, 15, "Spear");
            Wizard Lady = new Wizard("Lady Witherell the Wizard", 18, 11, 10, 5);
            Wizard Pearl = new Wizard("Pearl the Magician", 17, 12, 9, 4);
            gameCharacters.Add(Tnarg);
            gameCharacters.Add(Kincaid);
            gameCharacters.Add(Grant);
            gameCharacters.Add(Lady);
            gameCharacters.Add(Pearl);

            Console.WriteLine("Welcome to the World of Dev.Buildcraft!");

            foreach (GameCharacter character in gameCharacters)
            {
                Console.WriteLine(character.Play());
            }
        }
    }
}
