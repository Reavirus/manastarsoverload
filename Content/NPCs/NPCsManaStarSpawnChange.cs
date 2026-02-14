using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using manaRecoveryMinigame.Content.Items.Miscellaneous;

namespace manaRecoveryMinigame.Content.NPCs
{
    public class NPCDropResourcePickup : GlobalNPC
    {

        public override void OnHitByItem(NPC npc, Player player, Item item, NPC.HitInfo hit, int damageDone)
        {
            // Skip if the NPC is a Target Dummy
            if (npc.type == NPCID.TargetDummy)
                return;

            float dropChanceManaStar = 0.1f;
            float dropChanceOverloadStar = 0.01f;

            // Get the weapon that shot the projectile
            Item sourceItem = player.inventory[player.selectedItem];

            // Make it so weapons that are average useTime or slower have 15% chance of spawning mana stars and 2% of overload stars
            if (sourceItem.useTime >= 26)
            {
                dropChanceOverloadStar = 0.02f;
                dropChanceManaStar = 0.15f;
            }

            if (item.DamageType == DamageClass.Magic && Main.rand.NextFloat() < dropChanceManaStar)
            {
                // Random position within a radius around the enemy
                Vector2 randomPosition = npc.Center + new Vector2(
                    Main.rand.NextFloat(-30f, 30f),
                    Main.rand.NextFloat(-30f, 30f)
                );

                // Spawn the Overload Mana Star pickup
                Item.NewItem(npc.GetSource_OnHit(player), randomPosition, ModContent.ItemType<NewManaStarResourcePickup>());
            }

            if (item.DamageType == DamageClass.Magic && Main.rand.NextFloat() < dropChanceOverloadStar)
            {
                // Random position within a radius around the enemy
                Vector2 randomPosition = npc.Center + new Vector2(
                    Main.rand.NextFloat(-30f, 30f),
                    Main.rand.NextFloat(-30f, 30f)
                );

                // Spawn the Overload Mana Star pickup
                Item.NewItem(npc.GetSource_OnHit(player), randomPosition, ModContent.ItemType<OverloadManaStarResourcePickup>());
            }
        }

        public override void OnHitByProjectile(NPC npc, Projectile projectile, NPC.HitInfo hit, int damageDone)
        {
            // Skip if the NPC is a Target Dummy
            if (npc.type == NPCID.TargetDummy)
                return;

            float dropChanceManaStar = 0.1f;
            float dropChanceOverloadStar = 0.01f;

            // Get the player who owns the projectile
            Player player = Main.player[projectile.owner];

            //Get the weapon that shot the projectile
            Item sourceItem = player.inventory[player.selectedItem];

            // Make it so weapons that are fast or slower have 15% chance of spawning mana stars and 2% of overload stars
            if (sourceItem.useTime >= 26)
            {
                dropChanceOverloadStar = 0.02f;
                dropChanceManaStar = 0.15f;
            }

            if (projectile.DamageType == DamageClass.Magic && Main.rand.NextFloat() < dropChanceManaStar)
            {
                // Random position within a radius around the enemy
                Vector2 randomPosition = npc.Center + new Vector2(
                    Main.rand.NextFloat(-30f, 30f),
                    Main.rand.NextFloat(-30f, 30f)
                );

                // Spawn the Overload Mana Star pickup
                Item.NewItem(npc.GetSource_OnHit(projectile), randomPosition, ModContent.ItemType<NewManaStarResourcePickup>());
            }

            if (projectile.DamageType == DamageClass.Magic && Main.rand.NextFloat() < dropChanceOverloadStar
            )
            {
                // Random position within a radius around the enemy
                Vector2 randomPosition = npc.Center + new Vector2(
                    Main.rand.NextFloat(-30f, 30f),
                    Main.rand.NextFloat(-30f, 30f)
                );

                // Spawn the Overload Mana Star pickup
                Item.NewItem(npc.GetSource_OnHit(projectile), randomPosition, ModContent.ItemType<OverloadManaStarResourcePickup>());
            }
        }
    }
}