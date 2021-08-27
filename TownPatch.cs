using HarmonyLib;

using MCM.Abstractions.Settings.Base.Global;

using System.Collections.Generic;

using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace RichVillages
{
    [HarmonyPatch(typeof(Town))]
    public class TownPatch : MBSubModuleBase
    {
        [HarmonyPatch("DailyTick")]
        [HarmonyPostfix]
        public static void DailyTickTownPatch(ref Town __instance)
        {
            Harmony.DEBUG = false;
            List<string> buffer = FileLog.GetBuffer(true);

            int maxGold = GlobalSettings<RichVillagesSettings>.Instance.MinTownGold;


            if (Harmony.DEBUG)
            {
                buffer.Add("town maxGold: " + maxGold);

                //InformationManager.DisplayMessage(new InformationMessage("Rich Villages - " + __instance.Name + " - Current Gold: " + __instance.Gold, Color.FromUint(4282569842U)));

                buffer.Add("town __instance.GetName: " + __instance.GetName());
                buffer.Add("town __instance.Gold: " + __instance.Gold);
            }

            if (__instance.Gold >= maxGold)
            {
                return;
            }
            __instance.ChangeGold(maxGold - __instance.Gold);


            if (Harmony.DEBUG)
            {
                buffer.Add("town __instance.Gold: " + __instance.Gold);


                FileLog.LogBuffered(buffer);
                FileLog.FlushBuffer();
            }
            Harmony.DEBUG = false;
        }
    }
}