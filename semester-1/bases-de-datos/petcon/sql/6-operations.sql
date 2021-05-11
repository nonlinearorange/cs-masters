UPDATE patient
SET is_active = 0
WHERE id = %s;

UPDATE user
SET is_active = 0
WHERE id = %s;
