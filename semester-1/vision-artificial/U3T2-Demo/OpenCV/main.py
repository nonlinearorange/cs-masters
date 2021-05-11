# OpenCV Demo
# Visión Artificial
# Ian A. Ruiz

import cv2 as cv


def read_image_example():
    reference_image = cv.imread('images/wwf-elephant.jpg')
    cv.imshow('My-Elephant', reference_image)

    cv.waitKey(0)


def read_video_example():
    capture = cv.VideoCapture('videos/beach.mp4')

    while True:
        is_true, frame = capture.read()
        cv.imshow('Beach-Video', frame)

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
    read_image_example()
    read_rescaled_image_example()


if __name__ == '__main__':
    main()
