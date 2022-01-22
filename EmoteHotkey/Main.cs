using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using VRC.SDKBase;


namespace EmojiHotkey
{
    public static class Main
    {
        public const string Name = "EmojiHotkey";
        public const string Description = "Hotkey=Emoji";
        public const string Author = "Saya";
        public const string Company = null;
        public const string Version = "1.8.7";
        public const string DownloadLink = null;
    }

    public class EmojiHotkey : MelonMod
    {
        public override void OnApplicationStart()
        {
            MelonCoroutines.Start(ReadyUIEX());          
        }

        public static IEnumerator ReadyUIEX()
        {
           
            UIEX();
            yield return null;

        }
      
        public override void OnUpdate()
        {            
             if (Input.GetMouseButtonDown(2))
             {
                int number = MelonPreferences.GetEntryValue<int>("EmojiHotkey", "EmojiNumber");
                SendEmoji(number);     
             }
                       
        }
        public static void UIEX()
        {
            string EmojiHotkey1 = "EmojiHotkey";
            MelonPreferences.CreateCategory(EmojiHotkey1,"EmojiHotkey");
            MelonPreferences.CreateEntry<int>(EmojiHotkey1, "EmojiNumber", 55);
        }


        private static void SendEmoji(int Number)
        {
            MelonLogger.Msg(ConsoleColor.Green, $"Sending Emoji {Number}");
            Networking.RPC(RPC.Destination.All,
                LocalVRCPlayer.gameObject,
                "SpawnEmojiRPC",
                new Il2CppSystem.Object[1] {
                    new Il2CppSystem.Int32 {
                        m_value = Number
                    }.BoxIl2CppObject()
                });
        }

        public static VRCPlayer LocalVRCPlayer
        {
            get
            {
                return VRCPlayer.field_Internal_Static_VRCPlayer_0;
            }
        }
    }


}