class User:
    USER_ID = "identifier"
    FIRST_NAME = "first_name"
    LAST_NAME = "last_name"
    EMAIL = "email"
    USER_ROLE_ID = "role_id"
    USER_ROLE_NAME = "role_name"
    EMPLOYEE_ROLE_ID = "employee_role_id"
    EMPLOYEE_ROLE_NAME = "employee_role_name"

    def __init__(self, identifier, first_name, last_name, email, user_role_id, user_role_name, employee_role_id,
                 employee_role_name):
        self.identifier = identifier
        self.first_name = first_name
        self.last_name = last_name
        self.email = email
        self.user_role_id = user_role_id
        self.user_role_name = user_role_name
        self.employee_role_id = employee_role_id
        self.employee_role_name = employee_role_name

    @staticmethod
    def create_from_json(json):
        return User(json[User.USER_ID],
                    json[User.FIRST_NAME],
                    json[User.LAST_NAME],
                    json[User.EMAIL],
                    json[User.USER_ROLE_ID],
                    json[User.USER_ROLE_NAME],
                    json[User.EMPLOYEE_ROLE_ID],
                    json[User.EMPLOYEE_ROLE_NAME])
