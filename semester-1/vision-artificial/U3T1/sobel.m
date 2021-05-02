function [sobel_h, sobel_v, resulting_image] = sobel(reference_image)
    image = rgb2gray(reference_image);
    image  = double(image);    

    [x, y] = size(image);

    sobel_h = zeros(x, y);
    sobel_v = zeros(x, y);
    sobel = zeros(x, y);

    kernel_y = [-1 0 1; -2 0 2; -1 0 1];
    kernel_x = [-1 -2 -1; 0 0 0; 1 2 1];

    image  = padarray(image , [2 2], 256, 'both'); 

    for i = 2 : x - 1
        for j = 2 : y - 1
            sobel_h(i, j) = sum(sum(kernel_x.*image (i - 1: i + 1, j - 1: j + 1)));
            sobel_v(i, j) = sum(sum(kernel_y.*image (i - 1: i + 1, j - 1: j + 1)));

            sobel(i, j) = sqrt(power(sobel_h(i, j), 2) + power(sobel_v(i, j), 2));
        end
    end
    sobel_h = (abs(sobel_h))./max(max(sobel_h));
    sobel_v = (abs(sobel_v))./max(max(sobel_v));
    
    resulting_image = (abs(sobel))./max(max(sobel));
end