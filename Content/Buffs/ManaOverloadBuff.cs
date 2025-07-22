using Terraria;
using Terraria.ModLoader;

namespace manaRecoveryMinigame.Content.Buffs
{
    public class ManaOverloadBuff : ModBuff
    {
        public override void Update(Player player, ref int buffIndex)
        {
            player.manaCost = 0f;
        }
    }
}