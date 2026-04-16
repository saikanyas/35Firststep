using BepInEx;
using HarmonyLib;
using UnityEngine;

[BepInPlugin("saikanyas.35firstStep.ciTiaoPatch", "35 First step", "1.0.0")]
public class InitGameCiTiaoPatch : BaseUnityPlugin
{
    private void Awake()
    {
        var harmony = new Harmony("saikanyas.35firstStep.ciTiaoPatch");
        harmony.PatchAll();
        Logger.LogInfo("35 First step loaded.");
    }
}

[HarmonyPatch(typeof(InitGameUI), "InitData")]
public static class Patch_InitGameUI_InitData
{
    private static readonly AccessTools.FieldRef<InitGameUI, int> CiTiaoPointRef =
        AccessTools.FieldRefAccess<InitGameUI, int>("CiTaio_Point_Have");

    [HarmonyPostfix]
    public static void Postfix(InitGameUI __instance)
    {
        CiTiaoPointRef(__instance) = 35;
        Debug.Log("[Patch] CiTaio_Point_Have set to 35");
    }
}