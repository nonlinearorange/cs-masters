image = imread('./images/the-elephant-cafe.jpg');

salt_pepper_image = imnoise(image, 'salt & pepper', 0.06);
gaussian_image =  imnoise(image, 'gaussian');
uniform_image = imnoise(image, 'speckle', 0.15);

k_size_x = 3;
k_size_y = 3;

rows = 1;
columns = 3;

% Mean Filter Treated Images
mean_salt_pepper_image = mean_filter(salt_pepper_image, k_size_x, k_size_y);
mean_gaussian_image = mean_filter(gaussian_image, k_size_x, k_size_y);
mean_uniform_image = mean_filter(uniform_image, k_size_x, k_size_y);

subplot(rows, columns,1);
imshow(mean_salt_pepper_image);

subplot(rows, columns,2);
imshow(mean_gaussian_image);

subplot(rows, columns,3);
imshow(mean_uniform_image);

% Mode Filter Treated Images
mode_salt_pepper_image = mode_filter(salt_pepper_image, k_size_x, k_size_y);
mode_gaussian_image = mode_filter(gaussian_image, k_size_x, k_size_y);
mode_uniform_image = mode_filter(uniform_image, k_size_x, k_size_y);

% Median Filter Treated Images
median_salt_pepper_image = mode_filter(salt_pepper_image, k_size_x, k_size_y);
median_gaussian_image = mode_filter(gaussian_image, k_size_x, k_size_y);
median_uniform_image = mode_filter(uniform_image, k_size_x, k_size_y);

% Min Filter Treated Images
min_salt_pepper_image = mode_filter(salt_pepper_image, k_size_x, k_size_y);
min_gaussian_image = mode_filter(gaussian_image, k_size_x, k_size_y);
min_uniform_image = mode_filter(uniform_image, k_size_x, k_size_y);

% Max Filter Treated Images
max_salt_pepper_image = mode_filter(salt_pepper_image, k_size_x, k_size_y);
max_gaussian_image = mode_filter(gaussian_image, k_size_x, k_size_y);
max_uniform_image = mode_filter(uniform_image, k_size_x, k_size_y);

% Gaussian Filter Treated Images
gauss_salt_pepper_image = imgaussfilt(salt_pepper_image, k_size_x);
gauss_gaussian_image = imgaussfilt(gaussian_image, k_size_x);
gauss_uniform_image = imgaussfilt(uniform_image, k_size_x);
