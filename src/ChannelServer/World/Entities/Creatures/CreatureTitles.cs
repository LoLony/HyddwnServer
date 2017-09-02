﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using System;
using System.Collections.Generic;
using System.Linq;
using Aura.Channel.Network.Sending;
using Aura.Data;
using Aura.Data.Database;
using Aura.Mabi;
using Aura.Mabi.Const;
using Aura.Shared.Network;
using Aura.Shared.Util;

namespace Aura.Channel.World.Entities.Creatures
{
    public class CreatureTitles
    {
        private readonly Creature _creature;

        private readonly Dictionary<ushort, TitleState> _list;
        private ushort _tempTitle;
        private TitleData _titleData, _optionTitleData;

        /// <summary>
        ///     Creates new instance for cretaure.
        /// </summary>
        /// <param name="creature"></param>
        public CreatureTitles(Creature creature)
        {
            _creature = creature;
            _list = new Dictionary<ushort, TitleState>();
        }

        /// <summary>
        ///     Returns the title the creature is currently using,
        ///     temporary or not. Setting this value will not change
        ///     the temporary title.
        /// </summary>
        public ushort SelectedTitle
        {
            get => _tempTitle != 0 ? _tempTitle : ActualSelectedTitle;
            set => ActualSelectedTitle = value;
        }

        /// <summary>
        ///     Returns the title the creature is using, potentially behind
        ///     a temporary title.
        /// </summary>
        public ushort ActualSelectedTitle { get; private set; }

        /// <summary>
        ///     Gets or sets the option title the creature is using.
        ///     Doesn't update the client.
        /// </summary>
        public ushort SelectedOptionTitle { get; set; }

        /// <summary>
        ///     Returns the time at which the main title was set.
        /// </summary>
        public DateTime Applied { get; private set; }

        /// <summary>
        ///     Returns amount of known titles.
        /// </summary>
        public int Count
        {
            get
            {
                lock (_list)
                {
                    return _list.Count;
                }
            }
        }

        /// <summary>
        ///     Raised when creature changes titles.
        /// </summary>
        public event Action<Creature> Changed;

        /// <summary>
        ///     Adds title, returns true if title was added or state
        ///     was changed.
        /// </summary>
        /// <param name="titleId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public bool Add(ushort titleId, TitleState state)
        {
            lock (_list)
            {
                if (_list.ContainsKey(titleId) && _list[titleId] == state)
                    return false;

                _list[titleId] = state;
            }
            return true;
        }

        /// <summary>
        ///     Removes title.
        /// </summary>
        /// <param name="titleId"></param>
        /// <returns></returns>
        public bool Remove(ushort titleId)
        {
            lock (_list)
            {
                return _list.Remove(titleId);
            }
        }

        /// <summary>
        ///     Adds title as "Known" and updates client.
        /// </summary>
        /// <param name="titleId"></param>
        public void Show(ushort titleId)
        {
            if (Add(titleId, TitleState.Known))
                Send.AddTitle(_creature, titleId, TitleState.Known);
        }

        /// <summary>
        ///     Adds title as "Available" and updates client.
        /// </summary>
        /// <param name="titleId"></param>
        public void Enable(ushort titleId)
        {
            if (Add(titleId, TitleState.Usable))
                Send.AddTitle(_creature, titleId, TitleState.Usable);
        }

        /// <summary>
        ///     Returns true if creature knows about title in any way.
        /// </summary>
        /// <param name="titleId"></param>
        /// <returns></returns>
        public bool Knows(ushort titleId)
        {
            lock (_list)
            {
                return _list.ContainsKey(titleId);
            }
        }

        /// <summary>
        ///     Returns true if creature is able to use title.
        /// </summary>
        /// <param name="titleId"></param>
        /// <returns></returns>
        public bool IsUsable(ushort titleId)
        {
            lock (_list)
            {
                return _list.ContainsKey(titleId) && _list[titleId] == TitleState.Usable;
            }
        }

        /// <summary>
        ///     Returns new list of all titles.
        /// </summary>
        /// <returns></returns>
        public ICollection<KeyValuePair<ushort, TitleState>> GetList()
        {
            lock (_list)
            {
                return _list.ToArray();
            }
        }

        /// <summary>
        ///     Returns title or option title.
        /// </summary>
        /// <param name="option"></param>
        /// <returns></returns>
        private ushort GetTitle(bool option)
        {
            return !option ? SelectedTitle : SelectedOptionTitle;
        }

        /// <summary>
        ///     Sets title or option title.
        /// </summary>
        /// <param name="titleId"></param>
        /// <param name="option"></param>
        private void SetTitle(ushort titleId, bool option)
        {
            if (!option)
            {
                SelectedTitle = titleId;
                Applied = DateTime.Now;
            }
            else
            {
                SelectedOptionTitle = titleId;
            }
        }

        /// <summary>
        ///     Sets temporary title, that overwrites the actual title until
        ///     the character either relogs, or the temp title is reset by
        ///     setting it to 0.
        /// </summary>
        /// <param name="titleId"></param>
        public void SetTempTitle(ushort titleId)
        {
            if (titleId == 0)
            {
                _tempTitle = 0;
                ChangeTitle(ActualSelectedTitle, false);
            }
            else
            {
                var data = AuraData.TitleDb.Find(titleId);
                if (data == null)
                    throw new ArgumentException("Unknown title '" + titleId + "'.");

                _tempTitle = titleId;

                SwitchStatMods(data, false);

                Send.TitleUpdate(_creature);
                Changed.Raise(_creature);
            }
        }

        /// <summary>
        ///     Tries to change title, returns false if anything goes wrong.
        /// </summary>
        /// <param name="titleId"></param>
        /// <param name="option"></param>
        /// <returns></returns>
        public bool ChangeTitle(ushort titleId, bool option)
        {
            if (titleId == 0 && GetTitle(option) == 0)
                return true;

            if (titleId != 0 && !IsUsable(titleId))
            {
                SetTitle(0, option);
                Log.Warning("CreatureTitles: Player '{0}' tried to use disabled title '{1}'.", _creature.Name, titleId);
                return false;
            }

            TitleData data = null;
            if (titleId != 0)
            {
                data = AuraData.TitleDb.Find(titleId);
                if (data == null)
                {
                    SetTitle(0, option);
                    Log.Warning("CreatureTitles: Player '{0}' tried to use unknown title '{1}'.", _creature.Name,
                        titleId);
                    return false;
                }
            }

            SwitchStatMods(data, option);
            SetTitle(titleId, option);

            if (_creature.Region != Region.Limbo)
                Send.TitleUpdate(_creature);

            // Raise event only when player does it manually, not when loading
            // from db, we don't need it there.
            if (_creature.Client.State == ClientState.LoggedIn)
                Changed.Raise(_creature);

            return true;
        }

        /// <summary>
        ///     Removes previous stat mods and adds new ones.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="option"></param>
        private void SwitchStatMods(TitleData data, bool option)
        {
            // Remove prev stat mods
            if (option && _optionTitleData != null)
            {
                _creature.StatMods.Remove(StatModSource.Title, SelectedOptionTitle);
                if (_optionTitleData.Effects.Any(a => a.Key == "Speed"))
                    _creature.Conditions.Deactivate(ConditionsC.Hurry);
            }
            else if (!option && _titleData != null)
            {
                _creature.StatMods.Remove(StatModSource.Title, SelectedTitle);
                if (_titleData.Effects.Any(a => a.Key == "Speed"))
                    _creature.Conditions.Deactivate(ConditionsC.Hurry);
            }

            // Add new stat mods
            if (data != null)
                foreach (var effect in data.Effects)
                    // Simply adding the bonuses allows to "recover" stats by
                    // using different titles, eg first +40, then +120, to
                    // add 160 Life, even though it should only be 120?
                    // Not much of a problem with title apply delay.

                    switch (effect.Key)
                    {
                        case "Life":
                            _creature.StatMods.Add(Stat.LifeMaxMod, effect.Value, StatModSource.Title, data.Id);
                            if (effect.Value > 0)
                                _creature.Life += effect.Value; // Add value
                            else
                                _creature.Life = _creature.Life; // "Reset" stat (in case of reducation, stat = max)
                            break;
                        case "Mana":
                            _creature.StatMods.Add(Stat.ManaMaxMod, effect.Value, StatModSource.Title, data.Id);
                            if (effect.Value > 0)
                                _creature.Mana += effect.Value;
                            else
                                _creature.Mana = _creature.Mana;
                            break;
                        case "Stamina":
                            // Adjust hunger to new max value, so Food stays
                            // at the same percentage.
                            var hungerRate = 100 / _creature.StaminaMax * _creature.Hunger / 100f;

                            _creature.StatMods.Add(Stat.StaminaMaxMod, effect.Value, StatModSource.Title, data.Id);
                            if (effect.Value > 0)
                                _creature.Stamina += effect.Value;
                            else
                                _creature.Stamina = _creature.Stamina;
                            _creature.Hunger = _creature.StaminaMax * hungerRate;
                            break;
                        case "Str":
                            _creature.StatMods.Add(Stat.StrMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "Int":
                            _creature.StatMods.Add(Stat.IntMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "Dex":
                            _creature.StatMods.Add(Stat.DexMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "Will":
                            _creature.StatMods.Add(Stat.WillMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "Luck":
                            _creature.StatMods.Add(Stat.LuckMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "Defense":
                            _creature.StatMods.Add(Stat.DefenseBaseMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "Protection":
                            _creature.StatMods.Add(Stat.ProtectionBaseMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "MinAttack":
                            _creature.StatMods.Add(Stat.AttackMinMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "MaxAttack":
                            _creature.StatMods.Add(Stat.AttackMaxMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "MinInjury":
                            _creature.StatMods.Add(Stat.InjuryMinMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "MaxInjury":
                            _creature.StatMods.Add(Stat.InjuryMaxMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "Crit":
                            _creature.StatMods.Add(Stat.CriticalMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "CP":
                            _creature.StatMods.Add(Stat.CombatPowerMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "MagicAttack":
                            _creature.StatMods.Add(Stat.MagicAttackMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "MagicDefense":
                            _creature.StatMods.Add(Stat.MagicDefenseMod, effect.Value, StatModSource.Title, data.Id);
                            break;
                        case "MagicProtection":
                            _creature.StatMods.Add(Stat.MagicProtectionMod, effect.Value, StatModSource.Title, data.Id);
                            break;

                        case "Speed":
                            // XXX: Conditions with idents to deactive them
                            //   more easily, like stat mods and regens?
                            var extra = new MabiDictionary();
                            extra.SetShort("VAL", (short) effect.Value);
                            _creature.Conditions.Activate(ConditionsC.Hurry, extra);
                            break;

                        default:
                            Log.Warning("CreatureTitles: Unknown title effect '{0}' in title {1}.", effect.Key,
                                data.Id);
                            break;
                    }

            // Broadcast new stats if creature is in a region yet
            if (_creature.Region != Region.Limbo)
            {
                Send.StatUpdate(_creature, StatUpdateType.Private,
                    Stat.LifeMaxMod, Stat.Life, Stat.LifeInjured,
                    Stat.ManaMaxMod, Stat.Mana,
                    Stat.StaminaMaxMod, Stat.Stamina,
                    Stat.StrMod, Stat.IntMod, Stat.DexMod, Stat.WillMod, Stat.LuckMod,
                    Stat.DefenseBaseMod, Stat.ProtectionBaseMod,
                    Stat.AttackMinMod, Stat.AttackMaxMod,
                    Stat.InjuryMinMod, Stat.InjuryMaxMod,
                    Stat.CriticalMod, Stat.CombatPower,
                    Stat.MagicAttackMod, Stat.MagicDefenseMod, Stat.MagicProtectionMod
                );
                Send.StatUpdate(_creature, StatUpdateType.Public, Stat.Life, Stat.LifeMaxMod, Stat.LifeMax);
            }

            // Save data
            if (!option)
                _titleData = data;
            else
                _optionTitleData = data;
        }
    }

    public enum TitleState : byte
    {
        Known = 0,
        Usable = 1
    }
}