﻿using HarmonyLib;
using REPOLib.Modules;

namespace REPOLib.Patches;

[HarmonyPatch(typeof(RunManager))]
internal static class RunManagerPatch
{
    private static bool _patchedAwake = false;

    [HarmonyPatch(nameof(RunManager.Awake))]
    [HarmonyPostfix]
    private static void AwakePatch()
    {
        if (_patchedAwake) return;
        _patchedAwake = true;

        NetworkPrefabs.Initialize();
        Valuables.RegisterValuables();
    }
}
