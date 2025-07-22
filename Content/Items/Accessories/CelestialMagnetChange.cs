using manaRecoveryMinigame.Common.Player;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ExampleMod.Content.Items.Accessories
{
    public class ExampleResourceAccessory : GlobalItem
    {

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            // Check if player has any mana magnet accessories
            if (player.manaMagnet)
            {
                var modPlayer = player.GetModPlayer<ManaMagnetChange>();
                modPlayer.overloadManaResourceMagnet = true; // Boosts pickup range for ExampleResourcePickup
                modPlayer.newManaResourceMagnet = true;
            }
        }
    }
}