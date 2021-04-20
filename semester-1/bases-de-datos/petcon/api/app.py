from flask import Flask, jsonify

from models.user import User

app = Flask(__name__)


@app.route('/api/user', methods=['GET'])
def get_users():
    users = User.get_all()
    return jsonify(users)


@app.route('/api/user/<identifier>', methods=['GET'])
def get_user(identifier):
    user = User.get_by_identifier(identifier)
    return jsonify(user)


if __name__ == '__main__':
    app.run(port=5050)
