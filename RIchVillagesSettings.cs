using MCM.Abstractions.Attributes;
using MCM.Abstractions.Attributes.v2;
using MCM.Abstractions.Settings.Base.Global;

namespace RichVillages
{
  internal class RichVillagesSettings : AttributeGlobalSettings<RichVillagesSettings>
  {
    public RichVillagesSettings()
    {
      this.MinVillageGold = 1000;
    }

    public override string DisplayName => "RichVillages";

    public virtual string FolderName => "RichVillages";

    public virtual string FormatType
    {
      get;
    }

    public override string Id => "RichVillages V1.0.1";

    [SettingPropertyGroup("{=MCM_001_Settings_Header}General Mod Settings")]
    [SettingPropertyFloatingInteger("{=MCM_001_Settings_Name_001}Min Village Gold", 1, 10000000, "0 denars", HintText = "{=MCM_001_Settings_Info_001}Controls the min amount of gold (denars) which villages have at the start of the day. (Default = 1k)", RequireRestart = false)]
    public int MinVillageGold
    {
      get; set;
    }
  }
}