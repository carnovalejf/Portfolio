#include "ActionManager.h"
#include <iostream>
#include "MoveAct.h"


ActionManager::ActionManager(std::shared_ptr<Actor> actor_) {
	actor = actor_;
	undoActs = std::make_unique<std::vector<std::shared_ptr<Action>>>(std::vector<std::shared_ptr<Action>>());
	redoActs = std::make_unique<std::vector<std::shared_ptr<Action>>>(std::vector<std::shared_ptr<Action>>());
}

ActionManager::~ActionManager() {
	std::cout << "ActionManager was destroyed" << std::endl;
}

void ActionManager::HandleEvent(SDL_Event event_) {
	//check if its a movement input
	if (event_.key.keysym.sym == SDLK_UP || event_.key.keysym.sym == SDLK_DOWN ||
		event_.key.keysym.sym == SDLK_LEFT || event_.key.keysym.sym == SDLK_RIGHT) {
		auto action = std::make_shared<MoveAct>(MoveAct(event_, actor));
		action->DoAction();
		undoActs->push_back(action);
		redoActs->clear();
	}
	//checks if its undo call
	else if (event_.key.keysym.sym == SDLK_F1) {
		//check to make sure the undo list isnt empty
		if (!undoActs->empty()) {
			Undo();
		}
		else {
			std::cout << "undo is empty" << std::endl;
		}
	}
	//checks if its redo call
	else if(event_.key.keysym.sym == SDLK_F2) {
		//check to make sure the redo list isnt empty
		if (!redoActs->empty()) {
			Redo();
		}
		else {
			std::cout << "redo is empty" << std::endl;
		}
	}
	else {
		return;
	}
}

void ActionManager::Undo() {
	
	//do the reverse of the last action
	undoActs->back()->ReverseAction();

	//create a pointer to the undone action
	auto temppoint = undoActs->back();
	
	//send it to the redoActions
	redoActs->push_back(temppoint);


	//pop the undone action from the undoacts vector
	undoActs->pop_back();

}

void ActionManager::Redo() {

	//do the last action
	redoActs->back()->DoAction();

	//create a pointer to the redone action
	auto temppoint = redoActs->back();

	//send it to the undoActions
	undoActs->push_back(temppoint);


	//pop the undone action from the undoacts vector
	redoActs->pop_back();
}
