using EmeraldSlime;
using HarmonyLib;
using MonomiPark.SlimeRancher.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRoneTutorial
{
    [HarmonyPatch(typeof(GordoSnare))]
    [HarmonyPatch("GetGordoIdForBait")]
    class GordoSnaring
    {
        [HarmonyPriority(800)]
        public static bool Prefix(GordoSnare __instance, ref Identifiable.Id __result)
        {
            if (__instance.GetPrivateField<SnareModel>("model").baitTypeId != Identifiable.Id.BEET_VEGGIE || Randoms.SHARED.GetInRange(0, 100) > 60)
                return true;
            else
            {
                __result = Ids.EMERALD_GORDO;
                return false;
            }
        }
    }
}