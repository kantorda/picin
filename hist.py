import cv2 as cv
import numpy as np
import sys

#bins = np.arange(256).reshape(256, 1)

# Display individual RGB curves for image
# usage python hist.py <fileName> rgb
# Modified from https://github.com/opencv/opencv/blob/master/samples/python/hist.py
def hist_curve_1d(img):
    bins = np.arange(256).reshape(256, 1)
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

# Display Hue/Saturation curve for image
# usage python hist.py <fileName>
#hsv = cv.cvtColor(img, cv.COLOR_BGR2HSV)
#hist_item = cv.calcHist([hsv], [0, 1], None, [180, 256], [0, 180, 0, 256])
def hist_curve_2d(img):
    bin = np.arange(256)
    bins = []
    for i in range (0, 256):
        bins.append(bin)
    h = np.zeros((300, 256, 3))
    hsv_map = np.zeros((180, 256, 3), np.uint8)
    h, s = np.indices(hsv_map.shape[:2])
    hsv_map[:, :, 0] = h
    hsv_map[:, :, 1] = s
    hsv_map[:, :, 2] = 255
    #hsv_map = cv.cvtColor(hsv_map, cv.COLOR_HSV2BGR)
    hsv = cv.cvtColor(hsv_map, cv.COLOR_BGR2HSV)
    hist_item = cv.calcHist([hsv], [0, 1], None, [180, 256], [0, 180, 0, 256])
    cv.normalize(hist_item, hist_item, 0, 255, cv.NORM_MINMAX)
    hist = np.int32(np.around(hist_item))
    print(bins)
    print(hist)
    pts = np.int32(np.column_stack((bins, hist)))
    return hist

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

    if len(sys.argv) == 2:
        curve = hist_curve_2d(img)
    else:
        curve = hist_curve_1d(img)

    cv.imshow('histogram', curve)
    cv.imshow('image', img)
    cv.waitKey(0)
    cv.destroyAllWindows()