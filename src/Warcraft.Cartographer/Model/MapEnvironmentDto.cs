using War3Net.Build.Common;
using War3Net.Build.Environment;

namespace Warcraft.Cartographer.Model;

public sealed class MapEnvironmentDto
{
  public int FormatVersion { get; set; }
  public Tileset Tileset { get; set; }
  public bool IsCustomTileset { get; set; }
  public List<TerrainType> TerrainTypes { get; set; }
  public List<CliffType> CliffTypes { get; set; }
  public uint Width { get; set; }
  public uint Height { get; set; }
  public float Left { get; set; }
  public float Bottom { get; set; }
  public List<TerrainTileDto> TerrainTiles { get; set; }
  public float Right { get; set; }
  public float Top { get; set; }

  public static MapEnvironmentDto MapFrom(MapEnvironment environment)
  {
    return new MapEnvironmentDto
    {
      FormatVersion = (int)environment.FormatVersion,
      Tileset = environment.Tileset,
      IsCustomTileset = environment.IsCustomTileset,
      TerrainTypes = environment.TerrainTypes,
      CliffTypes = environment.CliffTypes,
      Width = environment.Width,
      Height = environment.Height,
      Left = environment.Left,
      Bottom = environment.Bottom,
      TerrainTiles = environment.TerrainTiles.Select(TerrainTileDto.MapFrom).ToList(),
      Right = environment.Right,
      Top = environment.Top
    };
  }

  public static MapEnvironment MapFrom(MapEnvironmentDto dto)
  {
    return new MapEnvironment((MapEnvironmentFormatVersion)dto.FormatVersion)
    {
      Tileset = dto.Tileset,
      IsCustomTileset = dto.IsCustomTileset,
      TerrainTypes = dto.TerrainTypes,
      CliffTypes = dto.CliffTypes,
      Width = dto.Width,
      Height = dto.Height,
      Left = dto.Left,
      Bottom = dto.Bottom,
      TerrainTiles = dto.TerrainTiles.Select(TerrainTileDto.MapFrom).ToList(),
      Right = dto.Right,
      Top = dto.Top
    };
  }
}

public sealed class TerrainTileDto
{
  public float Height { get; set; }
  public float WaterHeight { get; set; }
  public bool IsEdgeTile { get; set; }
  public int Texture { get; set; }
  public bool IsRamp { get; set; }
  public bool IsBlighted { get; set; }
  public bool IsWater { get; set; }
  public bool IsBoundary { get; set; }
  public int Variation { get; set; }
  public int CliffVariation { get; set; }
  public int CliffLevel { get; set; }
  public int CliffTexture { get; set; }

  public static TerrainTileDto MapFrom(TerrainTile terrainTile)
  {
    return new TerrainTileDto
    {
      Height = terrainTile.Height,
      WaterHeight = terrainTile.WaterHeight,
      IsEdgeTile = terrainTile.IsEdgeTile,
      Texture = terrainTile.Texture,
      IsRamp = terrainTile.IsRamp,
      IsBlighted = terrainTile.IsBlighted,
      IsWater = terrainTile.IsWater,
      IsBoundary = terrainTile.IsBoundary,
      Variation = terrainTile.Variation,
      CliffVariation = terrainTile.CliffVariation,
      CliffLevel = terrainTile.CliffLevel,
      CliffTexture = terrainTile.CliffTexture
    };
  }

  public static TerrainTile MapFrom(TerrainTileDto dto)
  {
    return new TerrainTile(MapEnvironmentFormatVersion.v12)
    {
      Height = dto.Height,
      WaterHeight = dto.WaterHeight,
      IsEdgeTile = dto.IsEdgeTile,
      Texture = dto.Texture,
      IsRamp = dto.IsRamp,
      IsBlighted = dto.IsBlighted,
      IsWater = dto.IsWater,
      IsBoundary = dto.IsBoundary,
      Variation = dto.Variation,
      CliffVariation = dto.CliffVariation,
      CliffLevel = dto.CliffLevel,
      CliffTexture = dto.CliffTexture
    };
  }
}
