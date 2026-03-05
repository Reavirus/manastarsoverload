using System.ComponentModel;
using Terraria.ModLoader.Config;

namespace manaRecoveryMinigame
{
    public class ManaRecoveryConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        [Range(0, 100)]
        [DefaultValue(50)]
        public int ManaRestorePercentage { get; set; }

        [DefaultValue(true)]
        public bool EnableOverloadStars { get; set; }
    }
}