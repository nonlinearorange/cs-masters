function resulting_image = global_correlation(full_image, reference_image)
    [full_height, full_width] = size(full_image);
    [reference_height, reference_width] = size(reference_image);

    resulting_image = zeros(full_height, full_width);

    sum = 0;
    for r = 1: full_height - reference_height
        for s = 1: full_width - reference_width
            for i = 0: reference_height - 1
                for j = 0: reference_width - 1
                    sum = full_image(r + i, s + j) * reference_image(i + 1, j + 1) + sum;
                end
            end

            resulting_image(r, s) = sum;
            sum = 0;
        end
    end
end