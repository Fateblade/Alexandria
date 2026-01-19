using System.Windows.Media.Imaging;

namespace Fateblade.Alexandria.UI.WPF.Base.ActionBar
{
    public interface IIconNameToIconResolver
    {
        bool PreferSvg { get; set; }
        int DefaultMaxWidth { get; set; }
        int DefaultMaxHeight { get; set; }

        object Resolve(string iconName);
        void AddOrOverrideMapping(string iconName, BitmapImage mappedIcon);
        void AddOrOverrideMapping(string iconName, SvgImageInfo mappedIcon);
    }

    public struct SvgImageInfo
    { 
        public string UriSource { get; }
        public bool Fill { get; }
        public bool Stroke { get; }

        public SvgImageInfo(string uriSource, bool fill, bool stroke)
        {
            UriSource = uriSource;
            Fill = fill;
            Stroke = stroke;
        }
    }
}
