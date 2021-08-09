namespace WarCroft.Core
{
    using System;
    using System.Linq;
    using System.Text;
    using System.Collections.Generic;

    using Entities.Characters.Contracts;
    using Entities.Items;
    using Entities.Characters;
    using Constants;

    public class WarController
    {
        private readonly List<Character> characters;
        private readonly List<Item> items;

        public WarController()
        {
            this.characters = new List<Character>();
            this.items = new List<Item>();
        }

        public string JoinParty(string[] args)
        {
            string characterType = args[0];
            string name = args[1];

            Character character = characterType switch
            {
                "Warrior" => new Warrior(name),
                "Priest" => new Priest(name),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidCharacterType, characterType)),
            };

            this.characters.Add(character);

            return string.Format(SuccessMessages.JoinParty, name);
        }

        public string AddItemToPool(string[] args)
        {
            string itemName = args[0];

            Item item = itemName switch
            {
                "FirePotion" => new FirePotion(),
                "HealthPotion" => new HealthPotion(),
                _ => throw new ArgumentException(string.Format(ExceptionMessages.InvalidItem, itemName)),
            };

            this.items.Add(item);

            return string.Format(SuccessMessages.AddItemToPool, itemName);
        }

        public string PickUpItem(string[] args)
        {
            string characterName = args[0];

            if (this.items.Count == 0)
            {
                throw new InvalidOperationException(ExceptionMessages.ItemPoolEmpty);
            }

            Character character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = this.items[^1];

            character.Bag.AddItem(item);

            this.items.RemoveAt(this.items.Count - 1);

            return string.Format(SuccessMessages.PickUpItem, characterName, item.GetType().Name);
        }

        public string UseItem(string[] args)
        {
            string characterName = args[0];
            string itemName = args[1];

            Character character = this.characters.FirstOrDefault(c => c.Name == characterName);

            if (character is null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, characterName));
            }

            Item item = character.Bag.GetItem(itemName);

            character.UseItem(item);

            return string.Format(SuccessMessages.UsedItem, characterName, itemName);
        }

        public string GetStats()
        {
            StringBuilder stats = new StringBuilder();

            foreach (var character in this.characters.OrderByDescending(c => c.IsAlive).ThenByDescending(c => c.Health))
            {
                string deadOrAlive = character.IsAlive ? "Alive" : "Dead";

                stats.AppendLine($"{character.Name} - " +
                    $"HP: {character.Health}/{character.BaseHealth}, " +
                    $"AP: {character.Armor}/{character.BaseArmor}, " +
                    $"Status: {deadOrAlive}");
            }

            return stats.ToString().Trim();
        }

        public string Attack(string[] args)
        {
            string attackerName = args[0];
            string receiverName = args[1];

            if (this.characters.All(c => c.Name != attackerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, attackerName));
            }

            if (this.characters.All(c => c.Name != receiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, receiverName));
            }

            //if character is NOT IAttacker
            if (this.characters
                .Where(c => c.GetType().Name == nameof(Warrior))
                .All(c => c.Name != attackerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.AttackFail, attackerName));
            }

            Warrior attacker = (Warrior)this.characters
                .Where(c => c.GetType().Name == nameof(Warrior))
                .First(c => c.Name == attackerName);

            Character receiver = this.characters.First(c => c.Name == receiverName);

            attacker.Attack(receiver);

            string result = $"{attackerName} attacks {receiverName} for {attacker.AbilityPoints} hit points! " +
                $"{receiverName} has {receiver.Health}/{receiver.BaseHealth} HP and " +
                $"{receiver.Armor}/{receiver.BaseArmor} AP left!";

            if (receiver.IsAlive == false)
            {
                result += Environment.NewLine + $"{receiver.Name} is dead!";
            }

            return result;
        }

        public string Heal(string[] args)
        {
            string healerName = args[0];
            string healingReceiverName = args[1];

            if (this.characters.All(c => c.Name != healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healerName));
            }

            if (this.characters.All(c => c.Name != healingReceiverName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.CharacterNotInParty, healingReceiverName));
            }

            //if character is NOT IHealer
            if (this.characters
                .Where(c => c.GetType().Name == nameof(Priest))
                .All(c => c.Name != healerName))
            {
                throw new ArgumentException(string.Format(ExceptionMessages.HealerCannotHeal, healerName));
            }

            Priest healer = (Priest)this.characters
                .Where(c => c.GetType().Name == nameof(Priest))
                .First(c => c.Name == healerName);

            Character receiver = this.characters.First(c => c.Name == healingReceiverName);

            healer.Heal(receiver);

            return $"{healer.Name} heals {receiver.Name} for {healer.AbilityPoints}! " +
                $"{receiver.Name} has {receiver.Health} health now!";
        }
    }
}
