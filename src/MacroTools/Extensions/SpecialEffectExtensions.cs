using WCSharp.Effects;

namespace MacroTools.Extensions
{
  /// <summary>
  /// Provides a useful set of extension methods for Warcraft 3 effects,
  /// which are purely visual representations of game models.
  /// </summary>
  public static class SpecialEffectExtensions
  {
    /// <summary>
    /// Causes the effect to be removed after the provided duration has elapsed.
    /// </summary>
    /// <returns>The same effect that was provided.</returns>
    public static void SetLifespan(this effect effect, float lifespan = 0.03125F)
    {
      EffectSystem.Add(effect, lifespan);
    }
  }
}