function resulting_image = canny (reference)
    image = rgb2gray(reference);
    image = double(image);
    resulting_image = edge(image, 'Canny');
end
