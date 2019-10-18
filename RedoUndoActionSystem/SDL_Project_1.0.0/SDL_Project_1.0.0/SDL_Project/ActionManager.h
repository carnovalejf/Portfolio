#ifndef ACTIONMANAGER_H
#define ACTIONMANAGER_H
#include <vector>
#include "Action.h"
#include "Actor.h"
#include <SDL.h>

class ActionManager {
	//member variable that stores an actor to manage, at the moment actionManager is more of a Actor controller
	//plans to implement it as more of an action manager by giving its handle events an actor shared_ptr argument
	//since actions store pointers to their actors
	std::shared_ptr<Actor> actor;
	//member variable that stores the an action for undo purposes
	std::unique_ptr<std::vector<std::shared_ptr<Action>>> undoActs;
	//member variable that stores the action that was undone for redo purposes
	std::unique_ptr<std::vector<std::shared_ptr<Action>>> redoActs;
public:
	//constructor for an actionManager that takes in an actor and initializes the two vectors
	ActionManager(std::shared_ptr<Actor> actor_);
	~ActionManager();
	//method that takes in an SDL_Event and will either create a new action and store it to the undo list while
	//clearing redo, or will call either redo or undo based on the event
	void HandleEvent(SDL_Event event_);
	//method that calls the reverse action of the most recent action then stores the pointer to the action in redoActs
	void Undo();
	//method that calls the action of the most recently undone action, then stores the pointer to the action in undoActs
	void Redo();
};

#endif // !ACTIONMANAGER_H
