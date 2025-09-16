using MacroTools.Extensions;
using MacroTools.Systems;
using WCSharp.Dummies;
using WCSharp.Shared.Data;

namespace MacroTools.DummyCasters;

public static class DummyCaster
{
  static DummyCaster()
  {
    UnitType.Register(new UnitType(DummySystem.UNIT_TYPE_DUMMY)
    {
      NeverDelete = true
    });
  }

  /// <summary>
  /// Casts an ability from a dummy unit on behalf of the specified source unit, with no target.
  /// </summary>
  public static void Cast(
      unit source,
      int abilityId,
      int orderId,
      int level,
      float? duration = null)
  {
    CastInternal(source, abilityId, orderId, level, null, null, DummyCastOriginType.Caster, duration);
  }

  /// <summary>
  /// Casts an ability from a dummy unit on behalf of the specified source unit, targeting a point.
  /// </summary>
  public static void Cast(
      unit source,
      int abilityId,
      int orderId,
      int level,
      Point pointTarget,
      float? duration = null)
  {
    CastInternal(source, abilityId, orderId, level, pointTarget, null, DummyCastOriginType.Caster, duration);
  }

  /// <summary>
  /// Casts an ability from a dummy unit on behalf of the specified source unit, targeting a unit.
  /// </summary>
  public static void Cast(
      unit source,
      int abilityId,
      int orderId,
      int level,
      unit unitTarget,
      DummyCastOriginType origin = DummyCastOriginType.Caster,
      float? duration = null,
      bool faceTarget = true)
  {
    CastInternal(source, abilityId, orderId, level, null, unitTarget, origin, duration, faceTarget);
  }

  private static void CastInternal(
      unit source,
      int abilityId,
      int orderId,
      int level,
      Point? pointTarget,
      unit? unitTarget,
      DummyCastOriginType origin,
      float? duration,
      bool faceTarget = false)
  {
    var originPos = origin switch
    {
      DummyCastOriginType.Target when unitTarget != null => unitTarget.GetPosition(),
      DummyCastOriginType.Target when pointTarget != null => pointTarget,
      _ => source.GetPosition()
    };

    var dummy = DummySystem.GetDummy(originPos.X, originPos.Y, 0, source.Owner);
    dummy.AddAbility(abilityId);
    dummy.SetAbilityLevel(abilityId, level);

    if (faceTarget && unitTarget != null)
    {
      dummy.FacePosition(unitTarget.GetPosition());
    }

    if (unitTarget != null)
    {
      dummy.IssueOrder(orderId, unitTarget);
    }
    else if (pointTarget != null)
    {
      dummy.IssueOrder(orderId, pointTarget.X, pointTarget.Y);
    }
    else
    {
      dummy.IssueOrder(orderId);
    }

    if (!duration.HasValue)
    {
      DummySystem.RecycleDummy(dummy);
    }
    else
    {
      DummySystem.RecycleDummy(dummy, duration.Value);
    }
  }
}
