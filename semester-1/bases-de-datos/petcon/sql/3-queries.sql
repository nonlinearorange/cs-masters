SELECT user_id
     , first_name
     , last_name
     , email
     , password
     , role_id
     , role_name
     , employee_role_id
     , employee_role_name
     , created_at
     , is_active
FROM user_consolidated;

SELECT user_id
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