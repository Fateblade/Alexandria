using Fateblade.Alexandria.UI.WPF.Base.Exceptions;
using SharpVectors.Converters;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Fateblade.Alexandria.UI.WPF.Base.ActionBar
{
    public class IconNameToResourceResolver : IIconNameToIconResolver
    {
        private readonly Dictionary<string, BitmapImage> _bitmapImageSources;
        private readonly Dictionary<string, SvgImageInfo> _svgImagePaths;

        public bool PreferSvg { get; set; } = true;
        public int DefaultMaxWidth { get; set; } = 32;
        public int DefaultMaxHeight { get; set; } = 32;

        public IconNameToResourceResolver()
        {
            _bitmapImageSources = new();
            _svgImagePaths = new();
        }

        public object Resolve(string iconName)
        {
            if (!_bitmapImageSources.ContainsKey(iconName) && !_svgImagePaths.ContainsKey(iconName))
                throw new IconMappingNotFoundException(
                    $"No mapping exists for '{iconName}' not found in {nameof(IconNameToResourceResolver)}, register it via {nameof(IIconNameToIconResolver)}.{nameof(AddOrOverrideMapping)}");

            if (PreferSvg)
            {
                var svgIcon = ResolveFromSvgMappings(iconName);
                if (svgIcon != null) return svgIcon;

                return ResolveFromBitmapMappings(iconName);
            }

            var bitmapImage = ResolveFromBitmapMappings(iconName);
            if (bitmapImage != null) return bitmapImage;

            return ResolveFromSvgMappings(iconName);
        }

        private Image ResolveFromBitmapMappings(string iconName)
        {
            if (!_bitmapImageSources.ContainsKey(iconName)) return null;

            var bitmapImageSource = _bitmapImageSources[iconName];

            return new Image()
            {
                Source = bitmapImageSource,
                MaxWidth = DefaultMaxWidth,
                MaxHeight = DefaultMaxHeight,
                SnapsToDevicePixels = true
            };
        }

        private SvgIcon ResolveFromSvgMappings(string iconName)
        {
            if (!_svgImagePaths.ContainsKey(iconName)) return null;

            var svgImageInfo = _svgImagePaths[iconName];

            var icon = new SvgIcon()
            {
                UriSource = tryFormatToSvgUri(svgImageInfo.UriSource),
                MaxWidth = DefaultMaxWidth,
                MaxHeight = DefaultMaxHeight
            };

            if (svgImageInfo.Fill)
            {
                icon.Fill = (Brush)Application.Current.FindResource("MahApps.Brushes.Badged.Background");
            }
            if (svgImageInfo.Stroke)
            {
                icon.Stroke = (Brush)Application.Current.FindResource("MahApps.Brushes.Badged.Background");
            }

            return icon;
        }

        private Uri tryFormatToSvgUri(string path)
        {
            if (!path.StartsWith("pack://"))
            {
                return new Uri($"pack://application:,,,{path}", UriKind.Absolute);
            }

            return new Uri(path);
        }

        public void AddOrOverrideMapping(string iconName, BitmapImage mappedIcon)
        {
            _bitmapImageSources[iconName] = mappedIcon;
        }

        public void AddOrOverrideMapping(string iconName, SvgImageInfo mappedIcon)
        {
            _svgImagePaths[iconName] = mappedIcon;
        }
    }

}
