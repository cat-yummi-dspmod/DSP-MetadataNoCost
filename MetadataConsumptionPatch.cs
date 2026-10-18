using HarmonyLib;

namespace MetadataNoCost
{
    [HarmonyPatch(typeof(PropertySystem))]
    public static class MetadataConsumptionPatch
    {
        [HarmonyPostfix]
        [HarmonyPatch("GameTick")]
        public static void ClearConsumption(PropertySystem __instance, long tick)
        {
            if (tick % 60 != 0 || !MetadataNoCost.Enabled.Value)
            {
                return;
            }

            if (GameMain.data == null || GameMain.data.gameDesc == null)
            {
                return;
            }

            long seedKey = GameMain.data.gameDesc.seedKey64;
            ClusterPropertyData clusterData = __instance.GetClusterData(seedKey);

            if (clusterData.totalConsumption != null)
            {
                for (int i = 0; i < clusterData.totalConsumption.Count; i++)
                {
                    if (clusterData.totalConsumption[i].count > 0)
                    {
                        IDCNT item = clusterData.totalConsumption[i];
                        item.count = 0;
                        clusterData.totalConsumption[i] = item;
                    }
                }
            }
        }
    }
}
