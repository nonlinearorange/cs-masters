DROP PROCEDURE sp_generate_patient_status_report;
CREATE PROCEDURE sp_generate_patient_status_report()
BEGIN
    SELECT p.id                                                                  AS 'PatientIdentifier'
         , p.name                                                                AS 'PatientName'
         , p.weight                                                              AS 'PatientWeight'
         , p.date_of_birth                                                       AS 'PatientBirthday'
         , CONCAT((TIMESTAMPDIFF(YEAR, p.date_of_birth, NOW())), ' ', 'Years', ', ',
                  (TIMESTAMPDIFF(MONTH, p.date_of_birth, NOW())), ' ', 'Months') AS 'PatientAge'
         , s.id                                                                  AS 'SpeciesIdentifier'
         , s.name                                                                AS 'SpeciesName'
         , (
               SELECT COUNT(*)
               FROM patient_condition AS pc
               WHERE pc.patient_id = p.id
           )                                                                     AS 'PatientQuantityOfConditions'
         , (
        IF((
               SELECT COUNT(*)
               FROM patient_condition AS pc
               WHERE pc.patient_id = p.id
           ) > 0, 'Yes', 'No')
        )                                                                        AS 'PatientHasACondition'
    FROM patient AS p
             INNER JOIN species AS s
                        ON p.species_id = s.id
             INNER JOIN customer AS c
                        ON p.owner_id = c.id
    WHERE p.is_active = 1;
END;

SELECT *
FROM employee_role;

DROP PROCEDURE sp_generate_executive_appointment_report;
CREATE PROCEDURE sp_generate_executive_appointment_report()
SELECT a.id            AS 'AppointmentIdentifier'
     , a.created_by    AS 'AppointmentCreatedBy'
     , a.designated_to AS 'AppointmentDesignatedTo'
     , (
    IF((
           SELECT COUNT(*)
           FROM user AS u
           WHERE u.id = u1.id
             AND u.employee_role_id = 1
       ) > 0, 'Yes', 'No')
    )                  AS 'IsAppointmentDesignatedByAMedic'
     , a.patient_id    AS 'PatientIdentifier'
     , a.due_to
     , a.created_at
     , a.is_active
FROM appointment AS a
         INNER JOIN patient AS p
                    ON a.patient_id = p.id
         INNER JOIN customer AS c
                    ON p.owner_id = c.id
         INNER JOIN user AS u1
                    ON a.created_by = u1.id
         INNER JOIN user AS u2
                    ON a.designated_to = u2.id
         INNER JOIN employee_role AS er1
                    ON u1.employee_role_id = er1.id
         INNER JOIN employee_role AS er2
                    ON u1.employee_role_id = er2.id;