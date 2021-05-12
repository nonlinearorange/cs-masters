% Implementación tal cual aparece en el libro de:
% Procesamiento de Imágenes con MATLAB y SIMULINK.

function resulting_image = book_normalized_cross_correlation(full_image, reference_image)
    Im=full_image;
    T=reference_image;

    [m n]=size(Im);

    Imd=double(Im);
    Td=double(T);

    [mt nt]=size(T);

    suma=0;
    suma1=0;

    for re=1:m-mt
        for co=1:n-nt
            indice=0;
            for rel=0:mt-1
                for col=0:nt-1
                    suma=Imd(re+rel,co+col)*Td(rel+1,col+1)+suma;
                    suma1=Imd(re+rel,co+col)*Imd(re+rel,co+col)+suma1;
                end
            end
            C(re,co)=2*suma;
            A(re,co)=suma1;
            suma=0;
            suma1=0;
        end
    end
    sum=0;

    for rel=0:mt-1
        for col=0:nt-1
           sum=Td(rel+1,col+1) *Td(rel+1,col+1)+sum;
        end
    end

    for re=1:m-mt
        for co=1:n-nt
            Cn(re,co)=C(re,co)/((sqrt(A(re,co)))*sqrt(sum));
        end
    end

    C=mat2gray(Cn);
    imshow(C);    
end