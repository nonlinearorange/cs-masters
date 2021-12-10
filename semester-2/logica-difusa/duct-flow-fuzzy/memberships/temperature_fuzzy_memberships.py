import numpy as np
import skfuzzy as fuzz
from skfuzzy import control as ctrl
from enums.concept_type import ConceptType


class TemperatureFuzzyMemberships:
    TOO_COLD = "too_cold"
    COLD = "cold"
    BALANCED = "balanced"
    HOT = "hot"
    TOO_HOT = "too_hot"
    NAME = "Temperature"
    UNITS = "°F"

    def __init__(self):
        self.definition = None
        self.concept_type = ConceptType.UNDEFINED

    def initialize(self):
        minimum = 0.0
        maximum = 200.0
        self.concept_type = ConceptType.ANTECEDENT
        self.definition = ctrl.Consequent(np.arange(minimum, maximum, 1), self.NAME)
        self.set_fuzzy_membership_functions()

    def set_fuzzy_membership_functions(self):
        self.definition[self.TOO_COLD] = fuzz.trimf(self.definition.universe, [0.0, 0.0, 80.0])
        self.definition[self.COLD] = fuzz.trimf(self.definition.universe, [40.0, 80.0, 120.0])
        self.definition[self.BALANCED] = fuzz.trimf(self.definition.universe, [80.0, 120.0, 160.0])
        self.definition[self.HOT] = fuzz.trimf(self.definition.universe, [120.0, 160.0, 200.0])
        self.definition[self.TOO_HOT] = fuzz.trimf(self.definition.universe, [160.0, 200.0, 200.0])

    def visualize_membership_functions(self):
        self.definition.view()

    def visualize_simulation(self, simulation):
        self.definition.view(sim=simulation)
