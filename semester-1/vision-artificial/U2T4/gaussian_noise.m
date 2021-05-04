function resulting_image = gaussian_noise(reference_image)
    [~, ~, channels] = size(reference_image);
    if channels > 1
        reference_image = rgb2gray(reference_image);
    end

    resulting_image = imnoise(reference_image, 'gaussian');
end