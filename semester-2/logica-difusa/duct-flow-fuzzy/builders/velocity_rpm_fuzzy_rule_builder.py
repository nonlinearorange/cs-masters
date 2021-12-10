from skfuzzy import control as ctrl


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
            ctrl.Rule(self.velocity_memberships.definition[self.velocity_memberships.TOO_FAST],
                      self.rpm_memberships.definition[self.rpm_memberships.TOO_SLOW])
        ]

        return rules
