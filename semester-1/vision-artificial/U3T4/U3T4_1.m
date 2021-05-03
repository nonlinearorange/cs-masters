% image = rgb2gray(imread('./images/the-elephant-cafe.jpg'));
image = rgb2gray(imread('./images/camaleon_puntos.png'));

window = [-1 -1 -1; -1 8 -1; -1 -1 -1];
resulting_image = abs(imfilter(double(image), window));
T = 200;
resulting_image = resulting_image >= T;

figure();
imshow(image);

figure();
imshow(resulting_image);