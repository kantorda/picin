using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PicIN
{
    public class ImageProcessing
    {
        #region Private Properties
        private FSHelper mFSHelper = new FSHelper();
        private Controller mController = Controller.Instance;
        #endregion

        #region Public Properties

        public ConcurrentDictionary<string, string> ImageData { get; }
        #endregion

        #region Private Methods

        private void ProcessImage(string path)
        {
            String[] mainColors = new String[9];
            String[] secondaryColors = new String[9];

            LibraryInterface.Interface.ProcessImage(path, out String luminocity,
            out String complexity, mainColors, secondaryColors, out String red,
            out String yellow, out String green, out String cyan, out String blue,
            out String purple, out String black, out String gray, out String white);

            ImageData image = new ImageData();
            image.mPath = path;
            image.mLuminocity = image.LuminocityStringToEnum(luminocity);
            image.mComplexity = float.Parse(complexity);
            mainColors.Where(e => !String.IsNullOrEmpty(e)).ToList().ForEach(e => image.mMainColors.Add(image.ColorStringToEnum(e)));
            secondaryColors.Where(e => !String.IsNullOrEmpty(e)).ToList().ForEach(e => image.mSecondaryColors.Add(image.ColorStringToEnum(e)));
            image.mColorWeight[image.ColorStringToEnum("red")] = float.Parse(red);
            image.mColorWeight[image.ColorStringToEnum("yellow")] = float.Parse(yellow);
            image.mColorWeight[image.ColorStringToEnum("green")] = float.Parse(green);
            image.mColorWeight[image.ColorStringToEnum("cyan")] = float.Parse(cyan);
            image.mColorWeight[image.ColorStringToEnum("blue")] = float.Parse(blue);
            image.mColorWeight[image.ColorStringToEnum("purple")] = float.Parse(purple);
            image.mColorWeight[image.ColorStringToEnum("black")] = float.Parse(black);
            image.mColorWeight[image.ColorStringToEnum("gray")] = float.Parse(gray);
            image.mColorWeight[image.ColorStringToEnum("white")] = float.Parse(white);

            mController.ImageListAll.Add(image);
        }
        #endregion

        #region Public Methods
        public async Task<bool> ProcessDirectoryAsync(string path)
        {
            if (!mFSHelper.FindImages(path))
                return false;

            // No clean way to Clear a ConcurrentBag
            // Re-indexing a directory from scratch
            // If data from a previous run or directory is stored in memory
            // replace it with a new container, let garbage collection clean up the memory
            if (!mController.ImageListAll.IsEmpty)
                mController.ImageListAll = new ConcurrentBag<ImageData>();

             _ = Parallel.ForEach(mFSHelper.ImageList, img => ProcessImage(img.FullName));

            return !mController.ImageListAll.IsEmpty;
        }

        #endregion
    }

    public class ImageData
    {
        #region Enums
        public enum Luminocity
        {
            Bright = 0,
            Neutral = 1,
            Dark = 2,
            Null = 3
        }

        public enum Color
        {
            Red = 0,
            Yellow = 1, 
            Green = 2,
            Cyan = 3,
            Blue = 4,
            Purple = 5,
            Black = 6,
            Gray = 7,
            White = 8,
            Null = 9
        }

        public Luminocity LuminocityStringToEnum(String lum)
        {
            if (String.Compare(lum, "bright", true) == 0)
                return Luminocity.Bright;
            if (String.Compare(lum, "neutral", true) == 0)
                return Luminocity.Neutral;
            if (String.Compare(lum, "dark", true) == 0)
                return Luminocity.Dark;

            return Luminocity.Null;
        }

        public Color ColorStringToEnum(string color)
        {
            if (String.Compare(color, "red", true) == 0)
                return Color.Red;
            if (String.Compare(color, "yellow", true) == 0)
                return Color.Yellow;
            if (String.Compare(color, "green", true) == 0)
                return Color.Green;
            if (String.Compare(color, "cyan", true) == 0)
                return Color.Cyan;
            if (String.Compare(color, "blue", true) == 0)
                return Color.Blue;
            if (String.Compare(color, "purple", true) == 0)
                return Color.Purple;
            if (String.Compare(color, "black", true) == 0)
                return Color.Black;
            if (String.Compare(color, "gray", true) == 0)
                return Color.Gray;
            if (String.Compare(color, "white", true) == 0)
                return Color.White;

            return Color.Null
;        }
        #endregion

        #region Constructor
        public ImageData()
        {
            mMainColors = new List<Color>();
            mSecondaryColors = new List<Color>();
            mColorWeight = new Dictionary<Color, float>();
        }
        #endregion

        #region Private Properties
        #endregion

        #region Public Properties
        public String mPath { get; set; }
        public Luminocity mLuminocity { get; set; }
        public float mComplexity { get; set; }
        public List<Color> mMainColors { get; set; }
        public List<Color> mSecondaryColors { get; set; }
        public Dictionary<Color, float> mColorWeight { get; set; }
        #endregion

        #region Private Methods
        #endregion
    }
}