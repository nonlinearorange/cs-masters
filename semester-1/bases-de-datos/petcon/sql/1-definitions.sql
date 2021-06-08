CREATE DATABASE IF NOT EXISTS petcon;
USE petcon;

DROP TABLE IF EXISTS system_role;
CREATE TABLE IF NOT EXISTS system_role
(
    id          INT,
    name        NVARCHAR(80)  NOT NULL,
    description NVARCHAR(255) NOT NULL DEFAULT SPACE(0),

    CONSTRAINT pk_system_role
        PRIMARY KEY (id)
);

DROP TABLE IF EXISTS employee_role;
CREATE TABLE IF NOT EXISTS employee_role
(
    id          INT,
    name        NVARCHAR(80)  NOT NULL,
    description NVARCHAR(255) NOT NULL DEFAULT SPACE(0),

    CONSTRAINT pk_employee_role
        PRIMARY KEY (id)
);

DROP TABLE IF EXISTS user;
CREATE TABLE IF NOT EXISTS user
(
    id               NVARCHAR(36),
    first_name       NVARCHAR(80)  NOT NULL,
    last_name        NVARCHAR(80)  NOT NULL,
    email            NVARCHAR(255) NOT NULL,
    password         NVARCHAR(72)  NOT NULL,
    system_role_id   INT           NOT NULL,
    employee_role_id INT           NOT NULL,
    created_at       DATETIME      NOT NULL DEFAULT NOW(),
    is_active        BIT           NOT NULL DEFAULT 1,

    CONSTRAINT pk_user
        PRIMARY KEY (id),

    CONSTRAINT fk_user_system_role
        FOREIGN KEY (system_role_id)
            REFERENCES system_role (id),

    CONSTRAINT fk_user_employee_role
        FOREIGN KEY (employee_role_id)
            REFERENCES employee_role (id)
);

DROP TABLE IF EXISTS customer;
CREATE TABLE IF NOT EXISTS customer
(
    id         NVARCHAR(36),
    first_name NVARCHAR(80) NOT NULL,
    last_name  NVARCHAR(80) NOT NULL,
    email      NVARCHAR(80) NOT NULL,
    created_at DATETIME     NOT NULL DEFAULT NOW(),
    is_active  BIT          NOT NULL DEFAULT 1,

    CONSTRAINT pk_customer
        PRIMARY KEY (id)
);

DROP TABLE IF EXISTS species;
CREATE TABLE IF NOT EXISTS species
(
    id         NVARCHAR(36),
    name       NVARCHAR(80) NOT NULL,
    created_at DATETIME     NOT NULL DEFAULT NOW(),

    CONSTRAINT pk_species
        PRIMARY KEY (id)
);

DROP TABLE IF EXISTS patient;
CREATE TABLE IF NOT EXISTS patient
(
    id            NVARCHAR(36),
    name          NVARCHAR(80) NOT NULL,
    weight        FLOAT        NOT NULL DEFAULT 0.0,
    date_of_birth DATETIME     NOT NULL DEFAULT NOW(),
    species_id    NVARCHAR(36) NOT NULL,
    owner_id      NVARCHAR(36) NOT NULL,
    created_at    DATETIME     NOT NULL DEFAULT NOW(),
    is_active     BIT          NOT NULL DEFAULT 1,

    CONSTRAINT pk_patient
        PRIMARY KEY (id),

    CONSTRAINT fk_patient_species
        FOREIGN KEY (species_id)
            REFERENCES species (id),

    CONSTRAINT fk_patient_customer
        FOREIGN KEY (owner_id)
            REFERENCES customer (id)
);

DROP TABLE IF EXISTS appointment;
CREATE TABLE IF NOT EXISTS appointment
(
    id            NVARCHAR(36),
    created_by    NVARCHAR(36) NOT NULL,
    designated_to NVARCHAR(36) NOT NULL,
    patient_id    NVARCHAR(36) NOT NULL,
    due_to        DATETIME     NOT NULL,
    created_at    DATETIME     NOT NULL DEFAULT NOW(),
    is_active     BIT          NOT NULL DEFAULT 1,

    CONSTRAINT pk_appointment
        PRIMARY KEY (id),

    CONSTRAINT fk_appointment_created_by_user
        FOREIGN KEY (created_by)
            REFERENCES user (id),

    CONSTRAINT fk_appointment_designated_to_user
        FOREIGN KEY (designated_to)
            REFERENCES user (id),

    CONSTRAINT fk_appointment_patient
        FOREIGN KEY (patient_id)
            REFERENCES patient (id)
);

DROP TABLE IF EXISTS appointment_notes;
CREATE TABLE IF NOT EXISTS appointment_notes
(
    id             NVARCHAR(36),
    appointment_id NVARCHAR(36)  NOT NULL,
    content        NVARCHAR(300) NOT NULL,
    created_at     DATETIME      NOT NULL DEFAULT NOW(),
    is_active      BIT           NOT NULL DEFAULT 1,

    CONSTRAINT pk_appointment_notes
        PRIMARY KEY (id),

    CONSTRAINT fk_appointment_notes_appointment
        FOREIGN KEY (appointment_id)
            REFERENCES appointment (id)
);

DROP TABLE IF EXISTS appointment_notification;
CREATE TABLE IF NOT EXISTS appointment_notification
(
    id             NVARCHAR(36),
    appointment_id NVARCHAR(36) NOT NULL,
    created_at     DATETIME     NOT NULL DEFAULT NOW(),
    has_been_sent  BIT          NOT NULL DEFAULT 1,

    CONSTRAINT pk_appointment_notification
        PRIMARY KEY (id),

    CONSTRAINT fk_appointment_notification
        FOREIGN KEY (appointment_id)
            REFERENCES appointment (id)
);

DROP TABLE IF EXISTS prescription;
CREATE TABLE IF NOT EXISTS prescription
(
    id             NVARCHAR(36),
    appointment_id NVARCHAR(36)  NOT NULL,
    content        NVARCHAR(255) NOT NULL,
    created_at     DATETIME      NOT NULL DEFAULT NOW(),
    is_active      BIT           NOT NULL DEFAULT 1,

    CONSTRAINT pk_prescription
        PRIMARY KEY (id),

    CONSTRAINT fk_prescription_appointment
        FOREIGN KEY (appointment_id)
            REFERENCES appointment (id)
);

DROP TABLE IF EXISTS prescription_note;
CREATE TABLE IF NOT EXISTS prescription_note
(
    id              NVARCHAR(36),
    prescription_id NVARCHAR(36)  NOT NULL,
    content         NVARCHAR(255) NOT NULL,
    created_at      DATETIME      NOT NULL DEFAULT NOW(),
    is_active       BIT           NOT NULL DEFAULT 1,

    CONSTRAINT pk_prescription_note
        PRIMARY KEY (id),

    CONSTRAINT fk_prescription_note_prescription
        FOREIGN KEY (prescription_id)
            REFERENCES prescription (id)
);

DROP TABLE IF EXISTS vaccination_type;
CREATE TABLE IF NOT EXISTS vaccination_type
(
    id          NVARCHAR(36),
    name        NVARCHAR(80)  NOT NULL,
    description NVARCHAR(255) NOT NULL DEFAULT SPACE(0),
    created_at  DATETIME      NOT NULL DEFAULT NOW(),
    is_active   BIT           NOT NULL DEFAULT 1,

    CONSTRAINT pk_vaccination_type
        PRIMARY KEY (id)
);

DROP TABLE IF EXISTS vaccination;
CREATE TABLE IF NOT EXISTS vaccination
(
    id                  NVARCHAR(36),
    appointment_id      NVARCHAR(36) NOT NULL,
    vaccination_type_id NVARCHAR(36) NOT NULL,
    created_at          DATETIME     NOT NULL DEFAULT NOW(),
    is_active           BIT          NOT NULL DEFAULT 1,

    CONSTRAINT pk_vaccination
        PRIMARY KEY (id),

    CONSTRAINT fk_vaccination_vaccination_type
        FOREIGN KEY (vaccination_type_id)
            REFERENCES vaccination_type (id)
);

DROP TABLE IF EXISTS condition_type;
CREATE TABLE IF NOT EXISTS condition_type
(
    id          NVARCHAR(36),
    name        NVARCHAR(100) NOT NULL,
    description NVARCHAR(255) NOT NULL DEFAULT '',
    created_at  DATETIME      NOT NULL DEFAULT NOW(),
    is_active   BIT           NOT NULL DEFAULT 1,

    CONSTRAINT pk_condition_type
        PRIMARY KEY (id)
);

DROP TABLE IF EXISTS patient_condition;
CREATE TABLE IF NOT EXISTS patient_condition
(
    id                 NVARCHAR(36),
    condition_type_id  NVARCHAR(36)  NOT NULL,
    patient_id         NVARCHAR(36)  NOT NULL,
    comment_on_patient NVARCHAR(255) NOT NULL,
    created_at         DATETIME      NOT NULL DEFAULT NOW(),
    is_active          BIT           NOT NULL DEFAULT 1,

    CONSTRAINT pk_patient_condition
        PRIMARY KEY (id),

    CONSTRAINT fk_patient_condition_condition_type
        FOREIGN KEY (condition_type_id)
            REFERENCES condition_type (id),

    CONSTRAINT fk_patient_condition_patient
        FOREIGN KEY (patient_id)
            REFERENCES patient (id)
);

DROP TABLE IF EXISTS patient_changes;
CREATE TABLE IF NOT EXISTS patient_changes
(
    identifier    INT AUTO_INCREMENT,
    patient_id    NVARCHAR(36),
    old_birth_day DATETIME NOT NULL,
    new_birth_day DATETIME NOT NULL,
    created_at    DATETIME NOT NULL DEFAULT NOW(),

    CONSTRAINT pk_patient_changes
        PRIMARY KEY (identifier),

    CONSTRAINT fk_patient_changes_patient
        FOREIGN KEY (patient_id)
            REFERENCES user (id)
);

DROP VIEW IF EXISTS user_consolidated;
CREATE VIEW IF NOT EXISTS user_consolidated
AS
SELECT u.id         AS identifier
     , u.first_name AS first_name
     , u.last_name  AS last_name
     , u.email      AS email
     , u.password   AS password
     , sr.id        AS role_id
     , sr.name      AS role_name
     , er.id        AS employee_role_id
     , er.name      AS employee_role_name
     , u.created_at AS created_at
     , u.is_active  AS is_active
FROM USER AS u
         INNER JOIN system_role AS sr
                    ON u.system_role_id = sr.id
         INNER JOIN employee_role AS er
                    ON u.employee_role_id = er.id;

DROP VIEW IF EXISTS patient_consolidated;
CREATE VIEW IF NOT EXISTS patient_consolidated
AS
SELECT p.id            AS 'identifier'
     , p.name          AS 'name'
     , p.weight        AS 'weight'
     , p.date_of_birth AS 'birthday'
     , p.created_at    AS 'created_at'
     , p.is_active     AS 'is_active'
     , s.id            AS 'species_id'
     , s.name          AS 'species_name'
     , c.id            AS 'customer_id'
     , c.first_name    AS 'customer_first_name'
     , c.last_name     AS 'customer_last_name'
     , c.email         AS 'customer_email'
FROM patient AS p
         INNER JOIN species AS s
                    ON p.species_id = s.id
         INNER JOIN customer AS c
                    ON p.owner_id = c.id;

DROP VIEW IF EXISTS customer_consolidated;
CREATE VIEW IF NOT EXISTS customer_consolidated
AS
SELECT c.id         AS 'identifier'
     , c.first_name AS 'first_name'
     , c.last_name  AS 'last_name'
     , c.email      AS 'email'
     , c.created_at AS 'created_at'
     , c.is_active  AS 'is_active'
FROM customer AS c;