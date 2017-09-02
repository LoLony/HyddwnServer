﻿// Copyright (c) Aura development team - Licensed under GNU GPL
// For more information, see license file in the main folder

using Aura.Channel.Network.Sending;
using Aura.Channel.Skills.Base;
using Aura.Channel.World.Entities;
using Aura.Mabi.Const;
using Aura.Mabi.Network;

namespace Aura.Channel.Skills.Life
{
    /// <summary>
    ///     Used by Dark Lord, teleports user behind the target.
    /// </summary>
    /// <remarks>
    ///     This implementation is guessed. It can be used by players and
    ///     monsters, but it's unlikely that it's official.
    /// </remarks>
    [Skill(SkillId.DarkLord)]
    public class DarkLordSkill : IPreparable, ICompletable, ICancelable
    {
        private const int DistanceToTarget = 100;

        /// <summary>
        ///     Cancels skill (do nothing).
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="skill"></param>
        public void Cancel(Creature creature, Skill skill)
        {
        }

        /// <summary>
        ///     Completes skill, teleporting behind target.
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="skill"></param>
        /// <param name="packet"></param>
        public void Complete(Creature creature, Skill skill, Packet packet)
        {
            var target = creature.Target;
            if (target != null)
            {
                var pos = creature.GetPosition();
                var targetPos = target.GetPosition();
                var telePos = pos.GetRelative(targetPos, DistanceToTarget);

                // Set teleport position to current position if there'd be
                // a collision between the creature and the target after the
                // teleport. This prevents creatures from teleporting
                // through walls.
                // According to the Wiki, monsters will "tele-bounce in place"
                // if there's an obstacle, so this should mimic official
                // behavior accurately.
                if (creature.Region.Collisions.Any(telePos, targetPos))
                    telePos = pos;

                Send.Effect(creature, Effect.SilentMoveTeleport, (byte) 2, telePos.X, telePos.Y);
                creature.Warp(creature.RegionId, telePos);
            }

            Send.SkillComplete(creature, skill.Info.Id);
        }

        /// <summary>
        ///     Prepares skill, goes straight to use to skip readying and using it.
        /// </summary>
        /// <param name="creature"></param>
        /// <param name="skill"></param>
        /// <param name="packet"></param>
        public bool Prepare(Creature creature, Skill skill, Packet packet)
        {
            Send.SkillUse(creature, skill.Info.Id, 0);
            skill.State = SkillState.Used;

            return true;
        }
    }
}