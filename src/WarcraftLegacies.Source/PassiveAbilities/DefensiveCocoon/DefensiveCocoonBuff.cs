using System;
using MacroTools.Extensions;
using WCSharp.Buffs;

namespace WarcraftLegacies.Source.PassiveAbilities.DefensiveCocoon
{
  public sealed class DefensiveCocoonBuff : PassiveBuff
  {
    private static readonly int[] HeroXpTable = { 100, 120, 160, 220, 300 };
    private unit? _egg;
    private trigger? _deathTrigger;
    private readonly int _originalHeroLevel;

    public required int MaximumHitPoints { private get; init; }
    public required string ReviveEffect { private get; init; }
    public required int EggId { private get; init; }

    public DefensiveCocoonBuff(unit caster, unit target) : base(caster, target)
    {
      _originalHeroLevel = GetHeroLevel(target);
    }
    
    public override void OnApply()
    {
      Target.SetLifePercent(100);
      Target.PauseEx(true);
      Target.Show(false);

      _egg = CreateUnit(Target.OwningPlayer(), EggId, GetUnitX(Target), GetUnitY(Target), 0);
      _egg.SetTimedLife(Duration + 1);
      _egg.SetMaximumHitpoints(MaximumHitPoints);
      _egg.SetLifePercent(100);
      _egg.SetArmor((int)BlzGetUnitArmor(Target));
      _egg.SetName($"Cocoon ({Target.GetProperName()})");

      var effect = AddSpecialEffect(ReviveEffect, GetUnitX(Target), GetUnitY(Target));
      effect.Scale = 2;
      effect.SetLifespan();

      _deathTrigger = CreateTrigger();
      _deathTrigger.RegisterUnitEvent(_egg, EVENT_UNIT_DEATH);
      _deathTrigger.AddAction(() => {
        var killingUnit = GetKillingUnit();
        if (killingUnit != null && IsUnitType(killingUnit, UNIT_TYPE_HERO))
        {
          var index = Math.Min(_originalHeroLevel - 1, HeroXpTable.Length - 1);
          var experienceGained = HeroXpTable[index];
          SetHeroXP(killingUnit, GetHeroXP(killingUnit) + experienceGained, true);
        }
        Target.Kill();
      });
    }

    public override void OnDispose()
    {
      _deathTrigger?.Destroy();
      Target.Show(true);
      Target.PauseEx(false);

      if (UnitAlive(_egg)) 
        Revive();
      else
      {
        Target.Kill();
        Target.SetPosition(_egg!.GetPosition());
      }
    }

    private void Revive()
    {
      Target.SetCurrentHitpoints(_egg!.GetCurrentHitPoints());
      _egg!.Kill();
      Target.SetPosition(_egg!.GetPosition());

      var effect = AddSpecialEffect(ReviveEffect, GetUnitX(Target), GetUnitY(Target));
      effect.Scale = 2;
      effect.SetLifespan();
    }
  }
}