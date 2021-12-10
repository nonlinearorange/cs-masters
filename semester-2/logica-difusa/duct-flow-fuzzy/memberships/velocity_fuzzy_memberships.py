import numpy as np
import skfuzzy as fuzz
from skfuzzy import control as ctrl

from enums.concept_type import ConceptType


class VelocityFuzzyMemberships:
    TOO_SLOW = "too_slow"
    SLOW = "slow"
    AVERAGE = "average"
    FAST = "fast"
    TOO_FAST = "too_fast"
    NAME = "Velocity"
    UNITS = "m/s"

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
