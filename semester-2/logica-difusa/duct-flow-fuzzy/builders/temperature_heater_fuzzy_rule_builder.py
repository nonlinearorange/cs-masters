from skfuzzy import control as ctrl


class TemperatureHeaterFuzzyRuleBuilder:
    def __init__(self, temperature_memberships, heater_memberships):
        self.temperature_memberships = temperature_memberships
        self.heater_memberships = heater_memberships

    def assemble(self):
        rules = [
            ctrl.Rule(self.temperature_memberships.definition[self.temperature_memberships.TOO_COLD],
                      self.heater_memberships.definition[self.heater_memberships.HIGH_ENERGY]),
            ctrl.Rule(self.temperature_memberships.definition[self.temperature_memberships.COLD],
                      self.heater_memberships.definition[self.heater_memberships.INCREASED_ENERGY]),
            ctrl.Rule(self.temperature_memberships.definition[self.temperature_memberships.BALANCED],
                      self.heater_memberships.definition[self.heater_memberships.STABLE]),
            ctrl.Rule(self.temperature_memberships.definition[self.temperature_memberships.HOT],
                      self.heater_memberships.definition[self.heater_memberships.REDUCED_ENERGY]),
            ctrl.Rule(self.temperature_memberships.definition[self.temperature_memberships.TOO_HOT],
                      self.heater_memberships.definition[self.heater_memberships.LOW_ENERGY]),
        ]

        return rules
