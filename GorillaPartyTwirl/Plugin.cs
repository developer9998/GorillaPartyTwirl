using BepInEx;
using HarmonyLib;
using UnityEngine;
using static GorillaLocomotion.Player;

namespace GorillaPartyTwirl
{
    [BepInPlugin(Constants.Guid, Constants.Name, Constants.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public Plugin()
        {
            new Harmony(Constants.Guid).PatchAll(typeof(Plugin).Assembly);
        }

        public void Update()
        {
            if (RefCache.PartyHorn)
            {
                float difference = Time.deltaTime / RefCache.Cooldown;
                Instance.Turn(difference * 360f);

                RefCache.Delta -= difference;
                if (RefCache.Delta < 0) RefCache.PartyHorn = null;
            }
        }
    }
}
