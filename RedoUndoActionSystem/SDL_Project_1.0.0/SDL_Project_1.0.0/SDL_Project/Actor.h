#ifndef ACTOR_H
#define ACTOR_H

//actor class, the actor is what actions will be modifying by using the actors methods
class Actor {
	//member variables
	float movemag, health;

public:
	float x, y;
	//blank constructor that sets the member variables to their defaults
	Actor();
	~Actor();

	//movement methods for the actor, that the MoveAct class will call
	void MoveUp();
	void MoveDown();
	void MoveLeft();
	void MoveRight();

	//modify health method to be implemented and used by a to be implemented HealthAct class
	void ModifyHealth(float amount_);

};

#endif // !ACTOR_H

