using static War3Api.Common;

namespace MacroTools.Extensions
{
  public static class SoundExtensions
  {
    public static void SetParamsFromLabel(this sound whichSound, string label)
    {
      SetSoundParamsFromLabel(whichSound, label);
    }

    public static void SetDuration(this sound whichSound, int duration)
    {
      SetSoundDuration(whichSound, duration);
    }

    public static void SetChannel(this sound whichSound, int channel)
    {
      SetSoundChannel(whichSound, channel);
    }

    public static void SetVolume(this sound whichSound, int volume)
    {
      SetSoundVolume(whichSound, volume);
    }

    public static void SetDistances(this sound whichSound, float minDistance, float maxDistance)
    {
      SetSoundDistances(whichSound, minDistance, maxDistance);
    }

    public static void SetDistanceCutoff(this sound whichSound, float cutoff)
    {
      SetSoundDistanceCutoff(whichSound, cutoff);
    }
  }
}