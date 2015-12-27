using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Day22
{
    internal enum Result
    {
        Nothing,
        Victory,
        Defeat,
    }

    internal class BattleState
    {
        #region Properties

        public Result Result { get; set; }
        public int EnemyHitpoints { get; set; }
        public int EnemyDamage { get; set; }
        public int WizardHitpoints { get; set; }
        public int WizardManaPoints { get; set; }

        //[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public Dictionary<Spell, int> ActiveSpells { get; private set; }

        public int RoundsCount { get; set; }
        public int TotalSpentMana { get; set; }
        //[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
        public List<Spell> CastedSpells { get; private set; }
        public bool IsHardMode { get; set; }

        #endregion

        #region Constructors

        public BattleState()
        {
            ActiveSpells = new Dictionary<Spell, int>();
            CastedSpells = new List<Spell>();
            Result = Result.Nothing;
        }

        public BattleState(BattleState s) : this()
        {
            IsHardMode = s.IsHardMode;
            WizardHitpoints = s.WizardHitpoints;
            WizardManaPoints = s.WizardManaPoints;
            EnemyDamage = s.EnemyDamage;
            EnemyHitpoints = s.EnemyHitpoints;
            RoundsCount = s.RoundsCount;
            TotalSpentMana = s.TotalSpentMana;
            ActiveSpells = s.ActiveSpells.ToDictionary(x => x.Key, x => x.Value);
            CastedSpells = s.CastedSpells.ToList();
        }

        #endregion

        public Result Fight(Spell spell)
        {
            RoundsCount++;
            if (IsHardMode)
            {
                WizardHitpoints--;
            }
            // wizard's turn
            ApplyActiveSpells();
            if (EnemyHitpoints <= 0)
                return Result = Result.Victory;
            CastSpell(spell);
            if (EnemyHitpoints <= 0)
                return Result = Result.Victory;

            // enemy's turn
            ApplyActiveSpells();
            if (EnemyHitpoints <= 0)
                return Result = Result.Victory;
            WizardHitpoints -= EnemyDamage - ActiveSpells.Sum(x => x.Key.Armor);
            if (WizardHitpoints <= 0)
                return (Result = Result.Defeat);
            return Result = Result.Nothing;
        }

        private void CastSpell(Spell spell)
        {
            var spellManaCost = spell.ManaCost;
            TotalSpentMana += spellManaCost;
            WizardManaPoints -= spellManaCost;
            CastedSpells.Add(spell);
            if (spell.Duration == 0)
            {
                ApplySpell(spell);
            }
            else
            {
                ActiveSpells.Add(spell, spell.Duration);
            }
        }

        private void ApplyActiveSpells()
        {
            foreach (var spell in ActiveSpells.Keys)
            {
                ApplySpell(spell);
            }

            var activeSpells = ActiveSpells.ToList();
            foreach (var activeSpell in activeSpells)
            {
                if (activeSpell.Value == 1)
                {
                    ActiveSpells.Remove(activeSpell.Key);
                }
                else
                {
                    ActiveSpells[activeSpell.Key] = activeSpell.Value - 1;
                }
            }
        }

        private void ApplySpell(Spell spell)
        {
            EnemyHitpoints -= spell.Damage;
            WizardHitpoints += spell.Heal;
            WizardManaPoints += spell.ManaCharge;
        }
    }
}