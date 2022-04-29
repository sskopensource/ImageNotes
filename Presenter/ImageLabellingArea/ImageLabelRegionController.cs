using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageLabellingArea
{
    public class ImageLabelRegionController
    {
        private ImageLabellingRegion labelRegion;

        public ImageLabelRegionController(MainGrid parentGrid)
        {
            labelRegion = new ImageLabellingRegion(parentGrid);
        }

    }
}
