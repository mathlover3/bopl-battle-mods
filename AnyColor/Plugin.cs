using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Steamworks;
using Steamworks.Data;

namespace AnyColor
{
    [BepInPlugin("com.David_Loves_JellyCar_Worlds.AnyColor", "AnyColor", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin AnyColor is loaded!");

            Harmony harmony = new Harmony("com.David_Loves_JellyCar_Worlds.AnyColor");

            Logger.LogInfo("harmany created");
            harmony.PatchAll();
            Logger.LogInfo("AnyColor Patch Compleate!");
        }


        [HarmonyPatch(typeof(CharacterSelectHandler_online))]
        public class myPatches
        {
            [HarmonyPatch("IsColorTaken")]
            [HarmonyPostfix]
            private static bool IsColorTaken(bool __result)
            {
                //the color isnt taken
                return false;
            }
        }

    }
}