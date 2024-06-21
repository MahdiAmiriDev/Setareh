using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Setareh.Bussines.Convertor
{
    public class ImageOptimizer
    {

        public void ImageResizer(string InputImagePath , string OutputImagePath , int? width , int? height)
        {
            var customWidth = width ?? 100;
            var customHeight = height ?? 100;

            using (var image = Image.Load(InputImagePath))
            {
                image.Mutate(operation => operation.Resize(customWidth, customHeight)); 

                image.Save(OutputImagePath , new JpegEncoder { Quality = 100});
                
            }
        }

    }
}
