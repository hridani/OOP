using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheSlum.GameEngine
{
    using TheSlum.Characters;
    using TheSlum.Items;
  
    class CustomEngine:Engine
    {
        public CustomEngine()
            :base()
        {
        }
        
        protected override void ExecuteCommand(string[] inputParams)
        {
            switch (inputParams[0])
            {
                case "create":
                    CreateCharacter(inputParams);
                    break;
                case "add":
                    AddItem(inputParams);
                    break;
                default:
                    base.ExecuteCommand(inputParams);
                    break;
            }
        }

        protected override void CreateCharacter(string[] inputParams)
        {
            Character character;
            switch(inputParams[1].ToLower())
            {
                case "warrior":
                    character = new Warrior(
                        inputParams[2],
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        (Team)Enum.Parse(typeof(Team), inputParams[5]));
                        this.characterList.Add(character);
                    break;
                case "mage":
                    character = new Mage(
                        inputParams[2],
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        (Team)Enum.Parse(typeof(Team), inputParams[5]));
                        this.characterList.Add(character);
                    break;
                case "healer":
                    character = new Healer(
                        inputParams[2],
                        int.Parse(inputParams[3]),
                        int.Parse(inputParams[4]),
                        (Team)Enum.Parse(typeof(Team), inputParams[5]));
                        this.characterList.Add(character);
                    break;
                default:
                    break;
            }
        }
        
        protected new void AddItem(string[] inputParams)
        {
            Item item;
            switch (inputParams[2].ToLower())
            {
                case "axe":
                    item = new Axe(inputParams[3]);
                    this.GetCharacterById(inputParams[1]).AddToInventory(item);
                    break;
                case "shield":
                    item = new Shield(inputParams[3]);
                    this.GetCharacterById(inputParams[1]).AddToInventory(item);
                    break;
                case "injection":
                    item=new Injection(inputParams[3]);
                    this.GetCharacterById(inputParams[1]).AddToInventory(item);
                    break;
                case "pill":
                    item=new Pill(inputParams[3]);
                    this.GetCharacterById(inputParams[1]).AddToInventory(item);
                    break;
                default:
                    break;
            }
                    
        }
    }
}
