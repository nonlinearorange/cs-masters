function [roberts_h, roberts_v, resulting_image] = roberts(reference_image)
    image = rgb2gray(reference_image);
    image  = double(image);

    [x, y] = size(image);

    roberts_h = zeros(x, y);
    roberts_v = zeros(x, y);
    resulting_image = zeros(x, y);

    kernel_y = [0 1; -1 0];
    kernel_x = [-1 0; 0  1];

    image  = padarray(image , [2 2], 256, 'both'); 

    for i = 1 : x - 1
        for j = 1 : y - 1
            roberts_h(i, j) = sum(sum(kernel_x.*image(i: i + 1, j: j + 1)));
            roberts_v(i, j) = sum(sum(kernel_y.*image(i: i + 1, j: j + 1)));
            resulting_image(i, j) = sqrt(power(roberts_h(i, j), 2) + power(roberts_v(i, j), 2));
        end
    end
    roberts_h = (abs(roberts_h))./max(max(roberts_h));
    roberts_v = (abs(roberts_v))./max(max(roberts_v));
    
    resulting_image = (abs(resulting_image))./max(max(resulting_image));
end