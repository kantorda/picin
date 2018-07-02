#Color analysis of image in HSV color space
#Code from https://giusedroid.blogspot.com/2015/04/using-python-and-k-means-in-hsv-color.html

import cv2 as cv
from scipy.cluster.vq import vq, kmeans
from matplotlib import pyplot as plt
import numpy as np
import time as t
import sys

#HSV Histograms
def hist(img):
	#convert from rgv to hsv color space
	hsvImg = cv.cvtColor(img, cv.COLOR_RGB2HSV)
	#break apart object structure for clarity
	hue, sat, val = hsvImg[:,:,0], hsvImg[:,:,1], hsvImg[:,:,2]
	#display image and each histogram
	plt.figure(figsize=(10,8))
	plt.subplot(411)
	plt.subplots_adjust(hspace=0.5)
	plt.title('Image')
	plt.imshow(img)
	plt.subplot(412)
	plt.title('Hue')
	plt.hist(np.ndarray.flatten(hue), bins=180)
	plt.subplot(413)
	plt.title('Saturation')
	plt.hist(np.ndarray.flatten(sat), bins=128)
	plt.subplot(414)
	plt.title('Luminosity Value')
	plt.hist(np.ndarray.flatten(val), bins=128)
	plt.show()
	return

#Display visually recognizable bins
def cluster(img, K, channels):
	#get height, width, and the number of channels from the image shape
	h,w,c = img.shape
	#prepare data for clustering by reshaping the image matrix into a (h*w) * c matrix of pixels
	clusterData = img.reshape((h*w,c))
	#record processing time
	t0 = t.time()
	#perform clustering
	codebook, distortion = kmeans(np.array(clusterData[:,0:channels], dtype=np.float), K)
	t1 = t.time()

	#calculate total number of pixels
	numPixels = h*w
	#generate clusters
	data, dist = vq(clusterData[:,0:channels], codebook)
	#calculate the number of elements for each cluster
	weights = [len(data[data == i]) for i in range(0,K)]

	#create a 4 column matrix
	#weight, hue, saturation, luminosity value
	colorRank = np.column_stack((weights, codebook))
	#sort by weight
	colorRank = colorRank[np.argsort(colorRank[:,0])]

	#create blank image
	newImg = np.array([0,0,255], dtype=np.uint8) * np.ones((500,500,3), dtype=np.uint8)
	imgHeight = newImg.shape[0]
	imgWidth = newImg.shape[1]

	#for each cluster
	for i,c in enumerate(colorRank[::-1]):
		weight = c[0]
		height = int(weight / float(numPixels) * imgHeight)
		width = imgWidth / len(colorRank)
		#calculate position of the bin
		x_pos = i * width
		#defines a color so that if less than 3 channels have been used
		#for clustering, the color has average saturation and luminosity value
		color = np.array([0,128,200], dtype=np.uint8)
		#substitute the known HSV components in the default color
		for j in range(len(c[1:])):
			color[j] = c[j + 1]
		#draws the bin to the image
		newImg[int(imgHeight - height):int(imgHeight), int(x_pos):int(x_pos+width)] = [color[0], color[1], color[2]]
	#return the cluster representation
	return newImg, t1 - t0

def bins(img):
	#create new figure size 12x10in
	plt.figure(figsize=(12,10))
	#create 4-column subplot
	plt.subplot(141)
	#draw img in first cell
	plt.imshow(img)

	#calculate clusters for:
	# h
	# h and s
	# h, s, and v

	for i in range(1,4):
		plt.subplot(141 + i)
		plt.title("Channels: %i" % i)
		newImg,elapsedTime = cluster(img, 5, i)
		newImg = cv.cvtColor(newImg, cv.COLOR_HSV2RGB)
		plt.imshow(newImg)
		print("clustering took %i seconds" % elapsedTime)
	plt.show()
	return



if __name__ == "__main__":
	try:
		file = sys.argv[1]
	except:
		print("missing argument(s)")
		exit()

	img = cv.imread(file)

	if img is None:
		print("couldn\'t load image: ", file)
		exit()

	if len(sys.argv) != 3:
		print("missing argument(s)")
		exit()

	if sys.argv[2] == '-b':
		bins(img)
	elif sys.argv[2] == '-h':
		hist(img)
	else:
		print("invalid argument")

	exit()