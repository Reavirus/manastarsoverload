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
            BuffID.Sets.NurseCannotRemoveDebuff = BuffID.Sets.Factory.CreateBoolSet(
                28, 34, 87, 89, 21, 86, 199, 332, 333, 334, 165, 146, 48, 158, 157, 350, 215, 147, 94
            );
            // Prevent usage if the player has the Mana Sickness debuff
            if ((item.type == ItemID.ManaPotion || item.type == ItemID.LesserManaPotion || item.type == ItemID.GreaterManaPotion || item.type == ItemID.SuperManaPotion)
                && player.HasBuff(BuffID.ManaSickness))
            {
                return false;
            }
            return base.CanUseItem(item, player);
        }

        public override bool ConsumeItem(Item item, Player player)
        {
            BuffID.Sets.NurseCannotRemoveDebuff = BuffID.Sets.Factory.CreateBoolSet(
                28, 34, 87, 89, 21, 86, 199, 332, 333, 334, 165, 146, 48, 158, 157, 350, 215, 147, 94
            );
            // Apply buffs and temporarily set healMana to 0 when potion is consumed
            if (item.type == ItemID.ManaPotion || item.type == ItemID.LesserManaPotion || item.type == ItemID.GreaterManaPotion || item.type == ItemID.SuperManaPotion)
            {
                int originalHealMana = item.healMana;
                item.healMana = 0;

                player.AddBuff(BuffID.ManaSickness, 3600, true, false);
                if (item.type == ItemID.ManaPotion)
                    player.AddBuff(ModContent.BuffType<ManaOverloadBuff>(), 450, true, false);
                else if (item.type == ItemID.LesserManaPotion)
                    player.AddBuff(ModContent.BuffType<ManaOverloadBuff>(), 330, true, false);
                else if (item.type == ItemID.GreaterManaPotion)
                    player.AddBuff(ModContent.BuffType<ManaOverloadBuff>(), 630, true, false);
                else if (item.type == ItemID.SuperManaPotion)
                    player.AddBuff(ModContent.BuffType<ManaOverloadBuff>(), 930, true, false);
                // Resets healMana value after the mana potion is consumed
                item.healMana = originalHealMana;
            }
            return base.ConsumeItem(item, player);
        }
    }
}