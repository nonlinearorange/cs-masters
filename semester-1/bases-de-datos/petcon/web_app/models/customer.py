class Customer:
    CUSTOMER_ID = "identifier"
    FIRST_NAME = "first_name"
    LAST_NAME = "last_name"
    EMAIL = "email"
    CREATED_AT = "created_at"

    def __init__(self, identifier, first_name, last_name, email, created_at):
        self.identifier = identifier
        self.first_name = first_name
        self.last_name = last_name
        self.email = email
        self.created_at = created_at

    @staticmethod
    def create_from_json(json):
        return Customer(json[Customer.CUSTOMER_ID],
                        json[Customer.FIRST_NAME],
                        json[Customer.LAST_NAME],
                        json[Customer.EMAIL],
                        json[Customer.CREATED_AT])
