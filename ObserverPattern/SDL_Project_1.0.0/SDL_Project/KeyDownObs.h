#pragma once
#include "Observer.h"

//A keydown observer, this class is a subclass of base observer, it extends observer and implements its own update
//and only acts if the event that it was notified of was a keydown event
class KeyDownObs : public Observer{
	
public:
	//keydownobs own personal update method that takes in the event and subject that notified them, it will then
	//print out what subject it observed the event from
	void Update(Subject * subject_, SDL_Event event_);
};
