from skfuzzy import control as ctrl


class TemperatureHeaterFuzzyRuleBuilder:
    def __init__(self, temperature_memberships, heater_memberships):
        self.temperature_memberships = temperature_memberships
        self.heater_memberships = heater_memberships

    def assemble(self):
        rules = [
            ctrl.Rule(self.temperature_memberships.definition[self.temperature_memberships.TOO_COLD],
                      self.heater_memberships.definition[self.heater_memberships.HIGH_ENERGY]),
        ]

        return rules
