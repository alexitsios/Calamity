//Author : https://github.com/seekeroftheball   https://gist.github.com/seekeroftheball
//Version : Calamity custom version, based on open-source version 1.1
//Updated : March 2023
using System.Collections.Generic;
using UnityEngine;
using Seeker.StringMarkupEncapsulation;

namespace Seeker.Emojis
{
    /// <summary>
    /// Lightweight static emoji library. 
    /// <para/>Note: Not all emojis will function in all parts of the Unity editor.
    /// Specific areas may require either type of accessor.
    /// <para/>Two types of accessors. GetEmojiFromDictionary(), and EmojiConstants.
    /// </summary>
    public struct Emoji
    {
        /// <summary>
        /// Get emoji from the emoji dictionary as a string.
        /// <para/>Useage example:
        /// <para/>string heartEmoji = Emoji.GetEmojiFromDictionary("heart");
        /// </summary>
        /// <param name="emoji">string name of the emoji to pull.</param>
        /// <returns>Requested emoji.</returns>
        public static string GetEmojiFromDictionary(string emoji)
        {
            emoji = emoji.Trim();
            emoji = emoji.ToLower();
            if (Emojis.ContainsKey(emoji))
                return Emojis[emoji];

            return string.Empty;
        }

        /// <summary>
        /// Overload method for getting emojis formatted with a specific RGBA color.
        /// <para/>Useage example:
        /// <para/>string heartEmoji = Emoji.GetEmojiFromDictionary("heart", Color.red);
        /// </summary>
        /// <param name="emoji">string name of the emoji to pull.</param>
        /// <returns>Requested emoji.</returns>
        public static string GetEmojiFromDictionary(string emoji, Color color)
        {
            emoji = emoji.Trim();
            emoji = emoji.ToLower();
            if (Emojis.ContainsKey(emoji))
                return StringFormatter.FormatStringWithMarkupTag(Emojis[emoji], color);

            return string.Empty;
        }

        /// <summary>
        /// Predefined emojis. Add any new emoji by creating a new const variable.
        /// <para/>Useage example:
        /// <para/>string ninja = Emoji.EmojiConstants.Ninja;
        /// <para/>Note: not all emojis have been implemented in this version. See comment list of common emojis to be implemented later.
        /// </summary>
        public readonly struct EmojiConstants
        {
            public const string Abacus = " 🧮 ";
            public const string BeamingFacewithSmilingEyes = " 😁 ";
            public const string BlackSquare = " ⬛️ ";
            public const string Boot = " 🥾 ";
            public const string ClapperBoard = " 🎬 ";
            public const string Controller = " 🎮 ";
            public const string FaceBlowingaKiss = " 😘 ";
            public const string FacewithTearsofJoy = " 😂 ";
            public const string Folder = " 📁 ";
            public const string Gear = " ⚙️ ";
            public const string GrinningFace = " 😀 ";
            public const string GrinningFacewithBigEyes = " 😃 ";
            public const string GrinningFacewithSmilingEyes = " 😄 ";
            public const string GrinningFacewithSweat = " 😅 ";
            public const string GrinningSquintingFace = " 😆 ";
            public const string KissingFace = " 😗 ";
            public const string KissingFacewithClosedEyes = " 😚 ";
            public const string KissingFacewithSmilingEyes = " 😙 ";
            public const string MagnifyingGlass = " 🔎 ";
            public const string Ninja = " 🥷 ";
            public const string Package = " 📦 ";
            public const string Plug = " 🔌 ";
            public const string Recycle = " ♻️ ";
            public const string Rocket = " 🚀 ";
            public const string RollingontheFloorLaughing = " 🤣 ";
            public const string Scroll = " 📜 ";
            public const string SlightlySmilingFace = " 🙂 ";
            public const string SmilingFace = " ☺️ ";
            public const string SmilingFacewithHalo = " 😇 ";
            public const string SmilingFacewithHeartEyes = " 😍 ";
            public const string SmilingFacewithHearts = " 🥰 ";
            public const string SmilingFacewithSmilingEyes = " 😊 ";
            public const string SmilingFacewithTear = " 🥲 ";
            public const string Speaker = " 🔊 ";
            public const string StarStruck = " 🤩 ";
            public const string TestTube = " 🧪 ";
            public const string TwoFingersTouching = " 👉👈 ";
            public const string UpsideDownFace = " 🙃 ";
            public const string VulcanSalute = " 🖖 ";

            public const string placeholder = " 🩸 ";

            public const string DroolingFace = " 🤤 ";
            public const string ExpressionlessFace = " 😑 ";
            public const string FaceExhaling = " 😮‍💨";
            public const string FaceinClouds = " 😶‍🌫️";
            public const string FaceVomiting = " 🤮 ";
            public const string FacewithHandOverMouth = " 🤭 ";
            public const string FacewithHeadBandage = " 🤕 ";
            public const string FacewithMedicalMask = " 😷 ";
            public const string FacewithRaisedEyebrow = " 🤨 ";
            public const string FacewithRollingEyes = " 🙄 ";
            public const string GrimacingFace = " 😬 ";
            public const string HotFace = " 🥵 ";
            public const string LyingFace = " 🤥 ";
            public const string MoneyMouthFace = " 🤑 ";
            public const string NauseatedFace = " 🤢 ";
            public const string NeutralFace = " 😐 ";
            public const string PensiveFace = " 😔 ";
            public const string RelievedFace = " 😌 ";
            public const string ShushingFace = " 🤫 ";
            public const string SleepingFace = " 😴 ";
            public const string SmilingFacewithOpenHands = " 🤗 ";
            public const string SneezingFace = " 🤧 ";
            public const string SquintingFacewithTongue = " 😝 ";
            public const string UnamusedFace = " 😒 ";
            public const string WinkingFacewithTongue = " 😜 ";
            public const string WoozyFace = " 🥴 ";
            public const string ZanyFace = " 🤪 ";
            public const string ColdFace = " 🥶 ";
            public const string FaceSavoringFood = " 😋 ";
            public const string FacewithCrossedOutEyes = " 😵 ";
            public const string FacewithSpiralEyes = " 😵‍💫 ";
            public const string FacewithThermometer = " 🤒 ";

            public const string AnatomicalHeart = " 🫀 ";
            public const string AnguishedFace = " 😧 ";
            public const string AngryFace = " 😠 ";
            public const string AngryFacewithHorns = " 👿 ";
            public const string BackhandIndexPointingDown = " 👇 ";
            public const string BackhandIndexPointingLeft = " 👈 ";
            public const string BackhandIndexPointingRight = " 👉 ";
            public const string BackhandIndexPointingUp = " 👆 ";
            public const string Brain = " 🧠 ";
            public const string CallMeHand = " 🤙 ";
            public const string CatwithTearsofJoy = " 😹 ";
            public const string CatwithWrySmile = " 😼 ";
            public const string ClownFace = " 🤡 ";
            public const string ConfoundedFace = " 😖 ";
            public const string ConfusedFace = " 😕 ";
            public const string CowboyHatFace = " 🤠 ";
            public const string CryingCat = " 😿 ";
            public const string CryingFace = " 😢 ";
            public const string DisappointedFace = " 😞 ";
            public const string DisguisedFace = " 🥸 ";
            public const string DowncastFacewithSweat = " 😓 ";
            public const string Ear = " 👂 ";
            public const string EarwithHearingAid = " 🦻 ";
            public const string EnragedFace = " 😡 ";
            public const string ExplodingHead = " 🤯 ";
            public const string FaceScreaminginFear = " 😱 ";
            public const string FacewithMonocle = " 🧐 ";
            public const string FacewithOpenMouth = " 😮 ";
            public const string FacewithSteamFromNose = " 😤 ";
            public const string FrowningFace = " ☹️ ";
            public const string FrowningFacewithOpenMouth = " 😦 ";
            public const string Ghost = " 👻 ";
            public const string Girl = " 👧 ";
            public const string GrinningCat = " 😺 ";
            public const string GrinningCatwithSmilingEyes = " 😸 ";
            public const string Handshake = " 🤝 ";
            public const string HandwithFingersSplayed = " 🖐️ ";
            public const string HushedFace = " 😯 ";
            public const string IndexPointingUp = " ☝️ ";
            public const string KissingCat = " 😽 ";
            public const string KissMark = " 💋 ";
            public const string Legs = " 🦵 ";
            public const string LoudlyCryingFace = " 😭 ";
            public const string LoveYouGesture = " 🤟 ";
            public const string Lungs = " 🫁 ";
            public const string Man = " 👨 ";
            public const string ManBald = " 👨‍🦲 ";
            public const string ManBlondHair = " 👱‍♂️ ";
            public const string ManCurlyHair = " 👨‍🦱 ";
            public const string ManRedHair = " 👨‍🦰 ";
            public const string ManWhiteHair = " 👨‍🦳 ";
            public const string MechanicalArm = " 🦾 ";
            public const string MechanicalLeg = " 🦿 ";
            public const string MiddleFinger = " 🖕 ";
            public const string NailPolish = " 💅 ";
            public const string NerdFace = " 🤓 ";
            public const string Nose = " 👃 ";
            public const string Ogre = " 👹 ";
            public const string OKHand = " 👌 ";
            public const string OpenHands = " 👐 ";

            public const string Artist = " 🎨 ";
            public const string Astronaut = " 🚀 ";
            public const string BabyAngel = " 👼 ";
            public const string BreastFeeding = " 🤱 ";
            public const string ConstructionWorker = " 👷 ";
            public const string Detective = " 🕵️ ";
            public const string FactoryWorker = " 🏭 ";
            public const string Firefighter = " 🚒 ";
            public const string Guard = " 💂 ";
            public const string ManArtist = " 👨‍🎨 ";
            public const string ManAstronaut = " 👨‍🚀 ";
            public const string ManConstructionWorker = " 👷‍♂️ ";
            public const string ManCook = " 👨‍🍳 ";
            public const string ManDetective = " 🕵️‍♂️ ";
            public const string ManFactoryWorker = " 👨‍🏭 ";
            public const string ManFeedingBaby = " 👨‍🍼 ";
            public const string ManGuard = " 💂‍♂️ ";
            public const string ManInTuxedo = " 🤵‍♂️ ";
            public const string ManMechanic = " 👨‍🔧 ";
            public const string ManOfficeWorker = " 👨‍💼 ";
            public const string ManPilot = " 👨‍✈️ ";
            public const string ManPrince = " 🤴 ";
            public const string ManScientist = " 👨‍🔬 ";
            public const string ManSuperhero = " 🦸‍♂️ ";
            public const string ManSupervillain = " 🦹‍♂️ ";
            public const string ManWearingTurban = " 👳‍♂️ ";
            public const string MxClaus = " 🧑‍🎄 ";
            public const string MrsClaus = " 🤶 ";
            public const string OfficeWorker = " 💼 ";
            public const string PersonFeedingBaby = " 🧑‍🍼 ";
            public const string PersonInTuxedo = " 🤵 ";
            public const string PersonWithSkullcap = " 👲 ";
            public const string PersonWithVeil = " 👰 ";
            public const string Pilot = " ✈️ ";
            public const string PoliceOfficer = " 👮 ";
            public const string Prince = " 🤴 ";
            public const string PregnantWoman = " 🤰 ";
            public const string SantaClaus = " 🎅 ";
            public const string Scientist = " 🔬 ";
            public const string Singer = " 🎤 ";
            public const string Superhero = " 🦸 ";
            public const string Supervillain = " 🦹 ";
            public const string Technologist = " 🧑‍💻 ";
            public const string WomanArtist = " 👩‍🎨 ";
            public const string WomanAstronaut = " 👩‍🚀 ";
            public const string WomanConstructionWorker = " 👷‍♀️ ";
            public const string WomanCook = " 👩‍🍳 ";
            public const string WomanFactoryWorker = " 👩‍🏭 ";
            public const string WomanFeedingBaby = " 👩‍🍼 ";
            public const string WomanGuard = " 💂‍♀️ ";
            public const string WomanInTuxedo = " 🤵‍♀️ ";
            public const string WomanMechanic = " 👩‍🔧 ";

            public const string Cook = " 🧑‍🍳 ";
            public const string Mechanic = " 🧑‍🔧 ";
            public const string WomanFirefighter = " 👩‍🚒 ";
            public const string WomanOfficeWorker = " 👩‍💼 ";
            public const string WomanPilot = " 👩‍✈️ ";
            public const string WomanPoliceOfficer = " 👮‍♀️ ";
            public const string WomanScientist = " 👩‍🔬 ";
            public const string WomanSinger = " 👩‍🎤 ";
            public const string WomanSupervillain = " 🦹‍♀️ ";
            public const string WomanSuperhero = " 🦸‍♀️ ";
            public const string WomanTechnologist = " 👩‍💻 ";
            public const string WomanwithHeadscarf = " 🧕 ";
            public const string WomanwithVeil = " 👰‍♀️ ";

            public const string MinusSign = " ➖ ";
            public const string PlusSign = " ➕ ";

            /*
             To be added later:
            
            

            🧙Mage
            🧙‍♂️ManMage
            🧙‍♀️WomanMage
            🧚Fairy
            🧚‍♂️ManFairy
            🧚‍♀️WomanFairy
            🧛Vampire
            🧛‍♂️ManVampire
            🧛‍♀️WomanVampire
            🧜Merperson
            🧜‍♂️Merman
            🧜‍♀️Mermaid
            🧝Elf
            🧝‍♂️ManElf
            🧝‍♀️WomanElf
            🧞Genie
            🧞‍♂️ManGenie
            🧞‍♀️WomanGenie
            🧟Zombie
            🧟‍♂️ManZombie
            🧟‍♀️WomanZombie
            💆PersonGettingMassage
            💆‍♂️ManGettingMassage
            💆‍♀️WomanGettingMassage
            💇PersonGettingHaircut
            💇‍♂️ManGettingHaircut
            💇‍♀️WomanGettingHaircut
            🚶PersonWalking
            🚶‍♂️ManWalking
            🚶‍♀️WomanWalking
            🧍PersonStanding
            🧍‍♂️ManStanding
            🧍‍♀️WomanStanding
            🧎PersonKneeling
            🧎‍♂️ManKneeling
            🧎‍♀️WomanKneeling
            🧑‍🦯PersonwithWhiteCane
            👨‍🦯ManwithWhiteCane
            👩‍🦯WomanwithWhiteCane
            🧑‍🦼PersoninMotorizedWheelchair
            👨‍🦼ManinMotorizedWheelchair
            👩‍🦼WomaninMotorizedWheelchair
            🧑‍🦽PersoninManualWheelchair
            👨‍🦽ManinManualWheelchair
            👩‍🦽WomaninManualWheelchair
            🏃PersonRunning
            🏃‍♂️ManRunning
            🏃‍♀️WomanRunning
            💃WomanDancing
            🕺ManDancing
            🕴️PersoninSuitLevitating
            👯PeoplewithBunnyEars
            👯‍♂️MenwithBunnyEars
            👯‍♀️WomenwithBunnyEars
            🧖PersoninSteamyRoom
            🧖‍♂️ManinSteamyRoom
            🧖‍♀️WomaninSteamyRoom
            🧘PersoninLotusPosition
            🧑‍🤝‍🧑PeopleHoldingHands
            👭WomenHoldingHands
            👫WomanandManHoldingHands
            👬MenHoldingHands
            💏Kiss
            👩‍❤️‍💋‍👨KissWomanMan
            👨‍❤️‍💋‍👨KissManMan
            👩‍❤️‍💋‍👩KissWomanWoman
            💑CouplewithHeart
            👩‍❤️‍👨CouplewithHeartWomanMan
            👨‍❤️‍👨CouplewithHeartManMan
            👩‍❤️‍👩CouplewithHeartWomanWoman
            👪Family
            👨‍👩‍👦FamilyManWomanBoy
            👨‍👩‍👧FamilyManWomanGirl
            👨‍👩‍👧‍👦FamilyManWomanGirlBoy
            👨‍👩‍👦‍👦FamilyManWomanBoyBoy
            👨‍👩‍👧‍👧FamilyManWomanGirlGirl
            👨‍👨‍👦FamilyManManBoy
            👨‍👨‍👧FamilyManManGirl
            👨‍👨‍👧‍👦FamilyManManGirlBoy
            👨‍👨‍👦‍👦FamilyManManBoyBoy
            👨‍👨‍👧‍👧FamilyManManGirlGirl
            👩‍👩‍👦FamilyWomanWomanBoy
            👩‍👩‍👧FamilyWomanWomanGirl
            👩‍👩‍👧‍👦FamilyWomanWomanGirlBoy
            👩‍👩‍👦‍👦FamilyWomanWomanBoyBoy
            👩‍👩‍👧‍👧FamilyWomanWomanGirlGirl
            👨‍👦FamilyManBoy
            👨‍👦‍👦FamilyManBoyBoy
            👨‍👧FamilyManGirl
            👨‍👧‍👦FamilyManGirlBoy
            👨‍👧‍👧FamilyManGirlGirl
            👩‍👦FamilyWomanBoy
            👩‍👦‍👦FamilyWomanBoyBoy
            👩‍👧FamilyWomanGirl
            👩‍👧‍👦FamilyWomanGirlBoy
            👩‍👧‍👧FamilyWomanGirlGirl
            🗣️SpeakingHead
            👤BustinSilhouette
            👥BustsinSilhouette
            🫂PeopleHugging
            👣Footprints
            🧳Luggage
            🌂ClosedUmbrella
            ☂️Umbrella
            🎃JackOLantern
            🧵Thread
            🧶Yarn
            👓Glasses
            🕶️Sunglasses
            🥽Goggles
            🥼LabCoat
            🦺SafetyVest
            👔Necktie
            👕TShirt
            👖Jeans
            🧣Scarf
            🧤Gloves
            🧥Coat
            🧦Socks
            👗Dress
            👘Kimono
            🥻Sari
            🩱OnePieceSwimsuit
            🩲Briefs
            🩳Shorts
            👙Bikini
            👚Woman’sClothes
            👛Purse
            👜Handbag
            👝ClutchBag
            🎒Backpack
            🩴ThongSandal
            👞Man’sShoe
            👟RunningShoe
            🥾HikingBoot
            🥿FlatShoe
            👠HighHeeledShoe
            👡Woman’sSandal
            🩰BalletShoes
            👢Woman’sBoot
            👑Crown
            👒Woman’sHat
            🎩TopHat
            🎓GraduationCap
            🧢BilledCap
            🪖MilitaryHelmet
            ⛑️RescueWorker’sHelmet
            💄Lipstick
            💍Ring
            💼Briefcase
            🩸DropofBlood
            */
        }

        /// <summary>
        /// Emoji dictionary.
        /// <para/> Mix of UTF-32, ASCII, predefined text, and others.
        /// </summary>
        private readonly static Dictionary<string, string> Emojis = new Dictionary<string, string>()
        {
            {"heart",'\u2764'.ToString()},

            {"sniper","(　-_･) ︻デ═一 ▸"},

            {"bug",@"¯\_(ツ)_/¯"},

            {"the bird",@"┌∩┐(◣_◢)┌∩┐"},
            {"the bird alt",@"╭∩╮(Ο_Ο)╭∩╮"},
            {"the bird alt2",@"┌ಠ_ಠ)┌∩┐ ᶠᶸᶜᵏ♥ᵧₒᵤ "},

            {"pistols",@"¯¯̿̿¯̿̿'̿̿̿̿̿̿̿'̿̿'̿̿̿̿̿'̿̿̿)͇̿̿)̿̿̿̿ '̿̿̿̿̿̿\̵͇̿̿\=(•̪̀●́)=o/̵͇̿̿/'̿̿ ̿ ̿̿"},

            {"looking face",@"ô¿ô"},
            {"real face",@"( ͡° ͜ʖ ͡°)﻿"},
            {"sad face",@"ε(´סּ︵סּ`)з"},
            {"happy face",@"【ツ】"},

            {"hit",@" █▬█ █ ▀█▀ "},
            {"dumbell",@" ❚█══█❚ "},

            {"ghost party",@"ʕ•̫͡•ʕ*̫͡*ʕ•͓͡•ʔ-̫͡-ʕ•̫͡•ʔ*̫͡*ʔ-̫͡-ʔ"},

            {"scissors", char.ConvertFromUtf32(0x02702)},
            {"infinity", char.ConvertFromUtf32(8734)},
            {"four dots", char.ConvertFromUtf32(8759)},

            {"plus", char.ConvertFromUtf32(8853)},
            {"minus", char.ConvertFromUtf32(8854)},
            {"cross", char.ConvertFromUtf32(8855)},
            {"division", char.ConvertFromUtf32(10808)},

            {"three dot line", char.ConvertFromUtf32(8943)},
            {"left arrow", char.ConvertFromUtf32(8592)},
            {"up arrow", char.ConvertFromUtf32(8593)},
            {"right arrow", char.ConvertFromUtf32(8594)},
            {"down arrow", char.ConvertFromUtf32(8595)},
            {"block arrow right", char.ConvertFromUtf32(8998)},
            {"block arrow left", char.ConvertFromUtf32(9003)},
            {"a circle capital", char.ConvertFromUtf32(9398)},
            {"b circle capital", char.ConvertFromUtf32(9399)},
            {"c circle capital", char.ConvertFromUtf32(9400)},
            {"d circle capital", char.ConvertFromUtf32(9401)},
            {"e circle capital", char.ConvertFromUtf32(9402)},
            {"f circle capital", char.ConvertFromUtf32(9403)},
            {"g circle capital", char.ConvertFromUtf32(9404)},
            {"h circle capital", char.ConvertFromUtf32(9405)},
            {"i circle capital", char.ConvertFromUtf32(9406)},
            {"j circle capital", char.ConvertFromUtf32(9407)},
            {"k circle capital", char.ConvertFromUtf32(9408)},
            {"l circle capital", char.ConvertFromUtf32(9409)},
            {"m circle capital", char.ConvertFromUtf32(9410)},
            {"n circle capital", char.ConvertFromUtf32(9411)},
            {"o circle capital", char.ConvertFromUtf32(9412)},
            {"p circle capital", char.ConvertFromUtf32(9413)},
            {"q circle capital", char.ConvertFromUtf32(9414)},
            {"r circle capital", char.ConvertFromUtf32(9415)},
            {"s circle capital", char.ConvertFromUtf32(9416)},
            {"t circle capital", char.ConvertFromUtf32(9417)},
            {"u circle capital", char.ConvertFromUtf32(9418)},
            {"v circle capital", char.ConvertFromUtf32(9419)},
            {"w circle capital", char.ConvertFromUtf32(9420)},
            {"x circle capital", char.ConvertFromUtf32(9421)},
            {"y circle capital", char.ConvertFromUtf32(9422)},
            {"z circle capital", char.ConvertFromUtf32(9423)},

            {"a circle lowercase", char.ConvertFromUtf32(9424)},
            {"b circle lowercase", char.ConvertFromUtf32(9425)},
            {"c circle lowercase", char.ConvertFromUtf32(9426)},
            {"d circle lowercase", char.ConvertFromUtf32(9427)},
            {"e circle lowercase", char.ConvertFromUtf32(9428)},
            {"f circle lowercase", char.ConvertFromUtf32(9429)},
            {"g circle lowercase", char.ConvertFromUtf32(9430)},
            {"h circle lowercase", char.ConvertFromUtf32(9431)},
            {"i circle lowercase", char.ConvertFromUtf32(9432)},
            {"j circle lowercase", char.ConvertFromUtf32(9433)},
            {"k circle lowercase", char.ConvertFromUtf32(9434)},
            {"l circle lowercase", char.ConvertFromUtf32(9435)},
            {"m circle lowercase", char.ConvertFromUtf32(9436)},
            {"n circle lowercase", char.ConvertFromUtf32(9437)},
            {"o circle lowercase", char.ConvertFromUtf32(9438)},
            {"p circle lowercase", char.ConvertFromUtf32(9439)},
            {"q circle lowercase", char.ConvertFromUtf32(9440)},
            {"r circle lowercase", char.ConvertFromUtf32(9441)},
            {"s circle lowercase", char.ConvertFromUtf32(9442)},
            {"t circle lowercase", char.ConvertFromUtf32(9443)},
            {"u circle lowercase", char.ConvertFromUtf32(9444)},
            {"v circle lowercase", char.ConvertFromUtf32(9445)},
            {"w circle lowercase", char.ConvertFromUtf32(9446)},
            {"x circle lowercase", char.ConvertFromUtf32(9447)},
            {"y circle lowercase", char.ConvertFromUtf32(9448)},
            {"z circle lowercase", char.ConvertFromUtf32(9449)},

            {"sun", char.ConvertFromUtf32(9728)},
            {"cloud", char.ConvertFromUtf32(9729)},
            {"umbrella", char.ConvertFromUtf32(9730)},
            {"star", char.ConvertFromUtf32(9733)},
            {"skull crossbones", char.ConvertFromUtf32(9760)},

            {"frown", char.ConvertFromUtf32(9785)},
            {"smiley", char.ConvertFromUtf32(9786)},
            {"smiley filled", char.ConvertFromUtf32(9787)},

            {"female", char.ConvertFromUtf32(9792)},
            {"male", char.ConvertFromUtf32(9794)},

            {"music note", char.ConvertFromUtf32(9834)},

            {"caution", char.ConvertFromUtf32(9888)},

            {"checkmark", char.ConvertFromUtf32(10004)},
            {"crossmark", char.ConvertFromUtf32(10006)},
            {"crossmark alt", char.ConvertFromUtf32(10008)},

            {"circle", char.ConvertFromUtf32(8413)},
            {"square", char.ConvertFromUtf32(8414)},
            {"diamond", char.ConvertFromUtf32(8415)},
            {"cylinder", char.ConvertFromUtf32(8419)},

            {"crossout", char.ConvertFromUtf32(8416)},

            {"fahrenheit", char.ConvertFromUtf32(8457)},
            {"celsius", char.ConvertFromUtf32(8451)},
        };
    }
}