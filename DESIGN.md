# Prototype 1: Architecture & Lessons Learned

## Overview
Prototype 1 is a forward-driving simulator. The core focus is on implementing physics-based vehicle movement, a decoupled camera tracking system, and handling inputs via the Unity New Input System.

## Architecture & Implementation Details

### 1. Player Controller (`PlayerController.cs`)
- **Input Handling**: Uses the **New Input System** via the `PlayerInput` component. We look up actions by string (e.g., `_playerInput.actions["Move"]`) and explicitly subscribe to the `.performed` and `.canceled` events in `OnEnable()`.
- **Physics-Based Movement**: Movement and rotation are strictly confined to `FixedUpdate()` to sync with Unity's physics steps.
  - **Velocity**: We calculate a target velocity based on the forward direction and apply it directly to `Rigidbody.linearVelocity`. The existing Y-axis velocity is preserved to ensure gravity functions correctly.
  - **Rotation**: Turning is handled via `Rigidbody.MoveRotation()`, ensuring smooth turning without bypassing the physics engine.

### 2. Camera System (`FollowCamera.cs`)
- **Execution Order**: The camera tracking logic is placed in `LateUpdate()`. This guarantees that the player's Rigidbody movements in `FixedUpdate` are completely resolved before the camera updates, preventing visual stutter.
- **Camera Switching Mechanic**: Listens to a `SwitchCamera` input action and cycles through an array of `Vector3` offsets. This allows the player to seamlessly toggle between multiple camera views (e.g., third-person and first-person).

### 3. Obstacle Behavior (`OncomingVehicles.cs`)
- **Simple Translation**: Unlike the player, oncoming vehicles don't require complex physics constraints. They use lightweight, frame-rate independent movement via `transform.Translate()` in the `Update()` loop.

## Lessons Learned
- **Input Flexibility vs. Safety**: We opted to use the `PlayerInput` component with string-based action lookups. While generated C# wrappers are safer for production (especially avoiding reflection stripping issues in WebGL IL2CPP builds), this simpler approach is sufficient for practice and rapid prototyping.
- **Physics vs. Transform Movement**: Mixing Rigidbody physics and `transform.Translate` requires care. Reserving Rigidbody methods (`linearVelocity`, `MoveRotation`) for the player ensures reliable collisions, while using `transform.Translate` for obstacles saves performance overhead.
- **Event Lifecycle**: Explicitly unsubscribing from Input actions using `-=` in `OnDisable` is a critical practice. We identified and fixed a bug where events were incorrectly subscribed to in `OnDisable`, which could lead to severe memory leaks or duplicate event firings when the object is toggled.