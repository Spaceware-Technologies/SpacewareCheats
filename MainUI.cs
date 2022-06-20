using UnityEngine; 
using System.Collections;
using System;
using SpacewareCheats.SDK;
using SpacewareCheats.SDK.ButtonAPI;
using SpacewareCheats.Modules.Example;
using SpacewareCheats.Modules;

namespace SpacewareCheats
{
    class MainUI
    {

        /*   • TargetMenu Example •
         *  
         *  Main.Instance.Targetbutton = new QMNestedButton(Main.Instance.ButtonIcons.selectedUserMenuQM.transform.Find("ScrollRect/Viewport/VerticalLayoutGroup/Buttons_UserActions/").transform, "Target Button\n Example", null);
         *  Main.Instance.Examplesettings = new QMNestedButton(Main.Instance.Targetbutton.menuTransform, "Nested Button\n Example", null);
         *  Main.Instance.ExampleNestedSettings = new QMNestedButton(Main.Instance.Examplesettings.menuTransform, "Nested Button\n Example", null);
        */
        public static IEnumerator StartUI()
        {
            Console.Title = $"SpacewareCheats.com | Developed By SpacewareCheats.com OPENSRC CLIENT BASE";
            Main.Instance.QuickMenuStuff = new Alien();
            QMTab mainTab = new QMTab("SpacewareCheats", "", "SpacewareCheats.com VRC Client!", ButtonIcons.Logo);
        
            //Creating buttons for tab menu example
            Main.Instance.ExampleButton = new QMNestedButton(mainTab.menuTransform, "Nested Button", ButtonIcons.Logo);

            //creating mod buttons
            Main.Instance.Modules.Add(new SingleButtonExample());
            Main.Instance.Modules.Add(new ToggleButtonExample());

            //Loads Modules and creates the UI/Buttons
            foreach (BaseModule module in Main.Instance.Modules) module.OnUIInit();
            yield return new WaitForSecondsRealtime(0.1f);
        }
    }
}
