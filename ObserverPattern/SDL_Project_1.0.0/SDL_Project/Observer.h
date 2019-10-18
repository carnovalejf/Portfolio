#pragma once
#include <vector>
#include <iostream>
#include <memory>
#include <SDL.h>
#include <string>

//Base observer class, the observer class is designed in a way that any subclassing on the observer can by 
//default subscibe and unsubscribe to a subject, they can also have multiple subjects that they are subscribed to
//and store that in a vector of Subject pointers. Each subclass of the observer needs to implement their own
//version of the update method. This is designed with the intention of functioning as an interface for any class
class Subject;
class Observer {
	//vector container of pointers to subjects that the observer is subscribed to
	std::unique_ptr<std::vector<Subject *>> subjects;

public:
	//default constructor that initializes the vector of subjects
	Observer();
	//method to subscribe to a subject, it will call the subjects attach method and pass a reference to itself as the parameter
	//it will then add the subject to its own personal list of subjects that it is subscribed to
	virtual void Subscribe(Subject * subject_);
	//method to unsubscribe to a subject, it will call the subjects detach method passing a reference to itself as the parameter
	//and will then remove the subject from its own list of subjects that it is subscribed to
	virtual void UnSubscribe(Subject * subject_);

	//update method that subjects will call when they need to notify their observers, each observer type will need
	//to implement their own version of the update method
	virtual void Update(Subject * subject_, SDL_Event event_) = 0;
};