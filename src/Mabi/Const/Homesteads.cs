﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

namespace Aura.Mabi.Const
{
    public enum HomesteadEnterRequestResponse : byte
    {
        UnkError = 0,
        RegionNotFound = 1,
        DbError = 2,
        HomesteadNameNotFound = 3,

        //UnkError4 = 4,
        IncorrectHomesteadName = 5,

        //UnkError6 = 6,
        //UnkError7 = 7,
        FailedToEnter = 8,

        //UnkError9 = 9,
        NotFromHere = 10,
        NotDuringFashionContest = 11,
        NoPets = 12,
        NoHousingArea = 13,
        NoSummonedPets = 14,
        NoMounts = 15,
        NotDuringJousting = 16,
        NotDuringRoleplay = 17,
        NotFromThisRegion = 18,
        NoZombies = 19,
        NotDuringPvp = 20,
        NotWhileCastingSkill = 21,
        NotWhileInDialog = 22,
        NotFromArena = 23,
        NotFromBattlefield = 24,
        NotFromPerformanceStage = 25,
        NotFromThisRegion2 = 26,
        NoMounts2 = 27,
        NotDuringBattle = 28,

        //UnkError29 = 29,
        NotAuhorized = 30,
        AuthRequestInquiry = 31,
        WaitForAuthRequestAnswer = 32,
        TooFarAway = 33,
        DifferentServer = 34,
        CannotUseOnTarget = 35,

        //UnkError36 = 36,
        //UnkError37 = 37,
        //UnkError38 = 38,
        CannotBeUsedAtThisTime = 39,
        CannotBeMovedAtThisTime = 40,
        ChangeChannelInquiry = 41,

        //UnkError42 = 42,
        NotDuringCommerce = 43,
        NotFromHousing = 44,

        //FarmPenalty = 45,
        NotWhileInstallingInstrument = 46,
        NotWhileFlying = 48
    }
}