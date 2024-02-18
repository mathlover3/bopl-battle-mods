using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using UnityEngine;

namespace SuperDash
{
    [BepInPlugin("com.David_Loves_Jellycar_Worlds.SuperDash", "SuperDash", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin SuperDash is loaded!");

            Harmony harmony = new Harmony("com.David_Loves_Jellycar_Worlds.SuperDash");


            MethodInfo original = AccessTools.Method(typeof(Dash), "Awake");
            MethodInfo patch = AccessTools.Method(typeof(myPatches), "Awake_SuperDash_Plug");
            harmony.Patch(original, new HarmonyMethod(patch));
        }

        public class myPatches
        {
            public static void Awake_SuperDash_Plug(Dash __instance)
            {
                __instance.dashLength = (Fix)1000f;
            }
        }
    }
}