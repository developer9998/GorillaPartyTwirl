using HarmonyLib;
using UnityEngine;
using static GorillaLocomotion.Player;

namespace GorillaPartyTwirl
{
    [HarmonyPatch]
    public class Patches
    {
        [HarmonyPatch(typeof(PartyHornTransferableObject), "LateUpdateShared"), HarmonyPrefix]
        public static void HornPrefix(PartyHornTransferableObject __instance, ref bool ___localWasActivated)
        {
            bool isValid = TransferrableObject.ItemStates.State1 == __instance.itemState && !___localWasActivated;
            bool isReasonable = __instance.IsMyItem() || Vector3.Distance(__instance.transform.position, Instance.bodyCollider.transform.position) < 1.8f;
            if (isValid && isReasonable)
            {
                RefCache.PartyHorn = __instance;
                RefCache.Cooldown = __instance.cooldown / 2.5f;
                RefCache.Delta = 1f;
            }
        }
    }
}
