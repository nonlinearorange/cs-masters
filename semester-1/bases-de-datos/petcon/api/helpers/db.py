import os
import mysql.connector


class DB:
    @staticmethod
    def get_open_connection():
        user = os.environ["USER"]
        password = os.environ["PASSWORD"]
        server = os.environ["SERVER"]
        port = os.environ["PORT"]
        database = os.environ["DATABASE"]

        connection = mysql.connector.connect(user=user,
                                             password=password,
                                             host=server,
                                             port=port,
                                             database=database)
        return connection
