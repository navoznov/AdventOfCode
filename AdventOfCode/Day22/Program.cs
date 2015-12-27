using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;

namespace Day22
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            const int enemyHitpoints = 58;
            const int enemyDamage = 9;
            const int wizardHitpoints = 50;
            const int wizardManaPoints = 500;


            var magicMissileSpell = new Spell("MagicMissle", 53, damage: 4);
            var drainSpell = new Spell("Drain", 73, damage: 2, heal: 2);
            var shieldSpell = new Spell("Shield", 113, 6, armor: 7);
            var poisonSpell = new Spell("Poison", 173, 6, damage: 3);
            var rechargeSpell = new Spell("Recharge", 229, 5, manaCharge: 101);

            var spells = new List<Spell> {magicMissileSpell, drainSpell, shieldSpell, poisonSpell, rechargeSpell};

            var startBattleState = new BattleState
            {
                EnemyHitpoints = enemyHitpoints,
                EnemyDamage = enemyDamage,
                WizardHitpoints = wizardHitpoints,
                WizardManaPoints = wizardManaPoints,
                IsHardMode = false,
            };


            Part1(startBattleState, spells);

            startBattleState.IsHardMode = true;
            Part2(startBattleState, spells);
        }

        private static void Part1(BattleState startBattleState, List<Spell> spells)
        {
            var minManaToWin = GetLeastManaToWin(startBattleState, spells);
            Console.WriteLine(minManaToWin);
        }

        private static void Part2(BattleState startBattleState, List<Spell> spells)
        {
            var minManaToWin = GetLeastManaToWin(startBattleState, spells);
            Console.WriteLine(minManaToWin);
        }

        private static int GetLeastManaToWin(BattleState startBattleState, List<Spell> spells)
        {
            var battleStates = new Queue<BattleState>(new[] {new BattleState(startBattleState),});

            var minManaToWin = int.MaxValue;
            while (battleStates.Count > 0)
            {
                var state = battleStates.Dequeue();

                if (state.TotalSpentMana >= minManaToWin)
                {
                    continue;
                }
                var availableSpells = spells
                    .Where(x => x.ManaCost <= state.WizardManaPoints)
                    .Except(state.ActiveSpells.Keys.Where(x => state.ActiveSpells[x] > 1))
                    .ToList();

                foreach (var spell in availableSpells)
                {
                    var battleState = new BattleState(state);
                    var result = battleState.Fight(spell);
                    if (result == Result.Nothing)
                    {
                        battleStates.Enqueue(battleState);
                    }
                    else if (battleState.Result == Result.Victory)
                    {
                        if (battleState.TotalSpentMana < minManaToWin)
                        {
                            minManaToWin = battleState.TotalSpentMana;
                            break;
                        }
                    }
                }
            }
            return minManaToWin;
        }
    }
}