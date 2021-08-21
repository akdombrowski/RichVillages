using HarmonyLib;

using MCM.Abstractions.Settings.Base.Global;

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

      int maxGold = GlobalSettings<RichVillagesSettings>.Instance.MinTownGold;
      FileLog.Log("town maxGold: " + maxGold);

      //InformationManager.DisplayMessage(new InformationMessage("Rich Villages - " + __instance.Name + " - Current Gold: " + __instance.Gold, Color.FromUint(4282569842U)));

      FileLog.Log("town __instance.GetName: " + __instance.GetName());
      FileLog.Log("town __instance.Gold: " + __instance.Gold);

      if (__instance.Gold >= maxGold)
      {
        return;
      }
      __instance.ChangeGold(maxGold - __instance.Gold);

      FileLog.Log("town __instance.Gold: " + __instance.Gold);
      Harmony.DEBUG = false;
    }
  }
}