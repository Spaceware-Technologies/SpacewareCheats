using System;
using UnityEngine;
using MelonLoader;
using SpacewareCheats.SDK;
using SpacewareCheats.Events;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using SpacewareCheats.Modules;
using SpacewareCheats.SDK.ButtonAPI;
using SpacewareCheats.SDK.Patching;

namespace SpacewareCheats
{
    public class Main : MelonMod
    {
        //CREDITS: Base Made By Joshua
        //Authors Website: https://spacewarecheats.com
        //Founders: Joshua, Meli, Max, Saint
        //Devs: Joshua
        //Illustrator: Meli (insta: @Gh0st_artz)

 
        public static Main Instance { get; set; }
        internal Alien QuickMenuStuff { get; set; }
        internal QMNestedButton ExampleButton { get; set; }
        internal QMNestedButton Targetbutton { get; set; }
        internal QMNestedButton Examplesettings { get; set; }
        internal QMNestedButton ExampleNestedSettings { get; set; }   
        internal List<BaseModule> Modules { get; set; } = new List<BaseModule>();
        public List<IOnUpdateEvent> OnUpdateEvents { get; set; } = new List<IOnUpdateEvent>();
        public List<IOnEventEvent> OnEventEvents { get; set; } = new List<IOnEventEvent>();
        public IOnUpdateEvent[] OnUpdateEventArray { get; set; } = new IOnUpdateEvent[0];
        public IOnEventEvent[] OnEventEventArray { get; set; } = new IOnEventEvent[0];

        private static bool HasOpened = false;
        private static bool HasStarted = false;

        public override void OnApplicationStart()
        {
            if (!HasStarted)
            {
                Instance = new Main();
                Task.Run(() => { SpacePatches.InitPatches(); });
                HasStarted = true;
            }
        }
       
        public override void OnUpdate()
        {
            for (int i = 0; i < Instance.OnUpdateEventArray.Length; i++) { Instance.OnUpdateEventArray[i].OnUpdate(); }
            if (Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.LeftAlt))
            {
                if (Input.GetKeyDown(KeyCode.Backspace))
                {
                    Process.Start("VRChat.exe", Environment.CommandLine);
                    Process.GetCurrentProcess().Kill();
                }
            }
        }

        public static void InitMenu()
        {
            try
            {
                if (!HasOpened)
                {
                    MelonCoroutines.Start(MainUI.StartUI());
                    LogHandler.Log(LogHandler.Colors.Green, "Client UI Initialized.", true, false);
                    HasOpened = true;
                }
            }
            catch { }
        }
    }
}
