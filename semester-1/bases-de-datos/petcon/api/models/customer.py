from helpers.db import DB


class Customer:
    CUSTOMER_ID = "identifier"
    FIRST_NAME = "first_name"
    LAST_NAME = "last_name"
    EMAIL = "email"
    CREATED_AT = "created_at"

    @staticmethod
    def get_by_identifier(identifier):
        sql = """
        SELECT identifier
             , first_name
             , last_name
             , email
             , created_at
        FROM customer_consolidated
        WHERE is_active = 1
        and identifier = %s;
        """

        connection = DB.get_open_connection()
        cursor = connection.cursor(dictionary=True, buffered=True)
        cursor.execute(sql, (identifier,))
        row = cursor.fetchone()

        customer = None
        if row is not None:
            customer = map_full_customer(row)

        cursor.close()
        connection.close()

        return customer

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
        if cursor.rowcount > 0:
            customers = list(map(lambda row: map_full_customer(row), cursor))

        cursor.close()
        connection.close()

        return customers

    @staticmethod
    def deactivate(identifier):
        sql = """
        UPDATE customer
        SET is_active = 0
        WHERE id = %s;
        """

        connection = DB.get_open_connection()
        cursor = connection.cursor()
        cursor.execute(sql, (identifier,))

        connection.commit()

        cursor.close()
        connection.close()


def map_full_customer(row):
    return {
        Customer.CUSTOMER_ID: row[Customer.CUSTOMER_ID],
        Customer.FIRST_NAME: row[Customer.FIRST_NAME],
        Customer.LAST_NAME: row[Customer.LAST_NAME],
        Customer.EMAIL: row[Customer.EMAIL],
        Customer.CREATED_AT: row[Customer.CREATED_AT]
    }
