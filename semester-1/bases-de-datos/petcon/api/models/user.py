from helpers.db import DB


class User:
    USER_ID = "identifier"
    FIRST_NAME = "first_name"
    LAST_NAME = "last_name"
    EMAIL = "email"
    PASSWORD = "password"
    USER_ROLE_ID = "role_id"
    USER_ROLE_NAME = "role_name"
    EMPLOYEE_ROLE_ID = "employee_role_id"
    EMPLOYEE_ROLE_NAME = "employee_role_name"

    @staticmethod
    def get_by_identifier(identifier):
        sql = """
        SELECT identifier
             , first_name
             , last_name
             , email
             , role_id
             , role_name
             , employee_role_id
             , employee_role_name
             , created_at
        FROM user_consolidated
        WHERE is_active = 1
        AND identifier = %s;
        """
        connection = DB.get_open_connection()
        cursor = connection.cursor(dictionary=True, buffered=True)
        cursor.execute(sql, (identifier,))
        row = cursor.fetchone()

        user = None
        if row is not None:
            user = map_full_user(row)

        cursor.close()
        connection.close()

        return user

    @staticmethod
    def get_by_email(email):
        pass

    @staticmethod
    def get_all():
        sql = """
        SELECT identifier
             , first_name
             , last_name
             , email
             , role_id
             , role_name
             , employee_role_id
             , employee_role_name
             , created_at
        FROM user_consolidated
        WHERE is_active = 1;
        """

        connection = DB.get_open_connection()
        cursor = connection.cursor(dictionary=True, buffered=True)
        cursor.execute(sql)

        users = []
        if cursor.rowcount <= 0:
            users = list(map(lambda row: map_full_user(row), cursor))

        cursor.close()
        connection.close()

        return users

    @staticmethod
    def deactivate(identifier):
        sql = """
        UPDATE user
        SET is_active = 0
        WHERE id = %s;
        """

        connection = DB.get_open_connection()
        cursor = connection.cursor()
        cursor.execute(sql, (identifier,))

        connection.commit()

        cursor.close()
        connection.close()


def map_full_user(row):
    return {
        User.USER_ID: row[User.USER_ID],
        User.FIRST_NAME: row[User.FIRST_NAME],
        User.LAST_NAME: row[User.LAST_NAME],
        User.EMAIL: row[User.EMAIL],
        User.USER_ROLE_ID: row[User.USER_ROLE_ID],
        User.USER_ROLE_NAME: row[User.USER_ROLE_NAME],
        User.EMPLOYEE_ROLE_ID: row[User.EMPLOYEE_ROLE_ID],
        User.EMPLOYEE_ROLE_NAME: row[User.EMPLOYEE_ROLE_NAME],
    }
