# Unity ML-Agents Reinforcement Learning Week 2 Project

This project demonstrates how to set up a basic reinforcement learning environment using Unity's ML-Agents toolkit. In this setup, an agent learns to navigate towards a target while avoiding walls, receiving rewards or penalties depending on its actions.

## Project Structure

- **Player.cs**: This is the main agent script controlling the player’s behavior. It includes functions for observation, action selection, and reward assignment based on the environment.
- **Unity Environment**: The Unity scene includes a floor, walls (with "wall" tags), and a coin (with a "target" tag). The agent navigates the environment, attempting to reach the target while avoiding collisions with the walls.

## Player Agent Behavior

The `Player` class inherits from `Agent`, provided by the ML-Agents toolkit.

1. **OnEpisodeBegin**: Resets the agent's and target's positions at the start of every episode. Both are placed at random locations within the environment's bounds.
   
2. **CollectObservations**: The agent collects its own position and the target's position as observations to use for decision-making.

3. **OnActionReceived**: The agent takes continuous actions (movement along the X and Z axes) based on the action inputs from the neural network model during training.

4. **OnTriggerEnter**: The agent receives a positive reward for reaching the target and a negative reward if it collides with a wall. The episode ends when either event occurs.

5. **Heuristic**: Provides a manual input control for debugging and testing using the keyboard.

## Requirements

To run this project, you will need:

- Unity 2022.3 or later (2023.2.13f1 recommended)
- Unity ML-Agents Toolkit (v2.0 or later)
- Python 3.9.16 or later (3.10.12 recommended)

## How to Run the Project
  
1. **Training the Agent**:
   - Launch the Unity Editor and go to the **ML-Agents** tab.
   - Run the training command in your terminal:
     ```
     mlagents-learn MoveToGoal.yaml --run-id=your_run_id
     ```
   - Start the training process in Unity by pressing Play.

3. **Testing the Trained Agent**:
   After training, you can test the agent by setting the model in the `Behavior Parameters` script of the `Player` and running the scene.

## Reward System

- **+1 Reward**: When the agent reaches the target.
- **-1 Reward**: When the agent collides with a wall.

This encourages the agent to learn to navigate toward the target without hitting obstacles.

## Heuristic (Manual Control)

You can test the agent manually by switching the agent’s **Behavior Type** to `Heuristic Only` and using the arrow keys to move the agent:
- **Left/Right Arrow**: Move on the X-axis.
- **Up/Down Arrow**: Move on the Z-axis.

