# 🥤 Pepsi Man – Endless Runner Game (Unity)

## 🎮 Game Overview

**Pepsi Man** is a simple **endless runner game** developed using **Unity 3D**.
The player controls a character that automatically runs forward on a three-lane path.
The main objective is to **avoid obstacles**, **survive as long as possible**, and **achieve the highest score**.

The game continues endlessly until the player collides with an obstacle.

---

## ▶️ How to Run the Game

1. Download or clone this repository.
2. Open **Unity Hub**.
3. Click **Open Project** and select the project folder.
4. Open the scene named **Main**.
5. Press the **Play** button in Unity.

---

## 🕹️ How to Play

- The character **moves forward automatically**.
- The road consists of **three lanes**: Left, Middle, and Right.
- Obstacles spawn randomly in different lanes.
- The player must **avoid obstacles** by switching lanes or jumping.

The game is endless, and the score increases the longer you survive.
Your **best score (record)** is saved and displayed during gameplay.

---

## 🎯 Controls

| Key       | Action     |
| --------- | ---------- |
| **A**     | Move Left  |
| **D**     | Move Right |
| **Space** | Jump       |

---

## ❌ Game Over & Restart

- If the player **hits an obstacle**, the game ends.
- A **Game Over panel** appears on the screen.
- The panel includes a **Restart button**.
- Clicking the Restart button **reloads the scene** and starts the game again.

---

## 🧠 Scoring System

- The score increases automatically over time.
- The **best score** is saved using `PlayerPrefs`.
- The best record is shown **during gameplay**, not only after Game Over.

---

## 🛠️ Technologies Used

- **Unity 3D**
- **C#**
- **Unity UI (Canvas, Text, Button, Panel)**
- **PlayerPrefs** for saving high scores

---

## 📁 Project Structure

- `Assets/` – Game assets, scripts, and scenes
- `Scenes/Main` – Main gameplay scene
- `Scripts/` – Player movement, obstacle spawning, UI management

---

## 📝 Notes

This project was created as a learning exercise to practice:

- Player movement in Unity
- Obstacle spawning using `Instantiate`
- Collision detection with `OnTriggerEnter`
- UI management and Game Over handling
- Scene reloading with `SceneManager`

---

## ✅ Controls Summary

```
A      → Move Left
D      → Move Right
Space  → Jump
```

---

## 🚀 Enjoy the Game!

This project demonstrates the basics of an endless runner game in Unity and serves as a solid foundation for further development.

Good luck and have fun! 🎉
