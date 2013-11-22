using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;

namespace CastleLegends.Common.Persistence
{
    public class HexMapRepository
    {
        public void Save(HexMap map, string fullPath)
        {
            if (null == map)
                throw new ArgumentNullException("map");
            if (string.IsNullOrWhiteSpace(fullPath))
                throw new ArgumentNullException("fullPath");

            var xMap = new XElement("HexMap", new XAttribute("version", "1.0")
                                            , new XAttribute("MapCoordsType", map.MapCoordsType)
                                            , new XAttribute("TilesType", map.TilesType)
                                            , new XAttribute("TilesCountX", map.TilesCountX)
                                            , new XAttribute("TilesCountY", map.TilesCountY)
                                            , new XAttribute("TilesRadius", map.TilesRadius));

            var tiles = map.Tiles.Cast<Tile>();

            if (null != tiles && tiles.Any())
            {
                var tilesets = map.Tilesets;
                if (null != tilesets && tilesets.Any())
                {
                    xMap.Add(new XElement("Tilesets", tilesets.Select(t => new XElement("Tileset",
                                                                                        new XAttribute("ID", t.ID),
                                                                                        new XAttribute("TileWidth", t.TileWidth),
                                                                                        new XAttribute("TileHeight", t.TileHeight),
                                                                                        new XElement("Asset", t.Asset),
                                                                                        new XElement("Alpha", new XAttribute("R", t.Alpha.R)
                                                                                                            , new XAttribute("G", t.Alpha.G)
                                                                                                            , new XAttribute("B", t.Alpha.B)
                                                                                                            , new XAttribute("A", t.Alpha.A)))
                                                                    )
                                        )
                            );
                }

                xMap.Add(new XElement("Tiles", tiles.Select(t => ToXml(t, tilesets))));
            }

            if (File.Exists(fullPath))
                File.Delete(fullPath);
            xMap.Save(fullPath);
        }

        private static XElement ToXml(Tile tile, IEnumerable<Tileset> tilesets)
        {
            var xTile = new XElement("Tile",
                                    new XAttribute("IndexX", tile.IndexX),
                                    new XAttribute("IndexY", tile.IndexY));

            if (null != tile.Tileset)
            {
                var xTextureSourceBounds = new XElement("TextureSourceBounds", new XAttribute("X", tile.TextureSourceBounds.X)
                                                                            , new XAttribute("Y", tile.TextureSourceBounds.Y)
                                                                            , new XAttribute("Width", tile.TextureSourceBounds.Width)
                                                                            , new XAttribute("Height", tile.TextureSourceBounds.Height));

                xTile.Add(new XElement("Tileset", new XAttribute("ID", tile.Tileset.ID)
                                                , xTextureSourceBounds));
            }
            return xTile;
        }

        public HexMap Load(string fullPath)
        {
            if (string.IsNullOrWhiteSpace(fullPath))
                throw new ArgumentNullException("fullPath");

            var xDoc = XDocument.Load(fullPath);

            var mapType = (HexMapType)Enum.Parse(typeof(HexMapType), xDoc.Root.Attribute("MapCoordsType").Value);
            var hexTilesType = (HexTileType)Enum.Parse(typeof(HexTileType), xDoc.Root.Attribute("TilesType").Value);
            var tilesCountX = int.Parse(xDoc.Root.Attribute("TilesCountX").Value);
            var tilesCountY = int.Parse(xDoc.Root.Attribute("TilesCountY").Value);
            var tilesRadius = int.Parse(xDoc.Root.Attribute("TilesRadius").Value);

            var hexMap = new HexMap(mapType, hexTilesType, tilesCountX, tilesCountY, tilesRadius);

            var tilesets = LoadTilesets(xDoc);

            var xTiles = xDoc.Root.Element("Tiles");
            if (null != xTiles)
            {
                foreach (var xElem in xTiles.Elements("Tile"))
                {
                    var indexX = int.Parse(xElem.Attribute("IndexX").Value);
                    var indexY = int.Parse(xElem.Attribute("IndexY").Value);

                    var currTile = hexMap.Tiles[indexX, indexY] ?? new Tile(indexX, indexY);

                    ParseTileTilesetInfo(tilesets, xElem, currTile);

                    hexMap.Tiles[indexX, indexY] = currTile;
                }
            }

            return hexMap;
        }

        private static void ParseTileTilesetInfo(Dictionary<Guid, Tileset> tilesets, XElement xElem, Tile currTile)
        {
            var xTileset = xElem.Element("Tileset");
            if (null != xTileset)
            {
                var tmpTilesetId = xTileset.Attribute("ID").Value;
                if (!string.IsNullOrWhiteSpace(tmpTilesetId))
                {
                    var tilesetID = new Guid(tmpTilesetId);
                    if (tilesets.ContainsKey(tilesetID))
                    {
                        currTile.Tileset = tilesets[tilesetID];

                        var xTextureSourceBounds = xTileset.Element("TextureSourceBounds");
                        if (null != xTextureSourceBounds)
                        {
                            currTile.TextureSourceBounds = new Microsoft.Xna.Framework.Rectangle(int.Parse(xTextureSourceBounds.Attribute("X").Value),
                                                                                                int.Parse(xTextureSourceBounds.Attribute("Y").Value),
                                                                                                int.Parse(xTextureSourceBounds.Attribute("Width").Value),
                                                                                                int.Parse(xTextureSourceBounds.Attribute("Height").Value));
                        }
                    }
                }
            }
        }

        private static Dictionary<Guid, Tileset> LoadTilesets(XDocument xDoc)
        {
            var tilesets = new Dictionary<Guid, Tileset>();

            var xTilesets = xDoc.Root.Element("Tilesets");
            if (null != xTilesets)
            {
                foreach (var xElem in xTilesets.Elements("Tileset"))
                {
                    var id = new Guid(xElem.Attribute("ID").Value);
                    if (tilesets.ContainsKey(id)) continue;

                    var asset = xElem.Element("Asset").Value;
                    var tileWidth = int.Parse(xElem.Attribute("TileWidth").Value);
                    var tileHeight = int.Parse(xElem.Attribute("TileHeight").Value);

                    var tileset = new Tileset(id, asset, tileWidth, tileHeight);
                    tilesets.Add(id, tileset);
                }
            }

            return tilesets;
        }
    }
}
