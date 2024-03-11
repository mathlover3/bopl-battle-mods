using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Steamworks;
using Steamworks.Data;

namespace SameColor
{
    [BepInPlugin("com.David_Loves_JellyCar_Worlds.SameColor", "SameColor", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin SameColor is loaded!");

            Harmony harmony = new Harmony("com.David_Loves_JellyCar_Worlds.SameColor");

            Logger.LogInfo("harmany created");
            harmony.PatchAll();
            Logger.LogInfo("SameColor Patch Compleate!");
        }


        [HarmonyPatch(typeof(SteamManager))]
        public class myPatches
        {
            [HarmonyPatch("HostGame")]
            [HarmonyPrefix]
            public static void HostGame_SameColor_Plug(SteamManager __instance, PlayerInit hostPlayer)
            { 
                for (int i = 0; i < __instance.connectedPlayers.Count; i++)
                {
                    __instance.connectedPlayers[i].lobby_color = (byte)hostPlayer.color;
                }
            }
        }

    }
}