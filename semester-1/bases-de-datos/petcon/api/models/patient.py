from helpers.db import DB


class Patient:
    PATIENT_ID = "identifier"
    NAME = "name"
    WEIGHT = "weight"
    BIRTHDAY = "birthday"
    CUSTOMER_ID = "customer_id"
    CUSTOMER_FIRST_NAME = "customer_first_name"
    CUSTOMER_LAST_NAME = "customer_last_name"

    @staticmethod
    def get_by_identifier(identifier):
        sql = """
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
        """

        connection = DB.get_open_connection()
        cursor = connection.cursor(dictionary=True, buffered=True)
        cursor.execute(sql, (identifier,))
        row = cursor.fetchone()

        patient = None
        if row is not None:
            patient = map_full_patient(row)

        cursor.close()
        connection.close()

        return patient

    @staticmethod
    def get_all():
        sql = """
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
        """

        connection = DB.get_open_connection()
        cursor = connection.cursor(dictionary=True, buffered=True)
        cursor.execute(sql)

        patients = []
        if cursor.rowcount > 0:
            patients = list(map(lambda row: map_full_patient(row), cursor))

        cursor.close()
        connection.close()

        return patients

    @staticmethod
    def deactivate(identifier):
        sql = """
        UPDATE patient
        SET is_active = 0
        WHERE id = %s;
        """

        connection = DB.get_open_connection()
        cursor = connection.cursor()
        cursor.execute(sql, (identifier,))

        connection.commit()

        cursor.close()
        connection.close()


def map_full_patient(row):
    return {
        Patient.PATIENT_ID: row[Patient.PATIENT_ID],
        Patient.NAME: row[Patient.NAME],
        Patient.WEIGHT: row[Patient.WEIGHT],
        Patient.BIRTHDAY: row[Patient.BIRTHDAY],
        Patient.CUSTOMER_ID: row[Patient.CUSTOMER_ID],
        Patient.CUSTOMER_FIRST_NAME: row[Patient.CUSTOMER_FIRST_NAME],
        Patient.CUSTOMER_LAST_NAME: row[Patient.CUSTOMER_LAST_NAME]
    }
