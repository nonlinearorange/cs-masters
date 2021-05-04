function resulting_image = salt_and_pepper_noise(reference_image, percentage)
    [y, x, channels] = size(reference_image);

    if channels > 1
        reference_image = rgb2gray(reference_image);
    end

    total_affected_pixels = round(((x * y) * (percentage / 100)) / 2);

    for i = 1: total_affected_pixels
        reference_image(randi(y),randi(x)) = 0;
        reference_image(randi(y),randi(x)) = 255;
    end

    resulting_image = reference_image;
end