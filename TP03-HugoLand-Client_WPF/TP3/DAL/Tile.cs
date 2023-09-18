using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace HugoWorld
{
    public class Tile 
    {
        private static BitmapCache _bitmaps = new BitmapCache();
        public const int TileSizeX = 64;
        public const int TileSizeY = 64;

        public Bitmap Bitmap;
        public Rectangle Rectangle;
        public bool IsTransparent;
        public int NumberOfFrames;
        public bool IsBlock;
        public string Category;
        public string UniqueAttribute;
        public string AttributeType;


        //Special fields for some
        public string Color;
        public int Health;

        public string Name;
        public string TypeID;
        public string Shortcut;

        public Tile(string[] tileData)
        {
            Name = tileData[0];
            TypeID = tileData[1];
            Shortcut = tileData[2];
            Category = tileData[3].ToLower();
            Bitmap = _bitmaps[tileData[4]];
            NumberOfFrames = Convert.ToInt32(tileData[8]);
            Rectangle = new Rectangle((Convert.ToInt32(tileData[5]) - 1) * TileSizeX, (Convert.ToInt32(tileData[6]) - 1) * TileSizeY, TileSizeX * NumberOfFrames, TileSizeY);
            IsTransparent = (tileData[7].ToLower() == "y");
            IsBlock = ((tileData[9].ToLower())=="block");
            UniqueAttribute = tileData[10].ToLower(); //Peut être une couleur ou durée d,animation
            AttributeType = tileData[11].ToLower(); //Objet, Animation, Item ,etc..

            //Some types of tiles have a color
            if (Category == "door" || Category =="key")
            {
                Color = tileData[10].ToLower();
            }

            //Some types of tiles have health
            if (Category == "character")
            {
                Health = Convert.ToInt32(tileData[10]);
            }

        }
    }
}
