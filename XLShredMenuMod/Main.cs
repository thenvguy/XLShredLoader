﻿using UnityEngine;
using Harmony12;
using System.Reflection;
using UnityModManagerNet;
using System;
using XLShredLib;

namespace XLShredMenuMod
{
    static class Main
    {
        public static bool enabled;
        private static GameObject modmenu;

        static bool Load(UnityModManager.ModEntry modEntry) {

            var harmony = HarmonyInstance.Create(modEntry.Info.Id);
            harmony.PatchAll(Assembly.GetExecutingAssembly());

            modEntry.OnToggle = OnToggle;

            modmenu = new GameObject();
            modmenu.AddComponent<ModMenu>();
            UnityEngine.Object.DontDestroyOnLoad(Main.modmenu);
            ModMenu.Instance.menuModPath = modEntry.Path;
            ModMenu.Instance.LoadMainMenuAsset();

            return true;
        }

        static bool OnToggle(UnityModManager.ModEntry modEntry, bool value) {
            enabled = value;
            ModMenu.Instance.enabled = value;
            return true;
        }
    }
}
