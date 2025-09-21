namespace MacroTools.Extensions;

public static class PlayerSoundExtensions
{
  /// <summary>
  /// Plays the specified sound for the player.
  /// </summary>
  public static void PlaySound(this player whichPlayer, sound sound)
  {
    if (whichPlayer.IsLocal)
    {
      sound.Start();
    }
  }

  /// <summary>
  /// Plays the specified music for the player.
  /// </summary>
  public static void PlayMusicThematic(this player whichPlayer, string musicPath)
  {
    if (whichPlayer.IsLocal)
    {
      PlayThematicMusic(musicPath);
    }
  }
}
