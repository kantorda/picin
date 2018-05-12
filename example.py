import cv2

img = cv2.imread("tree.jpg")
grayImg = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
cv2.imshow("Tree", img)
cv2.imshow("Tree - gray", grayImg)
cv2.waitKey(0)
cv2.destroyAllWindows()