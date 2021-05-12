% Implementación tal cual aparece en el libro de:
% Procesamiento de Imágenes con MATLAB y SIMULINK.

function resulting_image = book_correlation_coefficient(full_image, reference_image)
    Im=full_image;
    T=reference_image;

    [m n]=size(Im);
    Imd=double(Im);
    Td=double(T);
    [mt nt]=size(T);

    suma1=0;
    suma2=0;
    suma3=0;

    MT=mean(mean(Td));

    for re=1:m-mt
        for co=1:n-nt
            for rel=0:mt-1
                for col=0:nt-1
                    Itemp(rel+1,col+1)=Imd(re+rel,co+col);                    
                end
            end
            MI=mean(mean(Itemp));
            for rel=0:mt-1
                for col=0:nt-1
                    suma1=(Itemp(rel+1,col+1)-MT)*(Td(rel+1,col+1)-MT)+suma1;
                    suma2=((Itemp(rel+1,col+1)-MI)^2)+suma2;
                    suma3=((Td(rel+1,col+1)-MT)^2)+suma3;
                end
            end
            CL(re,co)=suma1/((sqrt(suma2)*sqrt(suma3))+eps);

            suma1=0;
            suma2=0;
            suma3=0;
        end
    end    

    CLN=mat2gray(CL);
    imshow(CLN);
end