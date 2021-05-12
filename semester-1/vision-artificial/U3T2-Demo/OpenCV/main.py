# OpenCV Demo
# Visión Artificial
# Ian A. Ruiz
import cv2
import cv2 as cv
import numpy as np


def laplacian_example():
    reference_image = cv.imread('images/wwf-elephant.jpg')
    gray_image = cv2.cvtColor(reference_image, cv2.COLOR_BGR2GRAY)

    laplacian = cv2.Laplacian(gray_image, cv2.CV_64F)
    cv.imshow('Laplacian', laplacian)

    cv.waitKey(0)


def sobel_example():
    reference_image = cv.imread('images/wwf-elephant.jpg')
    gray_image = cv2.cvtColor(reference_image, cv2.COLOR_BGR2GRAY)

    sobel = cv2.Sobel(gray_image, cv2.CV_64F, 1, 0, ksize=5)
    cv.imshow('Sobel', sobel)

    cv.waitKey(0)


def draw_example():
    blank = np.zeros((500, 500, 3), dtype='uint8')
    blank[:] = 0, 255, 0
    blank[200:300, 300:400] = 0, 0, 255

    cv.imshow('Blank', blank)

    cv.rectangle(blank, (0, 0), (250, 250), (255, 255, 0), thickness=2)
    cv.imshow('Rectangle', blank)

    cv.waitKey(0)


def read_image_example():
    reference_image = cv.imread('images/wwf-elephant.jpg')
    cv.imshow('My-Elephant', reference_image)

    cv.waitKey(0)


def read_video_example():
    capture = cv.VideoCapture('videos/beach.mp4')

    while True:
        is_true, frame = capture.read()
        sobel = cv2.Sobel(frame, cv2.CV_64F, 1, 0, ksize=5)
        cv.imshow('Beach-Video', sobel)

        if cv.waitKey(20) & 0xFF == ord('d'):
            break

    capture.release()
    cv.destroyAllWindows()


def read_rescaled_image_example():
    reference_image = cv.imread('images/wwf-elephant.jpg')
    resized_frame_image = rescale_frame(reference_image)

    cv.imshow('My-Elephant', resized_frame_image)
    cv.waitKey(0)


def read_rescaled_video_example():
    capture = cv.VideoCapture('videos/beach.mp4')

    while True:
        is_true, frame = capture.read()
        cv.imshow('Beach-Video', rescale_frame(frame))

        if cv.waitKey(20) & 0xFF == ord('d'):
            break

    capture.release()
    cv.destroyAllWindows()


def rescale_frame(frame, scale=0.75):
    width = int(frame.shape[1] * scale)
    height = int(frame.shape[0] * scale)

    dimensions = (width, height)

    return cv.resize(frame, dimensions, interpolation=cv.INTER_AREA)


def main():
    read_video_example()
    # read_rescaled_video_example()
    # read_image_example()
    # read_rescaled_image_example()
    # draw_example()
    # sobel_example()
    # laplacian_example()
    # sobel_example()


if __name__ == '__main__':
    main()
