# Prototype 1: Driving Simulator

**Play the Game:** [Junior Programmer on Unity Play](https://play.unity.com/en/games/cc52519c-3a41-4a3b-a2c8-e76e0d26d5a2/junior-programmer)

## Gameplay Mechanic
A forward-driving simulation where the player controls a vehicle moving down a straight road. The core challenge involves steering left and right to dodge oncoming traffic and obstacles.

## Core Game Loop
1. **Accelerate**: The vehicle moves forward continuously.
2. **Steer**: Player inputs horizontal controls to switch lanes.
3. **Survive**: Avoid collisions with `Oncoming Vehicles` to keep driving.
4. **Switch Camera**: Player can toggle between different camera views (e.g., third-person and first-person).

## Dataflow
- **Input**: The New Input System captures player inputs using the `PlayerInput` component with string-based action lookups.
- **Physics**: Player movement is handled in `FixedUpdate` using a cached input vector from event subscriptions, while obstacles move in `Update`.
- **Camera**: `FollowCamera` runs in `LateUpdate` to securely trail the player's position without jitter and handles camera switching logic.
