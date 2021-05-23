using HarmonyLib;

using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace RichVillages
{
  [HarmonyPatch(typeof(Town))]
  public class NewBehaviourScript1 : MBSubModuleBase
  {
    [HarmonyPatch("OnInit")]
    [HarmonyPostfix]
    public static void DailyTick(ref Town __instance)
    {
      Harmony.DEBUG = true;
      int maxGold = 1000000;
      FileLog.Log("maxGold: " + maxGold);
      Debug.Print("maxGold: " + maxGold);

      //InformationManager.DisplayMessage(new InformationMessage("Rich Villages - " + __instance.Name + " - Current Gold: " + __instance.Gold, Color.FromUint(4282569842U)));

      Debug.Print("__instance.Gold: " + __instance.Gold);
      FileLog.Log("__instance.Gold: " + __instance.Gold);

      __instance.ChangeGold(maxGold - __instance.Gold);

      Debug.Print("__instance.Gold: " + __instance.Gold);
      FileLog.Log("__instance.Gold: " + __instance.Gold);
      Harmony.DEBUG = false;
    }
  }
}