function resulting_image = zero_cross(reference_image)
    image =rgb2gray(reference_image);

    image = double(image);
    resulting_image = edge(image, 'zerocross');
end