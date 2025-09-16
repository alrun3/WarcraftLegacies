using MacroTools.DummyCasters;
using MacroTools.Spells;
using WCSharp.Shared.Data;

namespace WarcraftLegacies.Source.Spells;

public sealed class ChannelAnySpell : Spell
{
  public int DummyAbilityId { get; init; }
  public int DummyAbilityOrderId { get; init; }
  public int Duration { get; init; }

  public ChannelAnySpell(int id) : base(id)
  {
  }

  public override void OnCast(unit caster, unit target, Point targetPoint)
  {
    DummyCaster.Cast(caster, DummyAbilityId, DummyAbilityOrderId,
      GetAbilityLevel(caster), targetPoint, Duration);
  }
}
