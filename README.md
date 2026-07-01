# Console Snake Game

A pure C# Windows console implementation of the classic arcade game Snake. This project is built to isolate core programming logic, data structures, and algorithmic problem-solving before transitioning into Unity engine architecture.

---

## 🎮 Project Objective
To build a fully functioning game loop from scratch without relying on built-in game engine physics or update cycles. It serves to solidify C# Fundamentals and practice multi-dimensional collections and logic flow.

---

## 📋 Game Design Specifications

### 1. The Grid Map
* **Representation:** The 2D playing field is rendered using the `.` character.
* **Selectable Dimensions:** The player can choose from three grid sizes at startup: **24**, **36**, or **64**.

### 2. The Snake
* **Representation:** The snake is represented by the `0` character.
* **Movement:** Moves in any direction within the 2D grid.
* **Growth:** Consuming a fruit increases the snake's length by 1 tile at the end.

### 3. Dynamic Fruit Spawning
* **Representation:** Fruits are represented by distinct characters: `o`, `c`, and `+`.
* **Density Scaling:** The number of active fruits scales based on the map size:
  * **24 Size Map:** 4 fruits
  * **36 Size Map:** 6 fruits
  * **64 Size Map:** 10 fruits
* **Spatial Constraint:** Fruits and the snake cannot occupy the same space; fruit quantity reduces if free space is limited. Once eaten, fruits disappear and spawn on a random tile.

### 4. Win / Loss Conditions
* **Victory:** The game is won when the snake becomes as large as the map.
* **Game Over:** The game ends and displays the score if the snake touches the map edges or touches itself.

---

## 🛠️ Technical Architecture & Learning Focus
* **Grid Rendering:** Leveraging **Multi-dimensional Arrays** to map and draw the coordinate system.
* **Segment Tracking:** Utilizing **Generic Lists** or 1D arrays to store coordinate vectors for the snake.
* **Input Separation:** Isolating player keyboard input from the console's visual rendering.