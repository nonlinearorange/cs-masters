DROP TRIGGER IF EXISTS tr_update_patient;
CREATE TRIGGER IF NOT EXISTS tr_update_patient
    AFTER UPDATE
    ON patient
    FOR EACH ROW

BEGIN
    IF (old.date_of_birth <> new.date_of_birth) THEN
        INSERT INTO patient_changes(patient_id, old_birth_day, new_birth_day)
        VALUES (old.id, old.date_of_birth, new.date_of_birth);
    END IF;
END;
