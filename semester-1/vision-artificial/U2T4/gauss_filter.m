function resulting_image = gauss_filter(reference_image, k_size)
    [~, ~, channels] = size(reference_image);
    if channels > 1
        reference_image = rgb2gray(reference_image);
    end

    resulting_image = imgaussfilt(reference_image, k_size);
end