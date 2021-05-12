full_image = double(rgb2gray(imread('./images/benson-full.jpg')));
%full_image = double(rgb2gray(imread('./images/vorozheeva-full.jpg')));
%full_image = double(rgb2gray(imread('./images/rodan-bmw-full.jpg')));
%full_image = double(rgb2gray(imread('./images/book-full.jpg')));

figure();
imshow(mat2gray(full_image));

reference_image = double(rgb2gray(imread('./images/benson-reference.jpg')));
%reference_image = double(rgb2gray(imread('./images/vorozheeva-reference-2.jpg')));
%reference_image = double(rgb2gray(imread('./images/rodan-bmw-reference.jpg')));
%reference_image = double(rgb2gray(imread('./images/book-reference.jpg')));

figure();
imshow(mat2gray(reference_image));

%resulting_image = global_correlation(full_image, reference_image);
%figure();
%imshow(mat2gray(resulting_image));

%book_resulting_image = book_global_correlation(full_image, reference_image);
%book_resulting_image = book_normalized_cross_correlation(full_image, reference_image);
book_resulting_image = book_correlation_coefficient(full_image, reference_image);
