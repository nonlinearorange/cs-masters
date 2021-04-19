USE petcon;

INSERT INTO system_role(id, name)
VALUES (1, 'Administrador')
     , (2, 'Usuario');

INSERT INTO employee_role(id, name)
VALUES (1, 'Médico')
     , (2, 'Asistente');

INSERT INTO species(id, name)
VALUES (1, 'Perro')
     , (2, 'Gato')
     , (3, 'Perico')
     , (4, 'Caballo')
     , (5, 'Búho')
     , (6, 'Burro')
     , (7, 'Vaca')
     , (8, 'Pollo')
     , (9, 'Gallina')
     , (10, 'Conejo');

INSERT INTO vaccination_type(id, name)
VALUES ('543aa8b3-7268-11eb-b696-704d7b2d5b37', 'Rabia')
     , ('a48eb941-7d82-11eb-b598-704d7b2d5b37', 'Parvo-Virus')
     , ('a7e2d63d-7d82-11eb-b598-704d7b2d5b37', 'Moquillo')
     , ('aa00deda-7d82-11eb-b598-704d7b2d5b37', 'Cancer')
     , ('ac800a36-7d82-11eb-b598-704d7b2d5b37', 'Parásitos')
     , ('aebe93e4-7d82-11eb-b598-704d7b2d5b37', 'Alérgenos')
     , ('b0cf8c08-7d82-11eb-b598-704d7b2d5b37', 'Influenza')
     , ('b2f0f103-7d82-11eb-b598-704d7b2d5b37', 'Hepatitis')
     , ('b4f04600-7d82-11eb-b598-704d7b2d5b37', 'Parainfluenza')
     , ('b88d22b2-7d82-11eb-b598-704d7b2d5b37', 'Leptospirosis');

INSERT INTO condition_type(id, name)
VALUES ('2c53e964-7d84-11eb-b598-704d7b2d5b37', 'Amputación')
     , ('4bcc3579-7d84-11eb-b598-704d7b2d5b37', 'Epilepsia')
     , ('4dc4cdbb-7d84-11eb-b598-704d7b2d5b37', 'Ceguera')
     , ('4f6fd2ed-7d84-11eb-b598-704d7b2d5b37', 'Sobrepeso')
     , ('50e1abba-7d84-11eb-b598-704d7b2d5b37', 'Diabetes')
     , ('525398da-7d84-11eb-b598-704d7b2d5b37', 'Cancer')
     , ('53a6a159-7d84-11eb-b598-704d7b2d5b37', 'Enanismo')
     , ('5551469d-7d84-11eb-b598-704d7b2d5b37', 'Soplo')
     , ('56996627-7d84-11eb-b598-704d7b2d5b37', 'Sordera')
     , ('580d0854-7d84-11eb-b598-704d7b2d5b37', 'Parálisis');

INSERT INTO user(id, first_name, last_name, email, password, system_role_id, employee_role_id)
VALUES ('b610c483-7268-11eb-b696-704d7b2d5b37', 'Ian', 'Ruiz', 'iar@iar.com', '
$2y$12$oRonvswOsR/qapSDrjc7oOVGKNBQJCDF7E31Lg2pyfOTIFZv3Y/GW', 1, 1)
     , ('d94673e2-7d83-11eb-b598-704d7b2d5b37', 'Miguel', 'Hidalgo', 'miguel@hidalgo.com', '
$2y$12$oRonvswOsR/qapSDrjc7oOVGKNBQJCDF7E31Lg2pyfOTIFZv3Y/GW', 1, 1)
     , ('db61e1ec-7d83-11eb-b598-704d7b2d5b37', 'Josefa', 'Ortiz', 'josefa@ortiz.com', '
$2y$12$oRonvswOsR/qapSDrjc7oOVGKNBQJCDF7E31Lg2pyfOTIFZv3Y/GW', 2, 1)
     , ('e02dc0f4-7d83-11eb-b598-704d7b2d5b37', 'Porfirio', 'Diaz', 'porfirio@diaz.com', '
$2y$12$oRonvswOsR/qapSDrjc7oOVGKNBQJCDF7E31Lg2pyfOTIFZv3Y/GW', 2, 1)
     , ('e3bd6161-7d83-11eb-b598-704d7b2d5b37', 'Venustiano', 'Carranza', 'venustiano@carranza.com', '
$2y$12$oRonvswOsR/qapSDrjc7oOVGKNBQJCDF7E31Lg2pyfOTIFZv3Y/GW', 2, 2)
     , ('eb4195de-7d83-11eb-b598-704d7b2d5b37', 'Álvaro', 'Obregón', 'alvaro@obregon.com', '
$2y$12$oRonvswOsR/qapSDrjc7oOVGKNBQJCDF7E31Lg2pyfOTIFZv3Y/GW', 2, 2)
     , ('ede95cbc-7d83-11eb-b598-704d7b2d5b37', 'Andrés', 'Obrador', 'andres@obrador.com', '
$2y$12$oRonvswOsR/qapSDrjc7oOVGKNBQJCDF7E31Lg2pyfOTIFZv3Y/GW', 2, 2)
     , ('f0185a35-7d83-11eb-b598-704d7b2d5b37', 'Manuel', 'Mondragón', 'manuel@mondragon.com', '
$2y$12$oRonvswOsR/qapSDrjc7oOVGKNBQJCDF7E31Lg2pyfOTIFZv3Y/GW', 2, 2)
     , ('f22b268d-7d83-11eb-b598-704d7b2d5b37', 'Leona', 'Vicario', 'leona@vicario.com', '
$2y$12$oRonvswOsR/qapSDrjc7oOVGKNBQJCDF7E31Lg2pyfOTIFZv3Y/GW', 2, 2)
     , ('f44abfd8-7d83-11eb-b598-704d7b2d5b37', 'Hermenegildo', 'Galeana', 'hermenegildo@galeana.com', '
$2y$12$oRonvswOsR/qapSDrjc7oOVGKNBQJCDF7E31Lg2pyfOTIFZv3Y/GW', 2, 2);

INSERT INTO customer(id, first_name, last_name, email)
VALUES ('874bdd7b-7268-11eb-b696-704d7b2d5b37', 'Itzel', 'Rubio', 'itzel@iar.com')
     , ('bfdd3afa-7d7f-11eb-b598-704d7b2d5b37', 'Richard', 'Feynman', 'richard@feynman.com')
     , ('d64f3449-7d7f-11eb-b598-704d7b2d5b37', 'Albert', 'Einstein', 'albert@einstein.com')
     , ('e86f521c-7d7f-11eb-b598-704d7b2d5b37', 'Isaac', 'Newton', 'isaac@newton.com')
     , ('fe73716e-7d7f-11eb-b598-704d7b2d5b37', 'Kip', 'Thorne', 'kip@thorne.com')
     , ('257b1a4f-7d80-11eb-b598-704d7b2d5b37', 'Friedrich', 'Gauss', 'friedrich@gauss.com')
     , ('318a8c97-7d80-11eb-b598-704d7b2d5b37', 'Andrew', 'Wiles', 'andrew@wiles.com')
     , ('b2486288-7d80-11eb-b598-704d7b2d5b37', 'Roger', 'Penrose', 'roger@penrose.com')
     , ('b45571af-7d80-11eb-b598-704d7b2d5b37', 'Carl', 'Sagan', 'carl@sagan.com')
     , ('b6366684-7d80-11eb-b598-704d7b2d5b37', 'Gregori', 'Perelman', 'gregori@perelman.com')
     , ('bbdb3008-7d80-11eb-b598-704d7b2d5b37', 'Rowan', 'Hamilton', 'rowan@hamilton.com');

INSERT INTO patient(id, name, species_id, owner_id)
VALUES ('14288f7b-7269-11eb-b696-704d7b2d5b37', 'Nara', 1, '874bdd7b-7268-11eb-b696-704d7b2d5b37')
     , ('f6b75bb3-7d84-11eb-b598-704d7b2d5b37', 'Antonia', 2, 'bfdd3afa-7d7f-11eb-b598-704d7b2d5b37')
     , ('fb301bb6-7d84-11eb-b598-704d7b2d5b37', 'Caramelo', 3, 'd64f3449-7d7f-11eb-b598-704d7b2d5b37')
     , ('ff34a1b9-7d84-11eb-b598-704d7b2d5b37', 'Bombón', 1, 'e86f521c-7d7f-11eb-b598-704d7b2d5b37')
     , ('02776348-7d85-11eb-b598-704d7b2d5b37', 'Snoopy', 3, '257b1a4f-7d80-11eb-b598-704d7b2d5b37')
     , ('0552ff61-7d85-11eb-b598-704d7b2d5b37', 'Scooby', 5, 'b2486288-7d80-11eb-b598-704d7b2d5b37')
     , ('0809bfdf-7d85-11eb-b598-704d7b2d5b37', 'Sophie', 6, 'b45571af-7d80-11eb-b598-704d7b2d5b37')
     , ('0afc6ab7-7d85-11eb-b598-704d7b2d5b37', 'Leo', 7, 'b6366684-7d80-11eb-b598-704d7b2d5b37')
     , ('0dd210f7-7d85-11eb-b598-704d7b2d5b37', 'Gohan', 10, 'bbdb3008-7d80-11eb-b598-704d7b2d5b37')
     , ('106f877e-7d85-11eb-b598-704d7b2d5b37', 'Skippy', 8, 'fe73716e-7d7f-11eb-b598-704d7b2d5b37')
     , ('12bc00bc-7d85-11eb-b598-704d7b2d5b37', 'Balto', 9, 'bfdd3afa-7d7f-11eb-b598-704d7b2d5b37');

INSERT INTO appointment(id, created_by, designated_to, patient_id, due_to)
VALUES ( '62a30ce1-7269-11eb-b696-704d7b2d5b37', 'b610c483-7268-11eb-b696-704d7b2d5b37'
       , 'b610c483-7268-11eb-b696-704d7b2d5b37', '14288f7b-7269-11eb-b696-704d7b2d5b37', '2021-03-05')
     , ( 'a29ceb94-7d85-11eb-b598-704d7b2d5b37', 'd94673e2-7d83-11eb-b598-704d7b2d5b37'
       , 'b610c483-7268-11eb-b696-704d7b2d5b37', 'f6b75bb3-7d84-11eb-b598-704d7b2d5b37', '2021-03-10')
     , ( 'a58582de-7d85-11eb-b598-704d7b2d5b37', 'd94673e2-7d83-11eb-b598-704d7b2d5b37'
       , 'f22b268d-7d83-11eb-b598-704d7b2d5b37', 'fb301bb6-7d84-11eb-b598-704d7b2d5b37', '2021-03-15')
     , ( 'a7db8bd1-7d85-11eb-b598-704d7b2d5b37', 'eb4195de-7d83-11eb-b598-704d7b2d5b37'
       , 'f22b268d-7d83-11eb-b598-704d7b2d5b37', '02776348-7d85-11eb-b598-704d7b2d5b37', '2021-03-18')
     , ( 'aa0c13b1-7d85-11eb-b598-704d7b2d5b37', 'f0185a35-7d83-11eb-b598-704d7b2d5b37'
       , 'f0185a35-7d83-11eb-b598-704d7b2d5b37', '0552ff61-7d85-11eb-b598-704d7b2d5b37', '2021-03-06')
     , ( 'ac4e232b-7d85-11eb-b598-704d7b2d5b37', 'f44abfd8-7d83-11eb-b598-704d7b2d5b37'
       , 'd94673e2-7d83-11eb-b598-704d7b2d5b37', '0809bfdf-7d85-11eb-b598-704d7b2d5b37', '2021-03-05')
     , ( 'aea79c52-7d85-11eb-b598-704d7b2d5b37', 'ede95cbc-7d83-11eb-b598-704d7b2d5b37'
       , 'e3bd6161-7d83-11eb-b598-704d7b2d5b37', '106f877e-7d85-11eb-b598-704d7b2d5b37', '2021-03-08')
     , ( 'b0f086f6-7d85-11eb-b598-704d7b2d5b37', 'e02dc0f4-7d83-11eb-b598-704d7b2d5b37'
       , 'b610c483-7268-11eb-b696-704d7b2d5b37', '12bc00bc-7d85-11eb-b598-704d7b2d5b37', '2021-03-07')
     , ( 'b31849ed-7d85-11eb-b598-704d7b2d5b37', 'db61e1ec-7d83-11eb-b598-704d7b2d5b37'
       , 'b610c483-7268-11eb-b696-704d7b2d5b37', '14288f7b-7269-11eb-b696-704d7b2d5b37', '2021-03-28')
     , ( 'b55a2dc4-7d85-11eb-b598-704d7b2d5b37', 'db61e1ec-7d83-11eb-b598-704d7b2d5b37'
       , 'b610c483-7268-11eb-b696-704d7b2d5b37', 'f6b75bb3-7d84-11eb-b598-704d7b2d5b37', '2021-03-30');