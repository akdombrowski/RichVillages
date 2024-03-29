﻿using HarmonyLib;
using MCM.Abstractions.Base.Global;
using TaleWorlds.CampaignSystem.Settlements;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace RichVillages
{
    [HarmonyPatch(typeof(Village))]
    public class VillagesPatch : MBSubModuleBase
    {
        [HarmonyPatch("DailyTick")]
        [HarmonyPostfix]
        public static void DailyTick(ref Town __instance)
        {
            Harmony.DEBUG = false;

            int maxGold = GlobalSettings<RichVillagesSettings>.Instance.MinVillageGold;
            FileLog.Log("village maxGold: " + maxGold);
            Debug.Print("village maxGold: " + maxGold);

            //InformationManager.DisplayMessage(new InformationMessage("Rich Villages - " + __instance.Name + " - Current Gold: " + __instance.Gold, Color.FromUint(4282569842U)));

            Debug.Print("village __instance.GetName: " + __instance.GetName());
            Debug.Print("village __instance.Gold: " + __instance.Gold);
            FileLog.Log("village __instance.GetName: " + __instance.GetName());
            FileLog.Log("village __instance.Gold: " + __instance.Gold);

            if (__instance.Gold >= maxGold)
            {
                return;
            }
            __instance.ChangeGold(maxGold - __instance.Gold);

            Debug.Print("village __instance.Gold: " + __instance.Gold);
            FileLog.Log("village __instance.Gold: " + __instance.Gold);
            Harmony.DEBUG = false;
        }
    }
}