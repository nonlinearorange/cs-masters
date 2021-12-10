from builders.temperature_heater_fuzzy_rule_builder import TemperatureHeaterFuzzyRuleBuilder
from memberships.heater_fuzzy_memberships import HeaterFuzzyMemberships
from memberships.rpm_fuzzy_memberships import RpmFuzzyMemberships
from memberships.temperature_fuzzy_memberships import TemperatureFuzzyMemberships
from memberships.velocity_fuzzy_memberships import VelocityFuzzyMemberships

from skfuzzy import control as ctrl

from builders.velocity_rpm_fuzzy_rule_builder import VelocityRpmFuzzyRuleBuilder


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


def build_simulation_system(rules):
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

    system.view(sim=rpm)


def execute_velocity_rpm_fuzzy_controller():
    velocity_memberships = build_velocity_memberships()
    rpm_memberships = build_rpm_memberships()

    rule_builder = VelocityRpmFuzzyRuleBuilder(velocity_memberships, rpm_memberships)
    system = build_simulation_system(rule_builder.assemble())
    run_rpm_simulation(system)


def build_temperature_memberships():
    memberships = TemperatureFuzzyMemberships()
    memberships.initialize()
    memberships.visualize_membership_functions()
    return memberships


def build_heater_memberships():
    memberships = HeaterFuzzyMemberships()
    memberships.initialize()
    memberships.visualize_membership_functions()
    return memberships


def execute_temperature_heater_fuzzy_controller():
    temperature_memberships = build_temperature_memberships()
    heater_memberships = build_heater_memberships()

    rule_builder = TemperatureHeaterFuzzyRuleBuilder(temperature_memberships, heater_memberships)
    system = build_simulation_system(rule_builder.assemble())
    run_rpm_simulation(system)


def run_heater_simulation(system):
    print_separator()
    print("Sensor Input Readings:")

    temperature = 45.0  # m/s.
    print(f"Input Temperature: {temperature} °F")

    system.input[TemperatureFuzzyMemberships.NAME] = temperature
    system.compute()

    heater = system.output[HeaterFuzzyMemberships.NAME]
    print(f'Output Heater Work Required: {heater} kJ')


def main():
    execute_velocity_rpm_fuzzy_controller()


if __name__ == '__main__':
    main()
