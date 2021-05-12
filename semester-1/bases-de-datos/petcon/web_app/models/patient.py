class Patient:
    PATIENT_ID = "identifier"
    NAME = "name"
    WEIGHT = "weight"
    BIRTHDAY = "birthday"
    CUSTOMER_ID = "customer_id"
    CUSTOMER_FIRST_NAME = "customer_first_name"
    CUSTOMER_LAST_NAME = "customer_last_name"

    def __init__(self, identifier, name, weight, birthday):
        self.identifier = identifier
        self.name = name
        self.weight = weight
        self.birthday = birthday

    @staticmethod
    def create_from_json(json):
        return Patient(json[Patient.PATIENT_ID],
                       json[Patient.NAME],
                       json[Patient.WEIGHT],
                       json[Patient.BIRTHDAY])
