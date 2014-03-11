using System;
using System.ComponentModel;
using System.Linq;
using CastleLegends.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CastleLegends.Editor.ViewModels
{
    [DisplayName("Tile")]
    public class TileViewModel
    {
        private short _snapTo;

        public TileViewModel(Tile tile, HexMap map)
        {
            if (null == tile)
                throw new ArgumentNullException("tile");
            this.Tile = tile;

            this.Map = map;
        }

        #region Properties

        [Browsable(false)]
        public Tile Tile { get; private set; }

        [Browsable(false)]
        public HexMap Map { get; private set; }

        [DisplayName("Snap To")]
        [Category("Tile Properties")]
        [TypeConverter(typeof(RuleConverter))]
        public short Snap
        {
            get { return _snapTo; }
            set { 
                _snapTo = value;

                if (this.Map.TilesType == HexTileType.FlatTopped) {
                    switch ((SnapTo_FlatTopped)_snapTo) { 
                        case SnapTo_FlatTopped.Center:
                            this.Tile.TextureOffset = Vector2.Zero;
                            break;
                        case SnapTo_FlatTopped.CenterLeft:
                            this.Tile.TextureOffset = new Vector2(-this.Map.TilesRadius * .5f, 0);
                            break;
                        case SnapTo_FlatTopped.CenterRight:
                            this.Tile.TextureOffset = new Vector2(this.Map.TilesRadius * .5f, 0);
                            break;
                        case SnapTo_FlatTopped.TopLeft:
                            this.Tile.TextureOffset = new Vector2(-this.Map.TilesRadius * .5f, -this.Map.TileVerticalDistanceHalf);
                            break;
                        case SnapTo_FlatTopped.TopRight:
                            this.Tile.TextureOffset = new Vector2(this.Map.TilesRadius * .5f, -this.Map.TileVerticalDistanceHalf);
                            break;
                        case SnapTo_FlatTopped.BottomLeft:
                            this.Tile.TextureOffset = new Vector2(-this.Map.TilesRadius * .5f, this.Map.TileVerticalDistanceHalf);
                            break;
                        case SnapTo_FlatTopped.BottomRight:
                            this.Tile.TextureOffset = new Vector2(this.Map.TilesRadius * .5f, this.Map.TileVerticalDistanceHalf);
                            break;
                    }                    
                }
                
            }
        }

        #endregion Properties

        public enum SnapTo_PointyTopped: short
        { 
            Center = 0,
            TopLeft
        }

        public enum SnapTo_FlatTopped : short
        {
            Center = 0,
            TopLeft,
            TopRight,
            CenterLeft,
            CenterRight,
            BottomLeft,
            BottomRight
        }
    }

    public class RuleConverter : Int16Converter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            //true means show a combobox
            return true;
        }

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            //true will limit to list. false will show the list, 
            //but allow free-form entry
            return true;
        }

        public override object ConvertFrom(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value)
        {
            if (null == context) return 0;
             var enumType = ResolveEnumType(context);
             var retVal = (short)Enum.Parse(enumType, value as string);
             return retVal;
        }

        public override object ConvertTo(ITypeDescriptorContext context, System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (null == context) 
                return string.Empty;

            var name = value as string;
            if (!string.IsNullOrWhiteSpace(name))
                return name;

            var enumType = ResolveEnumType(context);
            name = Enum.GetName(enumType, value);
            return name; // base.ConvertTo(context, culture, value, destinationType);
        }

        public override System.ComponentModel.TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            if (null == context) return null;

            var enumType = ResolveEnumType(context);
            
            var values = Enum.GetNames(enumType);

            return new StandardValuesCollection(values);
        }

        private static Type ResolveEnumType(ITypeDescriptorContext context)
        {
            var vm = context.Instance as TileViewModel;
            var enumType = typeof(TileViewModel.SnapTo_FlatTopped);

            if (vm.Map.TilesType == HexTileType.PointyTopped)
                enumType = typeof(TileViewModel.SnapTo_PointyTopped);
            return enumType;
        }
    }
}
