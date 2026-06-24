# Prototype 1: Architecture & Lessons Learned

## Lessons Learned
- **Input Handling**: We are using the **New Input System** with the `PlayerInput` component and string-based action lookups. While generated C# wrappers are safer for production (especially for WebGL IL2CPP builds), this simpler approach is sufficient for practice and rapid prototyping.
- **Physics & Movement**: Player movement logic is confined to `FixedUpdate` for stable rigidbody physics, while simpler obstacles use `Update` for transform-based translation.
