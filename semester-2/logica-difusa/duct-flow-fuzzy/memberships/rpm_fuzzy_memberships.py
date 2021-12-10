import numpy as np
import skfuzzy as fuzz
from skfuzzy import control as ctrl
from enums.concept_type import ConceptType


class RpmFuzzyMemberships:
    TOO_SLOW = "too_slow"
    SLOW = "slow"
    AVERAGE = "average"
    FAST = "fast"
    TOO_FAST = "too_fast"
    NAME = "RPM"
    UNITS = "RPM"

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
