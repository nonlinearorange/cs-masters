image = imread('./images/the-elephant-cafe.jpg');

canny_image = canny(image);
laplacian_of_gaussian_image = laplacian_of_gaussian(image);
laplacian_4_image = laplacian(image, 4);
laplacian_8_image = laplacian(image, 8);
morphological_gradient_image = morphological_gradient(image);
prewitt_image = prewitt(image);
roberts_image = roberts(image);
sobel_image = sobel(image);
zero_image = zero_cross(image);

figure();
imshow(canny_image);

figure();
imshow(laplacian_of_gaussian_image);

figure();
imshow(laplacian_4_image);

figure();
imshow(laplacian_8_image);

figure();
imshow(morphological_gradient_image);

figure();
imshow(prewitt_image);

figure();
imshow(roberts_image);

figure();
imshow(sobel_image);

figure();
imshow(zero_image);