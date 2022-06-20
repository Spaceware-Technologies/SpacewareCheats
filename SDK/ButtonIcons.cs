using System;
using UnityEngine;
using SpacewareCheats.SDK.ButtonAPI;

namespace SpacewareCheats.SDK
{
    class ButtonIcons
    {
        //Custom Icon Example
        #region Client - Icon Paths
        public static Sprite ToggleOn = LoadSprite.LoadSpriteFromDisk(($"{Environment.CurrentDirectory}\\UserData\\SpacewareCheats\\On.png"));
        public static Sprite ToggleOff = LoadSprite.LoadSpriteFromDisk(($"{Environment.CurrentDirectory}\\UserData\\SpacewareCheats\\Off.png"));
        public static Sprite Logo = LoadSprite.LoadSpriteFromDisk(($"{Environment.CurrentDirectory}\\UserData\\SpacewareCheats\\Logo.png"));
        #endregion
    }
}
