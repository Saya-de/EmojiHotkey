using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using UnityEngine;
using VRC.SDKBase;
using UIExpansionKit.API;


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

        public static void UIEX()
        {
            
            MelonPreferences.CreateCategory("EmojiHotkey", "EmojiHotkey");           
            MelonPreferences.CreateEntry<string>("EmojiHotkey", "EmojiNumber", "");
            ExpansionKitApi.RegisterSettingAsStringEnum("EmojiHotkey", "EmojiNumber", new[] { ("0", "Angry"), ("1", "Blush"), ("2", "Cry"), ("3", "SadFace"), ("4", "Hi/Bye"), ("5", "Yeah"), ("6", "HeartEyes"), ("7", "Pumpkin"), ("8", "Kiss"), ("9", "LaughingFace"), ("10", "Skull"), ("11", "FappyFace"), ("12", "Ghost"), ("13", "NoExpression"), ("14", "Cool"), ("15", "Hmm"), ("16", "ThumbsDown"), ("17", "ThumbsUp"), ("18", "TongueOut"), ("19", "ExcitedFace"), ("20", "Bat"), ("21", "Smoke"), ("22", "Fire"), ("23", "Snowflake"), ("24", "Snowball"), ("25", "Splash"), ("26", "Spiderweb"), ("27", "Beer"), ("28", "RoundCandy"), ("29", "CandyCane"), ("30", "SmallCandy"), ("31", "SparklingWine"), ("32", "CoconutDrink"), ("33", "Gingerbread"), ("34", "IceCone"), ("35", "Pineapple"), ("36", "Pizza"), ("37", "Tomato"), ("38", "Beachball"), ("39", "Coal"), ("40", "Confetti"), ("41", "Present"), ("42", "Presents"), ("43", "LifeRing"), ("44", "Mistletoe"), ("45", "Money"), ("46", "Glasses"), ("47", "Suncream"), ("48", "Boo!"), ("49", "BrokenHeart"), ("50", "Exclamationmark"), ("51", "Go!"), ("52", "Heart"), ("53", "Musik"), ("54", "Questionmark"), ("55", "STOP"), ("56", "Sleep") });
            
        }

        public override void OnUpdate()
        {
            
             //int Hotkey = MelonPreferences.GetEntryValue<int>("EmojiHotkey", "Hotkey");
             if (Input.GetMouseButtonDown(2))
             {
                string EmojiNumber = MelonPreferences.GetEntryValue<string>("EmojiHotkey", "EmojiNumber");
                var Parsed = Int16.Parse(EmojiNumber);                               
                SendEmoji(Parsed);     
             }
                       
        }
       
        private static void SendEmoji(int Number)1
        {           
            string EmojiNumber1 = MelonPreferences.GetEntryValue<string>("EmojiHotkey", "EmojiNumber");
            MelonLogger.Msg(ConsoleColor.Green, $"Sending Emoji {EmojiNumber1}");
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