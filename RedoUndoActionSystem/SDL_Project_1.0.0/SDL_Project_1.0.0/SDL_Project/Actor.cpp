#include "Actor.h"
#include <iostream>
#include "MoveAct.h"

Actor::Actor() {
	x = 0.0f;
	y = 0.0f;
	health = 100.0f;
	movemag = 10.0f;
}

Actor::~Actor() {
	std::cout << "Destructor for actor was called " << std::endl;
}

void Actor::MoveUp() {
	y += movemag;
	std::cout << "Moved up" << std::endl;
}

void Actor::MoveDown() {
	y -= movemag;
	std::cout << "Moved Down" << std::endl;
}

void Actor::MoveLeft() {
	x -= movemag;
	std::cout << "Moved Left" << std::endl;
}

void Actor::MoveRight() {
	x += movemag;
	std::cout << "Moved Right" << std::endl;
}


void Actor::ModifyHealth(float amount_) {
	health += amount_;
}
