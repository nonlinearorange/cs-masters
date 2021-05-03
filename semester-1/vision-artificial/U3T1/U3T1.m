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
title("Canny");

figure();
imshow(laplacian_of_gaussian_image);
title("Laplacian of Gaussian");

figure();
imshow(laplacian_4_image);
title("Laplacian 4");

figure();
imshow(laplacian_8_image);
title("Laplacian 8");

figure();
imshow(morphological_gradient_image);
title("Morphological Gradient");

figure();
imshow(prewitt_image);
title("Prewitt");

figure();
imshow(roberts_image);
title("Roberts");

figure();
imshow(sobel_image);
title("Sobel");

figure();
imshow(zero_image);
title("Zero Crossing");