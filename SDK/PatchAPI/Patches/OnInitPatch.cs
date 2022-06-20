using ExitGames.Client.Photon;
using HarmonyLib;
using Photon.Realtime;
using SpacewareCheats.SDK.Patching;

namespace SpacewareCheats.SDK.PatchAPI.Patches
{
    public static class OnInitPatch
    {
        public static void InitOnEvent()
        {
            try
            {
                SpacePatches.Instance.Patch(typeof(VRC.UI.Elements.QuickMenu).GetMethod("Start"), null, new HarmonyMethod(AccessTools.Method(typeof(Main), "InitMenu")));
                SpacePatches.Instance.Patch(typeof(LoadBalancingClient).GetMethod("OnEvent"), new HarmonyMethod(AccessTools.Method(typeof(OnInitPatch), nameof(OnEvent)))); //method_Public_Virtual_New_Void_EventData_0"
                SpacePatches.Instance.Patch(AccessTools.Method(typeof(LoadBalancingClient), "method_Public_Virtual_New_Void_EventData_0", null, null), new HarmonyMethod(AccessTools.Method(typeof(OnInitPatch), nameof(OnEvent))));


                SDK.LogHandler.Log(SDK.LogHandler.Colors.Green, "[Patch] Basic Patches", false, false);
            }
            catch
            {
                SDK.LogHandler.Log(SDK.LogHandler.Colors.Red, "[Patch] [Error] Basic Patches", false, false);
            }
        }
        // method we are calling to hook into the Assembly-CSharp.dll and put our own code 
        private static bool OnEvent(EventData __0)
        {
            if (__0 == null) { return false; }
            // you always want to put this in every patch (you may need to tweak it a bit but generally the same for every patch) so you can call this in any mod file to create the mods them self
            for (int i = 0; i < Main.Instance.OnEventEventArray.Length; i++) { if (!Main.Instance.OnEventEventArray[i].OnEvent(__0)) return false; }
            return true;
        }
    }
}
