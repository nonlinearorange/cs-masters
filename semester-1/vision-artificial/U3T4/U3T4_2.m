% image = rgb2gray(imread('./images/the-elephant-cafe.jpg'));
reference_image = rgb2gray(imread('./images/camaleon_puntos.png'));

% Horizontal.
w(:, :, 1) = [-1, -1, -1; 2, 2, 2; -1, -1, 1];

% Vertical.
w(:, :, 2) = rot90(w(:, :, 1));

% 45°.
w(:, :, 3) = [-1, -1, 2; -1, 2, -1; 2, -1, -1];

% -45°.
w(:, :, 4) = rot90(w(:, :, 2));

for i = 1: 4
    resulting_image(:, :, i) = imfilter(reference_image, w(:, :, i));
    figure();
    imshow(resulting_image(:, :, i));  
end
