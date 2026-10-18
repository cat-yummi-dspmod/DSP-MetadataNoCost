using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;
using YummiUIHarness;

namespace MetadataNoCost
{
    [BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
    [BepInDependency(UIHarness.Guid)]
    public class MetadataNoCost : BaseUnityPlugin
    {
        public const string PLUGIN_GUID = "com.yummi.dsp.metadatanocost";
        public const string PLUGIN_NAME = "元数据老赖";
        public const string PLUGIN_VERSION = "0.0.0";
        public const string PageKey = "metadata_cheats";
        public const string PageTitleZh = "元数据作弊";
        public const string PageTitleEn = "Metadata Cheats";

        private static readonly Harmony harmony = new Harmony(PLUGIN_GUID);
        internal static ManualLogSource Log;
        internal static ConfigEntry<bool> Enabled;

        private void Awake()
        {
            Log = Logger;
            Enabled = Config.Bind("General", "Enabled", true,
                "Keep clearing cross-save Metadata consumption for the current cluster. | 持续清除当前星区的跨存档元数据消耗记录。");

            UIHarness.RegisterPage(PageKey, PageTitleZh, PageTitleEn)
                .AddCheckbox(Enabled, "启用：不扣除元数据", "Enable: no Metadata deduction")
                .AddLabel(
                    "每秒清除当前星区的跨存档消耗记录（Property 文件夹），存档内统计不变。",
                    "Every second, clears cross-save consumption records (Property folder); in-save stats unchanged.");

            harmony.PatchAll(typeof(MetadataConsumptionPatch));
            Log.LogInfo($"{PLUGIN_NAME} v{PLUGIN_VERSION} 已加载");
        }

        private void OnDestroy()
        {
            harmony.UnpatchSelf();
        }
    }
}
