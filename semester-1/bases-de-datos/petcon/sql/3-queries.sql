SELECT identifier
     , first_name
     , last_name
     , email
     , created_at
FROM customer_consolidated
WHERE is_active = 1;

SELECT identifier
     , name
     , weight
     , birthday
     , created_at
     , species_id
     , species_name
     , customer_id
     , customer_first_name
     , customer_last_name
     , customer_email
FROM patient_consolidated
WHERE is_active = 1;

SELECT identifier
     , name
     , weight
     , birthday
     , created_at
     , species_id
     , species_name
     , customer_id
     , customer_first_name
     , customer_last_name
     , customer_email
FROM patient_consolidated
WHERE is_active = 1
  AND identifier = %s;

SELECT identifier
     , first_name
     , last_name
     , email
     , password
     , role_id
     , role_name
     , employee_role_id
     , employee_role_name
     , created_at
FROM user_consolidated
WHERE is_active = 1;

SELECT identifier
     , first_name
     , last_name
     , email
     , created_at
     , is_active
FROM customer_consolidated;

SELECT id
     , created_by
     , designated_to
     , patient_id
     , due_to
     , created_at
     , is_active
FROM appointment AS a;

SELECT *
FROM customer;

SELECT *
FROM customer_consolidated;