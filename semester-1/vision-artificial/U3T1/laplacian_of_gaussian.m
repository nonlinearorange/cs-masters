function resulting_image = laplacian_of_gaussian(reference_image)    
    image =rgb2gray(reference_image);

    image = double(image);
    log_filter = fspecial('log', [3, 3], 0.5);
    resulting_image = imfilter(image, log_filter, 'symmetric', 'conv');
end