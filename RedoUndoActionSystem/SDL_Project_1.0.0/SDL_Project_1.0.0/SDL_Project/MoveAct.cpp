#include "MoveAct.h"
#include <iostream>


MoveAct::MoveAct(SDL_Event event_, std::shared_ptr<Actor> actor_) {
	actor = actor_;
	event = event_;
}

void MoveAct::DoAction() {

	//unwrapping the weak pointer of the action in order to make sure that the object still exists
	auto tempactor = actor.lock();
	if(!tempactor){
		return;
	}
	//if the actor exists, based on keyboard input one of the actors associated move methods will be called
	switch (event.key.keysym.sym) {
	case SDLK_UP:
		tempactor->MoveUp();
		break;
	case SDLK_DOWN:
		tempactor->MoveDown();
		break;
	case SDLK_LEFT:
		tempactor->MoveLeft();
		break;
	case SDLK_RIGHT:
		tempactor->MoveRight();
		break;
	}


}

void MoveAct::ReverseAction() {
	
	//unwrapping the weak_ptr to ensure that the actor still exists
	auto tempactor = actor.lock();
	if (!tempactor) {
		return;
	}
	//calling the actors movement action associated to the opposite of the key input
	switch (event.key.keysym.sym) {
	case SDLK_UP:
		tempactor->MoveDown();
		break;
	case SDLK_DOWN:
		tempactor->MoveUp();
		break;
	case SDLK_LEFT:
		tempactor->MoveRight();
		break;
	case SDLK_RIGHT:
		tempactor->MoveLeft();
		break;
	}
	
}

MoveAct::~MoveAct() {
	std::cout << "destructor called on MoveAct" << std::endl;
}
