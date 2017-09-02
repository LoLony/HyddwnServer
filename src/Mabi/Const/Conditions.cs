﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;

namespace Aura.Mabi.Const
{
    [Flags]
    public enum ConditionsA : ulong
    {
        Poisoned = 0x0000000000000001,
        Deadly = 0x0000000000000002,
        PotionPoisoning = 0x0000000000000004,
        Numb = 0x0000000000000008,
        Silence = 0x0000000000000010,
        Petrified = 0x0000000000000020,
        Coward = 0x0000000000000040,
        Outraged = 0x0000000000000080,
        Confused = 0x0000000000000100,
        Combat2xExp = 0x0000000000000200,
        Slow = 0x0000000000000400,
        Luck = 0x0000000000000800,
        Misfortune = 0x0000000000001000,
        LeadersBlessing = 0x0000000000002000,
        Explode1 = 0x0000000000004000,
        Explode2 = 0x0000000000008000,
        Mirage = 0x0000000000010000,
        Weak = 0x0000000000020000,
        PVPPenalty = 0x0000000000040000,
        Lethargic = 0x0000000000080000,
        CancelDarkKnight = 0x0000000000100000,
        Camouflage = 0x0000000000200000,
        Blessed = 0x0000000000400000,
        Invisible = 0x0000000000800000,
        NoTrade = 0x0000000001000000,
        Following = 0x0000000002000000,
        ChatBanned = 0x0000000004000000,
        ViewCutScene = 0x0000000008000000,
        Ensemble = 0x0000000010000000,
        SharpAiming = 0x0000000020000000,
        FastCasting = 0x0000000040000000,
        Weaken = 0x0000000080000000,
        MushroomCookie = 0x0000000100000000,
        CryFood = 0x0000000200000000,
        CrazyFood = 0x0000000400000000,
        SelfPraiseFood = 0x0000000800000000,
        HeartFood = 0x0000001000000000,
        PoisonImmune = 0x0000002000000000,
        PetrificationImmunity = 0x0000004000000000,
        ManaUsageReduction = 0x0000008000000000,
        StaminaUsageReduction = 0x0000010000000000,
        ExplosiveImmunity = 0x0000020000000000,
        StompImmunity = 0x0000040000000000,
        ManaUsageIncrease = 0x0000080000000000,
        StaminaUsageIncrease = 0x0000100000000000,
        ShareFood = 0x0000200000000000,
        IceShield = 0x0000400000000000,
        FireShield = 0x0000800000000000,
        LightningShield = 0x0001000000000000,
        NaturalShield = 0x0002000000000000,
        MoveSlow = 0x0004000000000000,
        FastGathering = 0x0008000000000000,
        Charge = 0x0010000000000000,
        AttackSpeed = 0x0020000000000000,
        Moonlight = 0x0040000000000000,
        SulfurPoison = 0x0080000000000000,
        Burn = 0x0100000000000000,
        Freeze = 0x0200000000000000,
        StarFood = 0x0400000000000000,
        ManaShield = 0x0800000000000000,
        CherryTree = 0x1000000000000000,
        Boose = 0x2000000000000000,
        FastCasting2 = 0x4000000000000000,
        WeaponAttackBoost = 0x8000000000000000,
        All = 0xFFFFFFFFFFFFFFFF
    }

    [Flags]
    public enum ConditionsB : ulong
    {
        Transparent = 0x0000000000000001,
        CombatExpPlus1_1 = 0x0000000000000002,
        CombatExpPlus2 = 0x0000000000000004,
        Bewildered = 0x0000000000000008,
        ElephantShower = 0x0000000000000010,
        Curse = 0x0000000000000020,
        Blind = 0x0000000000000040,
        Ice = 0x0000000000000080,
        ProductionRateChange = 0x0000000000000100,
        ItemProfInc = 0x0000000000000200,
        AlchemyCloud = 0x0000000000000400,
        FailedBotCheck = 0x0000000000000800,
        SnowStorm = 0x0000000000001000,
        Doppelganger = 0x0000000000002000,
        Demigod = 0x0000000000004000,
        DoppelgangerLaugh = 0x0000000000008000,
        DoppelgangerPain = 0x0000000000010000,
        ValentineHappy = 0x0000000000020000,
        ValentineUnhappy = 0x0000000000040000,
        FashionShow = 0x0000000000080000,
        LargeUpper = 0x0000000000100000,
        DumbTalking = 0x0000000000200000,
        LargeLower = 0x0000000000400000,
        VeryBig = 0x0000000000800000,
        VerySmall = 0x0000000001000000,
        Blessed = 0x0000000002000000,
        Outraged = 0x0000000004000000,
        MiniPotion = 0x0000000008000000,
        NoConsume = 0x0000000010000000,
        StoneBarrier = 0x0000000020000000,
        Discharge = 0x0000000040000000,
        Stand = 0x0000000080000000,
        LifeExpInc = 0x0000000100000000,
        CombatExpInc = 0x0000000200000000,
        MagicExpInc = 0x0000000400000000,
        AlchemyExpInc = 0x0000000800000000,
        NameColorChange = 0x0000001000000000,
        TowerCylinder = 0x0000002000000000,
        DemiStrInc = 0x0000004000000000,
        DemiDexInc = 0x0000008000000000,
        DemiWillInc = 0x0000010000000000,
        DemiLuckInc = 0x0000020000000000,
        DemiIntInc = 0x0000040000000000,
        DemiFuryInc = 0x0000080000000000,
        DemiSpearInc = 0x0000100000000000,
        DemiShadowInc = 0x0000200000000000,
        DemiDurationInc = 0x0000400000000000,
        DemiCooldownDec = 0x0000800000000000,
        DemiBrionacDmgInc = 0x0001000000000000,
        DemiBrionacCritInc = 0x0002000000000000,
        BardInc = 0x0004000000000000,
        SpeedInc = 0x0008000000000000,
        DemiImmune = 0x0010000000000000,
        HeightChange = 0x0020000000000000,
        RavenAttack = 0x0040000000000000,
        NuadhaPhase = 0x0080000000000000,
        MountAttack = 0x0100000000000000,
        StatsDec = 0x0200000000000000,
        ShadowBonus = 0x0400000000000000,
        ItemDropInc = 0x0800000000000000,
        ItemDropInc2 = 0x1000000000000000,
        FishDropInc = 0x2000000000000000,
        FishDropInc2 = 0x4000000000000000,
        ChatColorChange = 0x8000000000000000,
        All = 0xFFFFFFFFFFFFFFFF
    }

    [Flags]
    public enum ConditionsC : ulong
    {
        CombatExpBoost = 0x0000000000000001,
        DamageCurse = 0x0000000000000002,
        Frenzy = 0x0000000000000004,
        NuadhaSet = 0x0000000000000008,
        TheatreDungeonSpotLight = 0x0000000000000010,
        HamelinContract = 0x0000000000000020,
        OutOfBody = 0x0000000000000040,
        SpiritClear = 0x0000000000000080,
        HandsFull = 0x0000000000000100,
        TrollRecorvery = 0x0000000000000200,
        SmashEnhancement = 0x0000000000000400,
        AssaultSlashEnhancement = 0x0000000000000800,
        ChargeEnhancement = 0x0000000000001000,
        IceBoltEnhancement = 0x0000000000002000,
        FireBoltEnhancement = 0x0000000000004000,
        HealingEnhancement = 0x0000000000008000,
        FlameBurstEnhancement = 0x0000000000010000,
        WaterCannonEnhancement = 0x0000000000020000,
        LifeDrainEnhancement = 0x0000000000040000,
        MagnumShotEnhancement = 0x0000000000080000,
        SupportShotEnhancement = 0x0000000000100000,
        FishingEnhancement = 0x0000000000200000,
        RefiningEnhancement = 0x0000000000400000,
        BlacksmithEnhancement = 0x0000000000800000,
        MetallurgyEnhancement = 0x0000000001000000,
        ArmorBearRoar = 0x0000000002000000,
        RosemaryGloves = 0x0000000004000000,
        FlyingPetBoost = 0x0000000008000000,
        ClaudiusPursuit = 0x0000000010000000,
        AnimalCharacterTrainingKit = 0x0000000020000000,
        AnimalCharacterTrainingBoost = 0x0000000040000000,
        FlyingAnimalCharacterTrainingBoost = 0x0000000080000000,
        TodayShadowMissionComplete = 0x0000000100000000,
        UpToLadeca = 0x0000000200000000,
        OXQuiz = 0x0000000400000000,
        PetLandBoost = 0x0000000800000000,
        CommerceTransport = 0x0000001000000000,
        WingsOfEclipse = 0x0000002000000000,
        WingsOfRage = 0x0000004000000000,
        StatusBuffPotion = 0x0000008000000000,
        PersonaSpeedUp = 0x0000010000000000,
        Hurry = 0x0000020000000000,
        WeaponSealRemoval = 0x0000040000000000,
        MiniCharacterSize = 0x0000080000000000,
        MetalwareMoveSpeedUp = 0x0000100000000000,
        MetalwareCommerceSpeedUp = 0x0000200000000000,
        FishingChair = 0x0000400000000000,
        CommerceWarranty = 0x0000800000000000,
        PotionBoost = 0x0001000000000000,
        MagicAttackEnhance = 0x0002000000000000,
        Zombie = 0x0004000000000000,
        MusicalPetrification = 0x0008000000000000,
        GoldStrikeEnhancement = 0x0010000000000000,
        OutlawPursuit = 0x0020000000000000,
        DefProtectDebuff = 0x0040000000000000,
        RespiteAftereffect = 0x0080000000000000,
        FastMove = 0x0100000000000000,
        Pinned = 0x0200000000000000,
        Dazed = 0x0400000000000000,
        MaritalPounding = 0x0800000000000000,
        MerrowsCurse = 0x1000000000000000,
        FighterSkillTrainingBoost = 0x2000000000000000,
        DekalFollow = 0x4000000000000000,
        BomberMan = 0x8000000000000000,
        All = 0xFFFFFFFFFFFFFFFF
    }

    [Flags]
    public enum ConditionsD : ulong
    {
        MusicOfHaste = 0x0000000000000001,
        MagicalMusic = 0x0000000000000002,
        MusicOfHarvest = 0x0000000000000004,
        MusicOfPeace = 0x0000000000000008,
        Batter = 0x0000000000000010,
        RescueRevive = 0x0000000000000020,
        CommerceTransportLock = 0x0000000000000040,
        MusicSkillExpBoost = 0x0000000000000080,
        MarionetteSkillExpBoost = 0x0000000000000100,
        FlameOfResurrection = 0x0000000000000200,
        WireBound = 0x0000000000000400,
        WireTangle = 0x0000000000000800,
        TheatreMissionCrystal = 0x0000000000001000,
        BountyHunter = 0x0000000000002000,
        MarionetteSpirit = 0x0000000000004000,
        ImmuneInterrupt = 0x0000000000008000,
        MarionetteSpiralBuff = 0x0000000000010000,
        SkillStun = 0x0000000000020000,
        FlameOfResurrectionEx = 0x0000000000040000,
        BoneDragonDevilRush = 0x0000000000080000,
        BoneDragonDevilCry = 0x0000000000100000,
        TransformationEnhancement = 0x0000000000200000,
        IncreaseDamage = 0x0000000000400000,
        DecreaseDamage = 0x0000000000800000,
        DecreaseDefenseProtection = 0x0000000001000000,
        DoubleCompleteSkillExp = 0x0000000002000000,
        WindmillEnhance = 0x0000000004000000,
        Tangled = 0x0000000008000000,
        BerserkArmor = 0x0000000010000000,
        RestfulWind = 0x0000000020000000,
        RestfulWindsEmbrace = 0x0000000040000000,
        IncreaseDefenseProtection = 0x0000000080000000,
        Steadfast = 0x0000000100000000,
        Absorbtion = 0x0000000200000000,
        QuestExpBonus = 0x0000000400000000,
        RaidCrystal = 0x0000000800000000,
        RaidBossDamageEnhance = 0x0000001000000000,
        DragonSummonBonus = 0x0000002000000000,
        WayOfTheGun = 0x0000004000000000,
        DualGunSkillExpBoost = 0x0000008000000000,
        SpreadWings = 0x0000010000000000,
        MeteorStrike = 0x0000020000000000,
        InstanceCasting = 0x0000040000000000,
        Frostbite = 0x0000080000000000,
        EnhancedAssaultSlash = 0x0000100000000000,
        EngineShocked = 0x0000200000000000,
        MusicChorus = 0x0000400000000000,
        MusicSongOfSigh = 0x0000800000000000,
        AlchemyElemental = 0x0001000000000000,
        GoldenTime = 0x0002000000000000,
        InstrumentInstalled = 0x0004000000000000,
        LifeSkillExpBoostToday = 0x0008000000000000,
        DoubleCombatExpToday = 0x0010000000000000,
        ShadowMissionBonusToday = 0x0020000000000000,
        AlchemyElementalSpark = 0x0040000000000000,
        AlchemyWindPassive = 0x0080000000000000,
        CurseofAbyss = 0x0200000000000000,
        DukeBleeding = 0x0400000000000000,
        DukeTemptation = 0x0800000000000000,
        EmergencyEscape = 0x1000000000000000,
        Clocking = 0x2000000000000000,
        BeginnerPetBonus = 0x4000000000000000,
        GhostVoice = 0x8000000000000000,
        All = 0xFFFFFFFFFFFFFFFF
    }

    [Flags]
    public enum ConditionsE : ulong
    {
        SlientVoice = 0x0000000000000001,
        BeastRoar = 0x0000000000000002,
        DanceTime = 0x0000000000000004,
        GhostMadness = 0x0000000000000008,
        EasternVampireProtection = 0x0000000000000010,
        HalloweenChannelBuff = 0x0000000000000020,
        HalloweenWorldEventQuestCheck = 0x0000000000000040,
        FlightBoost = 0x0000000000000080, // IriaSkyRacingBoost
        SpeedDown = 0x0000000000000100,
        Transformation = 0x0000000000000200,
        Stun = 0x0000000000000400,
        TyphoonBoost = 0x0000000000000800, // IriaSkyRacingWindBoost
        FreezeUsableItem = 0x0000000000001000,
        AngryMonster = 0x0000000000002000,
        CommerceSpeed = 0x0000000000004000,
        LoveyDovey = 0x0000000000008000,
        CookingProductionExpBoost = 0x0000000000010000,
        LadderEscape = 0x0000000000020000,
        BattleMode = 0x0000000000040000,
        MovementSpeedIncreased = 0x0000000000080000, // OverlapSpeedUp
        DefenseDebuff = 0x0000000000100000,
        BossInvincible = 0x0000000000200000,
        BossAmbientSound = 0x0000000000400000,
        PossessedRuairiSwngSkillDotDamage = 0x0000000000800000,
        ShadowMissionExpBoost = 0x0000000001000000,
        NinjaSkillTrainingBoost = 0x0000000002000000,
        SpeedBoost = 0x0000000004000000, // Increase movement and gathering speed
        RegenerationEnhance = 0x0000000008000000, // Increase HP, Wound, MP, Strength recovery rate
        FairySleep = 0x0000000010000000,
        FairySpeedReduce = 0x0000000020000000,
        FairyMagicImmune = 0x0000000040000000,
        Refreshed = 0x0000000080000000, // NearObjectBuff
        Contagion = 0x0000000100000000, // SacredInfection
        Confinement = 0x0000000200000000, // SacredImprison
        FanaticismBuff = 0x0000000400000000,
        BindingTiming = 0x0000000800000000,
        SmitingTiming = 0x0000001000000000,
        ApostleWarding = 0x0000002000000000,
        SmitingEnhancementEffect = 0x0000004000000000,
        ShieldOfTrust = 0x0000008000000000,
        CelestialSpike = 0x0000010000000000,
        Fatty = 0x0000020000000000, // UseItemChangeScale
        CrusaderWardingPower = 0x0000040000000000, // ShieldOfTrustDefense
        CelestialSpikeDivineDamage = 0x0000080000000000,
        SummonLock = 0x0000100000000000,
        FanaticismDebuff = 0x0000200000000000,
        Meditation = 0x0000400000000000,
        PerfectPitch = 0x0000800000000000, // Perfect_Playing
        Incarnation = 0x0001000000000000,

        // 0x0002000000000000~0x1000000000000000 missing in client?
        CloseCombatBleedingEffect = 0x2000000000000000, // TalentRenovationCombatBleeding
        CloseCombatDazedEffect = 0x4000000000000000, // TalentRenovationCombatGroggy
        CloseCombatShatterEffect = 0x8000000000000000, // TalentRenovationCombatDecreaseDefenseProtect
        All = 0xFFFFFFFFFFFFFFFF
    }

    [Flags]
    public enum ConditionsF : ulong
    {
        IgnoreCommercePenalty = 0x0000000000000001,
        RageStack = 0x0000000000000002, // Bash Combo
        RageStackMax = 0x0000000000000004, // Bash Combo Max
        DamageCurse2 = 0x0000000000000008,
        CriticalDamageUp = 0x0000000000000010, // Enhanced Critical Damage
        BashEnhance = 0x0000000000000020,
        DurabilityLossDecrease = 0x0000000000000040,
        SheepSleep = 0x0000000000000080, // Sleeping Wool
        SheepBewitch = 0x0000000000000100, // Giving Off the Charm
        TouchMoveUp = 0x0000000000000200, // Light as Wool
        SkillIceSpearWithDamageReduce = 0x0000000000000400, // Ice Spear Deep Freeze
        SkillIceboltSlow = 0x0000000000000800, // Icebolt Hobble
        HpUpBonus = 0x0000000000001000,
        MaxDamageBonus = 0x0000000000002000,
        HpRecoverSpeedBonus = 0x0000000000004000,
        ManaRecoverSpeedBonus = 0x0000000000008000,
        StaminaRecoverSpeedBonus = 0x0000000000010000,
        CriticalRateBonus = 0x0000000000020000,
        TalentSkillExpBonus = 0x0000000000040000, // Increases Training Experience for particular talent skills
        MeleeDamageBonus = 0x0000000000080000, // Increases Close Combat Talent Skill damage
        MagicSpeedBonus = 0x0000000000100000, // Increases Magic Talent Skill Casting Speed
        RangeAttackSpeedBonus = 0x0000000000200000, // Increases Archer Talent Aim Speed
        CollectingSpeedBonus = 0x0000000000400000,
        SheepWolfWorldQuest = 0x0000000000800000, // Sheep Wolf World Quest check
        UrgentShotRangeSpeedBonus = 0x0000000001000000, // Ranged aiming speed increased
        Immobilize = 0x0000000002000000,
        TuanPetSleep = 0x0000000004000000,
        TuanPetSlow = 0x0000000008000000,
        MagicalEnergySupply = 0x0000000010000000,
        MagicalEnergyCancel = 0x0000000020000000,
        GodHand = 0x0000000040000000,
        DefenseProtectDebuff = 0x0000000080000000,
        DivineLinkMasterBuff = 0x0000000100000000,
        DivineLinkPetBuff = 0x0000000200000000,
        CookingExp1 = 0x0000000400000000, // Cooking Training EXP Boost
        CookingExp2 = 0x0000000800000000, // Cooking Training EXP Boost
        CookingQuality = 0x0000001000000000, // Recipe Quality Boost
        CookingBuffing = 0x0000002000000000, // Cooking Buff Duration Increased
        JudgementBladeEnhance = 0x0000004000000000,
        LanceChargeEnhance = 0x0000008000000000,
        CurseOfDevil = 0x0000010000000000, // Fallen Fairy Summon Skill
        BlessingOfDevilMove = 0x0000020000000000, // Fallen Fairy Summon Skill Movement Speed Buff
        BlessingOfDevilAttack = 0x0000040000000000, // Fallen Fairy Summon Skill Attack Speed Buff
        ComebackMilesian = 0x0000080000000000, // the Returned
        FlownSkyLantern = 0x0000100000000000,
        ProductionRateEnhance = 0x0000200000000000, // Craft Success Rate Enhanced
        FiresOfAllure = 0x0000400000000000, // Safeguard
        PhantomBerserk = 0x0000800000000000,
        PhantomFear = 0x0001000000000000,
        EnjoyPerformance = 0x0002000000000000, // Captive Audience
        SweetIllusion = 0x0004000000000000, // Soul Rift
        DoubleCombatExpOnEvent = 0x0008000000000000,
        BalloonReviveLock = 0x0010000000000000, // Cannot be revived by the balloon
        ForgetTarget = 0x0020000000000000, // Stealth Soul
        Cancer1 = 0x0040000000000000, // Doki Doki Wig Condition 1
        Sagittarius1 = 0x0080000000000000, // Doki Doki Wig Condition 2
        Capricorn1 = 0x0100000000000000, // Doki Doki Wig Condition 3
        CompleteLock = 0x0200000000000000,
        HitBossMonster = 0x0400000000000000, // Boss Monster Hit Check Condition
        SuchAsOil = 0x0800000000000000, // Scooter Imp Summon Skill
        Redicule = 0x1000000000000000, // Tiny Jibes
        PetDoubleExp = 0x2000000000000000,
        SpeedUpTotem = 0x4000000000000000,
        ShootingPose = 0x8000000000000000,
        All = 0xFFFFFFFFFFFFFFFF
    }

    [Flags]
    public enum ConditionsG : ulong
    {
        OrgelPlaying = 0x0000000000000001, // Play Music Box
        LandMarkBuff = 0x0000000000000002,
        SpeedUpPlus = 0x0000000000000004,
        AttackDelay = 0x0000000000000008,
        MaxDamagePlus = 0x0000000000000010,
        MagicAttackPlus = 0x0000000000000020,
        SkillSummonLock = 0x0000000000000040,
        ImmuneToDot = 0x0000000000000080,
        OrientalDragonSummon = 0x0000000000000100, // Decreases Defense/Protection
        FantasyMelody = 0x0000000000000200,
        Psycomancy = 0x0000000000000400,
        BlessedFantasyMelody = 0x0000000000000800,
        PotionEffectUp = 0x0000000000001000,
        ExploreExpEnhance = 0x0000000000002000,
        HugeLuckyEffect = 0x0000000000004000,
        StatusUp = 0x0000000000008000,
        MerchantExpEnhance = 0x0000000000010000,
        QuadraCombatExp = 0x0000000000020000,
        All = 0xFFFFFFFFFFFFFFFF
    }
}