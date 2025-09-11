using MacroTools.Extensions;

namespace WarcraftLegacies.Source
{
  /// <summary>
  /// Provides ambiance sounds with predefined settings.
  /// </summary>
  public static class AmbianceLibrary
  {
    public static sound DalaranRuinsNight { get; }
    public static sound BlackCitadelOutlandNight { get; }
    public static sound BlackCitadelOutlandDay { get; }
    public static sound IceCrownNight { get; }
    public static sound AshenvaleNight { get; }
    public static sound LordaeronFallDay { get; }
    public static sound AshenvaleDay { get; }
    public static sound BarrensDay { get; }
    public static sound DalaranRuinsDay { get; }
    public static sound WetlandsNight { get; }
    public static sound Wetlandsday { get; }
    public static sound IceCrownDay { get; }
    public static sound LordaeronSummerDay { get; }
    public static sound CityScapeDay { get; }
    public static sound LordaeronSummerNight { get; }
    public static sound NorthrendDay { get; }
    public static sound NorthrendNight { get; }
    public static sound LordaeronWinterNight { get; }
    public static sound LordaeronFallNight { get; }
    public static sound LordaeronWinterDay { get; }

    static AmbianceLibrary()
    {
      DalaranRuinsNight = CreateSound("Sound/Ambient/DalaranRuins/DalaranRuinsNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      DalaranRuinsNight.SetParamsFromLabel("DalaranRuinsNight");
      DalaranRuinsNight.SetDuration(114759);
      DalaranRuinsNight.SetChannel(10);
      DalaranRuinsNight.SetVolume(15);
      DalaranRuinsNight.SetDistances(0, 10000.0f);
      DalaranRuinsNight.SetDistanceCutoff(100);

      BlackCitadelOutlandNight = CreateSound("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      BlackCitadelOutlandNight.SetParamsFromLabel("BlackCitadelNight");
      BlackCitadelOutlandNight.SetDuration(116318);
      BlackCitadelOutlandNight.SetChannel(10);
      BlackCitadelOutlandNight.SetVolume(18);
      BlackCitadelOutlandNight.SetDistances(0, 10000.0f);
      BlackCitadelOutlandNight.SetDistanceCutoff(100);

      BlackCitadelOutlandDay = CreateSound("Sound/Ambient/BlackCitadel/BlackCitadel_OutlandDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      BlackCitadelOutlandDay.SetParamsFromLabel("BlackCitadelDay");
      BlackCitadelOutlandDay.SetDuration(119186);
      BlackCitadelOutlandDay.SetChannel(10);
      BlackCitadelOutlandDay.SetVolume(14);
      BlackCitadelOutlandDay.SetDistances(0, 10000f);
      BlackCitadelOutlandDay.SetDistanceCutoff(100);

      IceCrownNight = CreateSound("Sound/Ambient/IceCrown/IceCrownNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      IceCrownNight.SetParamsFromLabel("IceCrownNight");
      IceCrownNight.SetDuration(123220);
      IceCrownNight.SetChannel(10);
      IceCrownNight.SetVolume(14);
      IceCrownNight.SetDistances(0, 10000f);
      IceCrownNight.SetDistanceCutoff(100);

      AshenvaleNight = CreateSound("Sound/Ambient/Ashenvale/AshenvaleNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      AshenvaleNight.SetParamsFromLabel("AshenvaleNight");
      AshenvaleNight.SetDuration(119013);
      AshenvaleNight.SetChannel(10);
      AshenvaleNight.SetVolume(10);
      AshenvaleNight.SetDistances(0, 10000);
      AshenvaleNight.SetDistanceCutoff(100);

      LordaeronFallDay = CreateSound("Sound/Ambient/LordaeronFall/LordaeronFallDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      LordaeronFallDay.SetParamsFromLabel("LordaeronFallDay");
      LordaeronFallDay.SetDuration(124766);
      LordaeronFallDay.SetChannel(10);
      LordaeronFallDay.SetVolume(10);
      LordaeronFallDay.SetDistances(0, 10000);
      LordaeronFallDay.SetDistanceCutoff(100);

      AshenvaleDay = CreateSound("Sound/Ambient/Ashenvale/AshenvaleDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      AshenvaleDay.SetParamsFromLabel("AshenvaleDay");
      AshenvaleDay.SetDuration(47700);
      AshenvaleDay.SetChannel(10);
      AshenvaleDay.SetVolume(10);
      AshenvaleDay.SetDistances(0, 10000);
      AshenvaleDay.SetDistanceCutoff(100);

      BarrensDay = CreateSound("Sound/Ambient/Barrens/BarrensDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      BarrensDay.SetParamsFromLabel("BarrensDay");
      BarrensDay.SetDuration(113856);
      BarrensDay.SetChannel(10);
      BarrensDay.SetVolume(20);
      BarrensDay.SetDistances(0, 10000);
      BarrensDay.SetDistanceCutoff(100);

      DalaranRuinsDay = CreateSound("Sound/Ambient/DalaranRuins/DalaranRuinsDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      DalaranRuinsDay.SetParamsFromLabel("DalaranRuinsDay");
      DalaranRuinsDay.SetDuration(119795);
      DalaranRuinsDay.SetChannel(10);
      DalaranRuinsDay.SetVolume(20);
      DalaranRuinsDay.SetDistances(0, 10000);
      DalaranRuinsDay.SetDistanceCutoff(100);

      WetlandsNight = CreateSound("Sound/Ambient/SunkenRuins/WetlandsNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      WetlandsNight.SetParamsFromLabel("SunkenRuinsNight");
      WetlandsNight.SetDuration(172730);
      WetlandsNight.SetChannel(10);
      WetlandsNight.SetVolume(5);
      WetlandsNight.SetDistances(0, 10000);
      WetlandsNight.SetDistanceCutoff(100);

      Wetlandsday = CreateSound("Sound/Ambient/SunkenRuins/Wetlandsday.flac", true, true, true, 1, 1, "DefaultEAXON");
      Wetlandsday.SetParamsFromLabel("SunkenRuinsDay");
      Wetlandsday.SetDuration(175048);
      Wetlandsday.SetChannel(10);
      Wetlandsday.SetVolume(5);
      Wetlandsday.SetDistances(0, 10000);
      Wetlandsday.SetDistanceCutoff(100);

      IceCrownDay = CreateSound("Sound/Ambient/IceCrown/IceCrownDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      IceCrownDay.SetParamsFromLabel("IceCrownDay");
      IceCrownDay.SetDuration(120528);
      IceCrownDay.SetChannel(10);
      IceCrownDay.SetVolume(14);
      IceCrownDay.SetDistances(0, 10000);
      IceCrownDay.SetDistanceCutoff(100);

      LordaeronSummerDay = CreateSound("Sound/Ambient/LordaeronSummer/LordaeronSummerDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      LordaeronSummerDay.SetParamsFromLabel("LordaeronSummerDay");
      LordaeronSummerDay.SetDuration(117210);
      LordaeronSummerDay.SetChannel(10);
      LordaeronSummerDay.SetVolume(10);
      LordaeronSummerDay.SetDistances(0, 10000);
      LordaeronSummerDay.SetDistanceCutoff(100);

      CityScapeDay = CreateSound("Sound/Ambient/CityScape/CityScapeDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      CityScapeDay.SetParamsFromLabel("DalaranDay");
      CityScapeDay.SetDuration(253775);
      CityScapeDay.SetChannel(10);
      CityScapeDay.SetVolume(16);
      CityScapeDay.SetDistances(0, 10000);
      CityScapeDay.SetDistanceCutoff(100);

      LordaeronSummerNight = CreateSound("Sound/Ambient/LordaeronSummer/LordaeronSummerNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      LordaeronSummerNight.SetParamsFromLabel("LordaeronSummerNight");
      LordaeronSummerNight.SetDuration(122859);
      LordaeronSummerNight.SetChannel(10);
      LordaeronSummerNight.SetVolume(10);
      LordaeronSummerNight.SetDistances(0, 10000);
      LordaeronSummerNight.SetDistanceCutoff(100);

      NorthrendDay = CreateSound("Sound/Ambient/Northrend/NorthrendDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      NorthrendDay.SetParamsFromLabel("NorthrendDay");
      NorthrendDay.SetDuration(114102);
      NorthrendDay.SetChannel(10);
      NorthrendDay.SetVolume(15);
      NorthrendDay.SetDistances(0, 10000);
      NorthrendDay.SetDistanceCutoff(100);

      NorthrendNight = CreateSound("Sound/Ambient/Northrend/NorthrendNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      NorthrendNight.SetParamsFromLabel("DungeonNight");
      NorthrendNight.SetDuration(106607);
      NorthrendNight.SetChannel(10);
      NorthrendNight.SetVolume(25);
      NorthrendNight.SetDistances(0, 10000);
      NorthrendNight.SetDistanceCutoff(400);

      LordaeronWinterNight = CreateSound("Sound/Ambient/LordaeronWinter/LordaeronWinterNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      LordaeronWinterNight.SetParamsFromLabel("LordaeronWinterNight");
      LordaeronWinterNight.SetDuration(118060);
      LordaeronWinterNight.SetChannel(10);
      LordaeronWinterNight.SetVolume(10);
      LordaeronWinterNight.SetDistances(0, 10000);
      LordaeronWinterNight.SetDistanceCutoff(100);

      LordaeronFallNight = CreateSound("Sound/Ambient/LordaeronFall/LordaeronFallNight.flac", true, true, true, 1, 1, "DefaultEAXON");
      LordaeronFallNight.SetParamsFromLabel("VillageFallNight");
      LordaeronFallNight.SetDuration(124342);
      LordaeronFallNight.SetChannel(10);
      LordaeronFallNight.SetVolume(10);
      LordaeronFallNight.SetDistances(0, 10000.0f);
      LordaeronFallNight.SetDistanceCutoff(100);

      LordaeronWinterDay = CreateSound("Sound/Ambient/LordaeronWinter/LordaeronWinterDay.flac", true, true, true, 1, 1, "DefaultEAXON");
      LordaeronWinterDay.SetParamsFromLabel("LordaeronWinterDay");
      LordaeronWinterDay.SetDuration(117986);
      LordaeronWinterDay.SetChannel(10);
      LordaeronWinterDay.SetVolume(10);
      LordaeronWinterDay.SetDistances(0, 10000.0f);
      LordaeronWinterDay.SetDistanceCutoff(100);
    }
  }
}