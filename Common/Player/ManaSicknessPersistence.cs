using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.ModLoader.IO;

namespace manaRecoveryMinigame.Common.Players
{
    //Keeps Mana Sickness even if player logout and enters the world
    public class ManaSicknessPersistence : ModPlayer
    {

        public override void SaveData(TagCompound tag)
        {
            if (Player.manaSick)
            {
                // Save whether the player has the Mana Sickness debuff
                tag["HasManaSickness"] = Player.HasBuff(BuffID.ManaSickness);
            }

        }

        public override void LoadData(TagCompound tag)
        {
            // Load the Mana Sickness debuff state
            if (tag.ContainsKey("HasManaSickness") && tag.Get<bool>("HasManaSickness"))
            {
                Player.AddBuff(BuffID.ManaSickness, 3600); // Reapply the debuff for 60 seconds
            }
        }
    }
}