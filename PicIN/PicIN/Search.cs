using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PicIN
{
    enum ComplexityLevel
    {
        Simple = 0,
        Medium = 1,
        Complex = 2
    }

    enum SearchType
    {
        And = 0,
        Or = 1
    }

    class Search
    {
        #region Private Properties
        Controller mController = Controller.Instance;
        #endregion

        #region Public Properties
        public List<ImageData.Color> MainColors = new List<ImageData.Color>();
        public List<ImageData.Color> SecondaryColors = new List<ImageData.Color>();
        public List<ImageData.Luminocity> Luminocities = new List<ImageData.Luminocity>();
        public List<ComplexityLevel> ComplexityLevels = new List<ComplexityLevel>();
        public SearchType ActiveSearchType = SearchType.Or;

        #endregion

        #region Public Methods
        public async Task SearchAsync()
        {
            mController.ImagesSearchResults = mController.ImagesConcurrentBag.ToList<ImageData>();
            mController.ImageListSearchResults.Images.Clear();

            colorSearch();

            luminocitySearch();

            complexitySearch();

            sortImageList();
        }

        #endregion

        #region Private Methods
        private void colorSearch()
        {
            // Main Colors

            if (ActiveSearchType == SearchType.And)
            {
                foreach (ImageData.Color color in MainColors)
                {
                    mController.ImagesSearchResults = mController.ImagesSearchResults.Where(img
                        => img.mMainColors.Contains(color)).ToList<ImageData>();
                }
            }
            else
            {
                if (MainColors.Count > 0)
                {
                    mController.ImagesSearchResults.Clear();

                    foreach (ImageData.Color color in MainColors)
                    {
                        mController.ImagesSearchResults.AddRange(mController.ImagesConcurrentBag.Where(img
                            => img.mMainColors.Contains(color)).ToList<ImageData>());
                    }
                }
            }

            //SecondaryColors
            if (SecondaryColors.Count > 0)
            {
                List<ImageData> temp = new List<ImageData>(mController.ImagesSearchResults);
                mController.ImagesSearchResults.Clear();

                foreach (ImageData.Color color in SecondaryColors)
                {
                    mController.ImagesSearchResults.AddRange(temp.Where(img
                        => img.mSecondaryColors.Contains(color)).ToList<ImageData>());
                }
            }
        }

        private void luminocitySearch()
        {
            if (Luminocities.Count > 0)
            {
                List<ImageData> temp = new List<ImageData>(mController.ImagesSearchResults);
                mController.ImagesSearchResults.Clear();

                foreach (ImageData.Luminocity lum in Luminocities)
                {
                    mController.ImagesSearchResults.AddRange((temp.Where(img
                        => img.mLuminocity == lum)));
                }
            }
        }

        private void complexitySearch()
        {
            if (ComplexityLevels.Count > 0)
            { 
                float complexityMin = 14.0f;
                float complexityMax = 0.0f;

                foreach (ComplexityLevel complexity in ComplexityLevels)
                {
                    switch (complexity)
                    {
                        case ComplexityLevel.Simple:
                            complexityMin = Math.Min(complexityMin, 0.0f);
                            complexityMax = Math.Max(complexityMax, 6.0f);
                            break;
                        case ComplexityLevel.Medium:
                            complexityMin = Math.Min(complexityMin, 3.0f);
                            complexityMax = Math.Max(complexityMax, 9.0f);
                            break;
                        case ComplexityLevel.Complex:
                            complexityMin = Math.Min(complexityMin, 9.0f);
                            complexityMax = Math.Max(complexityMax, 14.0f);
                            break;
                    }
                }

                mController.ImagesSearchResults = mController.ImagesSearchResults.Where(img 
                    => (img.mComplexity >= complexityMin && img.mComplexity <= complexityMax)).ToList<ImageData>();
            }
        }

        private void sortImageList()
        {
            if (MainColors.Count == 1)
            {
                mController.ImagesSearchResults.Sort(delegate (ImageData left, ImageData right)
                {
                    ImageData.Color color = MainColors.First();

                    if (left.mColorWeight[color] < right.mColorWeight[color])
                        return 1;
                    if (left.mColorWeight[color] > right.mColorWeight[color])
                        return -1;
                    return 0;
                });
            }
        }
        #endregion
    }
}
