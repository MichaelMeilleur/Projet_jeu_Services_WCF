using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using ServiceConnexion;
using System.Windows.Shapes;
using System.Linq;
using System.Security.AccessControl;

namespace HugoWorld
{

    /// <summary>
    /// Area defines the 8x8 grid that contains a set of MapTiles
    /// </summary>
    public class Area : GameObject
    {
        public const int AreaOffsetX = 30;
        public const int AreaOffsetY = 50;
        public const int MapSizeX = 8;
        public const int MapSizeY = 8;

        public MapTile[,] Map = new MapTile[MapSizeX, MapSizeY];
        private System.Drawing.Rectangle _areaRectangle = new System.Drawing.Rectangle(AreaOffsetX, AreaOffsetY, MapSizeX * Tile.TileSizeX, MapSizeY * Tile.TileSizeY);

        public string Name;
        public string NorthArea;
        public string EastArea;
        public string SouthArea;
        public string WestArea;

        public Area(List<ObjetMonde> lstObj, List<Item> lstItems, Dictionary<string, Tile> tiles, int tileX, int tileY)
        {
            //Look up the tile and construct the sprite
            for (int j = 0; j < MapSizeY; j++)
            {
                //Get a line of map characters
                for (int i = 0; i < MapSizeX; i++)
                {
                    MapTile mapTile = new MapTile();
                    //Gazon par défaut
                    Tile tile = tiles["."];
                    mapTile.Tile = tile;
                    mapTile.SetSprite(j, i);
                    Map[j, i] = mapTile;

                    //Trouver les objets pour la tile spécifique
                    List<ObjetMonde> objs = lstObj.Where(x => x.X == i * (tileX + 1) && x.Y == j * (tileY + 1)).ToList();
                    List<Item> items = lstItems.Where(x => x.X == i * (tileX + 1) && x.Y == j * (tileY + 1) && x.IdHero == null).ToList();

                    foreach (ObjetMonde obj in objs)
                    {
                        mapTile.Tile = tiles[ConvertIdToType(obj.TypeObjet.ToString())];
                        mapTile.SetSprite(j, i);
                    }
                    foreach (Item item in items)
                    {
                        mapTile.ObjectTile = tiles[ConvertIdToType(item.ImageId.ToString())]; //Mapper typeobjet à un objet
                        mapTile.SetObjectSprite(item.Y.Value, item.X.Value);

                        if (mapTile.ObjectTile != null && mapTile.ObjectTile.IsTransparent)
                        {
                            mapTile.ObjectSprite.ColorKey = Color.FromArgb(75, 75, 75);
                        }
                        Map[j, i] = mapTile;
                    }
                }
            }

        }

        private string ConvertIdToType(string id)
        {
            using (StreamReader streamReader = new StreamReader(@"GameData\TileLookups.csv"))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    //separate out the elements of the 
                    string[] elements = line.Split(',');

                    if (elements[1] == id)
                    {
                        return elements[2];
                    }
                }
                return null;
            }
        }

        public override void Update(double gameTime, double elapsedTime)
        {
            //Update all the map tiles and any objects
            foreach (MapTile mapTile in Map)
            {
                mapTile.Sprite.Update(gameTime, elapsedTime);
                if (mapTile.ObjectSprite != null)
                {
                    if (mapTile.ObjectSprite.NumberOfFrames > 1)
                    {
                        mapTile.ObjectSprite.CurrentFrame = (int)((gameTime * 8.0) % (double)mapTile.ObjectSprite.NumberOfFrames);
                    }
                    mapTile.ObjectSprite.Update(gameTime, elapsedTime);
                }
            }
        }

        public override void Draw(Graphics graphics)
        {
            //And draw the map and any objects
            foreach (MapTile mapTile in Map)
            {
                mapTile.Sprite.Draw(graphics);
                if (mapTile.ObjectSprite != null)
                {
                    mapTile.ObjectSprite.Draw(graphics);
                }
            }

        }
    }
}
