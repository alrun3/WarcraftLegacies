using MacroTools.DummyCasters;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class AnySpellNoTarget : Spell
{
  public int DummyAbilityId { get; init; }
  public int DummyAbilityOrderId { get; init; }

  public AnySpellNoTarget(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    DummyCaster.Cast(
        caster,
        DummyAbilityId,
        DummyAbilityOrderId,
        GetAbilityLevel(caster)
    );
  }
}
