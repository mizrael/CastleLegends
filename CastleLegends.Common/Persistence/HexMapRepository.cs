﻿using System;
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
                var tilesets = tiles.Where(t => null != t.Tileset)
                                    .Select(t => t.Tileset)
                                    .Distinct()                                   
                                    .ToArray();

                if (null != tilesets)
                {
                    xMap.Add(new XElement("Tilesets", tilesets.Select(t => new XElement("Tileset",
                                                                                        new XAttribute("ID", t.ID),                                                                                    
                                                                                        new XElement("Asset", t.Asset),
                                                                                        new XElement("Alpha", t.Alpha))
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
                                    new XAttribute("IndexY", tile.IndexY),                                                                              
                                    new XElement("TextureSourceBounds", tile.TextureSourceBounds));

            if (null != tile.Tileset)
                xTile.Add(new XElement("Tileset", tile.Tileset.ID));

            return xTile;            
        }

        public HexMap Load(string fullPath)
        {
            if (string.IsNullOrWhiteSpace(fullPath))
                throw new ArgumentNullException("fullPath");

            var xDoc = XDocument.Load(fullPath);
            var mapType = Convert.ChangeType(xDoc.Root.Attribute("MapCoordsType").Value, typeof(HexMapType));


            throw new NotImplementedException();
        }
    }
}
