from flask import Flask, jsonify

from models.customer import Customer
from models.patient import Patient
from models.user import User

app = Flask(__name__)


@app.route('/api/user', methods=['GET'])
def get_users():
    users = User.get_all()
    return jsonify(users)


@app.route('/api/user/<identifier>', methods=['GET'])
def get_user(identifier):
    user = User.get_by_identifier(identifier)
    if user is None:
        return resource_not_found_response(identifier)

    return jsonify(user)


@app.route('/api/user/<identifier>', methods=['DELETE'])
def deactivate_user(identifier):
    User.deactivate(identifier)
    return resource_deleted_response(identifier)


@app.route('/api/patient', methods=['GET'])
def get_patients():
    patients = Patient.get_all()
    return jsonify(patients)


@app.route('/api/patient/<identifier>', methods=['GET'])
def get_patient(identifier):
    patient = Patient.get_by_identifier(identifier)
    if patient is None:
        return resource_not_found_response(identifier)

    return jsonify(patient)


@app.route('/api/patient/<identifier>', methods=['DELETE'])
def deactivate_patient(identifier):
    Patient.deactivate(identifier)
    return resource_deleted_response(identifier)


@app.route('/api/customer', methods=['GET'])
def get_customers():
    customers = Customer.get_all()
    return jsonify(customers)


def resource_not_found_response(identifier):
    return jsonify({
        'resource_identifier': identifier,
        'status': 'not found'
    }), 404


def resource_deleted_response(identifier):
    return jsonify({
        'resource_identifier': identifier,
        'status': 'success'
    }), 200


if __name__ == '__main__':
    app.run(port=5050)
