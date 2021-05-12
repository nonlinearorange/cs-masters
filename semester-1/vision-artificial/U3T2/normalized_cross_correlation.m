function resulting_image = normalized_cross_correlation(full_image, reference_image)
    [full_height, full_width] = size(full_image);
    [reference_height, reference_width] = size(reference_image);

    resulting_image = zeros(full_height, full_width);

    sumZero = 0;
    sumOne = 0;
    
    for r = 1: full_height - reference_height
        for s = 1: full_width - reference_width
            for i = 0: reference_height - 1
                for j = 0: reference_width - 1
                    sumZero = full_image(r + i, s + j) * reference_image(i + 1, j + 1) + sumZero;
                    sumOne = full_image(r + i, s + j) * full_image(r + i, s + j) + sumOne;
                end
            end

            resulting_image(r, s) = sumZero;
            sumZero = 0;
        end
    end
end