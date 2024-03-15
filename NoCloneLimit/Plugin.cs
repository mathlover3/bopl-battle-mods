using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Steamworks;
using Steamworks.Data;

namespace NoCloneLimit
{
    [BepInPlugin("com.David_Loves_JellyCar_Worlds.NoCloneLimit", "NoCloneLimit", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin NoCloneLimit is loaded!");

            Harmony harmony = new Harmony("com.David_Loves_JellyCar_Worlds.NoCloneLimit");

            Logger.LogInfo("harmany created");
            harmony.PatchAll();
            Logger.LogInfo("NoCloneLimit Patch Compleate!");
        }


    [HarmonyPatch(typeof(PlayerCollision))]
    public class myPatches
    {
        [HarmonyPatch("SpawnClone")]
        [HarmonyPrefix]
        private static void OnChatMessageCallback_NoCloneLimit_Plug(ref int ___maxAllowedClonesAndBodies)
        {
            Debug.Log("cloneing");
            ___maxAllowedClonesAndBodies = 1000000;
        }
    }

        }
    }