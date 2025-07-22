using manaRecoveryMinigame.Content.Buffs;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace manaRecoveryMinigame.Content.Items
{
    public class ManaPotionsRework : GlobalItem
    {
        public override bool CanUseItem(Item item, Player player)
        {
            // Locks Nurse from healing Mana Sickness (BUFFID 94) by adding to the Set list
            BuffID.Sets.NurseCannotRemoveDebuff = BuffID.Sets.Factory.CreateBoolSet(28, 34, 87, 89, 21, 86, 199, 332, 333, 334, 165, 146, 48, 158, 157, 350, 215, 147, 94);
            // Check if the item is a mana potion
            if (item.type == ItemID.ManaPotion || item.type == ItemID.LesserManaPotion || item.type == ItemID.GreaterManaPotion || item.type == ItemID.SuperManaPotion)
            {
                // Prevent usage if the player has the Mana Sickness debuff
                if (player.HasBuff(BuffID.ManaSickness))
                {
                    return false; // Block the use of mana potions
                }
                else
                {
                    player.AddBuff(BuffID.ManaSickness, 3600, true, false);
                    item.healMana = 0;
                    if (item.type == ItemID.ManaPotion)
                    {
                        player.AddBuff(ModContent.BuffType<ManaOverloadBuff>(), 450, true, false);
                    }
                    else if (item.type == ItemID.LesserManaPotion)
                    {
                        player.AddBuff(ModContent.BuffType<ManaOverloadBuff>(), 330, true, false);
                    }
                    else if (item.type == ItemID.GreaterManaPotion)
                    {
                        player.AddBuff(ModContent.BuffType<ManaOverloadBuff>(), 630, true, false);
                    }
                    else if (item.type == ItemID.SuperManaPotion)
                    {
                        player.AddBuff(ModContent.BuffType<ManaOverloadBuff>(), 930, true, false);
                    }
                }
            }


            return base.CanUseItem(item, player); // Allow other items to be used
        }
    }
}