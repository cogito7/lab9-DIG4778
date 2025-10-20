Lab 9
=====

> Melanie Galindo Waugh

This is a super cool lab that I did using Object Pooling for the bullets, Builder Pattern for the enemies, and Observer Pattern for the way the score is updated when a target is hit. In this 2D Shooting game, the Object Pool Pattern is implemented through a bullet pool that reuses inactive bullets instead of creating and destroying them each time the player fires, improving performance. The Builder Pattern is used in the enemy spawning system, where an EnemyBuilder constructs different enemy types with custom values before they appear at the top of the screen. The Observer Pattern connects the targets and the score system: each Target broadcasts an OnTargetHit event when destroyed, and the ScoreManager observes this event to update the player score in real time. Together, these implementations keep the game efficient, modular, and easy to extend.

![Diagram](./Lab9.png)