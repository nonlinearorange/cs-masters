function resulting_image = max_filter(reference_image, k_size_x, k_size_y)
    [height, width, channels] = size(reference_image);

    if channels > 1
        reference_image = rgb2gray(reference_image);
    end

    window_size = k_size_x * k_size_y;
    array = zeros(1, window_size);
    resulting_image = reference_image;

    edge_x = floor(k_size_x / 2.0) + 1;
    edge_y = floor(k_size_y / 2.0) + 1;

    for x = edge_x : width - edge_x + 1
        for y = edge_y : height - edge_y + 1
            cnt = 1;
            for fx = 1 : k_size_x
                for fy = 1 : k_size_y
                    array(cnt) = reference_image(y + fy - edge_y, x + fx - edge_x);
                    cnt = cnt + 1;
                end
                
                resulting_image(y, x) = max(array);
            end
        end
    end            
end
