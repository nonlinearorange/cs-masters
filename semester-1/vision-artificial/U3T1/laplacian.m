function resulting_image = laplacian(reference_image, type)    
    image = rgb2gray(reference_image);
    image = double(image);
    temporal = image;

    [x, y] = size(image);
    resulting_image = zeros(x, y);

    image = padarray(image, [2 2], 256, 'both'); 

    for i = 2: x - 1
        for j = 2: y - 1
            if(type == 4)
                resulting_image(i, j) = image(i, j - 1) + image(i - 1, j) + image(i + 1, j)+ image(i, j + 1)-4*image(i, j);
            elseif(type == 8)
                resulting_image(i, j) = image(i - 1, j - 1) + image(i, j - 1) + image(i + 1, j - 1)+ image(i - 1, j) - 8 * (image(i, j)) + image(i + 1, j)+ image(i - 1,j + 1) + image(i, j + 1) + image(i + 1,j + 1);
            end                    
        end
    end
    
    resulting_image = temporal - resulting_image;
    resulting_image = (abs(resulting_image))./max(max(resulting_image));    
end