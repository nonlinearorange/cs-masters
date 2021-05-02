function resulting_image = morphological_gradient(reference_image)
    image = rgb2gray(reference_image);
    image = double (image);

    [x, y] = size(image);

    d1 = zeros(x, y);
    d2 = zeros(x, y);
    d3 = zeros(x, y);
    d4 = zeros(x, y);

    resulting_image = zeros(x, y);
    image = padarray(image, [2, 2], 0, 'both');

    for i = 2: x - 1
        for j = 2: y - 1
            d1(i, j) = sqrt(power(image(i, j)-image(i, j - 1), 2) + power(image(i, j) - image(i, j + 1), 2));
            d2(i, j) = sqrt(power(image(i, j)-image(i - 1, j), 2) + power(image(i, j) - image(i + 1, j), 2));
            d3(i, j) = sqrt(power(image(i, j)-image(i - 1, j - 1), 2) + power(image(i, j) - image(i + 1, j + 1), 2));
            d4(i, j) = sqrt(power(image(i, j)-image(i - 1, j + 1), 2) + power(image(i, j) - image(i + 1, j - 1), 2));

            resulting_image(i, j) = d1(i, j)+ d2(i, j) + d2(i, j)+ d4(i, j);
        end
    end
end