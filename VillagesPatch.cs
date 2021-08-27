using HarmonyLib;

using MCM.Abstractions.Settings.Base.Global;

using System.Collections.Generic;

using TaleWorlds.CampaignSystem;
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
            List<string> buffer = FileLog.GetBuffer(true);

            int maxGold = GlobalSettings<RichVillagesSettings>.Instance.MinVillageGold;
            if (Harmony.DEBUG)
            {
                buffer.Add("village maxGold: " + maxGold);
            }

            //InformationManager.DisplayMessage(new InformationMessage("Rich Villages - " + __instance.Name + " - Current Gold: " + __instance.Gold, Color.FromUint(4282569842U)));

            if (Harmony.DEBUG)
            {
                buffer.Add("village __instance.GetName: " + __instance.GetName());
                buffer.Add("village __instance.Gold: " + __instance.Gold);
            }

            if (__instance.Gold >= maxGold)
            {
                return;
            }
            __instance.ChangeGold(maxGold - __instance.Gold);

            if (Harmony.DEBUG)
            {
                buffer.Add("village __instance.Gold: " + __instance.Gold);

                FileLog.LogBuffered(buffer);
                FileLog.FlushBuffer();
            }

            Harmony.DEBUG = false;
        }
    }
}