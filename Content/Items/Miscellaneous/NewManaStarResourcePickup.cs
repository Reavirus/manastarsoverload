using System;
using manaRecoveryMinigame.Common.Player;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace manaRecoveryMinigame.Content.Items.Miscellaneous
{

	// Most comments below are from the Tmodloader example mod code
	// This class showcases a "pickup". Also known as a power-up.
	// Pickup refers to items that don't enter then inventory when picked up, but rather have some other effect when obtained.
	// Pickups usually provide resources to the player, such as hearts providing life or stars providing mana. Nebula armor boosters are another example.
	// This example drops from enemies when Example Resource is low, similar to how hearts and stars only drop if the player is lacking health or mana.
	// See ExampleResourcePickupGlobalNPC for the item drop code.
	public class NewManaStarResourcePickup : ModItem
	{

		public override void SetStaticDefaults()
		{
			ItemID.Sets.ItemsThatShouldNotBeInInventory[Type] = true;
			ItemID.Sets.IgnoresEncumberingStone[Type] = true;
			ItemID.Sets.IsAPickup[Type] = true;
			ItemID.Sets.ItemSpawnDecaySpeed[Type] = 0;

			ItemID.Sets.ItemIconPulse[Type] = true;
			ItemID.Sets.ItemNoGravity[Type] = true;
		}

		public override void SetDefaults()
		{
			Item.height = 12;
			Item.width = 12;

		}

		public override void Update(ref float gravity, ref float maxFallSpeed)
		{
			gravity = 0f;
			Item.velocity.Y = (float)System.Math.Sin(Main.GameUpdateCount / 30f + Item.position.X) * 0.3f; // up/down float
			Item.velocity.X *= 0.98f; // Slow horizontal drift

			//supposed to make the item disappear after 30 seconds, but doesn't work smh
			if (Item.timeSinceItemSpawned > 60 * 30)
			{
				Item.TurnToAir();
			}
		}

		public override bool OnPickup(Player player)
		{
			// Calculate 50% of max mana
			int healAmount = (int)(player.statManaMax2 * 0.5f);

			// Heal the player's mana
			player.statMana = Math.Min(player.statMana + healAmount, player.statManaMax2);

			// Show mana restoration text
			if (healAmount > 0)
			{
				CombatText.NewText(player.getRect(), CombatText.HealMana, healAmount);
			}

			// play pickup music, change to something else later
			SoundEngine.PlaySound(SoundID.Grab, player.Center);

			// return false so item does not go to player inventory
			return false;
		}

		// Since ItemID.Sets.IsAPickup is true, we don't need to override the ItemSpace hook to allow picking up the item when inventory is full

		// We can override CanPickup to prevent attempting to pick up this item when at max ExampleResource, but hearts and stars do not do this so we won't either.

		// GrabRange can be used to implement effects similar to Heartreach potion or Celestial Magnet.
		public override void GrabRange(Player player, ref int grabRange)
		{
			if (player.GetModPlayer<ManaMagnetChange>().newManaResourceMagnet)
			{
				grabRange += ManaMagnetChange.newManaResourceMagnetGrabRange;
			}

		}
	}
}
