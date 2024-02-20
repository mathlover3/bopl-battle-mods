using BepInEx;
using BoplFixedMath;
using HarmonyLib;
using System.Reflection;
using UnityEngine;
using Steamworks;
using Steamworks.Data;

namespace AntiKick
{
    [BepInPlugin("com.David_Loves_JellyCar_Worlds.AntiKick", "AntiKick", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        private void Awake()
        {
            Logger.LogInfo("Plugin AntiKick is loaded!");

            Harmony harmony = new Harmony("com.David_Loves_JellyCar_Worlds.AntiKick");

            Logger.LogInfo("harmany created");
            harmony.PatchAll();
            Logger.LogInfo("AntiKick Patch Compleate!");
        }


    [HarmonyPatch(typeof(SteamManager))]
    public class myPatches
    {
        [HarmonyPatch("OnChatMessageCallback")]
        [HarmonyPrefix]
        private static bool OnChatMessageCallback_AntiKick_Plug(Lobby lobby, Friend sender, string msg)
        {
            Debug.Log("someone tryed to kick " + msg);
                //skip main funcson (you have to return false in a prefix to skip the rest)
                return false;
        }
    }

        }
    }