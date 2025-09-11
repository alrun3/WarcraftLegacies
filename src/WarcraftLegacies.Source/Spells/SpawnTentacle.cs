using MacroTools.Data;
using MacroTools.Extensions;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells
{
  /// <summary>
  /// Spawns a tentacle at the target location.
  /// </summary>
  public sealed class SpawnTentacle : Spell
  {
    public required LeveledAbilityField<int> HitPoints { get; init; }
    
    public required LeveledAbilityField<int> AttackDamageBase { get; init; }
    
    public required int UnitTypeId { get; init; }
    
    public required LeveledAbilityField<float> Duration { get; init; }
    
    /// <inheritdoc />
    public SpawnTentacle(int id) : base(id)
    {
    }

    /// <inheritdoc />
    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var level = GetAbilityLevel(caster);

      var unit = CreateUnit(caster.OwningPlayer(), UnitTypeId, targetPoint.X, targetPoint.Y, caster.GetFacing());
      unit.SetTimedLife(Duration.Base + Duration.PerLevel * level);
      unit.SetDamageBase(AttackDamageBase.Base + AttackDamageBase.PerLevel * level);
      unit.SetMaximumHitpoints(HitPoints.Base + HitPoints.PerLevel * level);
      unit.SetLifePercent(100);
      unit.SetAnimation("birth");
      unit.QueueAnimation("stand");
      unit.AddType(UNIT_TYPE_SUMMONED);
    }
  }
}