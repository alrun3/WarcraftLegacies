using System.Collections.Generic;
using MacroTools.DummyCasters;
using MacroTools.SpellSystem;
using WCSharp.Shared.Data;
using System.Linq;
using MacroTools.Utils;

namespace MacroTools.Spells
{
  /// <summary>
  /// A filter that can be applied to dummy casts so that the casts are only performed on particular targets.
  /// </summary>
  public delegate bool CastFilter(unit caster, unit target);

  public sealed class MassAnySpell : Spell
  {
    public int DummyAbilityId { get; init; }

    public int DummyAbilityOrderId { get; init; }
    
    public float Radius { get; init; }

    public required CastFilter CastFilter { get; init; }

    public SpellTargetType TargetType { get; init; } = SpellTargetType.None;

    public float Chance { get; init; } = 1.0f;

    public DummyCastOriginType DummyCastOriginType { get; init; } = DummyCastOriginType.Target;

    public float DamageBase { get; init; } = 0f; 
    public float DamageLevel { get; init; } = 0f;  
    public bool EnableDamage { get; init; } = false;

    public MassAnySpell(int id) : base(id)
    {
    }

    public override void OnCast(unit caster, unit target, Point targetPoint)
    {
      var center = TargetType == SpellTargetType.None ? new Point(GetUnitX(caster), GetUnitY(caster)) : targetPoint;
      var units = GetUnitsInRadius(center, Radius, CastFilter);

      var filteredUnits = units.Where(u => GetRandomReal(0, 1) <= Chance).ToList();

      foreach (var unit in filteredUnits)
      {
        if (EnableDamage && IsUnitEnemy(unit, GetOwningPlayer(caster)))
        {
          var damage = DamageBase + DamageLevel * GetAbilityLevel(caster);
          UnitDamageTarget(caster, unit, damage, false, false, ATTACK_TYPE_NORMAL, DAMAGE_TYPE_MAGIC, WEAPON_TYPE_WHOKNOWS);
        }
      }

      foreach (var unit in GlobalGroup.EnumUnitsInRange(center, Radius).FindAll(u => filteredUnits.Contains(u)))
      {
        DummyCaster.Cast(
          caster,
          DummyAbilityId,
          DummyAbilityOrderId,
          GetAbilityLevel(caster),
          unit,
          DummyCastOriginType
        );
      }
    }


    private IEnumerable<unit> GetUnitsInRadius(Point center, float radius, CastFilter castFilter)
    {
      var group = CreateGroup();
      GroupEnumUnitsInRange(group, center.X, center.Y, radius, null);
      var units = new List<unit>();
      unit u;

      while ((u = FirstOfGroup(group)) != null)
      {
        GroupRemoveUnit(group, u);
        if (castFilter(null, u))
        {
          units.Add(u);
        }
      }

      DestroyGroup(group);
      return units;
    }
  }
}