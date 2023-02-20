using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Base.Global;

namespace RichVillages
{
    internal sealed class RichVillagesSettings : AttributeGlobalSettings<RichVillagesSettings>
    {
        public override string Id => "RichVillages V1.1.1";

        public override string DisplayName => "RichVillages";
        public override string FolderName => "RichVillages";
        public override string FormatType => "json2";


        [SettingPropertyGroup("General Mod Settings")]
        [SettingPropertyFloatingInteger("Min Village Gold", 1, 10000000, "0 denars", HintText = "Controls the min amount of gold (denars) which villages have at the start of the day. (Default = 1k)", RequireRestart = false)]
        public int MinVillageGold { get; set; } = 1000;

        [SettingPropertyGroup("General Mod Settings")]
        [SettingPropertyFloatingInteger("Min Town Gold", 1, 10000000, "0 denars", HintText = "Controls the min amount of gold (denars) which towns have at the start of the day. (Default = 100k)", RequireRestart = false)]
        public int MinTownGold { get; set; } = 100000;
    }
}