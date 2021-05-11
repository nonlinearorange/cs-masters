from helpers.db import DB


class Customer:
    CUSTOMER_ID = "identifier"
    FIRST_NAME = "first_name"
    LAST_NAME = "last_name"
    EMAIL = "email"
    CREATED_AT = "created_at"

    @staticmethod
    def get_by_identifier(identifier):
        pass

    @staticmethod
    def get_all():
        sql = """
        SELECT identifier
             , first_name
             , last_name
             , email
             , created_at
        FROM customer_consolidated
        WHERE is_active = 1;
        """

        connection = DB.get_open_connection()
        cursor = connection.cursor(dictionary=True, buffered=True)
        cursor.execute(sql)

        customers = []
        if cursor.rowcount <= 0:
            list(map(lambda row: map_full_customer(row), cursor))

        cursor.close()
        connection.close()

        return customers


def map_full_customer(row):
    return {
        Customer.CUSTOMER_ID: row[Customer.CUSTOMER_ID],
        Customer.FIRST_NAME: row[Customer.FIRST_NAME],
        Customer.LAST_NAME: row[Customer.LAST_NAME],
        Customer.EMAIL: row[Customer.EMAIL],
        Customer.CREATED_AT: row[Customer.CREATED_AT]
    }
