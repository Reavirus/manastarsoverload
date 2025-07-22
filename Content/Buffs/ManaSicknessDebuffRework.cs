using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace manaRecoveryMinigame.Content.Buffs
{
    public class ManaSicknessDebuffRework : GlobalBuff
    {
        public override void Update(int type, Player player, ref int buffIndex)
        {
            // Check if the buff is Mana Sickness (BuffID 94)
            if (type == BuffID.ManaSickness)
            {
                // Set the cooldown duration for Mana Sickness
                Player.manaSickTime = 3600; // Current cooldown duration (60 seconds)
                Player.manaSickTimeMax = 3600; // Maximum cooldown duration (60 seconds)

                // Adjust mana sickness reduction damage
                Player.manaSickLessDmg = 0;
                player.manaSickReduction = 0;
            }
        }

        public override void ModifyBuffText(int type, ref string buffName, ref string tip, ref int rare)
        {
            if (type == BuffID.ManaSickness)
            {
                tip = "Cannot consume any more mana potions";
            }
        }
    }
}