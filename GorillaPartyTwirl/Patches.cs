using HarmonyLib;
using UnityEngine;

namespace GorillaPartyTwirl
{
    [HarmonyPatch]
    public class Patches
    {
        [HarmonyPatch(typeof(PartyHornTransferableObject), "LateUpdateShared"), HarmonyPrefix]
        public static void HornPrefix(PartyHornTransferableObject __instance, ref bool ___localWasActivated)
        {
            if (__instance.IsMyItem() && TransferrableObject.ItemStates.State1 == __instance.itemState && !___localWasActivated)
            {
                RefCache.PartyHorn = __instance;
                RefCache.Cooldown = __instance.cooldown / 2.5f;
                RefCache.Delta = 1f;
            }
        }
    }
}
