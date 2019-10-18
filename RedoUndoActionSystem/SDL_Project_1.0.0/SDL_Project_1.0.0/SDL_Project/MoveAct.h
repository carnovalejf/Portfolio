#ifndef MOVEACT_H
#define MOVEACT_H

#include "Action.h"
#include "Actor.h"
#include <SDL.h>

//an action class that takes in a pointer to an actor and an event, and according to the event will call the actors
//movement functions
class MoveAct : public Action {
	//member variables
	std::weak_ptr<Actor> actor;
	SDL_Event event;
public:

	//constructor that takes a event and pointer to an actor
	MoveAct(SDL_Event event_, std::shared_ptr<Actor> actor_);


	//method that will do the movement actions of the associated actor based on an event
	void DoAction();

	//method that will do the reverse action of the movement of the associated actor based on an event
	void ReverseAction();

	~MoveAct();

};

#endif // !MOVEACT_H

