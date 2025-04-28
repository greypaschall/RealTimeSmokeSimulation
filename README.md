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
- Performance monitoring and data collection

# Implemented but not yet working:
- Shaders are implemented but need improvement
- High quality Particle Textures

# Not yet Implemented:
- GPU based particle optimization
# The Plan:
Currently the simulation is CPU driven. I plan to change this to a GPU based simulation which will also allow for more particles to be handled at once.
