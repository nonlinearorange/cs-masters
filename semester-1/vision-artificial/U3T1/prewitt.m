function [prewitt_h, prewitt_v, resulting_image] = prewitt(reference_image)
    image = rgb2gray(reference_image);
    image  = double(image);    

    [x, y] = size(image);

    prewitt_h = zeros(x, y);
    prewitt_v = zeros(x, y);
    prewitt = zeros(x, y);

    kernel_y = [-1 0 1; -1 0 1; -1 0 1];
    kernel_x = [-1 -1 -1; 0 0 0; 1 1 1];

    image  = padarray(image , [2 2], 256, 'both'); 

    for i = 2 : x - 1
        for j = 2 : y - 1
            prewitt_h(i, j) = sum(sum(kernel_x.*image (i - 1: i + 1, j - 1: j + 1)));
            prewitt_v(i, j) = sum(sum(kernel_y.*image (i - 1: i + 1, j - 1: j + 1)));

            prewitt(i, j) = sqrt(power(prewitt_h(i, j), 2) + power(prewitt_v(i, j), 2));
        end
    end
    prewitt_h = (abs(prewitt_h))./max(max(prewitt_h));
    prewitt_v = (abs(prewitt_v))./max(max(prewitt_v));
    
    resulting_image = (abs(prewitt))./max(max(prewitt));
end