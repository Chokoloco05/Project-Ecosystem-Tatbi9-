# Ecosystem : "Tatbi9" 
### __Directed By : Omar Chokayri 22379__


## How does the simulation work ?
- The simulation features various entities, including animals and plants. Animals are characterized by their gender ("Male" or "Female") and dietary preferences, being either carnivorous or herbivorous. When an animal dies, it transforms into meat, which can later degrade into poop if uneaten. Animals also produce poop over time and may engage in fights to secure food.
- Both animals and plants have energy levels that deplete over time. If an entity's energy bar runs out, it sacrifices health to replenish energy. To regain health, animals and plants must consume food.
- When an entity's health is fully depleted, it dies and is removed from the simulation. Animals can reproduce if both a male and a female are present, while plants rely on poop as nourishment to grow and propagate.

- In the simulation, entities are represented with specific visual symbols: a red circle denotes a male carnivorous animal, while a pink circle represents a female carnivorous animal. A blue circle signifies a male herbivorous animal, and a light blue circle indicates a female herbivorous animal. Green circles represent plants, small Indian red circles symbolize meat, and brown ellipses signify poop.

## Diagrams : 
- Sequence Diagram :
<picture>
  <img src="https://github.com/Chokoloco05/Project-Ecosystem-Tatbi9-/blob/main/SequenceDiagram.png">
<picture>
- Class Diagram :
<picture>
  <img src="https://github.com/Chokoloco05/Project-Ecosystem-Tatbi9-/blob/main/SequenceDiagram.png">
<picture>
  
##  SOLID Principles : 
-  Liskov Substitution Principle : 
    - Every type should be replaceable by a subtype without making the program semantically incorrect. In our code, we define many arguments for subclass constructors, ensuring the code remains flexible and semantically correct.

- Open/Closed Principle : 
    - Entities should be open for extension but closed for modification. It is easy to create new classes representing additional species that inherit from "Carnivore," "Herbivore," or "Plant" without needing to modify existing entities.
