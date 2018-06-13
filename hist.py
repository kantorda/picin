import cv2 as cv
import numpy as np
import sys

bins = np.arange(256).reshape(256, 1)

# Display individual RGB curves for image
# usage python hist.py <fileName>
# Modified from https://github.com/opencv/opencv/blob/master/samples/python/hist.py
def hist_curve(img):
    h = np.zeros((300, 256, 3))
    if len(img.shape) == 2:
        color = [(255, 255, 255)]
    elif img.shape[2] == 3:
        color = [ (255, 0, 0), (0, 255, 0), (0, 0, 255) ]
    for ch, col in enumerate(color):
        hist_item = cv.calcHist([img], [ch], None, [256], [0,256])
        cv.normalize(hist_item, hist_item, 0, 255, cv.NORM_MINMAX)
        hist = np.int32(np.around(hist_item))
        pts = np.int32(np.column_stack((bins, hist)))
        cv.polylines(h, [pts], False, col)
    y = np.flipud(h)
    return y

if __name__ == '__main__':
    try:
        fname = sys.argv[1]
    except:
        print('bad input')
        exit()

    img = cv.imread(fname)

    if img is None:
        print('couldn\'t load image: ', fname )
        exit()

    curve = hist_curve(img)
    cv.imshow('histogram', curve)
    cv.imshow('image', img)
    cv.waitKey(0)
    cv.destroyAllWindows()