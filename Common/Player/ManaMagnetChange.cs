using Terraria.ModLoader;

namespace manaRecoveryMinigame.Common.Player
{

    public class ManaMagnetChange : ModPlayer
    {
        public bool overloadManaResourceMagnet = false;
        public static readonly int overloadManaResourceMagnetGrabRange = 300;
        public bool newManaResourceMagnet = false;
        public static readonly int newManaResourceMagnetGrabRange = 300;

        public override void ResetEffects()
        {
            ResetVariables();
        }

        public override void UpdateDead()
        {
            ResetVariables();
        }

        private void ResetVariables()
        {
            newManaResourceMagnet = false;
            overloadManaResourceMagnet = false;
        }
    }
}