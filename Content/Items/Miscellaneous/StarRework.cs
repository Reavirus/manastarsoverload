using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;

namespace manaRecoveryMinigame.Content.Items
{
    //Mana Star Rework
    public class StarRework : GlobalItem
    {
        public override bool InstancePerEntity => true;

        //Removes Mana Stars Vanilla

        public override void OnSpawn(Item item, IEntitySource source)
        {
            if (item.type == ItemID.Star || item.type == ItemID.SoulCake || item.type == ItemID.SugarPlum)
            {
                item.TurnToAir();
            }
        }

        //tried changing the vanilla star, but was having problems, decided to make a new one that looks the same but that works as I want along with the overload star

        // float code, reuse to newstar
        /*
        public override void Update(Item item, ref float gravity, ref float maxFallSpeed)
        {
            if (item.type == ItemID.Star || item.type == ItemID.SoulCake || item.type == ItemID.SugarPlum)
            {
                gravity = 0f; // No gravity
                item.velocity.Y = (float)System.Math.Sin(Main.GameUpdateCount / 30f + item.position.X) * 0.3f; // up/down float
                item.velocity.X *= 0.98f; // Slow horizontal drift
            }
        }
        */
    }
}
