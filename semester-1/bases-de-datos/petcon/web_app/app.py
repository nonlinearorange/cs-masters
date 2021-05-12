import os
import requests

from flask import Flask, render_template

from models.customer import Customer
from models.patient import Patient
from models.user import User

app = Flask(__name__)

BASE_API_URL = os.environ["BASE_API_URL"]


@app.route('/app/customer')
def load_all_customers():
    raw_data = requests.get(f'{BASE_API_URL}/customer')
    customers = []
    if raw_data is not None:
        json_data = raw_data.json()
        for item in json_data:
            customers.append(Customer.create_from_json(item))
    return render_template('customer.html', customers=customers)


@app.route('/app/user')
def load_all_users():
    raw_data = requests.get(f'{BASE_API_URL}/user')
    users = []
    if raw_data is not None:
        json_data = raw_data.json()
        for item in json_data:
            users.append(User.create_from_json(item))
    return render_template('user.html', users=users)


@app.route('/app/patient')
def load_all_patients():
    raw_data = requests.get(f'{BASE_API_URL}/patient')
    patients = []
    if raw_data is not None:
        json_data = raw_data.json()
        for item in json_data:
            patients.append(Patient.create_from_json(item))
    return render_template('patient.html', patients=patients)


if __name__ == '__main__':
    app.run(port=5000)
