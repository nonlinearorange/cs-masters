import numpy as np
import skfuzzy as fuzz

from skfuzzy import control as ctrl


class ConceptType:
    UNDEFINED = 0
    ANTECEDENT = 1
    CONSEQUENT = 2


class RpmFuzzyMemberships:
    TOO_SLOW = "too_slow"
    SLOW = "slow"
    AVERAGE = "average"
    FAST = "fast"
    TOO_FAST = "too_fast"
    NAME = "RPM"

    def __init__(self):
        self.definition = None
        self.concept_type = ConceptType.UNDEFINED

    def initialize(self):
        minimum = 0.0
        maximum = 20000.0
        self.concept_type = ConceptType.CONSEQUENT
        self.definition = ctrl.Consequent(np.arange(minimum, maximum, 1), self.NAME)
        self.set_fuzzy_membership_functions()

    def set_fuzzy_membership_functions(self):
        self.definition[self.TOO_SLOW] = fuzz.trimf(self.definition.universe, [0.0, 0.0, 8000.0])
        self.definition[self.SLOW] = fuzz.trimf(self.definition.universe, [4000.0, 8000.0, 12000.0])
        self.definition[self.AVERAGE] = fuzz.trimf(self.definition.universe, [8000.0, 12000.0, 16000.0])
        self.definition[self.FAST] = fuzz.trimf(self.definition.universe, [12000.0, 16000.0, 20000.0])
        self.definition[self.TOO_FAST] = fuzz.trimf(self.definition.universe, [16000.0, 20000.0, 20000.0])

    def visualize_membership_functions(self):
        self.definition.view()

    def visualize_simulation(self, simulation):
        self.definition.view(sim=simulation)


class VelocityFuzzyMemberships:
    TOO_SLOW = "too_slow"
    SLOW = "slow"
    AVERAGE = "average"
    FAST = "fast"
    TOO_FAST = "too_fast"
    NAME = "Velocity"

    def __init__(self):
        self.definition = None
        self.concept_type = ConceptType.UNDEFINED

    def initialize(self):
        minimum = 0.0
        maximum = 30.0
        self.definition = ctrl.Antecedent(np.arange(minimum, maximum, 1), self.NAME)
        self.set_fuzzy_membership_functions()

    def set_fuzzy_membership_functions(self):
        self.definition[self.TOO_SLOW] = fuzz.trimf(self.definition.universe, [0.0, 0.0, 10.0])
        self.definition[self.SLOW] = fuzz.trimf(self.definition.universe, [5.0, 10.0, 15.0])
        self.definition[self.AVERAGE] = fuzz.trimf(self.definition.universe, [10.0, 15.0, 20.0])
        self.definition[self.FAST] = fuzz.trimf(self.definition.universe, [15.0, 20.0, 25.0])
        self.definition[self.TOO_FAST] = fuzz.trimf(self.definition.universe, [20.0, 30.0, 30.0])

    def visualize_membership_functions(self):
        self.definition.view()


class VelocityRpmFuzzyRuleBuilder:
    def __init__(self, velocity_memberships, rpm_memberships):
        self.velocity_memberships = velocity_memberships
        self.rpm_memberships = rpm_memberships

    def assemble(self):
        rules = [
            ctrl.Rule(self.velocity_memberships.definition[self.velocity_memberships.TOO_SLOW],
                      self.rpm_memberships.definition[self.rpm_memberships.TOO_FAST]),
            ctrl.Rule(self.velocity_memberships.definition[self.velocity_memberships.SLOW],
                      self.rpm_memberships.definition[self.rpm_memberships.FAST]),
            ctrl.Rule(self.velocity_memberships.definition[self.velocity_memberships.AVERAGE],
                      self.rpm_memberships.definition[self.rpm_memberships.AVERAGE]),
            ctrl.Rule(self.velocity_memberships.definition[self.velocity_memberships.FAST],
                      self.rpm_memberships.definition[self.rpm_memberships.SLOW]),
            ctrl.Rule(self.velocity_memberships.definition[self.velocity_memberships.TOO_SLOW],
                      self.rpm_memberships.definition[self.rpm_memberships.TOO_FAST])
        ]

        return rules


def print_separator():
    print("-" * 45)


def build_velocity_memberships():
    memberships = VelocityFuzzyMemberships()
    memberships.initialize()
    memberships.visualize_membership_functions()
    return memberships


def build_rpm_memberships():
    memberships = RpmFuzzyMemberships()
    memberships.initialize()
    memberships.visualize_membership_functions()
    return memberships


def build_rpm_simulation_system(rules):
    control_system = ctrl.ControlSystem(rules)
    simulation_system = ctrl.ControlSystemSimulation(control_system)
    return simulation_system


def run_rpm_simulation(system):
    print_separator()
    print("Sensor Input Readings:")

    fluid_velocity = 6.0  # m/s.
    print(f"Input Fluid Velocity: {fluid_velocity} m/s")

    system.input[VelocityFuzzyMemberships.NAME] = fluid_velocity
    system.compute()

    rpm = system.output[RpmFuzzyMemberships.NAME]
    print(f'Output RPM Speed: {rpm} RPMs')


def execute_velocity_rpm_fuzzy_controller():
    velocity_memberships = build_velocity_memberships()
    rpm_memberships = build_rpm_memberships()

    rule_builder = VelocityRpmFuzzyRuleBuilder(velocity_memberships, rpm_memberships)
    system = build_rpm_simulation_system(rule_builder.assemble())
    run_rpm_simulation(system)


def main():
    execute_velocity_rpm_fuzzy_controller()


if __name__ == '__main__':
    main()
