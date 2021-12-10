import numpy as np
import skfuzzy as fuzz
from skfuzzy import control as ctrl
from enums.concept_type import ConceptType


class HeaterFuzzyMemberships:
    LOW_ENERGY = "low_energy"
    REDUCED_ENERGY = "reduced_energy"
    STABLE = "stable"
    INCREASED_ENERGY = "increased_energy"
    HIGH_ENERGY = "high_energy"
    NAME = "Heater"
    UNITS = "kJ"

    def __init__(self):
        self.definition = None
        self.concept_type = ConceptType.UNDEFINED

    def initialize(self):
        minimum = 0.0
        maximum = 2000
        self.concept_type = ConceptType.ANTECEDENT
        self.definition = ctrl.Consequent(np.arange(minimum, maximum, 1), self.NAME)
        self.set_fuzzy_membership_functions()

    def set_fuzzy_membership_functions(self):
        self.definition[self.LOW_ENERGY] = fuzz.trimf(self.definition.universe, [0.0, 0.0, 800.0])
        self.definition[self.REDUCED_ENERGY] = fuzz.trimf(self.definition.universe, [400.0, 800.0, 1200.0])
        self.definition[self.STABLE] = fuzz.trimf(self.definition.universe, [800.0, 1200.0, 1600.0])
        self.definition[self.INCREASED_ENERGY] = fuzz.trimf(self.definition.universe, [1200.0, 1600.0, 2000.0])
        self.definition[self.HIGH_ENERGY] = fuzz.trimf(self.definition.universe, [1600.0, 2000.0, 2000.0])

    def visualize_membership_functions(self):
        self.definition.view()

    def visualize_simulation(self, simulation):
        self.definition.view(sim=simulation)
