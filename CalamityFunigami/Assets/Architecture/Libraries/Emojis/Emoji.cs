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
            public const string Recycle = " ♻️ ";
            public const string ClapperBoard = " 🎬 ";
            public const string Gear = " ⚙️ ";
            public const string Controller = " 🎮 ";
            public const string Ninja = " 🥷 ";
            public const string Plug = " 🔌 ";
            public const string Rocket = " 🚀 ";
            public const string Abacus = " 🧮 ";
            public const string Package = " 📦 ";
            public const string Scroll = " 📜 ";
            public const string Boot = " 🥾 ";
            public const string BlackSquare = " ⬛️ ";
            public const string GrinningFace = " 😀 ";
            public const string GrinningFacewithBigEyes = " 😃 ";
            public const string GrinningFacewithSmilingEyes = " 😄 ";
            public const string BeamingFacewithSmilingEyes = " 😁 ";
            public const string GrinningSquintingFace = " 😆 ";
            public const string GrinningFacewithSweat = " 😅 ";
            public const string RollingontheFloorLaughing = " 🤣 ";
            public const string FacewithTearsofJoy = " 😂 ";
            public const string SlightlySmilingFace = " 🙂 ";
            public const string UpsideDownFace = " 🙃 ";
            public const string WinkingFace = " 😉 ";
            public const string SmilingFacewithSmilingEyes = " 😊 ";
            public const string SmilingFacewithHalo = " 😇 ";
            public const string SmilingFacewithHearts = " 🥰 ";
            public const string SmilingFacewithHeartEyes = " 😍 ";
            public const string StarStruck = " 🤩 ";
            public const string FaceBlowingaKiss = " 😘 ";
            public const string KissingFace = " 😗 ";
            public const string SmilingFace = " ☺️ ";
            public const string KissingFacewithClosedEyes = " 😚 ";
            public const string KissingFacewithSmilingEyes = " 😙 ";
            public const string SmilingFacewithTear = " 🥲 ";
            public const string VulcanSalute = " 🖖 ";
            public const string TwoFingersTouching = " 👉👈 ";
            public const string Speaker = " 🔊 ";
            public const string TestTube = " 🧪 ";
            public const string MagnifyingGlass = " 🔎 ";
            public const string placeholder = " 🩸 ";

            /*
             To be added later:
            😋FaceSavoringFood
            😛FacewithTongue
            😜WinkingFacewithTongue
            🤪ZanyFace
            😝SquintingFacewithTongue
            🤑MoneyMouthFace
            🤗SmilingFacewithOpenHands
            🤭FacewithHandOverMouth
            🤫ShushingFace
            🤔ThinkingFace
            🤐ZipperMouthFace
            🤨FacewithRaisedEyebrow
            😐NeutralFace
            😑ExpressionlessFace
            😶FaceWithoutMouth
            😶‍🌫️FaceinClouds
            😏SmirkingFace
            😒UnamusedFace
            🙄FacewithRollingEyes
            😬GrimacingFace
            😮‍💨FaceExhaling
            🤥LyingFace
            😌RelievedFace
            😔PensiveFace
            😪SleepyFace
            🤤DroolingFace
            😴SleepingFace
            😷FacewithMedicalMask
            🤒FacewithThermometer
            🤕FacewithHeadBandage
            🤢NauseatedFace
            🤮FaceVomiting
            🤧SneezingFace
            🥵HotFace
            🥶ColdFace
            🥴WoozyFace
            😵FacewithCrossedOutEyes
            😵‍💫FacewithSpiralEyes
            🤯ExplodingHead
            🤠CowboyHatFace
            🥳PartyingFace
            🥸DisguisedFace
            😎SmilingFacewithSunglasses
            🤓NerdFace
            🧐FacewithMonocle
            😕ConfusedFace
            😟WorriedFace
            🙁SlightlyFrowningFace
            ☹️FrowningFace
            😮FacewithOpenMouth
            😯HushedFace
            😲AstonishedFace
            😳FlushedFace
            🥺PleadingFace
            😦FrowningFacewithOpenMouth
            😧AnguishedFace
            😨FearfulFace
            😰AnxiousFacewithSweat
            😥SadbutRelievedFace
            😢CryingFace
            😭LoudlyCryingFace
            😱FaceScreaminginFear
            😖ConfoundedFace
            😣PerseveringFace
            😞DisappointedFace
            😓DowncastFacewithSweat
            😩WearyFace
            😫TiredFace
            🥱YawningFace
            😤FacewithSteamFromNose
            😡EnragedFace
            😠AngryFace
            🤬FacewithSymbolsonMouth
            😈SmilingFacewithHorns
            👿AngryFacewithHorns
            💀Skull
            ☠️SkullandCrossbones
            💩PileofPoo
            🤡ClownFace
            👹Ogre
            👺Goblin
            👻Ghost
            👽Alien
            👾AlienMonster
            🤖Robot
            😺GrinningCat
            😸GrinningCatwithSmilingEyes
            😹CatwithTearsofJoy
            😻SmilingCatwithHeartEyes
            😼CatwithWrySmile
            😽KissingCat
            🙀WearyCat
            😿CryingCat
            😾PoutingCat
            💋KissMark
            👋WavingHand
            🤚RaisedBackofHand
            🖐️HandwithFingersSplayed
            ✋RaisedHand
            👌OKHand
            🤌PinchedFingers
            🤏PinchingHand
            ✌️VictoryHand
            🤞CrossedFingers
            🤟LoveYouGesture
            🤘SignoftheHorns
            🤙CallMeHand
            👈BackhandIndexPointingLeft
            👉BackhandIndexPointingRight
            👆BackhandIndexPointingUp
            🖕MiddleFinger
            👇BackhandIndexPointingDown
            ☝️IndexPointingUp
            👍ThumbsUp
            👎ThumbsDown
            ✊RaisedFist
            👊OncomingFist
            🤛LeftFacingFist
            🤜RightFacingFist
            👏ClappingHands
            🙌RaisingHands
            👐OpenHands
            🤲PalmsUpTogether
            🤝Handshake
            🙏FoldedHands
            ✍️WritingHand
            💅NailPolish
            🤳Selfie
            💪FlexedBiceps
            🦾MechanicalArm
            🦿MechanicalLeg
            🦵Leg
            🦶Foot
            👂Ear
            🦻EarwithHearingAid
            👃Nose
            🧠Brain
            🫀AnatomicalHeart
            🫁Lungs
            🦷Tooth
            🦴Bone
            👀Eyes
            👁️Eye
            👅Tongue
            👄Mouth
            👶Baby
            🧒Child
            👦Boy
            👧Girl
            🧑Person
            👱PersonBlondHair
            👨Man
            🧔PersonBeard
            👨‍🦰ManRedHair
            👨‍🦱ManCurlyHair
            👨‍🦳ManWhiteHair
            👨‍🦲ManBald
            👩Woman
            👩‍🦰WomanRedHair
            🧑‍🦰PersonRedHair
            👩‍🦱WomanCurlyHair
            🧑‍🦱PersonCurlyHair
            👩‍🦳WomanWhiteHair
            🧑‍🦳PersonWhiteHair
            👩‍🦲WomanBald
            🧑‍🦲PersonBald
            👱‍♀️WomanBlondHair
            👱‍♂️ManBlondHair
            🧓OlderPerson
            👴OldMan
            👵OldWoman
            🙍PersonFrowning
            🙍‍♂️ManFrowning
            🙍‍♀️WomanFrowning
            🙎PersonPouting
            🙎‍♂️ManPouting
            🙎‍♀️WomanPouting
            🙅PersonGesturingNo
            🙅‍♂️ManGesturingNo
            🙅‍♀️WomanGesturingNo
            🙆PersonGesturingOK
            🙆‍♂️ManGesturingOK
            🙆‍♀️WomanGesturingOK
            💁PersonTippingHand
            💁‍♂️ManTippingHand
            💁‍♀️WomanTippingHand
            🙋PersonRaisingHand
            🙋‍♂️ManRaisingHand
            🙋‍♀️WomanRaisingHand
            🧏DeafPerson
            🧏‍♂️DeafMan
            🧏‍♀️DeafWoman
            🙇PersonBowing
            🙇‍♂️ManBowing
            🙇‍♀️WomanBowing
            🤦PersonFacepalming
            🤦‍♂️ManFacepalming
            🤦‍♀️WomanFacepalming
            🤷PersonShrugging
            🤷‍♂️ManShrugging
            🤷‍♀️WomanShrugging
            🧑‍⚕️HealthWorker
            👨‍⚕️ManHealthWorker
            👩‍⚕️WomanHealthWorker
            🧑‍🎓Student
            👨‍🎓ManStudent
            👩‍🎓WomanStudent
            🧑‍🏫Teacher
            👨‍🏫ManTeacher
            👩‍🏫WomanTeacher
            🧑‍⚖️Judge
            👨‍⚖️ManJudge
            👩‍⚖️WomanJudge
            🧑‍🌾Farmer
            👨‍🌾ManFarmer
            👩‍🌾WomanFarmer
            🧑‍🍳Cook
            👨‍🍳ManCook
            👩‍🍳WomanCook
            🧑‍🔧Mechanic
            👨‍🔧ManMechanic
            👩‍🔧WomanMechanic
            🧑‍🏭FactoryWorker
            👨‍🏭ManFactoryWorker
            👩‍🏭WomanFactoryWorker
            🧑‍💼OfficeWorker
            👨‍💼ManOfficeWorker
            👩‍💼WomanOfficeWorker
            🧑‍🔬Scientist
            👨‍🔬ManScientist
            👩‍🔬WomanScientist
            🧑‍💻Technologist
            👨‍💻ManTechnologist
            👩‍💻WomanTechnologist
            🧑‍🎤Singer
            👨‍🎤ManSinger
            👩‍🎤WomanSinger
            🧑‍🎨Artist
            👨‍🎨ManArtist
            👩‍🎨WomanArtist
            🧑‍✈️Pilot
            👨‍✈️ManPilot
            👩‍✈️WomanPilot
            🧑‍🚀Astronaut
            👨‍🚀ManAstronaut
            👩‍🚀WomanAstronaut
            🧑‍🚒Firefighter
            👨‍🚒ManFirefighter
            👩‍🚒WomanFirefighter
            👮PoliceOfficer
            👮‍♂️ManPoliceOfficer
            👮‍♀️WomanPoliceOfficer
            🕵️Detective
            🕵️‍♂️ManDetective
            🕵️‍♀️WomanDetective
            💂Guard
            💂‍♂️ManGuard
            💂‍♀️WomanGuard        
            👷ConstructionWorker
            👷‍♂️ManConstructionWorker
            👷‍♀️WomanConstructionWorker
            🤴Prince
            👸Princess
            👳PersonWearingTurban
            👳‍♂️ManWearingTurban
            👳‍♀️WomanWearingTurban
            👲PersonwithSkullcap
            🧕WomanwithHeadscarf
            🤵PersoninTuxedo
            🤵‍♂️ManinTuxedo
            🤵‍♀️WomaninTuxedo
            👰PersonwithVeil
            👰‍♂️ManwithVeil
            👰‍♀️WomanwithVeil
            🤰PregnantWoman
            🤱BreastFeeding
            👩‍🍼WomanFeedingBaby
            👨‍🍼ManFeedingBaby
            🧑‍🍼PersonFeedingBaby
            👼BabyAngel
            🎅SantaClaus
            🤶MrsClaus
            🧑‍🎄MxClaus
            🦸Superhero
            🦸‍♂️ManSuperhero
            🦸‍♀️WomanSuperhero
            🦹Supervillain
            🦹‍♂️ManSupervillain
            🦹‍♀️WomanSupervillain
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