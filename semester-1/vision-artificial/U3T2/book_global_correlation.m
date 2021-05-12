% Implementación tal cual aparece en el libro de:
% Procesamiento de Imágenes con MATLAB y SIMULINK.

function resulting_image = book_global_correlation(full_image, reference_image)
    Im=full_image;
    T=reference_image;

    [m n]=size(Im);
    Imd=double(Im);
    Td=double(T);
    [mt nt]=size(T);
    suma=0;
    
    for re=1:m-mt
        for co=1:n-nt
            indice=0;
            for rel=0:mt-1
                for col=0:nt-1
                    suma=Imd(re+rel,co+col)*Td(rel+1,col+1)+suma;
                end
            end
            de(re,co)=suma;
            suma=0;
        end
    end

    C=mat2gray(de);
    imshow(C);
end