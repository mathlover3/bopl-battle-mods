using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Steamworks;
using Steamworks.Data;

namespace PurplePlayers
{
    [BepInPlugin("com.David_Loves_JellyCar_Worlds.PurplePlayers", "PurplePlayers", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin PurplePlayers is loaded!");

            Harmony harmony = new Harmony("com.David_Loves_JellyCar_Worlds.PurplePlayers");

            Logger.LogInfo("harmany created");
            harmony.PatchAll();
            Logger.LogInfo("PurplePlayers Patch Compleate!");
        }


        [HarmonyPatch(typeof(SteamManager))]
        public class myPatches
        {
            [HarmonyPatch("HostGame")]
            [HarmonyPrefix]
            public static void HostGame_PurplePlayers_Plug(SteamManager __instance, PlayerInit hostPlayer)
            {
                for (int i = 0; i < __instance.connectedPlayers.Count; i++)
                {
                    __instance.connectedPlayers[i].lobby_color = 1;
                }
            }
        }

    }
}