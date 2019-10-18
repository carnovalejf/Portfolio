#pragma once
#include <vector>
#include <iostream>
#include <string>
#include <SDL.h>

//subject class for Observer design pattern, this subject is currently meant to notify all observers 
//that an SDL_Event type has fired, this can be generalized by removing the parameter to notify and then 
//subclass the subject into specific types of notifications so that observers only interested in
//those subclasses can subscribe to
class Subject {
	//member variables, a name for testing purposesB
	std::string name;
	//a unique pointer to a vector of observer pointers
	std::unique_ptr<std::vector<class Observer*>> observers;
public:
	//constructor that takes in a name for the subject
	Subject(std::string name_);
	~Subject();
	//method that will add an observer to the vector of observers
	void Attach(Observer* observer_);
	//method that will remove an observer from the vector of observers
	void Detach(Observer* observer_);
	//method to return the name of the subject
	std::string getName();
	//method that will iterate through the vector of observers and call their update methods with the parameter
	//of the notify
	void Notify(SDL_Event event_);

};