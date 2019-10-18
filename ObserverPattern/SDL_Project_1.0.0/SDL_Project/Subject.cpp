#include "Subject.h"
#include <algorithm>
#include "Observer.h"

Subject::Subject(std::string name_) {
	//initializing member variables
	name = name_;
	observers = std::make_unique<std::vector<Observer *>>(std::vector<Observer *>());
}

Subject::~Subject() {
	std::cout << "destructor for subject " << name << " was called" << std::endl;
}

void Subject::Attach(Observer *observer_) {
	observers->push_back(observer_);
}

void Subject::Detach(Observer *observer_) {
	observers->erase(std::remove(observers->begin(), observers->end(), observer_), observers->end());
}

std::string Subject::getName() {
	return name;
}

void Subject::Notify(SDL_Event event_) {
	//iterate through the list of observers and notify them all of the event
	for (std::vector<Observer*>::const_iterator iter = observers->begin(); iter != observers->end(); iter++) {
		if (*iter != 0) {
			(*iter)->Update(this, event_);
		}
	}
}
