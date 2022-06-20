using HarmonyLib;
using System;
using System.Reflection;
using Harmony;
using SpacewareCheats.SDK.PatchAPI.Patches;

namespace SpacewareCheats.SDK.Patching
{
    class SpacePatches
    {
        public static HarmonyLib.Harmony Harmony { get; set; }
        public static HarmonyLib.Harmony Instance = new HarmonyLib.Harmony("SpacewareCheats.com");

        [Obsolete]
        public static Harmony.HarmonyMethod GetLocalPatch(Type type, string methodName)
        {
            return new Harmony.HarmonyMethod(type.GetMethod(methodName, BindingFlags.Static | BindingFlags.NonPublic));
        }

        public static void InitPatches()
        {
            try
            {
                LogHandler.Log(LogHandler.Colors.Green, "[Patch] Starting Patches....", true, false);
                OnInitPatch.InitOnEvent();
            }
            catch (Exception ERR) { LogHandler.Log(LogHandler.Colors.Green, ERR.Message, false, false); }
        }
    }
}
