clc;

image = imread('./images/the-elephant-cafe.jpg');
reference_image = rgb2gray(image);

% Kernel size.
k_size_x = 3;
k_size_y = 3;

salt_pepper_image = salt_and_pepper_noise(reference_image, 6);
gaussian_image =  imnoise(reference_image, 'gaussian');
uniform_image = imnoise(reference_image, 'speckle', 0.15);

% Noise.
% Salt and Pepper noise-affected images.
figure(); % 1
imshow([reference_image, salt_pepper_image]);

% Gaussian noise-affected images.
figure(); % 2
imshow([reference_image, gaussian_image]);

% Uniform noise-affected images.
figure(); % 3
imshow([reference_image, uniform_image]);

% Filters.
% Mean Filter Treated Images.

% --- Salt and Pepper.
mean_salt_pepper_image = mean_filter(salt_pepper_image, k_size_x, k_size_y);

figure(); % 4
imshow([reference_image, salt_pepper_image, mean_salt_pepper_image]);

% --- Gaussian.
mean_gaussian_image = mean_filter(gaussian_image, k_size_x, k_size_y);

figure(); % 5
imshow([reference_image, gaussian_image, mean_gaussian_image]);

% --- Uniform.
mean_uniform_image = mean_filter(uniform_image, k_size_x, k_size_y);

figure(); % 6
imshow([reference_image, uniform_image, mean_uniform_image]);

% Mode Filter Treated Images.

% --- Salt and Pepper.
mode_salt_pepper_image = mode_filter(salt_pepper_image, k_size_x, k_size_y);

figure(); % 7
imshow([reference_image, salt_pepper_image, mode_salt_pepper_image]);

% --- Gaussian.
mode_gaussian_image = mode_filter(gaussian_image, k_size_x, k_size_y);

figure(); % 8
imshow([reference_image, gaussian_image, mode_gaussian_image]);

% --- Uniform.
mode_uniform_image = mode_filter(uniform_image, k_size_x, k_size_y);

figure(); % 9
imshow([reference_image, uniform_image, mode_uniform_image]);

% Median Filter Treated Images.

% --- Salt and Pepper.
median_salt_pepper_image = mode_filter(salt_pepper_image, k_size_x, k_size_y);

figure(); % 10
imshow([reference_image, salt_pepper_image, median_salt_pepper_image]);

% --- Gaussian.
median_gaussian_image = mode_filter(gaussian_image, k_size_x, k_size_y);

figure(); % 11
imshow([reference_image, gaussian_image, median_gaussian_image]);

% --- Uniform.
median_uniform_image = mode_filter(uniform_image, k_size_x, k_size_y);

figure(); % 12
imshow([reference_image, uniform_image, median_uniform_image]);

% Min Filter Treated Images

% --- Salt and Pepper.
min_salt_pepper_image = mode_filter(salt_pepper_image, k_size_x, k_size_y);

figure(); % 13
imshow([reference_image, salt_pepper_image, min_salt_pepper_image]);

% --- Gaussian.
min_gaussian_image = mode_filter(gaussian_image, k_size_x, k_size_y);

figure(); % 14
imshow([reference_image, gaussian_image, min_gaussian_image]);

% --- Uniform.
min_uniform_image = mode_filter(uniform_image, k_size_x, k_size_y);

figure(); % 15
imshow([reference_image, uniform_image, min_uniform_image]);

% Max Filter Treated Images.

% --- Salt and Pepper.
max_salt_pepper_image = mode_filter(salt_pepper_image, k_size_x, k_size_y);

figure(); % 16
imshow([reference_image, salt_pepper_image, max_salt_pepper_image]);

% --- Gaussian.
max_gaussian_image = mode_filter(gaussian_image, k_size_x, k_size_y);

figure(); % 17
imshow([reference_image, gaussian_image, max_gaussian_image]);

% --- Uniform.
max_uniform_image = mode_filter(uniform_image, k_size_x, k_size_y);

figure(); % 18
imshow([reference_image, uniform_image, max_uniform_image]);

% Gaussian Filter Treated Images

% --- Salt and Pepper.
gauss_salt_pepper_image = imgaussfilt(salt_pepper_image, k_size_x);

figure(); % 19
imshow([reference_image, salt_pepper_image, gauss_salt_pepper_image]);

% --- Gaussian.
gauss_gaussian_image = imgaussfilt(gaussian_image, k_size_x);

figure(); % 20
imshow([reference_image, gaussian_image, gauss_gaussian_image]);

% --- Uniform.
gauss_uniform_image = imgaussfilt(uniform_image, k_size_x);

figure(); % 21
imshow([reference_image, uniform_image, gauss_uniform_image]);

