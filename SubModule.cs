using HarmonyLib;
using TaleWorlds.Library;
using TaleWorlds.MountAndBlade;

namespace RichVillages
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
            new Harmony("com.RichVillages.akdombrowski").PatchAll();
            InformationManager.DisplayMessage(new InformationMessage("Loaded 'Rich Villages'.", Color.FromUint(4282569842U)));
        }
    }
}