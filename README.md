# HOW TO RUN SIMULATION
- Download the SmokeSimulation.zip from releases (v1.0)
- Extract the SmokeSimulation file inside and run the RealTimeSmokeSimulation.exe to start the simulation

# RealTimeSmokeSimulation
A real-time smoke simulation using Unity's particle system and shaders.

# Implemented and working:
- Realtime Smoke Simulation
- Gravity influence with slider
- Wind force with slider
- Emission rate with slider (Needs adjustment)
- Randomized particle turbulence using Perlin Noise equation
- Implemented Dissipation using exponential decay (Needs tuning)

# Implemented but not yet working:
- Performance Monitoring
- Shaders are implemented but need improvement
- High quality Particle Textures

# Not yet Implemented:
- GPU based particle optimization
# The Plan:
I will implement better particle blending and high fidelity particles to make the smoke look more realistic. Currently the emmission rate outputs particles at a rate that does not clearly ressemble smoke. This is just to test out the implementation of equations and also because this has not been implemented on the GPU yet. The sliders are implemented but do not have labels at the moment:
the top slider adjusts emmision rate
the middle slider adjusts gravity
the bottom slider adjusts wind speed and direction

Currently the simulation is CPU driven. I plan to change this to a GPU based simulation which will also allow for more particles to be handled at once.
