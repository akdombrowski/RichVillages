using HarmonyLib;

using MCM.Abstractions.Settings.Base.Global;

using TaleWorlds.CampaignSystem;
using TaleWorlds.Core;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace RichVillages
{
  [HarmonyPatch(typeof(Village), "DailyTick")]
  public class SubModule : MBSubModuleBase
  {
    [HarmonyPostfix]
    public static void DailyTick(ref Village __instance)
    {
      Harmony.DEBUG = false;

      int maxGold = GlobalSettings<RichVillagesSettings>.Instance.MinVillageGold;
      FileLog.Log("maxGold: " + maxGold);
      Debug.Print("maxGold: " + maxGold);

      //InformationManager.DisplayMessage(new InformationMessage("Rich Villages - " + __instance.Name + " - Current Gold: " + __instance.Gold, Color.FromUint(4282569842U)));

      Debug.Print("__instance.GetName: " + __instance.GetName());
      Debug.Print("__instance.Gold: " + __instance.Gold);
      FileLog.Log("__instance.GetName: " + __instance.GetName());
      FileLog.Log("__instance.Gold: " + __instance.Gold);

      if (__instance.Gold >= maxGold)
      {
        return;
      }
      __instance.ChangeGold(maxGold - __instance.Gold);

      Debug.Print("__instance.Gold: " + __instance.Gold);
      FileLog.Log("__instance.Gold: " + __instance.Gold);
      Harmony.DEBUG = false;
    }

    protected override void OnBeforeInitialModuleScreenSetAsRoot()
    {
      base.OnBeforeInitialModuleScreenSetAsRoot();
      new Harmony("com.RichVillages.akdombrowski").PatchAll();
      InformationManager.DisplayMessage(new InformationMessage("Loaded 'Rich Villages'.", Color.FromUint(4282569842U)));
    }
  }
}