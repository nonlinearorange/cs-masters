import numpy as np
import skfuzzy as fuzz

from skfuzzy import control as ctrl


class RpmFuzzyController:
    TOO_SLOW = "too_slow"
    SLOW = "slow"
    AVERAGE = "average"
    FAST = "fast"
    TOO_FAST = "too_fast"
    NAME = "RPM"

    def __init__(self):
        self.consequent = None

    def initialize(self):
        minimum = 0.0
        maximum = 20000.0
        self.consequent = ctrl.Consequent(np.arange(minimum, maximum, 1), self.NAME)
        self.set_fuzzy_membership_functions()

    def set_fuzzy_membership_functions(self):
        self.consequent[self.TOO_SLOW] = fuzz.trimf(self.consequent.universe, [0.0, 0.0, 8000.0])
        self.consequent[self.SLOW] = fuzz.trimf(self.consequent.universe, [4000.0, 8000.0, 12000.0])
        self.consequent[self.AVERAGE] = fuzz.trimf(self.consequent.universe, [8000.0, 12000.0, 16000.0])
        self.consequent[self.FAST] = fuzz.trimf(self.consequent.universe, [12000.0, 16000.0, 20000.0])
        self.consequent[self.TOO_FAST] = fuzz.trimf(self.consequent.universe, [16000.0, 20000.0, 20000.0])

    def visualize_membership_functions(self):
        self.consequent.view()

    def visualize_simulation(self, simulation):
        self.consequent.view(sim=simulation)


class VelocityFuzzyController:
    TOO_SLOW = "too_slow"
    SLOW = "slow"
    AVERAGE = "average"
    FAST = "fast"
    TOO_FAST = "too_fast"
    NAME = "Velocity"

    def __init__(self):
        self.antecedent = None

    def initialize(self):
        minimum = 0.0
        maximum = 30.0
        self.antecedent = ctrl.Antecedent(np.arange(minimum, maximum, 1), self.NAME)
        self.set_fuzzy_membership_functions()

    def set_fuzzy_membership_functions(self):
        self.antecedent[self.TOO_SLOW] = fuzz.trimf(self.antecedent.universe, [0.0, 0.0, 10.0])
        self.antecedent[self.SLOW] = fuzz.trimf(self.antecedent.universe, [5.0, 10.0, 15.0])
        self.antecedent[self.AVERAGE] = fuzz.trimf(self.antecedent.universe, [10.0, 15.0, 20.0])
        self.antecedent[self.FAST] = fuzz.trimf(self.antecedent.universe, [15.0, 20.0, 25.0])
        self.antecedent[self.TOO_FAST] = fuzz.trimf(self.antecedent.universe, [20.0, 30.0, 30.0])

    def visualize_membership_functions(self):
        self.antecedent.view()


class VelocityFuzzyRuleBuilder:
    def __init__(self, velocity_controller, rpm_controller):
        self.velocity_controller = velocity_controller
        self.rpm_controller = rpm_controller

    def assemble(self):
        rules = [
            ctrl.Rule(self.velocity_controller.antecedent[self.velocity_controller.TOO_SLOW],
                      self.rpm_controller.consequent[self.rpm_controller.TOO_FAST]),
            ctrl.Rule(self.velocity_controller.antecedent[self.velocity_controller.SLOW],
                      self.rpm_controller.consequent[self.rpm_controller.FAST]),
            ctrl.Rule(self.velocity_controller.antecedent[self.velocity_controller.AVERAGE],
                      self.rpm_controller.consequent[self.rpm_controller.AVERAGE]),
            ctrl.Rule(self.velocity_controller.antecedent[self.velocity_controller.FAST],
                      self.rpm_controller.consequent[self.rpm_controller.SLOW]),
            ctrl.Rule(self.velocity_controller.antecedent[self.velocity_controller.TOO_SLOW],
                      self.rpm_controller.consequent[self.rpm_controller.TOO_FAST])
        ]

        return rules


def print_separator():
    print("-" * 45)


def build_velocity_controller():
    controller = VelocityFuzzyController()
    controller.initialize()
    controller.visualize_membership_functions()
    return controller


def build_rpm_controller():
    controller = RpmFuzzyController()
    controller.initialize()
    controller.visualize_membership_functions()
    return controller


def build_simulation_system(rules):
    control_system = ctrl.ControlSystem(rules)
    simulation_system = ctrl.ControlSystemSimulation(control_system)
    return simulation_system


def run_simulation(simulation_system):
    print_separator()
    print("Sensor Input Readings:")

    fluid_velocity = 6.0  # m/s.
    print(f"Input Fluid Velocity: {fluid_velocity} m/s")

    simulation_system.input[VelocityFuzzyController.NAME] = fluid_velocity
    simulation_system.compute()

    rpm = simulation_system.output[RpmFuzzyController.NAME]
    print(f'Output RPM Speed: {rpm} RPMs')


def main():
    rpm_controller = build_rpm_controller()
    velocity_controller = build_velocity_controller()

    rule_builder = VelocityFuzzyRuleBuilder(velocity_controller, rpm_controller)
    rules = rule_builder.assemble()
    simulation_system = build_simulation_system(rules)

    run_simulation(simulation_system)
    rpm_controller.visualize_simulation(simulation_system)


if __name__ == '__main__':
    main()
