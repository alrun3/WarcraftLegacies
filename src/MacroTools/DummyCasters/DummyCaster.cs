using System;
using System.Collections.Generic;
using MacroTools.Extensions;
using MacroTools.UnitTypes;
using WCSharp.Dummies;
using WCSharp.Shared.Data;

namespace MacroTools.DummyCasters;

public sealed class DummyCaster : IDisposable
{
  static DummyCaster()
  {
    UnitType.Register(new UnitType(DummySystem.UNIT_TYPE_DUMMY)
    {
      NeverDelete = true
    });
  }

  private readonly unit _unit;

  private DummyCaster(float x, float y, player owner)
  {
    _unit = DummySystem.GetDummy(x, y, owner);
  }

  /// <summary>
  /// Casts an ability from a dummy unit on behalf of the specified source unit, targeting a unit.
  /// </summary>
  public void Cast(int orderId, unit target, DummyCastOriginType origin = DummyCastOriginType.Caster)
  {
    if (origin == DummyCastOriginType.Target)
    {
      _unit.SetPosition(target.X, target.Y);
    }

    _unit.IssueOrder(orderId, target);
  }

  /// <summary>
  /// Casts an ability from a dummy unit on behalf of the specified source unit, targeting a group of units.
  /// </summary>
  public void Cast(int orderId, List<unit> targets, DummyCastOriginType origin = DummyCastOriginType.Caster)
  {
    foreach (var target in targets)
    {
      Cast(orderId, target, origin);
    }
  }

  public void Dispose()
  {
    DummySystem.RecycleDummy(_unit);
  }

  public static DummyCaster GetOrCreate(float x, float y, player owner, int abilityId, int abilityLevel)
  {
    var caster = new DummyCaster(x, y, owner);
    caster._unit.AddAbility(abilityId);
    caster._unit.SetAbilityLevel(abilityId, abilityLevel);
    return caster;
  }

  /// <summary>
  /// Casts an ability from a dummy unit on behalf of the specified source unit, with no target.
  /// </summary>
  public static void Cast(
      unit source,
      int abilityId,
      int orderId,
      int level,
      float? duration = null,
      DummyCastOriginType origin = DummyCastOriginType.Caster)
  {
    CastInternal(source, abilityId, orderId, level, null, null, duration, origin);
  }

  /// <summary>
  /// Casts an ability from a dummy unit on behalf of the specified source unit, targeting a point.
  /// </summary>
  public static void Cast(
      unit source,
      int abilityId,
      int orderId,
      int level,
      Point target,
      float? duration = null,
      DummyCastOriginType origin = DummyCastOriginType.Caster)
  {
    CastInternal(source, abilityId, orderId, level, target, null, duration, origin);
  }

  /// <summary>
  /// Casts an ability from a dummy unit on behalf of the specified source unit, targeting a unit.
  /// </summary>
  public static void Cast(
      unit source,
      int abilityId,
      int orderId,
      int level,
      unit target,
      DummyCastOriginType origin = DummyCastOriginType.Caster,
      bool faceTarget = true)
  {
    CastInternal(source, abilityId, orderId, level, null, target, null, origin, faceTarget);
  }

  private static void CastInternal(
      unit source,
      int abilityId,
      int orderId,
      int level,
      Point? pointTarget,
      unit? unitTarget,
      float? duration,
      DummyCastOriginType origin,
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
      // If duration is not specified, allow DummySystem to handle recycling based on its internal rules.
      DummySystem.RecycleDummy(dummy);
    }
    else
    {
      DummySystem.RecycleDummy(dummy, duration.Value);
    }
  }
}
